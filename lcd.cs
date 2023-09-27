﻿using Sandbox.Game.EntityComponents;
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
        string[] SPINNER_BITS = new string[] { "-", "\\", "|", "/" };

        // general LCD vars
        const int LCD_WIDTH = 32;
        const float LCD_FONT_SIZE = 0.8f;
        string LCD_DIVIDER = new String('-', LCD_WIDTH);

        Color LCD_OVERLAY_COLOUR = new Color(255, 0, 0, 255);

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
                while (Step > 3)
                {
                    Step -= 4;
                }
                            
                if (Status == 0) // nominal
                {
                    OUTPUT = "| " + Name.PadRight(4) + " |";
                    OUTPUT_OVERLAY = "        ";
                } 
                else if (Status == 1) // warning
                {
                    OUTPUT = "| " + Name.PadRight(4) + " |";
                    OUTPUT_OVERLAY = " >    < ";
                }
                else if (Status == 2) // danger
                {
                    if (Step == 0 || Step == 2)
                    {
                        OUTPUT_OVERLAY = " >" + Name.PadRight(4) + "< ";
                        OUTPUT = "|      |";
                    }
                    else if (Step == 1 || Step == 3)
                    {
                        OUTPUT_OVERLAY = "< " + Name.PadRight(4) + " >";
                        OUTPUT = " |    | ";
                    }


                }
                else if (Status == 3) // critcal
                {
                    if (Step == 0)
                    {
                        OUTPUT_OVERLAY = " >" + Name.PadRight(4) + " |";
                        OUTPUT = "|     < ";
                    }
                    else if (Step == 1)
                    {
                        OUTPUT = "| " + Name.PadRight(4) + "< ";
                        OUTPUT_OVERLAY = " >     |";
                    }
                    else if (Step == 2)
                    {
                        OUTPUT_OVERLAY = " >" + Name.PadRight(4) + " |";
                        OUTPUT = "|     < ";
                    }
                    else if (Step == 3)
                    {
                        OUTPUT = "| " + Name.PadRight(4) + "< ";
                        OUTPUT_OVERLAY = " >     |";
                    }
                }

            }
        }

        String[] ALERT_PRIORITIES = new string[] { "[- ", "[= ", "[# ", "[! " };
        List<ALERT> ALERTS = new List<ALERT>();


        // updates all LCDs on the ship to display our data.
        void updateLcd()
        {
            if (debug) Echo("Updating LCDs...");

            SPINNER_STATUS++;
            if (SPINNER_STATUS >= SPINNER_BITS.Length) SPINNER_STATUS = 0;
            string spinner = SPINNER_BITS[SPINNER_STATUS];




            string output_comms = current_comms;
            if (antenna_blocks.Count > 0)
                if (antenna_blocks[0] != null)
                    output_comms = antenna_blocks[0].HudText.PadLeft(15);

            string output_comms_range = (Math.Round((current_comms_range / 1000)).ToString() + " km").PadLeft(15);

            string output_sig_range = (Math.Round((current_sig_range / 1000)).ToString() + " km").PadLeft(15);

            string output_aux = "      ACTIVE";
            if (aux_active == 1)
                output_aux = "     INACTIVE";

            string output_doors = (doors_count_closed + "/" + doors_count).PadLeft(15);

            string output_vents = (vents_sealed + "/" + vents.Count).PadLeft(15);






            // -----------------------
            // Build inventory section
            // -----------------------

            string sec_inventory_counts =
                "-- Inventory ----------------" + spinner + "--" + "\n\n";

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
            double vel = Math.Round(velocity);
            string vel_msg = "Velocity:        ";

            if (vel < 1) // if velocity is close to zero, use 500m/s instead.
            {
                vel = 500;
                vel_msg = "Velocity (Max):  ";
            }

            double AccelMax = Math.Round((max_thrust / mass / 9.81), 2);
            double AccelActual = Math.Round((actual_thrust / mass / 9.81), 2);

            string output_decel_short;
            if (actual_thrust > 0)
            {
                output_decel_short = "Decel (Actual):  " + stopDistance(actual_thrust, vel) +
                    "\nAccel (Actual):  " + (AccelActual + " Gs").PadLeft(15);
            }
            else
            {
                output_decel_short = "Decel (Dampener):" + stopDistance(max_thrust, vel, true) +
                    "\nAccel (Best):    " + (AccelMax + " Gs").PadLeft(15);
            }

            string sec_thrust =
               "-- Thrust -------------------" + spinner + "--\n\n"
                + output_decel_short
                + "\nDrive Signature: " + output_sig_range + "\n\n";


            

            // -----------------------
            // Build Tanks & Batteries
            // -----------------------


            fuel_percentage = Math.Round(100 * (tank_h2_actual / tank_h2_total));
            double oxygen_percentage = Math.Round(100 * (tank_o2_actual / tank_o2_total));
            double battery_percentage = Math.Round(100 * (bat_actual / bat_total));

            string sec_tanks_and_batts =
               "-- Power & Gas --------------" + spinner + "--\n\n" +
                "Fuel      [" + generateBar(fuel_percentage) + "] " + (fuel_percentage + " %").PadLeft(9) + "\n" +
                "Oxygen    [" + generateBar(oxygen_percentage) + "] " + (oxygen_percentage + " %").PadLeft(9) + "\n" +
                "Battery   [" + generateBar(battery_percentage) + "] " + (battery_percentage + " %").PadLeft(9) + "\n" +
                "Max Power:" + (Math.Round(max_power, 2) + " MW").PadLeft(22) + "\n\n";




/*string sec_comms =
    "-- Communications -----------" + spinner + "--" + "\n\n"
    + "Comms:           " + output_comms + "\n"
    + "Comms Range:     " + output_comms_range + "\n\n";

string sec_aux =
    "-- Auxiliary  ---------------" + spinner + "--" + "\n\n"
    + aux_keyword + ":" + output_aux.PadLeft(31 - aux_keyword.Length) + "\n\n";

string sec_doors =
   "-- Doors & Vents ------------" + spinner + "--" + "\n\n"
   + "Doors Closed:    " + output_doors + "\n"
   + "Vents Sealed:    " + output_vents + "\n\n";*/


        // -------------------------
        // Build Subsystem Integrity
        // -------------------------
        string sec_integrity =
                "-- Subsystem Integrity ------" + spinner + "--\n\n";

            if (reactors_init > 0)
                sec_integrity += "Reactors  [" + generateBar(integrity_reactors) + "] " + (integrity_reactors + " %").PadLeft(9) + "\n";
            if (bat_init > 0)
                sec_integrity += "Batteries [" + generateBar(integrity_bats) + "] " + (integrity_bats + " %").PadLeft(9) + "\n";
            if (pdcs_init > 0)
                sec_integrity += "PDCs      [" + generateBar(integrity_pdcs) + "] " + (integrity_pdcs + " %").PadLeft(9) + "\n";
            if (torps_init > 0)
                sec_integrity += "Torpedoes [" + generateBar(integrity_torps) + "] " + (integrity_torps + " %").PadLeft(9) + "\n";
            if (railguns_init > 0)
                sec_integrity += "Railguns  [" + generateBar(integrity_railguns) + "] " + (integrity_railguns + " %").PadLeft(9) + "\n";
            if (tank_h2_init > 0)
                sec_integrity += "H2 Tanks  [" + generateBar(integrity_tanks_H2) + "] " + (integrity_tanks_H2 + " %").PadLeft(9) + "\n";
            if (tank_o2_init > 0)
                sec_integrity += "O2 Tanks  [" + generateBar(integrity_tanks_O2) + "] " + (integrity_tanks_O2 + " %").PadLeft(9) + "\n";
            if (thrust_main_init > 0)
                sec_integrity += "Epstein   [" + generateBar(integrity_main_thrust) + "] " + (integrity_main_thrust + " %").PadLeft(9) + "\n";
            if (thrust_rcs_init > 0)
                sec_integrity += "RCS       [" + generateBar(integrity_rcs_thrust) + "] " + (integrity_rcs_thrust + " %").PadLeft(9) + "\n";
            if (gyros_init > 0)
                sec_integrity += "Gyros     [" + generateBar(integrity_gyros) + "] " + (integrity_gyros + " %").PadLeft(9) + "\n\n";


            if (sec_integrity == "-- Subsystem Integrity ------" + spinner + "--" + "\n\n") // nothing init basically.
                sec_integrity = LCD_DIVIDER + "\n\n"
                    + "Run init when ship is\nfully repaired to display\nsubsystem integrity!" + "\n\n";


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


            // handle fuel
            int h2_priority = 0;
            if (fuel_percentage < 5)
            {
                LCDAlerts.Add(new ALERT("FUEL CRITICAL!", "FUEL CRITICAL!\nFuel Level < 5%!", 3));
                h2_priority = 3;
            }
            else if (fuel_percentage < 25)
            {
                LCDAlerts.Add(new ALERT("FUEL LOW!", "FUEL LOW!\nFuel Level < 10%!", 2));
                h2_priority = 2;
            }
     
            if (stance_data[stance_i][21] > 1)
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

            StatusLights.Add(new STATUS_LIGHT("OXYG", o2_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            // handle power
            int power_priority = 0;
            if (batteries.Count > 0)
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

            if (reactorsAll.Count > 0)
            {
                if (reactorsEmpty.Count > 0)
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT("Reactors need fuel!", "At least one reactor needs Fusion Fuel!", 3));
                }

                if (ITEMS[0].PERCENTAGE > 5) // Fusion fuel below 5% of init quota.
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT("FUSION FUEL LEVEL CRITICAL!", "Fusion fuel level is low!", 3));
                }

                if (ITEMS[0].PERCENTAGE > 10) // Fusion fuel below 10% of init quota.
                {
                    power_priority += 1;
                    LCDAlerts.Add(new ALERT("Fusion Fuel Level Low!", "Fusion fuel level is low!", 2));
                }
            }
          
            if (power_priority > 3) power_priority = 3;

            StatusLights.Add(new STATUS_LIGHT("POWR", power_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            int weap_priority = 0;

            if (missing_ammo != "") 
            {
                string[] Ammos = missing_ammo.Split('\n');
                foreach(string Ammo in Ammos)
                {
                    string output_ammo = Ammo;
                    if (Ammo.Length > 23) output_ammo = Ammo.Substring(0, 23);
                    LCDAlerts.Add(new ALERT("NEED " + output_ammo + "!", "NEED " + output_ammo + "!  Ammo Critical!", 3));
                }
                weap_priority = 3;
            }

            if (weap_priority > 3) weap_priority = 3;

            StatusLights.Add(new STATUS_LIGHT("WEAP", weap_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;


            // sort alerts by priority.
            LCDAlerts = LCDAlerts.OrderBy(a => a.PRIORITY).ToList();

            string sec_warnings =
                "-- Warnings -----------------" + spinner + "--\n\n";

            // output alerts to warnings list.
            for (int i = 0; i < LCDAlerts.Count; i++)
            {
                sec_warnings += ALERT_PRIORITIES[LCDAlerts[i].PRIORITY] + LCDAlerts[i].MESSAGE + "\n";
                Echo(ALERT_PRIORITIES[LCDAlerts[i].PRIORITY] + LCDAlerts[i].LONG_MESSAGE);
            }
            sec_warnings += "\n";


            // ------------------------
            // Build header and overlay
            // ------------------------

            string status_lts = "";
            string status_lts_overlay = "";

            string sec_header =
                LCD_DIVIDER + "\n" +
                centreText(spinner + " " + ship_name.ToUpper() + " " + spinner, LCD_WIDTH) + "\n" +
                centreText(current_stance, LCD_WIDTH) + "\n" +
                LCD_DIVIDER + "\n" +
                status_lts + "\n";

            string sec_header_overlay =
                "\n\n\n\n" + status_lts_overlay;



            // ---------------------
            // Build Advanced Thrust
            // ---------------------
            string sec_thrust_advanced = "\n" + spinner + "\n";

            if (build_advanced_thrust_data)
            {

                string Basics = "";
                if (ADVANCED_THRUST_SHOW_BASICS)
                {
                    Basics =
                        "\nMass:            " + (Math.Round((mass / 1000000), 2) + " Mkg").PadLeft(15) +
                        "\n" + vel_msg + (vel + " ms").PadLeft(15) +
                        "\nMax Accel:       " + (AccelMax + " Gs").PadLeft(15) +
                        "\nActual Accel:    " + (AccelActual + " Gs").PadLeft(15);
                }

                sec_thrust_advanced =
                    "-- Telemetry & Thrust -------" + spinner + "--\n"
                    + Basics +
                    "\nMax Thrust:      " + ((max_thrust / 1000000) + " MN").PadLeft(15) +
                    "\nActual Thrust:   " + ((actual_thrust / 1000000) + " MN").PadLeft(15) +
                    "\nDecel (Dampener):" + stopDistance(max_thrust, vel, true) +
                    "\nDecel (Actual):  " + stopDistance(actual_thrust, vel);

                foreach (double Percent in ADVANCED_THRUST_PERCENTS)
                {
                    sec_thrust_advanced += "\n" + ("Decel (" + (Percent * 100) + "%):").PadRight(17) + stopDistance((float)(max_thrust * Percent), vel);
                }

                sec_thrust_advanced += "\n\n";
            }







            for (int i = 0; i < lcd_blocks.Count; i++)
            {
                bool show_header = true;
                bool show_header_overlay = true;
                bool show_warnings = true;
                bool show_tanks_and_batts = true;
                bool show_inventory = true;
                bool show_thrust = true;
                /*
                bool show_comms = true;
                bool show_aux = false;
                bool show_doors = false;
                */
                bool show_integrity = false;
                bool show_thrust_advanced = false;

                bool AllGood = false;
                string hudlcd_safe = "";
                try
                {
                    // Parse LCD Panel Data
                    string[] LcdConfigs = lcd_blocks[i].CustomData.Split('\n');


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

                if (AllGood != true)
                {
                    lcd_blocks[i].CustomData =
                        "Show Header=" + show_header +
                        "\nShow Header Overlay=" + show_header_overlay +
                        "\nShow Warnings=" + show_warnings +
                        "\nShow Tanks & Batteries=" + show_tanks_and_batts +
                        "\nShow Inventory=" + show_inventory +
                        "\nShow Thrust=" + show_thrust +
                        /*
                        "\nShow Comms=" + show_comms +
                        "\nShow Auxiliary=" + show_aux +
                        "\nShow Doors=" + show_doors +
                        */
                        "\nShow Subsystem Integrity=" + show_integrity +
                        "\nShow Advanced Thrust=" + show_thrust_advanced
                        + "\n" + hudlcd_safe;
                }

                string output_text = "";

                if (show_header && show_header_overlay) // can't be both bro.
                    show_header = false;

                if (show_header) output_text += sec_header;
                if (show_header) output_text += sec_header_overlay;
                if (show_warnings) output_text += sec_warnings;
                if (show_tanks_and_batts) output_text += sec_tanks_and_batts;
                if (show_inventory) output_text += sec_inventory_counts;
                if (show_thrust) output_text += sec_thrust;
                /*
                if (show_comms) output_text += sec_comms;
                if (show_aux) output_text += sec_aux;
                if (show_doors) output_text += sec_doors;
                */

                if (show_integrity) output_text += sec_integrity;
                if (show_thrust_advanced)
                {
                    output_text += sec_thrust_advanced;
                    build_advanced_thrust_data = true;
                }
                output_text += LCD_DIVIDER;

                //Echo("Wrote to " + lcd_blocks[i].CustomName);
                lcd_blocks[i].WriteText(output_text, false);


                // force font colour
                if (!disable_text_colour_enforcement)
                {
                    if (show_header_overlay)
                        lcd_blocks[i].FontColor = LCD_OVERLAY_COLOUR;
                    else
                        lcd_blocks[i].FontColor = new Color(
                            stance_data[stance_i][12],
                            stance_data[stance_i][13],
                            stance_data[stance_i][14],
                            stance_data[stance_i][15]);
                }
            }

            if (debug) Echo("Finished updating " + lcd_blocks.Count.ToString() + " LCDs...");


            // write to PB details.
            //Echo(sec_header + debug_text);
            // TODO write something to Echo!

            return;
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
                    percentage = Math.Round(100 * (tank_h2_actual / tank_h2_total));
                    val = percentage.ToString() + " %";
                    fuel_percentage = percentage;
                    break;
                case "O2":
                    percentage = Math.Round(100 * (tank_o2_actual / tank_o2_total));
                    val = percentage.ToString() + " %";
                    break;
                case "Battery":
                    percentage = Math.Round(100 * (bat_actual / bat_total));
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
            double result = 0.5 * (Math.Pow(speed, 2) * (mass / thrust));

            //t = v / (F / mass)
            double time = speed / (thrust / mass);
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