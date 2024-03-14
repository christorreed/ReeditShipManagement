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
    partial class Program
    {
        // Keywords -----------------------------------------------------------------

        char NAME_DELIMITER = '.';

        string KEYWORD_LCD = "[RSM]"; // for RSM LCDs
        string KEYWORD_AUX = "[Autorepair]"; // for auxiliary blocks
        string KEYWORD_IGNORE = "[I]"; // for blocks to be ignored
        string KEYWORD_DEF_PDC = "Repel"; // for PDCs marked for permanent defence
        string KEYWORD_THRUST_MIN = "Min"; // for epsteins enabled at min
        string KEYWORD_THRUST_DOCKING = "Docking"; // for epsteins enabled with RCS
        string KEYWORD_COLOUR_SYNC = "[CS]"; // for LCD colour sync
        string KEYWORD_AIRLOCK = "Airlock"; // for airlocks
        string KEYWORD_PB_EFC = "[EFC]"; // for EFC PBs/LCDs
        string KEYWORD_PB_NAVOS = "[NavOS]"; // for NavOS PBs/LCDs
        string KEYWORD_LIGHT_NAV = "NAV"; // for Nav lights

        // Toggles -----------------------------------------------------------------

        bool AUTOLOAD = true; // Enable Weapon Autoload Functionality.
        bool AUTO_CONFIG_WEAPs = true; // Automatically configure PDCs, Railguns, Torpedoes.
        bool DISABLE_LIGHTING = false; // Disable lighting all control.
        bool DISABLE_LCD_COLOURS = false; // Disable LCD Text Colour Enforcement.
        bool SPAWN_PRIVATE = false; // Private spawn (don't inject faction tag into SK custom data).
        bool DISCHARGE_MGMT = true; // Only set batteries to discharge on active railgun/coilgun target.
        bool ADVANCED_THRUST_SHOW_BASICS = true; // show basic telemetry data on advanced thrust LCD
        bool NAME_WEAPON_TYPES = true; // append type names to all weapons during init.

        // Lists -----------------------------------------------------------------

        // list of friendly faction ids, steamids, that can be used to open spawns.
        private string FRIENDLY_TAGS = ""; 

        // blocks which will be enumerated at init.
        private List<string> FORCE_ENUMERATION = new List<string>(); 

        // thrust percentages to show on the Advanced Thrust LCD
        private List<double> ADVANCED_THRUST_PERCENTS = new List<double>();

        // Doors -----------------------------------------------------------------

        private int DOOR_OPEN_TIME = 3; // Doors open timer (x100 ticks, default 3)
        private int DOOR_AIRLOCK_TIME = 6; // Airlock doors disabled timer (x100 ticks, default 6)

        // Performance & Debugging -----------------------------------------------------------------

        private int WAIT_COUNT = 0; // for throttling CPU usage
        private int REFRESH_FREQ = 50; // number of loops between complete refreshes.
        private bool D = false; // verbose debugging enabled

        // System -----------------------------------------------------------------

        string SHIP_NAME = "Untitled Ship";

        // todo
        // review this method
        // change to ini
        // split up parsing and saving
        // save often, parse only at recompile
        void updateCustomData(bool dontParse)
        {

            // this function updates some of the variables from custom data of the prog block
            // first attempt to parse custom data.
            // if it works, update vars.
            // If it fails, reset from current vars.

            bool parsedVars = false;
            bool parsedStances = false;

            if (D) Echo("updateCustomData(dontParse = " + dontParse + ");\n");

            if (dontParse == false)
            {

                string varSection = "";
                string stanceSection = "";

                // first we split into our two sections
                // general variables, and stances
                // since stances is iterated over
                // also, I want in different try catch statements
                // also, this makes it easier to add variables
                // so that if u fuck up a stance it doesn't ruin
                // vars and vise versa.
                try
                {
                    string[] sections = Me.CustomData.Split(new string[] { "[Stances]" }, StringSplitOptions.None);
                    varSection = sections[0];
                    stanceSection = sections[1];
                }
                catch
                {
                    if (D) Echo("Custom Data Error! Custom data invalid or blank.");
                }

                // so now we attempt to parse the variables part.
                try
                {

                    string[] parse_dat = varSection.Split('\n');
                    int config_count = 0;

                    for (int i = 0; i < parse_dat.Length; i++)
                    {
                        if (parse_dat[i].Contains("="))
                        {
                            //string[] cleanup = parse_dat[i].Split('=');
                            string value = parse_dat[i].Substring(1);

                            // so if we contain an =, the item prior is my setting name.
                            switch (parse_dat[(i - 1)])
                            {
                                case "Ship name. Blocks without this name will be ignored":
                                    config_count++;
                                    SHIP_NAME = value;

                                    break;
                                case "Block name delimiter, used by init. One character only!":

                                    config_count++;
                                    NAME_DELIMITER = char.Parse(value.Substring(0, 1));

                                    if (D) Echo("DELIMITER = " + NAME_DELIMITER);

                                    break;
                                case "Keyword used to identify RSM LCDs.":
                                    config_count++;
                                    KEYWORD_LCD = value;

                                    break;
                                case "Keyword used to identify autorepair systems":
                                case "Keyword used to identify auxiliary blocks":
                                    config_count++;
                                    KEYWORD_AUX = value;

                                    break;
                                case "Keyword used to identify defence PDCs.":
                                    config_count++;
                                    KEYWORD_DEF_PDC = value;

                                    break;
                                case "Keyword used to identify minimum epstein drives.":
                                    config_count++;
                                    KEYWORD_THRUST_MIN = value;
                                    break;
                                case "Keyword used to identify docking epstein drives.":
                                    config_count++;
                                    KEYWORD_THRUST_DOCKING = value;
                                    break;
                                case "Keyword to ignore block.":
                                    config_count++;
                                    KEYWORD_IGNORE = value;
                                    break;
                                case "Automatically configure PDCs, Railguns, Torpedoes.":
                                    config_count++;
                                    AUTO_CONFIG_WEAPs = bool.Parse(value);
                                    break;

                                case "Disable lighting all control.":
                                    config_count++;
                                    DISABLE_LIGHTING = bool.Parse(value);
                                    break;
                                case "Disable LCD Text Colour Enforcement.":
                                    config_count++;
                                    DISABLE_LCD_COLOURS = bool.Parse(value);
                                    break;

                                case "Enable Weapon Autoload Functionality.":
                                    config_count++;
                                    AUTOLOAD = bool.Parse(value);
                                    break;


                                case "Number these blocks at init.":
                                    config_count++;
                                    FORCE_ENUMERATION.Clear();
                                    string[] FNames = value.Split(',');
                                    foreach (string FName in FNames)
                                    {
                                        if (FName != "")
                                            FORCE_ENUMERATION.Add(FName);
                                    }
                                    break;

                                case "Add type names to weapons at init.":
                                    config_count++;
                                    NAME_WEAPON_TYPES = bool.Parse(value);
                                    break;

                                case "Only set batteries to discharge on active railgun/coilgun target.":
                                    config_count++;
                                    DISCHARGE_MGMT = bool.Parse(value);
                                    break;


                                case "Show basic telemetry.":
                                    config_count++;
                                    ADVANCED_THRUST_SHOW_BASICS = bool.Parse(value);
                                    break;
                                case "Show Decel Percentages (comma seperated).":
                                    config_count++;
                                    ADVANCED_THRUST_PERCENTS.Clear();
                                    string[] Percents = value.Split(',');
                                    foreach (string Percent in Percents)
                                    {
                                        ADVANCED_THRUST_PERCENTS.Add(double.Parse(Percent) / 100);
                                    }
                                    break;



                                case "Fusion Fuel count":
                                    config_count++;
                                    ITEMS[0].TARGET = int.Parse(value);
                                    break;

                                case "Fuel tank count":
                                    config_count++;
                                    ITEMS[1].TARGET = int.Parse(value);
                                    break;

                                case "Jerry can count":
                                    config_count++;
                                    ITEMS[2].TARGET = int.Parse(value);
                                    break;

                                case "40mm PDC Magazine count":
                                    config_count++;
                                    ITEMS[3].TARGET = int.Parse(value);
                                    break;
                                case "40mm Teflon Tungsten PDC Magazine count":
                                    config_count++;
                                    ITEMS[4].TARGET = int.Parse(value);
                                    break;

                                case "220mm Torpedo count":
                                // was like this in versions prior to 0.5.0
                                case "Torpedo count":
                                    config_count++;
                                    ITEMS[5].TARGET = int.Parse(value);
                                    break;

                                case "220mm MCRN torpedo count":
                                    config_count++;
                                    ITEMS[6].TARGET = int.Parse(value);
                                    break;

                                case "220mm UNN torpedo count":
                                    config_count++;
                                    ITEMS[7].TARGET = int.Parse(value);
                                    break;

                                case "Ramshackle torpedo count":
                                // was like this in versions prior to 0.4.0
                                case "Ramshackle torpedo Count":
                                    config_count++;
                                    ITEMS[8].TARGET = int.Parse(value);
                                    break;

                                case "Large ramshacke torpedo count":
                                    config_count++;
                                    ITEMS[9].TARGET = int.Parse(value);
                                    break;

                                case "Zako 120mm Railgun rounds count":
                                // was like this in versions prior to 0.5.0
                                case "Railgun rounds count":
                                    config_count++;
                                    ITEMS[10].TARGET = int.Parse(value);
                                    break;

                                case "Dawson 100mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[11].TARGET = int.Parse(value);
                                    break;

                                case "Stiletto 100mm MCRN Railgun rounds count":
                                    config_count++;
                                    ITEMS[12].TARGET = int.Parse(value);
                                    break;

                                case "T-47 80mm Railgun rounds count":
                                    config_count++;
                                    ITEMS[13].TARGET = int.Parse(value);
                                    break;

                                case "Foehammer 120mm MCRN rounds count":
                                    config_count++;
                                    ITEMS[14].TARGET = int.Parse(value);
                                    break;

                                case "Farren 120mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[15].TARGET = int.Parse(value);
                                    break;


                                case "Kess 180mm rounds count":
                                    config_count++;
                                    ITEMS[16].TARGET = int.Parse(value);
                                    break;

                                case "Steel plate count":
                                    config_count++;
                                    ITEMS[17].TARGET = int.Parse(value);
                                    break;


                                case "Doors open timer (x100 ticks, default 3)":
                                    config_count++;
                                    DOOR_OPEN_TIME = int.Parse(value);
                                    break;
                                case "Airlock doors disabled timer (x100 ticks, default 6)":
                                    config_count++;
                                    DOOR_AIRLOCK_TIME = int.Parse(value);
                                    break;
                                case "Throttle script (x100 ticks pause between loops, default 0)":
                                    config_count++;
                                    WAIT_COUNT = int.Parse(value);
                                    break;
                                case "Full refresh frequency (x100 ticks, default 50)":
                                    config_count++;
                                    REFRESH_FREQ = int.Parse(value);
                                    break;
                                case "Verbose script debugging. Prints more logging info to PB details.":
                                    config_count++;
                                    D = bool.Parse(value);
                                    break;


                                case "Private spawn (don't inject faction tag into SK custom data).":
                                    config_count++;
                                    SPAWN_PRIVATE = bool.Parse(value);
                                    break;


                                case "Comma seperated friendly factions or steam ids for survival kits.":
                                    config_count++;
                                    FRIENDLY_TAGS = string.Join("\n", value.Split(','));
                                    //debug = bool.Parse(value);
                                    break;

                                case "Current Stance":
                                    config_count++;
                                    STANCE = value;
                                    break;

                                case "Reactor Integrity":
                                    config_count++;
                                    INIT_REACTORs = float.Parse(value);
                                    break;
                                case "Battery Integrity":
                                    config_count++;
                                    INIT_BATTERIEs = float.Parse(value);
                                    break;
                                case "PDC Integrity":
                                    config_count++;
                                    INIT_PDCs = int.Parse(value);
                                    break;
                                case "Torpedo Integrity":
                                    config_count++;
                                    INIT_TORPs = int.Parse(value);
                                    break;
                                case "Railgun Integrity":
                                    config_count++;
                                    INIT_RAILs = int.Parse(value);
                                    break;
                                case "H2 Tank Integrity":
                                    config_count++;
                                    INIT_H2 = double.Parse(value);
                                    break;
                                case "O2 Tank Integrity":
                                    config_count++;
                                    INIT_O2 = double.Parse(value);
                                    break;
                                case "Epstein Integrity":
                                    config_count++;
                                    INIT_THRUSTERs_MAIN = float.Parse(value);
                                    break;
                                case "RCS Integrity":
                                    config_count++;
                                    INIT_THRUSTERs_RCS = float.Parse(value);
                                    break;
                                case "Gyro Integrity":
                                    config_count++;
                                    INIT_GYROs = int.Parse(value);
                                    break;
                                case "Cargo Integrity":
                                    config_count++;
                                    INIT_CARGOs = double.Parse(value);
                                    break;
                                case "Welder Integrity":
                                    config_count++;
                                    INIT_WELDERs = int.Parse(value);
                                    break;



                            }
                        }
                    }

                    if (config_count == 55)
                    {
                        parsedVars = true;
                    }



                    else
                    {
                        Echo("Did not get enough config items (" + config_count + ") from custom data, resetting.");
                    }
                }
                catch
                {
                    Echo("Custom Data Error (vars)");
                }

                if (SPAWN_PRIVATE)
                {
                    if (SPAWN_OPEN)
                        SK_DATA = FRIENDLY_TAGS;
                    else
                        SK_DATA = "";

                }
                else
                {
                    SK_DATA = "                                                                                                                                 " +
                        FACTION_TAG;

                    if (SPAWN_OPEN)
                        SK_DATA += "\n" + FRIENDLY_TAGS;

                    SK_DATA += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                         FACTION_TAG;
                }



                // alright so now we try to parse stance data
                try
                {
                    string[] stances = stanceSection.Split(new string[] { "Stance:" }, StringSplitOptions.None);

                    if (D) Echo("Parsing " + (stances.Length - 1) + " stances");

                    int data_length = STANCES[0].Length;

                    List<string> new_name_list = new List<string>();
                    List<int[]> new_data_list = new List<int[]>();

                    for (int i = 1; i < stances.Length; i++)
                    {
                        string[] stance_vars = stances[i].Split('=');

                        string new_name = "";
                        int[] new_data = new int[data_length];

                        new_name = stance_vars[0].Split(' ')[0];
                        if (D) Echo("Parsing '" + new_name + "'");
                        for (int j = 0; j < new_data.Length; j++)
                        {
                            string[] cleanup = stance_vars[(j + 1)].Split('\n');
                            new_data[j] = int.Parse(cleanup[0]);
                            //if (D) Echo(new_data[j].ToString());
                        }
                        new_name_list.Add(new_name);
                        new_data_list.Add(new_data);
                    }
                    if (new_name_list.Count >= 1 && new_name_list.Count == new_data_list.Count)
                    {
                        // we did it.
                        STANCE_NAMES = new_name_list;
                        STANCES = new_data_list;
                        parsedStances = true;
                        if (D) Echo("Finished parsing " + STANCE_NAMES.Count + " stances.");

                        // update the S value as well so lights and colours aren't effected.
                        for (int j = 0; j < STANCE_NAMES.Count; j++)
                        {
                            if (STANCE == STANCE_NAMES[j]) S = j;
                        }
                    }
                    else
                    {
                        // lol force a crash
                        // TODO actually throw a proper error instead or something.
                        Echo("Didn't find any stances!");
                        Echo(stances[69420]);
                    }
                }
                catch
                {
                    Echo("Custom Data Error (stances)");
                }

                // STOP HERE IF EVERYTHING PARSED WELL!
                if (parsedVars && parsedStances) return;

            }



            string stance_text = "";

            if (STANCE_NAMES.Count != STANCES.Count) Echo("Um, so...\nstance_names.Count != STANCES.Count");

            if (STANCE_NAMES.Count < 1 && D)
            {
                Echo("No stances!");
            }

            if (!dontParse)
                ALERTS.Add(new ALERT(
                    "RESET CUSTOM DATA!",
                    "Something went wrong, so custom data was reset.\nVars Parsed=" + parsedVars + "\nStances Parsed=" + parsedStances
                    , 3
                    ));

            else
                Echo("Saved custom data.");

            for (int i = 0; i < STANCE_NAMES.Count; i++)
            {
                stance_text += " - Stance:" + STANCE_NAMES[i] + " - \n"
                    + "torpedoes; 0: off, 1: on;\n="
                    + STANCES[i][0] + "\n"
                    + "pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only\n="
                    + STANCES[i][1] + "\n"
                    + "railguns; 0: off, 1: hold fire, 2: AI weapons free;\n="
                    + STANCES[i][2] + "\n"
                    + "main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change\n="
                    + STANCES[i][3] + "\n"
                    + "maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change\n="
                    + STANCES[i][4] + "\n"
                    + "spotlights; 0: off, 1: on, 2: on max radius, 3: no change\n="
                    + STANCES[i][5] + "\n"

                    + "exterior lights; 0: off, 1: on, 3: no change\n="
                    + STANCES[i][6]
                    + "\nred=" + STANCES[i][7] + "\ngreen=" + STANCES[i][8]
                    + "\nblue=" + STANCES[i][9] + "\nalpha=" + STANCES[i][10] + "\n"

                    + "interior lights lights; 0: off, 1: on, 3: no change\n="
                    + STANCES[i][11]
                    + "\nred=" + STANCES[i][12] + "\ngreen=" + STANCES[i][13]
                    + "\nblue=" + STANCES[i][14] + "\nalpha=" + STANCES[i][15] + "\n"

                    // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                    + "stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts\n="
                    + STANCES[i][16] + "\n"
                    + "EFC boost; 0: off, 1: on\n="
                    + STANCES[i][17] + "\n"
                    + "EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%\n="
                    + STANCES[i][18] + "\n"
                    + "EFC kill; 0: no change, 1: run 'Off' on EFC.\n="
                    + STANCES[i][19] + "\n"
                    + "auxiliary blocks; 0: off, 1: on\n="
                    + STANCES[i][20] + "\n"
                    + "extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.\n="
                    + STANCES[i][21] + "\n"
                    + "keep-alives for REACTORs, connectors, gyros, lcds, cameras, sensors, lidars; 0: ignore, 1: force on, 2: force off\n="
                    + STANCES[i][22] + "\n"
                    + "hangar doors; 0: closed, 1: open, 2: no change\n="
                    + STANCES[i][23] + "\n\n"
                    ;
            }

            string DecelPercents = "";

            foreach (double Percent in ADVANCED_THRUST_PERCENTS)
            {
                if (DecelPercents != "") DecelPercents += ",";
                DecelPercents += (Percent * 100).ToString();
            }

            string ForcedNames = "";

            foreach (string FName in FORCE_ENUMERATION)
            {
                if (ForcedNames != "") ForcedNames += ",";
                ForcedNames += FName;
            }

            Me.CustomData =
                "-------------------------\n"
                + "Reedit Ship Management" + "\n"
                + "-------------------------\n"
                + "If this data can't be parsed, it will be reset!" + "\n"

                + "\n---- [General Settings] ----\n"
                + "Block name delimiter, used by init. One character only!\n=" + NAME_DELIMITER + "\n"
                + "Keyword used to identify RSM LCDs.\n=" + KEYWORD_LCD + "\n"
                + "Keyword used to identify auxiliary blocks\n=" + KEYWORD_AUX + "\n"
                + "Keyword used to identify minimum epstein drives.\n=" + KEYWORD_THRUST_MIN + "\n"
                + "Keyword used to identify docking epstein drives.\n=" + KEYWORD_THRUST_DOCKING + "\n"
                + "Keyword used to identify defence PDCs.\n=" + KEYWORD_DEF_PDC + "\n"
                + "Keyword to ignore block.\n=" + KEYWORD_IGNORE + "\n"
                + "Enable Weapon Autoload Functionality.\n=" + AUTOLOAD + "\n"
                + "Automatically configure PDCs, Railguns, Torpedoes.\n=" + AUTO_CONFIG_WEAPs + "\n"
                + "Disable lighting all control.\n=" + DISABLE_LIGHTING + "\n"
                + "Disable LCD Text Colour Enforcement.\n=" + DISABLE_LCD_COLOURS + "\n"
                + "Private spawn (don't inject faction tag into SK custom data).\n=" + SPAWN_PRIVATE + "\n"
                + "Comma seperated friendly factions or steam ids for survival kits.\n=" + (string.Join(",", FRIENDLY_TAGS.Split('\n'))) + "\n"
                + "Number these blocks at init.\n=" + ForcedNames + "\n"
                + "Add type names to weapons at init.\n=" + NAME_WEAPON_TYPES + "\n"
                + "Only set batteries to discharge on active railgun/coilgun target.\n=" + DISCHARGE_MGMT + "\n"

                + "\n---- [Door Timers] ----\n"
                + "Doors open timer (x100 ticks, default 3)\n=" + DOOR_OPEN_TIME + "\n"
                + "Airlock doors disabled timer (x100 ticks, default 6)\n=" + DOOR_AIRLOCK_TIME + "\n"

                + "\n---- [Advanced Thrust LCD] ----\n"
                + "Show basic telemetry.\n=" + ADVANCED_THRUST_SHOW_BASICS + "\n"
                + "Show Decel Percentages (comma seperated).\n=" + DecelPercents + "\n"

                + "\n---- [Performance & Debugging] ----\n"
                + "Throttle script (x100 ticks pause between loops, default 0)\n=" + WAIT_COUNT + "\n"
                + "Full refresh frequency (x100 ticks, default 50)\n=" + REFRESH_FREQ + "\n"
                + "Verbose script debugging. Prints more logging info to PB details.\n=" + D + "\n"

                + "\n---- [System] ----\n"
                + "You can edit these if you want...\nbut they are usually populated by the script and saved here.\n"
                + "Ship name. Blocks without this name will be ignored\n=" + SHIP_NAME + "\n"
                + "Current Stance\n=" + STANCE + "\n"
                + "Reactor Integrity\n=" + INIT_REACTORs + "\n"
                + "Battery Integrity\n=" + INIT_BATTERIEs + "\n"
                + "PDC Integrity\n=" + INIT_PDCs + "\n"
                + "Torpedo Integrity\n=" + INIT_TORPs + "\n"
                + "Railgun Integrity\n=" + INIT_RAILs + "\n"
                + "H2 Tank Integrity\n=" + INIT_H2 + "\n"
                + "O2 Tank Integrity\n=" + INIT_O2 + "\n"
                + "Epstein Integrity\n=" + INIT_THRUSTERs_MAIN + "\n"
                + "RCS Integrity\n=" + INIT_THRUSTERs_RCS + "\n"
                + "Gyro Integrity\n=" + INIT_GYROs + "\n"
                + "Cargo Integrity\n=" + INIT_CARGOs + "\n"
                + "Welder Integrity\n=" + INIT_WELDERs + "\n"

                + "\n---- [Inventory Counts] ----\n"
                + "You can edit these if you want...\nbut they are usually populated by the script and saved here.\n"
                + "Fusion Fuel count\n=" + ITEMS[0].TARGET + "\n"

                + "Fuel tank count\n=" + ITEMS[1].TARGET + "\n"
                + "Jerry can count\n=" + ITEMS[2].TARGET + "\n"

                + "40mm PDC Magazine count\n=" + ITEMS[3].TARGET + "\n"
                + "40mm Teflon Tungsten PDC Magazine count\n=" + ITEMS[4].TARGET + "\n"

                + "220mm Torpedo count\n=" + ITEMS[5].TARGET + "\n"
                + "220mm MCRN torpedo count\n=" + ITEMS[6].TARGET + "\n"
                + "220mm UNN torpedo count\n=" + ITEMS[7].TARGET + "\n"

                + "Ramshackle torpedo count\n=" + ITEMS[8].TARGET + "\n"
                + "Large ramshacke torpedo count\n=" + ITEMS[9].TARGET + "\n"

                + "Zako 120mm Railgun rounds count\n=" + ITEMS[10].TARGET + "\n"
                + "Dawson 100mm UNN Railgun rounds count\n=" + ITEMS[11].TARGET + "\n"
                + "Stiletto 100mm MCRN Railgun rounds count\n=" + ITEMS[12].TARGET + "\n"
                + "T-47 80mm Railgun rounds count\n=" + ITEMS[13].TARGET + "\n"

                + "Foehammer 120mm MCRN rounds count\n=" + ITEMS[14].TARGET + "\n"
                + "Farren 120mm UNN Railgun rounds count\n=" + ITEMS[15].TARGET + "\n"


                + "Kess 180mm rounds count\n=" + ITEMS[16].TARGET + "\n"
                + "Steel plate count\n=" + ITEMS[17].TARGET + "\n"

                + "\n---- [Stances] ----\n"
                + stance_text

                + "-------------------------\n\n\n\n\n";

            return;


        }




    }
}
