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
        // updates all LCDs on the ship to display our data.
        void updateLcd()
        {
            if (debug) Echo("Updating LCDs...");

            lcd_spinner_status++;
            if (lcd_spinner_status >= lcd_spinners.Length) lcd_spinner_status = 0;
            string spinner = lcd_spinners[lcd_spinner_status];

            string debug_text = "";
            string debug_lcd = new String('.', lcd_spinner_status * 2);

            if (debug_msg != "")
            {
                debug_lcd = debug_msg;
                debug_dwell++;
                if (debug_dwell >= debug_dwell_max)
                {
                    debug_dwell = 0;
                    debug_msg = "";
                }
                else
                {
                    debug_text = "\n\n" + debug_msg + "\n"
                        + (debug_msg_long.Length <= 100 ? debug_msg_long : debug_msg_long.Substring(0, 100) + "...");
                }
            }
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

            string ammo_warning = "";

            if (missing_ammo != "")
            {
                if (lcd_spinner_status == 0 || lcd_spinner_status == 2)
                    ammo_warning += centreText("WARNING!", 32);
                else
                    ammo_warning += centreText("NO AMMO!", 32);

                ammo_warning += "\n" + missing_ammo + "\n\n";
            }


            string sec_inventory_counts =
                "-- Inventory ----------------" + spinner + "--" + "\n\n" + ammo_warning;

            foreach (ITEM Item in ITEMS)
            {
                if (Item.TARGET != 0)
                {
                    double percentage = (100 * ((double)Item.COUNT / (double)Item.TARGET));
                    string val = (Item.COUNT + "/" + Item.TARGET).PadLeft(9);
                    if (val.Length > 9) val = val.Substring(0, 9);
                    sec_inventory_counts += Item.NAME + " [" + generateBar(percentage) + "] " + val + "\n";
                }
            }

            sec_inventory_counts += "\n";

            double vel = Math.Round(velocity);
            string vel_msg = "Velocity:        ";

            if (vel < 1)
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

            string sec_header =
                lcd_divider + "\n"
                + centreText(spinner + " " + ship_name.ToUpper() + " " + spinner, 32) + "\n"
                + lcd_divider + "\n"
                + centreText("STANCE: " + current_stance.ToUpper(), 32) + "\n"
                + lcd_divider + "\n"
                + centreText(debug_lcd, 32) + "\n";

            string sec_tanks_and_batts =
               "-- Power & Gas --------------" + spinner + "--" + "\n\n"
                + "Max Power:" + (Math.Round(max_power, 2) + " MW").PadLeft(22) + "\n"
                + "Fuel     " + barMe("H2") + "\n"
                + "Oxygen   " + barMe("O2") + "\n"
                + "Battery  " + barMe("Battery") + "\n\n";

            string sec_thrust =
               "-- Thrust -------------------" + spinner + "--" + "\n\n"
                + output_decel_short
                + "\nDrive Signature: " + output_sig_range + "\n\n";

            string sec_comms =
                "-- Communications -----------" + spinner + "--" + "\n\n"
                + "Comms:           " + output_comms + "\n"
                + "Comms Range:     " + output_comms_range + "\n\n";

            string sec_aux =
                "-- Auxiliary  ---------------" + spinner + "--" + "\n\n"
                + aux_keyword + ":" + output_aux.PadLeft(31 - aux_keyword.Length) + "\n\n";

            string sec_doors =
               "-- Doors & Vents ------------" + spinner + "--" + "\n\n"
               + "Doors Closed:    " + output_doors + "\n"
               + "Vents Sealed:    " + output_vents + "\n\n";

            string sec_integrity =
                "-- Subsystem Integrity ------" + spinner + "--" + "\n\n";




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


            if (sec_integrity == lcd_divider + "\n\n") // nothing init basically.
                sec_integrity = lcd_divider + "\n\n"
                    + "Run init when ship is fully repaired\n to display subsystem integrity!" + "\n\n";

            string sec_thrust_advanced = "";

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
                    "-- Telemetry & Thrust -------" + spinner + "--" + "\n"
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
                // force colour
                if (!disable_text_colour_enforcement)
                    lcd_blocks[i].FontColor = new Color(
                            stance_data[stance_i][12],
                            stance_data[stance_i][13],
                            stance_data[stance_i][14],
                            stance_data[stance_i][15]
                            );

                bool show_header = true;
                bool show_tanks_and_batts = true;
                bool show_inventory = true;
                bool show_thrust = true;
                bool show_comms = true;
                bool show_aux = false;
                bool show_doors = false;
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

                            else if (Parsed[0] == "Show header")
                            {
                                show_header = bool.Parse(Parsed[1]);
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
                    if (config_count == 9)
                        AllGood = true;

                }
                catch { }

                if (AllGood != true)
                {
                    lcd_blocks[i].CustomData =
                        "Show header=" + show_header +
                        "\nShow Tanks & Batteries=" + show_tanks_and_batts +
                        "\nShow Inventory=" + show_inventory +
                        "\nShow Thrust=" + show_thrust +
                        "\nShow Comms=" + show_comms +
                        "\nShow Auxiliary=" + show_aux +
                        "\nShow Doors=" + show_doors +
                        "\nShow Subsystem Integrity=" + show_integrity +
                        "\nShow Advanced Thrust=" + show_thrust_advanced
                        + "\n" + hudlcd_safe;
                }

                string output_text = "";

                if (show_header) output_text += sec_header;
                if (show_tanks_and_batts) output_text += sec_tanks_and_batts;
                if (show_inventory) output_text += sec_inventory_counts;
                if (show_thrust) output_text += sec_thrust;
                if (show_comms) output_text += sec_comms;
                if (show_aux) output_text += sec_aux;
                if (show_doors) output_text += sec_doors;
                if (show_integrity) output_text += sec_integrity;
                if (show_thrust_advanced)
                {
                    output_text += sec_thrust_advanced;
                    build_advanced_thrust_data = true;
                }
                output_text += lcd_divider;

                //Echo("Wrote to " + lcd_blocks[i].CustomName);
                lcd_blocks[i].WriteText(output_text, false);
            }

            if (debug) Echo("Finished updating " + lcd_blocks.Count.ToString() + " LCDs...");


            // write to PB details.
            Echo(sec_header + debug_text);


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
                    if (lcd_spinner_status == 0)
                        return " ><    >< ";
                    if (lcd_spinner_status == 1)
                        return "  ><  ><  ";
                    if (lcd_spinner_status == 2)
                        return "   ><><   ";
                    if (lcd_spinner_status == 3)
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
