using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {

        // you spin me right round baby
        int SPINNER_STATUS = 0;
        string[] BASIC_SPINNER_BITS = new string[] { "─", "\\", "│", "/" };
        //string[] SPINNER_BITS = new string[] { "┐", "┘", "└", "┌" };
        string[] SPINNER_BITS = new string[] { "▄ ", " ▄", " ▀", "▀ " };

        string[] STANCE_DATA_OUT_TOGGLE = new string[] { " OFF", "  ON", "  ON", "  ON", "  ON" }; // extras are there to cover old custom data.
        string[] STANCE_DATA_OUT_MAINTHRUST = new string[] { " OFF", "  ON", " MIN" };
        string[] STANCE_DATA_OUT_RCS = new string[] { " OFF", "  ON", "NFWD", "NREV" };
        string[] STANCE_DATA_OUT_RAILS = new string[] { " OFF", "HOLD", "FREE" };
        string[] STANCE_DATA_OUT_PDCS = new string[] { " OFF", "MDEF", " DEF", " CQB", "  ON" };
        string[] STANCE_DATA_OUT_TANKS = new string[] { "AUTO", "STOC", " AUTO" };
        string[] STANCE_DATA_OUT_BATTS = new string[] { " AUTO", "CHG", " DCHG" };

        // general LCD vars
        const int LCD_WIDTH = 32;
        const float LCD_FONT_SIZE = 0.8f;
        string LCD_DIVIDER = "└" + new String('─', LCD_WIDTH - 2) + "┘";

        Color LCD_OVERLAY_COLOUR = new Color(255, 116, 33, 255);

        // alerts appear at the top of the warnings screen
        // they are temporary messages which will be cleared at LIFETIME = 0;
        class ALERT
        {
            public string MESSAGE;
            public string LONG_MESSAGE;
            public int PRIORITY;
            public int LIFETIME;

            public ALERT(string Message, string LongMessage, int Priority = 0, int Lifetime = 20)
            {
                if (Message.Length > LCD_WIDTH - 3)
                    Message = Message.Substring(0, LCD_WIDTH - 3);

                MESSAGE = Message.PadRight(LCD_WIDTH - 3);
                LONG_MESSAGE = LongMessage;
                PRIORITY = Priority;
                LIFETIME = Lifetime;
            }
        }

        class STATUS_LIGHT
        {
            public string OUTPUT;
            public string OUTPUT_OVERLAY;

            public STATUS_LIGHT(string Name, int Status, int Step)
            {
                string blank = "    ";

                while (Step > 3)
                {
                    Step -= 4;
                }
                            
                if (Status == 0) // nominal
                {
                    OUTPUT = "║ " + Name.PadRight(4) + " ║";
                    OUTPUT_OVERLAY = "  " + blank + "  ";
                } 
                else if (Status == 1) // warning
                {
                    if (Step == 0 || Step == 2) OUTPUT = "║─" + Name.PadRight(4) + " ║";
                    else OUTPUT = "║ " + Name.PadRight(4) + "─║";
                    OUTPUT_OVERLAY = " ░" + blank + "░ ";
                }
                else if (Status == 2) // danger
                {
                    if (Step == 0 || Step == 2)
                    {
                        OUTPUT = "║ " + Name.PadRight(4) + "═║";
                        OUTPUT_OVERLAY = "║▒" + blank + "░║";
                    }
                    else/* if (Step == 1)*/
                    {
                        OUTPUT = "║═" + Name.PadRight(4) + " ║";
                        OUTPUT_OVERLAY = "║░" + blank + "▒║";
                    }
                    /*
                    else if (Step == 2)
                    {
                        OUTPUT = "║ " + Name.PadRight(4) + " ║";
                        OUTPUT_OVERLAY = " >" + blank + "< ";
                    }
                    else if (Step == 3)
                    {
                        OUTPUT = "║ " + Name.PadRight(4) + " ║";
                        OUTPUT_OVERLAY = " =" + blank + "= ";
                    }
                    */
                }
                else if (Status == 3) // critcal
                {

                    if (Step == 0 || Step == 2)
                    {
                        OUTPUT = "║!" + Name.PadRight(4) + "!║";
                        OUTPUT_OVERLAY = "║▓" + blank + "▓║";
                    }
                    else /*if (Step == 1)*/
                    {
                        OUTPUT = "║ " + blank + " ║";
                        OUTPUT_OVERLAY = "║!" + Name.PadRight(4) + "!║";

                    }
                    /*
                    else if (Step == 2)
                    {
                        OUTPUT = "║-" + Name.PadRight(4) + "-║";
                        OUTPUT_OVERLAY = "┼>" + blank + "< ";
                    }
                    else if (Step == 3)
                    {
                        OUTPUT = "║-" + blank + "-║";
                        OUTPUT_OVERLAY = "╬|" + Name.PadRight(4) + "| ";
                    }
                    */
                }
            }
        }

        string[] ALERT_PRIORITIES = new string[] { "- ", "= ", "x ", "! " };
        List<ALERT> ALERTS = new List<ALERT>();

        // todo
        // review and improve this
        // updates all LCDs on the ship to display our data.
        void updateLcds()
        {
            if (D) Echo("Updating LCDs...");

            SPINNER_STATUS++;
            if (SPINNER_STATUS >= SPINNER_BITS.Length) SPINNER_STATUS = 0;
            string spinner = SPINNER_BITS[SPINNER_STATUS];
            string basic_spinner = BASIC_SPINNER_BITS[SPINNER_STATUS];

            //string output_comms_range = (Math.Round((current_comms_range / 1000)).ToString() + " km").PadLeft(15);
            /*string output_aux = "      ACTIVE";
            if (AUX_ACTIVE_COUNT == 1)
                output_aux = "     INACTIVE";*/


            // -----------------------
            // Build inventory section
            // -----------------------

            string sec_inventory_counts =
                "──┤ Inventory ├──────────────" + basic_spinner + "──\n\n";


            foreach (ITEM Item in ITEMS)
            {
                if (Item.TARGET != 0)
                {
                    Item.PERCENTAGE = (100 * ((double)Item.COUNT / (double)Item.TARGET));
                    string val = (Item.COUNT + "/" + Item.TARGET).PadLeft(9);
                    if (val.Length > 9) val = val.Substring(0, 9);
                    sec_inventory_counts += Item.NAME + " [" + generateBar(Item.PERCENTAGE) + "] " + val + "\n";
                }
            }
            sec_inventory_counts += "\n";


            // --------------------
            // Build thrust section
            // --------------------
            //string output_sig_range = (Math.Round((current_sig_range / 1000)).ToString() + " km").PadLeft(15);
            double vel = Math.Round(VELOCITY);
            string vel_msg = "Velocity:        ";

            if (vel < 1) // if velocity is close to zero, use 500m/s instead.
            {
                vel = 500;
                vel_msg = "Velocity (Max):  ";
            }

            double AccelMax = Math.Round((THRUST_MAX / MASS / 9.81), 2);
            double AccelActual = Math.Round((THRUST_ACTUAL / MASS / 9.81), 2);

            string output_decel_short;
            if (THRUST_ACTUAL > 0)
            {
                output_decel_short = "Decel (Actual):  " + stopDistance(THRUST_ACTUAL, vel) +
                    "\nAccel (Actual):  " + (AccelActual + " Gs").PadLeft(15);
            }
            else
            {
                output_decel_short = "Decel (Dampener):" + stopDistance(THRUST_MAX, vel, true) +
                    "\nAccel (Best):    " + (AccelMax + " Gs").PadLeft(15);
            }

            string sec_thrust =

               "──┤ Thrust ├─────────────────" + basic_spinner + "──\n\n" +
                output_decel_short;
                //"\nDrive Signature: " + output_sig_range + "\n\n";


            

            // -----------------------
            // Build Tanks & Batteries
            // -----------------------


            if (D)
            {
                Echo("Actual H2:" + ACTUAL_H2 + "\nTotal H2: " + TOTAL_H2);

            }

            FUEL_PERCENTAGES = Math.Round(100 * (ACTUAL_H2 / TOTAL_H2));
            double oxygen_percentage = Math.Round(100 * (ACTUAL_O2 / TOTAL_O2));
            double battery_percentage = Math.Round(100 * (ACTUAL_BATTERIEs / TOTAL_BATTERIEs));

            double init_power = Math.Round(INIT_REACTORs + INIT_BATTERIEs, 1);
            double nice_max_power = Math.Round(MAX_POWER, 1);
            double capacity_percentage = Math.Round(100 * (nice_max_power/init_power));

            string sec_tanks_and_batts =
               "──┤ Power & Gas ├────────────" + basic_spinner + "──\n\n" +
                "Fuel      [" + generateBar(FUEL_PERCENTAGES) + "] " + (FUEL_PERCENTAGES + " %").PadLeft(9) + "\n" +
                "Oxygen    [" + generateBar(oxygen_percentage) + "] " + (oxygen_percentage + " %").PadLeft(9) + "\n" +
                "Battery   [" + generateBar(battery_percentage) + "] " + (battery_percentage + " %").PadLeft(9) + "\n" +
                "Capacity  [" + generateBar(capacity_percentage) + "] " + (capacity_percentage + " %").PadLeft(9) + "\n" +
                "Max Power:" + (nice_max_power + " MW / " + init_power + " MW").PadLeft(22) + "\n\n";




            /*string sec_comms =
                "-- Communications -----------" + spinner + "--" + "\n\n"
                + "Comms:           " + output_comms + "\n"
                + "Comms Range:     " + output_comms_range + "\n\n";

            string sec_aux =
                "-- Auxiliary  ---------------" + spinner + "--" + "\n\n"
                + KEYWORD_AUX + ":" + output_aux.PadLeft(31 - KEYWORD_AUX.Length) + "\n\n";

            string sec_doors =
               "-- Doors & Vents ------------" + spinner + "--" + "\n\n"
               + "Doors Closed:    " + output_doors + "\n"
               + "Vents Sealed:    " + output_vents + "\n\n";*/




            // -------------------------------------
            // Build warnings section, status lights
            // -------------------------------------

            List<ALERT> LCDAlerts = new List<ALERT>();
            List<STATUS_LIGHT> StatusLights = new List<STATUS_LIGHT>();

            int status_light_spice = 0;

            // Clear out old alerts.
            for (int i = 0; i < ALERTS.Count; i++)
            {
                ALERTS[i].LIFETIME--;
                if (ALERTS[i].LIFETIME < 1) // Alert timed out.
                    ALERTS.RemoveAt(i);
                else
                    LCDAlerts.Add(ALERTS[i]);
            }

            // handle lidar
            if (!LIDAR_WORKING)
            {
                LCDAlerts.Add(new ALERT(
                    "NO LiDAR!", 
                    "No LiDARs are currently working. Ship is blind to enemy contacts at long range.", 
                    2
                    ));
            }

            // handle fuel
            int h2_priority = 0;
            if (FUEL_PERCENTAGES < 5)
            {
                LCDAlerts.Add(new ALERT("FUEL CRITICAL!", "FUEL CRITICAL!\nFuel Level < 5%!", 3));
                h2_priority = 3;
            }
            else if (FUEL_PERCENTAGES < 25)
            {
                LCDAlerts.Add(new ALERT("FUEL LOW!", "FUEL LOW!\nFuel Level < 10%!", 2));
                h2_priority = 2;
            }
     
            if (STANCES[S][21] > 1)
            {
                if (NO_SPARE_TANKS)
                {
                    if (h2_priority == 0) h2_priority = 1;

                    LCDAlerts.Add(new ALERT(
                        "No spare fuel tanks",
                        "Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",
                        h2_priority));
                }

                if (NO_EXTRACTOR)
                {
                    if (h2_priority == 0) h2_priority = 1;

                    LCDAlerts.Add(new ALERT(
                        "No Extractor",
                        "Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",
                        h2_priority));
                }
            }

            StatusLights.Add(new STATUS_LIGHT("FUEL", h2_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            // handle oxygen
            int o2_priority = 0;
            if (oxygen_percentage < 5)
            {
                LCDAlerts.Add(new ALERT("OXYGEN CRITICAL!", "OXYGEN CRITICAL!\nShip O2 Level < 5%!", 3));
                o2_priority = 3;
            }
            else if (oxygen_percentage < 10)
            {
                LCDAlerts.Add(new ALERT("OXYGEN LOW!", "OXYGEN LOW!\nShip O2 Level < 10%!", 2));
                o2_priority = 2;
            }
            else if (oxygen_percentage < 25)
            {
                LCDAlerts.Add(new ALERT("Oxygen Low", "Oxygen Low!\nShip O2 Level < 25%!", 1));
                o2_priority = 1;
            }

            // handle vents
            //string output_vents = (vents_sealed + "/" + vents.Count).PadLeft(15);
            if (VENTs.Count > ACTUAL_VENTS_SEALED)
            {
                int unsealed = (VENTs.Count - ACTUAL_VENTS_SEALED);
                o2_priority++;
                LCDAlerts.Add(new ALERT(
                    unsealed + " vents are unsealed",
                    unsealed + " vents are unsealed",
                    1));
            }

            // handle doors
            if (doors_count_unlocked > 0)
            {
                LCDAlerts.Add(new ALERT(
                    doors_count_unlocked + " doors are insecure",
                    doors_count_unlocked + " doors are insecure",
                    0));
            }

            // handle aux
            if (AUX_ACTIVE_COUNT > 0)
            {
                LCDAlerts.Add(new ALERT(
                    KEYWORD_AUX + " is active (" + AUX_ACTIVE_COUNT + ")",
                    KEYWORD_AUX + " is active (" + AUX_ACTIVE_COUNT + ")",
                    0));
            }

            StatusLights.Add(new STATUS_LIGHT("OXYG", o2_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            // handle power
            int power_priority = 0;
            if (BATTERIEs.Count > 0)
            {
                if (battery_percentage < 5)
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT("BATTERIES CRITICAL!", "BATTERIES CRITICAL!\nBattery Level < 5%!", 2));
                }
                else if (battery_percentage < 10)
                {
                    power_priority += 1;
                    LCDAlerts.Add(new ALERT("Batteries Low!", "Batteries Low!\nBattery Level < 10%!", 1));
                }
            }

            if (REACTORs.Count > 0)
            {
                if (EMPTY_REACTORs > 0)
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT(EMPTY_REACTORs + " REACTORS NEED FUS. FUEL!", "At least one reactor needs Fusion Fuel!", 3));
                }

                if (ITEMS[0].TARGET == 0) // Different error if there is no target.
                {
                    if (ITEMS[0].COUNT > 0)
                    {
                        power_priority += 1;
                        LCDAlerts.Add(new ALERT("No Spare Fusion Fuel!", "No spare fusion fuel detected in ships cargo!", 2));
                    }
                }
                else if (ITEMS[0].PERCENTAGE < 5) // Fusion fuel below 5% of init quota.
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT("FUSION FUEL LEVEL CRITICAL!", "Fusion fuel level is low!", 3));
                }
                else if (ITEMS[0].PERCENTAGE < 10) // Fusion fuel below 10% of init quota.
                {
                    power_priority += 1;
                    LCDAlerts.Add(new ALERT("Fusion Fuel Level Low!", "Fusion fuel level is low!", 2));
                }
            }
          
            if (power_priority > 3) power_priority = 3;

            StatusLights.Add(new STATUS_LIGHT("POWR", power_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            int weap_priority = 0;

            if (MISSING_AMMO != "") 
            {
                string[] Ammos = MISSING_AMMO.Split('\n');
                foreach(string Ammo in Ammos)
                {
                    string output_ammo = Ammo;
                    if (Ammo.Length > 23) output_ammo = Ammo.Substring(0, 23);
                    output_ammo = output_ammo.ToUpper();
                    LCDAlerts.Add(new ALERT("NEED " + output_ammo + "!", "NEED " + output_ammo + "!  Ammo Critical!", 3));
                }
                weap_priority = 3;
            }

            if (weap_priority > 3) weap_priority = 3;

            StatusLights.Add(new STATUS_LIGHT("WEAP", weap_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            // handle comms
            if (COMMS_ON)
            {

                string output_comms = COMMS_MSG;
                if (ANTENNAs.Count > 0)
                    if (ANTENNAs[0] != null)
                        output_comms = (ANTENNAs[0] as IMyRadioAntenna).HudText;

                string output_range = "";
                if (COMMS_RANGE < 1000)
                    output_range = Math.Round(COMMS_RANGE) + "m";
                else
                    output_range = Math.Round(COMMS_RANGE / 1000) + "km";

                LCDAlerts.Add(new ALERT(
                    "Comms ("+ output_range + "): " + output_comms, 
                    "Antenna(s) are broadcasting at a range of " + output_range + " with the message " + output_comms, 0));
            }

            // handle unowned
            if (UNOWNED_BLOCKS > 0)
            {
                LCDAlerts.Add(new ALERT(
                UNOWNED_BLOCKS + " UNOWNED BLOCKS!",
                "RSM detected " + UNOWNED_BLOCKS + " terminal blocks on this grid owned by a player with a different faction tag."
                , 3
                ));
            }

            // handle doors
            //string output_doors = (doors_count_closed + "/" + doors_count).PadLeft(15);
            if (doors_count > doors_count_closed)
            {
                int open = (doors_count - doors_count_closed);
                LCDAlerts.Add(new ALERT(
                    open + " doors are open",
                    open + " doors are open",
                    0));
            }


            // sort alerts by priority.
            LCDAlerts = LCDAlerts.OrderBy(a => a.PRIORITY).Reverse().ToList();

            string sec_warnings =
                "──┤ Warnings ├───────────────" + basic_spinner + "──\n\n";
            
            if (LCDAlerts.Count < 1) sec_warnings += "No warnings\n";
            else Echo("\n\n WARNINGS:");



            // output alerts to warnings list.
            for (int i = 0; i < LCDAlerts.Count; i++)
            {
                sec_warnings += ALERT_PRIORITIES[LCDAlerts[i].PRIORITY] + LCDAlerts[i].MESSAGE + "\n";
                Echo("-" + ALERT_PRIORITIES[LCDAlerts[i].PRIORITY] + LCDAlerts[i].LONG_MESSAGE);
            }

            sec_warnings += "\n";




            // -------------------------
            // Build Subsystem Integrity
            // -------------------------

            int[] CurrentStance = STANCES[S];

            string sec_integrity =

                "──┤ Subsystem Integrity ├────" + basic_spinner + "──\n\n";

            try
            {
                if (INIT_THRUSTERs_MAIN > 0)
                    sec_integrity += "Epstein   [" + generateBar(INTEGRITY_THRUSTERs_MAIN) + "] " + (INTEGRITY_THRUSTERs_MAIN + "% ").PadLeft(5) + STANCE_DATA_OUT_MAINTHRUST[CurrentStance[3]] + "\n";
                if (INIT_THRUSTERs_RCS > 0)
                    sec_integrity += "RCS       [" + generateBar(INTEGRITY_THRUSTERs_RCS) + "] " + (INTEGRITY_THRUSTERs_RCS + "% ").PadLeft(5) + STANCE_DATA_OUT_RCS[CurrentStance[4]] + "\n";
                if (INIT_REACTORs > 0)
                    sec_integrity += "Reactors  [" + generateBar(INTEGRITY_REACTORs) + "] " + (INTEGRITY_REACTORs + "% ").PadLeft(5) + "    \n";
                if (INIT_BATTERIEs > 0)
                    sec_integrity += "Batteries [" + generateBar(INTEGRITY_BATTERIEs) + "] " + (INTEGRITY_BATTERIEs + "% ").PadLeft(5) + STANCE_DATA_OUT_BATTS[CurrentStance[16]] + "\n";
                if (INIT_PDCs > 0)
                    sec_integrity += "PDCs      [" + generateBar(INTEGRITY_PDCs) + "] " + (INTEGRITY_PDCs + "% ").PadLeft(5) + STANCE_DATA_OUT_PDCS[CurrentStance[1]] + "\n";
                if (INIT_TORPs > 0)
                    sec_integrity += "Torpedoes [" + generateBar(INTEGRITY_TORPs) + "] " + (INTEGRITY_TORPs + "% ").PadLeft(5) + STANCE_DATA_OUT_TOGGLE[CurrentStance[0]] + "\n";
                if (INIT_RAILs > 0)
                    sec_integrity += "Railguns  [" + generateBar(INTEGRITY_RAILs) + "] " + (INTEGRITY_RAILs + "% ").PadLeft(5) + STANCE_DATA_OUT_RAILS[CurrentStance[2]] + "\n";
                if (INIT_H2 > 0)
                    sec_integrity += "H2 Tanks  [" + generateBar(INTEGRITY_H2) + "] " + (INTEGRITY_H2 + "% ").PadLeft(5) + STANCE_DATA_OUT_TANKS[CurrentStance[16]] + "\n";
                if (INIT_O2 > 0)
                    sec_integrity += "O2 Tanks  [" + generateBar(INTEGRITY_O2) + "] " + (INTEGRITY_O2 + "% ").PadLeft(5) + STANCE_DATA_OUT_TANKS[CurrentStance[16]] + "\n";
                if (INIT_GYROs > 0)
                    sec_integrity += "Gyros     [" + generateBar(INTEGRITY_GYROs) + "] " + (INTEGRITY_GYROs + "% ").PadLeft(5) + "    \n";
                if (INIT_CARGOs > 0)
                    sec_integrity += "Cargo     [" + generateBar(INTEGRITY_CARGOs) + "] " + (INTEGRITY_CARGOs + "% ").PadLeft(5) + "    \n";
                if (INIT_WELDERs > 0)
                    sec_integrity += "Welders   [" + generateBar(INTEGRITY_WELDERs) + "] " + (INTEGRITY_WELDERs + "% ").PadLeft(5) + "    \n";
            }

            catch { }


            if (sec_integrity == "-- Subsystem Integrity ------" + spinner + "--" + "\n\n") // nothing init basically.
                sec_integrity = LCD_DIVIDER + "\n\n"
                    + "Run init when ship is\nfully repaired to display\nsubsystem integrity!" + "\n\n";

            if (D) Echo("Building header...");

            // ------------------------
            // Build header and overlay
            // ------------------------

            string status_lts = "";
            string status_lts_overlay = "";

            for (int i = 0; i < StatusLights.Count; i++) 
            {
                status_lts += StatusLights[i].OUTPUT;
                status_lts_overlay += StatusLights[i].OUTPUT_OVERLAY;
            }

            /*string sec_header =
                LCD_DIVIDER + "\n" +
                centreText(spinner + " " + SHIP_NAME.ToUpper() + " " + spinner, LCD_WIDTH) + "\n" +
                centreText(STANCE, LCD_WIDTH) + "\n" +
                LCD_DIVIDER + "\n" +
                status_lts + "\n";*/

            string sec_header =

                 centreText(SHIP_NAME.ToUpper(), LCD_WIDTH) + "\n" +
                 "  " + spinner + " " + centreText(STANCE, LCD_WIDTH - 10) + " " + spinner + "  \n" +


                //centreText(spinner + " " + SHIP_NAME.ToUpper() + " " + spinner, LCD_WIDTH) + "\n" +
                //centreText(STANCE, LCD_WIDTH) + "\n" +
                //LCD_DIVIDER + "\n" +

                //"┌" + new String('─', LCD_WIDTH - 2) + "┐\n" +
                "╔══════╗╔══════╗╔══════╗╔══════╗\n" +
                status_lts + "\n" +
                "╚══════╝╚══════╝╚══════╝╚══════╝\n";

            int overlay_status = SPINNER_STATUS + 2;
            if (overlay_status > 3) overlay_status -= 4;
            string spinner_overlay = SPINNER_BITS[overlay_status];
            string sec_header_overlay =
                "\n  " + spinner_overlay + "                        " + spinner_overlay + "  \n\n" + status_lts_overlay;



            // ---------------------
            // Build Advanced Thrust
            // ---------------------
            string sec_thrust_advanced = "\n" + spinner + "\n";

            // only build this stuff if the player actually wants it.
            if (BUILD_ADVANCED_THRUST)
            {

                if (D) Echo("Building advanced thrust...");

                string Basics = "";
                if (ADVANCED_THRUST_SHOW_BASICS)
                {
                    Basics =
                        "\nMass:            " + (Math.Round((MASS / 1000000), 2) + " Mkg").PadLeft(15) +
                        "\n" + vel_msg + (vel + " ms").PadLeft(15) +
                        "\nMax Accel:       " + (AccelMax + " Gs").PadLeft(15) +
                        "\nActual Accel:    " + (AccelActual + " Gs").PadLeft(15);
                }

                sec_thrust_advanced =

                    "──┤ Telemetry & Thrust ├─────" + basic_spinner + "──\n"
                    + Basics +
                    //"\nMax Thrust:      " + ((max_thrust / 1000000) + " MN").PadLeft(15) +
                    //"\nActual Thrust:   " + ((actual_thrust / 1000000) + " MN").PadLeft(15) +
                    "\nDecel (Dampener):" + stopDistance(THRUST_MAX, vel, true) +
                    "\nDecel (Actual):  " + stopDistance(THRUST_ACTUAL, vel);

                foreach (double Percent in ADVANCED_THRUST_PERCENTS)
                {
                    sec_thrust_advanced += "\n" + ("Decel (" + (Percent * 100) + "%):").PadRight(17) + stopDistance((float)(THRUST_MAX * Percent), vel);
                }

                sec_thrust_advanced += "\n\n";
            }

            if (D) Echo("Interating over "+ LCDs_RSM.Count + " LCDs");

            for (int i = 0; i < LCDs_RSM.Count; i++)
            {
                bool show_header = true;
                bool show_header_overlay = false;
                bool show_warnings = false;
                bool show_tanks_and_batts = true;
                bool show_inventory = true;
                bool show_thrust = true;
                bool show_integrity = false;
                bool show_thrust_advanced = false;

                bool AllGood = false;
                string hudlcd_safe = "";
                try
                {
                    // Parse LCD Panel Data
                    string[] LcdConfigs = LCDs_RSM[i].CustomData.Split('\n');


                    int config_count = 0;

                    foreach (string LcdConfig in LcdConfigs)
                    {
                        if (LcdConfig.Contains("hudlcd"))
                            hudlcd_safe = LcdConfig;
                        if (LcdConfig.Contains("="))
                        {
                            string[] Parsed = LcdConfig.Split('=');

                            if (Parsed[0] == "Show Tanks & Batteries")
                            {
                                show_tanks_and_batts = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show header" || Parsed[0] == "Show Header")
                            {
                                show_header = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Header Overlay")
                            {
                                show_header_overlay = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Warnings")
                            {
                                show_warnings = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Inventory")
                            {
                                show_inventory = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Thrust")
                            {
                                show_thrust = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            /*
                            else if (Parsed[0] == "Show Comms")
                            {
                                show_comms = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Autorepair" || Parsed[0] == "Show Auxiliary")
                            {
                                show_aux = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Doors")
                            {
                                show_doors = bool.Parse(Parsed[1]);
                                config_count++;
                            }
                            */

                            else if (Parsed[0] == "Show Subsystem Integrity")
                            {
                                show_integrity = bool.Parse(Parsed[1]);
                                config_count++;
                            }

                            else if (Parsed[0] == "Show Advanced Thrust")
                            {
                                show_thrust_advanced = bool.Parse(Parsed[1]);
                                config_count++;
                            }
                        }


                    }
                    if (config_count == 8)
                        AllGood = true;

                }
                catch { }

                if (!AllGood)
                    setLcdCustomData(LCDs_RSM[i],
                        new bool[] {
                         show_header,
                         show_header_overlay,
                         show_warnings,
                         show_tanks_and_batts,
                         show_inventory,
                         show_thrust,
                         show_integrity,
                         show_thrust_advanced
                        }, hudlcd_safe);
                    




                

                string output_text = "";

                if (show_header && show_header_overlay) // can't be both bro.
                    show_header = false;

                if (show_header) output_text += sec_header;
                if (show_header_overlay) output_text += sec_header_overlay;
                if (show_warnings) output_text += sec_warnings;
                if (show_tanks_and_batts) output_text += sec_tanks_and_batts;
                if (show_inventory) output_text += sec_inventory_counts;
                if (show_thrust) output_text += sec_thrust;

                if (show_integrity) output_text += sec_integrity;
                if (show_thrust_advanced)
                {
                    output_text += sec_thrust_advanced;
                    BUILD_ADVANCED_THRUST = true;
                }
                //if (!show_header_overlay) output_text += LCD_DIVIDER;

                //Echo("Wrote to " + lcd_blocks[i].CustomName);
                LCDs_RSM[i].WriteText(output_text, false);


                // force font colour
                if (!DISABLE_LCD_COLOURS)
                {

                    if (show_header_overlay)
                        LCDs_RSM[i].FontColor = LCD_OVERLAY_COLOUR;
                    else
                        LCDs_RSM[i].FontColor = new Color(
                            CurrentStance[12],
                            CurrentStance[13],
                            CurrentStance[14],
                            CurrentStance[15]);
                }
            }

            if (D) Echo("Finished updating " + LCDs_RSM.Count.ToString() + " LCDs...");

            return;
        }

        // colour sync for non RSM LCDs
        void syncLcdColours()
        {

            if (LCDs_CS.Count > 0)
            {
                if (D) Echo("Setting " + LCDs_CS.Count + " colour sync LCDs.");

                foreach (IMyTextPanel LCD in LCDs_CS)
                {
                    LCD.FontColor = new Color(
                        STANCES[S][12],
                        STANCES[S][13],
                        STANCES[S][14],
                        STANCES[S][15]
                        );
                }
            }
        }

        void setHudLcd(string State, string Filter)
        {
            State = State.ToLower();
            List<IMyTextPanel> AllLCDs = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(LCDs);

            foreach (IMyTextPanel lcd in LCDs)
            {
                if (Filter == "" || lcd.CustomName.Contains(Filter))
                {
                    string cd = lcd.CustomData;
                    if (cd.Contains("hudlcd") && (State == "off" || State == "toggle"))
                        lcd.CustomData = cd.Replace("hudlcd", "hudXlcd");

                    if (cd.Contains("hudXlcd") && (State == "on" || State == "toggle"))
                        lcd.CustomData = cd.Replace("hudXlcd", "hudlcd");
                }
            }
        }


        // generates a fixed-width percentage bar for display
        // shows an error below 10%
        string generateBar(double percentage)
        {
            try
            {
                int ones_count = 0;
                if (percentage > 0)
                {
                    int try_this = (int)percentage / 10;
                    if (try_this > 10) return new string('=', 10);
                    if (try_this != 0) ones_count = try_this;
                }

                char zero = ' ';
                if (percentage < 10)
                {
                    if (SPINNER_STATUS == 0)
                        return " ><    >< ";
                    if (SPINNER_STATUS == 1)
                        return "  ><  ><  ";
                    if (SPINNER_STATUS == 2)
                        return "   ><><   ";
                    if (SPINNER_STATUS == 3)
                        return "<   ><   >";

                }

                string ones = new string('=', ones_count);
                string zeros = new string(zero, 10 - ones_count);
                return ones + zeros;
            }
            catch
            {
                return "# ERROR! #";
            }

        }

        // formats bars for h2/o2/batteries
        string barMe(string bar_type)
        {
            string bar;
            string val = "";
            double percentage = 0;


            switch (bar_type)
            {
                case "H2":
                    percentage = Math.Round(100 * (ACTUAL_H2 / INIT_H2));
                    val = percentage.ToString() + " %";
                    FUEL_PERCENTAGES = percentage;
                    break;
                case "O2":
                    percentage = Math.Round(100 * (ACTUAL_O2 / INIT_O2));
                    val = percentage.ToString() + " %";
                    break;
                case "Battery":
                    percentage = Math.Round(100 * (ACTUAL_BATTERIEs / TOTAL_BATTERIEs));
                    val = percentage.ToString() + " %";
                    break;

            }
            bar = generateBar(percentage);


            return " [" + bar + "] " + val.PadLeft(9);
        }


        // pad text on either side to centre it
        // important for hudlcd
        string centreText(string Text, int Width)
        {
            int spaces = Width - Text.Length;
            int padLeft = spaces / 2 + Text.Length;
            return Text.PadLeft(padLeft).PadRight(Width);
        }

        string stopDistance(double thrust, double speed, bool dampeners = false)
        {

            if (thrust <= 0) return ("N/A").PadLeft(15);

            if (dampeners) thrust = thrust * 1.5;

            //s = 1/2 * v ^ 2 * (m / F)
            double result = 0.5 * (Math.Pow(speed, 2) * (MASS / thrust));

            //t = v / (F / mass)
            double time = speed / (thrust / MASS);
            string unit = "m";
            if (result > 1000)
            {
                unit = "km";
                result = result / 1000;
            }

            return (Math.Round(result) + unit + " " + Math.Round(time) + "s").PadLeft(15);
        }


    }
}
