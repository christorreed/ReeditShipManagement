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

            public int PRIORITY; // 
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
        // updates all _allLcds on the ship to display our data.
        void refreshLcds()
        {
            if (_d) Echo("Updating _allLcds...");

            updateTelemetry();

            SPINNER_STATUS++;
            if (SPINNER_STATUS >= SPINNER_BITS.Length) SPINNER_STATUS = 0;
            string spinner = SPINNER_BITS[SPINNER_STATUS];
            string basic_spinner = BASIC_SPINNER_BITS[SPINNER_STATUS];

            //string output_comms_range = (Math.Round((current_comms_range / 1000)).ToString() + " km").PadLeft(15);
            /*string output_aux = "      ACTIVE";
            if (_activeAuxBlockCount == 1)
                output_aux = "     INACTIVE";*/


            // -----------------------
            // Build inventory section
            // -----------------------

            string sec_inventory_counts =
                "──┤ Inventory ├──────────────" + basic_spinner + "──\n\n";


            foreach (Item Item in _items)
            {
                if (Item.InitQty != 0)
                {
                    Item.Percentage = (100 * ((double)Item.ActualQty / (double)Item.InitQty));
                    string val = (Item.ActualQty + "/" + Item.InitQty).PadLeft(9);
                    if (val.Length > 9) val = val.Substring(0, 9);
                    sec_inventory_counts += Item.LcdName + " [" + generateBar(Item.Percentage) + "] " + val + "\n";
                }
            }
            sec_inventory_counts += "\n";


            // --------------------
            // Build thrust section
            // --------------------
            //string output_sig_range = (Math.Round((current_sig_range / 1000)).ToString() + " km").PadLeft(15);
            double vel = Math.Round(_shipVelocity);
            string vel_msg = "Velocity:        ";

            if (vel < 1) // if velocity is close to zero, use 500m/s instead.
            {
                vel = 500;
                vel_msg = "Velocity (Max):  ";
            }

            double accelDueToGrav = 9.81;
            string units = " Gs";
            if (_isWeirdAboutThrustLikeGerm)
            {
                accelDueToGrav = 1;
                units = " m/s/s";
            }
            double AccelMax = Math.Round((_maxThrust / _shipMass / accelDueToGrav), 2);
            double AccelActual = Math.Round((_actualThrust / _shipMass / accelDueToGrav), 2);

            string output_decel_short;
            if (_actualThrust > 0)
            {
                output_decel_short = "Decel (Actual):  " + stopDistance(_actualThrust, vel) +
                    "\nAccel (Actual):  " + (AccelActual + units).PadLeft(15);
            }
            else
            {
                output_decel_short = "Decel (Dampener):" + stopDistance(_maxThrust, vel, true) +
                    "\nAccel (Best):    " + (AccelMax + units).PadLeft(15);
            }

            string sec_thrust =

               "──┤ Thrust ├─────────────────" + basic_spinner + "──\n\n" +
                output_decel_short;
                //"\nDrive Signature: " + output_sig_range + "\n\n";


            

            // -----------------------
            // Build Tanks & Batteries
            // -----------------------


            if (_d)
            {
                Echo("Actual H2:" + _actualH2 + "\nTotal H2: " + _totalH2);

            }

            _fuelPercentage = Math.Round(100 * (_actualH2 / _totalH2));
            double oxygen_percentage = Math.Round(100 * (ACTUAL_O2 / TOTAL_O2));
            double battery_percentage = Math.Round(100 * (ACTUAL__batteries / TOTAL__batteries));

            double init_power = Math.Round(_initReactors + _initBatteries, 1);
            double nice_max_power = Math.Round(_maxPower, 1);
            double capacity_percentage = Math.Round(100 * (nice_max_power/init_power));

            string sec_tanks_and_batts =
               "──┤ Power & Gas ├────────────" + basic_spinner + "──\n\n" +
                "Fuel      [" + generateBar(_fuelPercentage) + "] " + (_fuelPercentage + " %").PadLeft(9) + "\n" +
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
                + _keywordAuxBlocks + ":" + output_aux.PadLeft(31 - _keywordAuxBlocks.Length) + "\n\n";

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
            if (!_lidarWorking)
            {
                LCDAlerts.Add(new ALERT(
                    "NO LiDAR!", 
                    "No LiDARs are currently working. Ship is blind to enemy contacts at long range.", 
                    2
                    ));
            }

            // handle fuel
            int h2_priority = 0;
            if (_fuelPercentage < 5)
            {
                LCDAlerts.Add(new ALERT("FUEL CRITICAL!", "FUEL CRITICAL!\nFuel Level < 5%!", 3));
                h2_priority = 3;
            }
            else if (_fuelPercentage < 25)
            {
                LCDAlerts.Add(new ALERT("FUEL LOW!", "FUEL LOW!\nFuel Level < 10%!", 2));
                h2_priority = 2;
            }
     
            if (_currentStance.ExtractorMode != ExtractorModes.Off)
            {
                if (_noSpareTanks)
                {
                    if (h2_priority == 0) h2_priority = 1;

                    LCDAlerts.Add(new ALERT(
                        "No spare fuel tanks",
                        "Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",
                        h2_priority));
                }

                if (_noExtractor)
                {
                    if (h2_priority == 0) h2_priority = 1;

                    LCDAlerts.Add(new ALERT(
                        "No Extractor",
                        "Cannot refuel!\nNo functional extractor!",
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
            if (_vents.Count > _ventsSealedCount)
            {
                int unsealed = (_vents.Count - _ventsSealedCount);
                o2_priority++;
                LCDAlerts.Add(new ALERT(
                    unsealed + " vents are unsealed",
                    unsealed + " vents are unsealed",
                    1));
            }

            // handle doors
            if (_doorsCountUnlocked > 0)
            {
                LCDAlerts.Add(new ALERT(
                    _doorsCountUnlocked + " doors are insecure",
                    _doorsCountUnlocked + " doors are insecure",
                    0));
            }

            // handle aux
            if (_activeAuxBlockCount > 0)
            {
                LCDAlerts.Add(new ALERT(
                    _keywordAuxBlocks + " is active (" + _activeAuxBlockCount + ")",
                    _keywordAuxBlocks + " is active (" + _activeAuxBlockCount + ")",
                    0));
            }

            StatusLights.Add(new STATUS_LIGHT("OXYG", o2_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            // handle power
            int power_priority = 0;
            if (_batteries.Count > 0)
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

            if (_reactors.Count > 0)
            {
                if (EMPTY__reactors > 0)
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT(EMPTY__reactors + " REACTORS NEED FUS. FUEL!", "At least one reactor needs Fusion Fuel!", 3));
                }

                if (_items[0].InitQty == 0) // Different error if there is no target.
                {
                    if (_items[0].ActualQty > 0)
                    {
                        power_priority += 1;
                        LCDAlerts.Add(new ALERT("No Spare Fusion Fuel!", "No spare fusion fuel detected in ships cargo!", 2));
                    }
                }
                else if (_items[0].Percentage < 5) // Fusion fuel below 5% of init quota.
                {
                    power_priority += 2;
                    LCDAlerts.Add(new ALERT("FUSION FUEL LEVEL CRITICAL!", "Fusion fuel level is low!", 3));
                }
                else if (_items[0].Percentage < 10) // Fusion fuel below 10% of init quota.
                {
                    power_priority += 1;
                    LCDAlerts.Add(new ALERT("Fusion Fuel Level Low!", "Fusion fuel level is low!", 2));
                }
            }
          
            if (power_priority > 3) power_priority = 3;

            StatusLights.Add(new STATUS_LIGHT("POWR", power_priority, SPINNER_STATUS + status_light_spice));
            status_light_spice++;

            int weap_priority = 0;

            if (_ammoCritical != "") 
            {
                string[] Ammos = _ammoCritical.Split('\n');
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
            if (_commsActive)
            {

                string output_comms = _commsMessage;
                if (_antennas.Count > 0)
                    if (_antennas[0] != null)
                        output_comms = (_antennas[0] as IMyRadioAntenna).HudText;

                string output_range = "";
                if (_commsRange < 1000)
                    output_range = Math.Round(_commsRange) + "m";
                else
                    output_range = Math.Round(_commsRange / 1000) + "km";

                LCDAlerts.Add(new ALERT(
                    "Comms ("+ output_range + "): " + output_comms, 
                    "Antenna(s) are broadcasting at a range of " + output_range + " with the message " + output_comms, 0));
            }

            // handle unowned
            if (_unownedBlockCount > 0)
            {
                LCDAlerts.Add(new ALERT(
                _unownedBlockCount + " UNOWNED BLOCKS!",
                "RSM detected " + _unownedBlockCount + " terminal blocks on this grid owned by a player with a different faction tag."
                , 3
                ));
            }

            // handle doors
            //string output_doors = (doors_count_closed + "/" + doors_count).PadLeft(15);
            if (_doorsCount > _doorsCountClosed)
            {
                int open = (_doorsCount - _doorsCountClosed);
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

            string sec_integrity =
                "──┤ Subsystem Integrity ├────" + basic_spinner + "──\n\n";

            string empty = sec_integrity.ToString();

            string mainThrusterStance = _currentStance.MainDriveMode.ToString().ToUpper();
            if (mainThrusterStance.Length > 3) mainThrusterStance = mainThrusterStance.Substring(0, 3);

            string rcsThrusterStance = _currentStance.ManeuveringThrusterMode.ToString().ToUpper();
            if (rcsThrusterStance.Length > 3) rcsThrusterStance = rcsThrusterStance.Substring(0, 3);

            string tanksAndBatteriesStance = _currentStance.MainDriveMode.ToString().ToUpper();
            if (tanksAndBatteriesStance.Length > 3) tanksAndBatteriesStance = tanksAndBatteriesStance.Substring(0, 3);

            string pdcsStance = _currentStance.PdcMode.ToString().ToUpper();
            if (pdcsStance.Length > 3) pdcsStance = pdcsStance.Substring(0, 3);

            string torpStance = _currentStance.TorpedoMode.ToString().ToUpper();
            if (torpStance.Length > 3) torpStance = torpStance.Substring(0, 3);

            string railStance = _currentStance.RailgunMode.ToString().ToUpper();
            if (railStance.Length > 3) railStance = railStance.Substring(0, 3);

            try
            {
                if (_initThrustMain > 0)
                    sec_integrity += "Epstein   [" + generateBar(_integrityThrustMain) + "] " + (_integrityThrustMain + "% ").PadLeft(5) + mainThrusterStance + "\n";
                if (_initThrustRCS > 0)
                    sec_integrity += "RCS       [" + generateBar(INTEGRITY__rcsThrusters) + "] " + (INTEGRITY__rcsThrusters + "% ").PadLeft(5) + rcsThrusterStance + "\n";
                if (_initReactors > 0)
                    sec_integrity += "Reactors  [" + generateBar(INTEGRITY__reactors) + "] " + (INTEGRITY__reactors + "% ").PadLeft(5) + "    \n";
                if (_initBatteries > 0)
                    sec_integrity += "Batteries [" + generateBar(INTEGRITY__batteries) + "] " + (INTEGRITY__batteries + "% ").PadLeft(5) + tanksAndBatteriesStance + "\n";
                if (_initPdcs > 0)
                    sec_integrity += "PDCs      [" + generateBar(_integrityPdcs) + "] " + (_integrityPdcs + "% ").PadLeft(5) + pdcsStance + "\n";
                if (_initTorpLaunchers > 0)
                    sec_integrity += "Torpedoes [" + generateBar(_integrityTorpedoLaunchers) + "] " + (_integrityTorpedoLaunchers + "% ").PadLeft(5) + torpStance + "\n";
                if (_initKinetics > 0)
                    sec_integrity += "Railguns  [" + generateBar(_integrityKinetics) + "] " + (_integrityKinetics + "% ").PadLeft(5) + railStance + "\n";
                if (_initH2 > 0)
                    sec_integrity += "H2 Tanks  [" + generateBar(_integrityH2) + "] " + (_integrityH2 + "% ").PadLeft(5) + tanksAndBatteriesStance + "\n";
                if (_initO2 > 0)
                    sec_integrity += "O2 Tanks  [" + generateBar(INTEGRITY_O2) + "] " + (INTEGRITY_O2 + "% ").PadLeft(5) + tanksAndBatteriesStance + "\n";
                if (_initGyros > 0)
                    sec_integrity += "Gyros     [" + generateBar(_integrityGyros) + "] " + (_integrityGyros + "% ").PadLeft(5) + "    \n";
                if (_initCargos > 0)
                    sec_integrity += "Cargo     [" + generateBar(_integrityCargos) + "] " + (_integrityCargos + "% ").PadLeft(5) + "    \n";
                if (_initWelders > 0)
                    sec_integrity += "Welders   [" + generateBar(_integrityWelders) + "] " + (_integrityWelders + "% ").PadLeft(5) + "    \n";
            }

            catch { }


            if (sec_integrity == empty + "\n\n") // nothing init basically.
                sec_integrity = LCD_DIVIDER + "\n\n"
                    + "Run init when ship is\nfully repaired to display\nsubsystem integrity!" + "\n\n";

            if (_d) Echo("Building header...");

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
                centreText(spinner + " " + _shipName.ToUpper() + " " + spinner, LCD_WIDTH) + "\n" +
                centreText(STANCE, LCD_WIDTH) + "\n" +
                LCD_DIVIDER + "\n" +
                status_lts + "\n";*/

            string sec_header =

                 centreText(_shipName.ToUpper(), LCD_WIDTH) + "\n" +
                 "  " + spinner + " " + centreText(_currentStanceName, LCD_WIDTH - 10) + " " + spinner + "  \n" +


                //centreText(spinner + " " + _shipName.ToUpper() + " " + spinner, LCD_WIDTH) + "\n" +
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
            if (_buildAdvancedThrust)
            {

                if (_d) Echo("Building advanced thrust...");

                string Basics = "";
                if (_showBasicTelemetry)
                {
                    Basics =
                        "\nMass:            " + (Math.Round((_shipMass / 1000000), 2) + " Mkg").PadLeft(15) +
                        "\n" + vel_msg + (vel + " ms").PadLeft(15) +
                        "\nMax Accel:       " + (AccelMax + " Gs").PadLeft(15) +
                        "\nActual Accel:    " + (AccelActual + " Gs").PadLeft(15) +
                        "\nMax Thrust:      " + ((_maxThrust / 1000000) + " MN").PadLeft(15) +
                        "\nActual Thrust:   " + ((_actualThrust / 1000000) + " MN").PadLeft(15);
                }

                sec_thrust_advanced =

                    "──┤ Telemetry & Thrust ├─────" + basic_spinner + "──\n"
                    + Basics +

                    "\nDecel (Dampener):" + stopDistance(_maxThrust, vel, true) +
                    "\nDecel (Actual):  " + stopDistance(_actualThrust, vel);

                foreach (double Percent in _decelPercentages)
                {
                    sec_thrust_advanced += "\n" + ("Decel (" + (Percent * 100) + "%):").PadRight(17) + stopDistance((float)(_maxThrust * Percent), vel);
                }

                sec_thrust_advanced += "\n\n";
            }

            if (_d) Echo("Interating over "+ _rsmLcds.Count + " _allLcds");

            for (int i = 0; i < _rsmLcds.Count; i++)
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
                    string[] LcdConfigs = _rsmLcds[i].CustomData.Split('\n');


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
                    setLcdCustomData(_rsmLcds[i],
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
                    _buildAdvancedThrust = true;
                }
                //if (!show_header_overlay) output_text += LCD_DIVIDER;

                //Echo("Wrote to " + lcd_blocks[i].CustomName);
                _rsmLcds[i].WriteText(output_text, false);


                // force font colour
                if (!_disableLcdColourControl)
                {

                    if (show_header_overlay)
                        _rsmLcds[i].FontColor = LCD_OVERLAY_COLOUR;
                    else
                        _rsmLcds[i].FontColor = _currentStance.LcdTextColour;
                }
            }

            if (_d) Echo("Finished updating " + _rsmLcds.Count.ToString() + " _allLcds...");

            return;
        }

        // colour sync for non RSM _allLcds
        void syncLcdColours()
        {
            if (_colourSyncLcds.Count > 0)
            {
                if (_d) Echo("Setting " + _colourSyncLcds.Count + " colour sync _allLcds.");

                foreach (IMyTextPanel LCD in _colourSyncLcds)
                {
                    LCD.FontColor = _currentStance.LcdTextColour;
                }

                // do the RSM ones as well while we're at it.
                foreach (IMyTextPanel LCD in _rsmLcds)
                {
                    LCD.FontColor = _currentStance.LcdTextColour;
                }
            }
        }

        void setHudLcd(string State, string Filter)
        {
            State = State.ToLower();
            List<IMyTextPanel> All_allLcds = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(_allLcds);

            foreach (IMyTextPanel lcd in _allLcds)
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
                    percentage = Math.Round(100 * (_actualH2 / _initH2));
                    val = percentage.ToString() + " %";
                    _fuelPercentage = percentage;
                    break;
                case "O2":
                    percentage = Math.Round(100 * (ACTUAL_O2 / _initO2));
                    val = percentage.ToString() + " %";
                    break;
                case "Battery":
                    percentage = Math.Round(100 * (ACTUAL__batteries / TOTAL__batteries));
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
            double result = 0.5 * (Math.Pow(speed, 2) * (_shipMass / thrust));

            //t = v / (F / mass)
            double time = speed / (thrust / _shipMass);
            string unit = "m";
            if (result > 1000)
            {
                unit = "km";
                result = result / 1000;
            }

            return (Math.Round(result) + unit + " " + Math.Round(time) + "s").PadLeft(15);
        }

        void updateTelemetry()
        {
            if (_shipController != null)
            {
                try
                {
                    // calculate current mass and velocity
                    _shipVelocity = _shipController.GetShipSpeed();
                    _shipMass = _shipController.CalculateShipMass().PhysicalMass;
                }
                catch (Exception exxie)
                {
                    Echo("Failed to get velocity or mass!");
                    Echo(exxie.Message);
                }
            }
        }
    }
}
