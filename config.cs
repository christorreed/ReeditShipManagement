﻿using Sandbox.Engine.Utils;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        // the config ini object itself
        MyIni _config = new MyIni();

        // Main -----------------------------------------------------------------

        // if true, RSM will operate on all blocks even if they don't have the ship name in them.
        bool _requireShipName = true;

        // Enable Autoload Functionality.
        bool _autoLoad = true;

        // Enable autoload functionality for reactors.
        bool _autoLoadReactors = true; 

        // Automatically configure PDCs, Railguns, Torpedoes.
        bool _autoConfigWeapons = true;

        // set turret fire mode based on stance
        bool _setTurretFireMode = true;

        // Only set batteries to discharge on active railgun/coilgun target.
        bool _manageBatteryDischarge = true; 

        // Spawns -----------------------------------------------------------------

        // Private spawn (don't inject faction tag into SK custom data).
        bool _privateSpawns = false; 

        // list of friendly faction ids, steamids,
        // that can be used to open spawns.
        string _friendlyTags = "";

        // Doors -----------------------------------------------------------------

        // enable door management functionality
        bool _manageDoors = true;

        // door open timer (x100 ticks)
        int _doorCloseTimer = 3;

        // airlock door disable timer (x100 ticks)
        int _airlockDoorDisableTimer = 6; 

        // Keywords -----------------------------------------------------------------
        
        string _keywordIgnore = "[I]"; // for blocks to be ignored
        string _keywordRsmLcds = "[RSM]"; // for RSM LCDs
        string _keywordColourSyncLcds = "[CS]"; // for LCD colour sync
        string _keywordAuxBlocks = "Autorepair"; // for auxiliary blocks
        string _keywordDefPdcs = "Repel"; // for PDCs marked for permanent defence
        string _keywordThrustersMinimum = "Min"; // for epsteins enabled at min
        string _keywordThrustersDocking = "Docking"; // for epsteins enabled with RCS
        string _keywordLightNavigation = "Nav"; // for Nav lights
        string _keywordAirlock = "Airlock"; // for airlocks

        // todo
        // remove these, check the custom data or something isntead.
        string KEYWORD_PB_EFC = "[EFC]"; // for EFC PBs/LCDs
        string KEYWORD_PB_NAVOS = "[NavOS]"; // for NavOS PBs/LCDs

        // Init & Block Naming -----------------------------------------------------------------

        // single char delimiter for names
        char _nameDelimiter = '.';

        // append type names to all weapons during init.
        bool _appendWeaponTypes = true;

        // todo
        // implement!!
        // append type names to all drives during init.
        bool _appendDriveTypes = true;

        // blocks which will be enumerated at init.
        List<string> _enumerateTheseBlocks = new List<string>();

        // Misc -----------------------------------------------------------------

        // disable lighting all control.
        bool _disableLightingControl = false;

        // disable text colour control for all LCDs 
        bool _disableLcdColourControl = false;

        // show basic telemetry data on advanced thrust LCD
        bool _showBasicTelemetry = true;

        // thrust percentages to show on the Advanced Thrust LCD
        List<double> _decelPercentages = new List<double>();

        // Performance & Debugging -----------------------------------------------------------------

        // verbose debugging enabled
        bool _d = false;

        // performance profiling enabled
        bool _p = true;

        // ticks x100 to stall between runs
        int _loopStallCount = 0;

        //ticks x100 between block refreshes
        int _blockRefreshFreq = 100;

        // System -----------------------------------------------------------------

        string _shipName = "Untitled Ship";

        // Parse -----------------------------------------------------------------
        bool parseCustomData()
        {
            string toParse = Me.CustomData;

            // attempt to parse ini from the custom data
            MyIniParseResult result;
            if (!_config.TryParse(toParse, out result))
            {
                // failed to parse ini

                // check for legacy config.
                string[] legacyLines = toParse.Split('\n');
                if (legacyLines[1] == "Reedit Ship Management")
                {
                    Echo("Legacy config detected...");
                    parseLegacyCustomData(toParse);
                    return false;
                }
                else
                {
                    // yeah, nah...
                    // this is just unparsable...
                    Echo("Could not parse custom data!\n" + result.ToString());
                    return false;
                }
            }

            // Performance & Debugging -----------------------------------------------------------------

            _d = _config.Get("Debug", "VerboseDebugging").ToBoolean(_d);
            _p = _config.Get("Debug", "RuntimeProfiling").ToBoolean(_p);
            _blockRefreshFreq =  _config.Get("Debug", "BlockRefreshFreq").ToInt32(_blockRefreshFreq);
            _loopStallCount =  _config.Get("Debug", "StallCount").ToInt32(_loopStallCount);

            

            return true;
        }




        void setCustomData()
        {
            //_config.Clear();
            string sec, name;

            // Main -----------------------------------------------------------------

            sec = "Main";

            name = "RequireShipName";
            _config.Set(sec, name, _requireShipName);
            _config.SetComment(sec, name, "limit to blocks with the ship name in their name");

            name = "EnableAutoload";
            _config.Set(sec, name, _autoLoad);
            _config.SetComment(sec, name, "enable RSM loading & balancing functionality for weapons");

            name = "AutoloadReactors";
            _config.Set(sec, name, _autoLoadReactors);
            _config.SetComment(sec, name, "enable loading and balancing for reactors");

            name = "AutoConfigWeapons";
            _config.Set(sec, name, _autoConfigWeapons);
            _config.SetComment(sec, name, "automatically configure weapon on stance set");

            name = "SetTurretFireMode";
            _config.Set(sec, name, _setTurretFireMode);
            _config.SetComment(sec, name, "set turret fire mode based on stance");

            name = "ManageBatteryDischarge";
            _config.Set(sec, name, _manageBatteryDischarge);
            _config.SetComment(sec, name, "set batteries to discharge on active railgun/coilgun target");

            // Header -----------------------------------------------------------------
            // this is the bit at the top of the custom data

            _config.SetSectionComment(sec, " -------------------------\n Reedit Ship Management\n -------------------------\n\n Config.ini\n Recompile to apply changes!\n\n");

            // Spawns -----------------------------------------------------------------

            sec = "Spawns";

            name = "PrivateSpawns";
            _config.Set(sec, name, _privateSpawns);
            _config.SetComment(sec, name, "don't inject faction tag into spawn custom data");

            name = "Friendly Tags";
            _config.Set(sec, name, _friendlyTags);
            _config.SetComment(sec, name, "Comma seperated friendly factions or steam ids");

            // Doors -----------------------------------------------------------------

            sec = "Doors";

            name = "EnableDoorManagement";
            _config.Set(sec, name, _manageDoors);
            _config.SetComment(sec, name, "enable door management functionality");

            name = "DoorCloseTimer";
            _config.Set(sec, name, _doorCloseTimer);
            _config.SetComment(sec, name, "enable door management functionality");

            name = "AirlockDoorDisableTimer";
            _config.Set(sec, name, _airlockDoorDisableTimer);
            _config.SetComment(sec, name, "airlock door disable timer (x100 ticks)");

            // Keywords -----------------------------------------------------------------

            sec = "Keywords";

            name = "Ignore";
            _config.Set(sec, name, _keywordIgnore);
            _config.SetComment(sec, name, "to identify blocks which RSM should ignore");

            name = "RsmLcds";
            _config.Set(sec, name, _keywordRsmLcds);
            _config.SetComment(sec, name, "to identify RSM LCDs");

            name = "ColourSyncLcds";
            _config.Set(sec, name, _keywordColourSyncLcds);
            _config.SetComment(sec, name, "to identify non RSM LCDs for colour sync");

            name = "AuxiliaryBlocks";
            _config.Set(sec, name, _keywordAuxBlocks);
            _config.SetComment(sec, name, "to identify aux blocks");

            name = "DefensivePdcs";
            _config.Set(sec, name, _keywordDefPdcs);
            _config.SetComment(sec, name, "to identify defensive PDCs");

            name = "MinimumThrusters";
            _config.Set(sec, name, _keywordThrustersMinimum);
            _config.SetComment(sec, name, "to identify minimum epsteins");

            name = "DockingThrusters";
            _config.Set(sec, name, _keywordThrustersDocking);
            _config.SetComment(sec, name, "to identify docking epsteins");

            name = "NavLights";
            _config.Set(sec, name, _keywordLightNavigation);
            _config.SetComment(sec, name, "to identify navigational lights");

            name = "Airlock";
            _config.Set(sec, name, _keywordAirlock);
            _config.SetComment(sec, name, "to identify airlock doors and vents");

            // Init & Block Naming -----------------------------------------------------------------

            sec = "InitNaming";

            name = "NameDelimiter";
            _config.Set(sec, name, _nameDelimiter.ToString());
            _config.SetComment(sec, name, "single char delimiter for names");

            name = "NameWeaponTypes";
            _config.Set(sec, name, _appendWeaponTypes);
            _config.SetComment(sec, name, "append type names to all weapons on init");

            name = "NameDriveTypes";
            _config.Set(sec, name, _appendDriveTypes);
            _config.SetComment(sec, name, "append type names to all drives on init");

            string ForcedNames = "";

            foreach (string FName in _enumerateTheseBlocks)
            {
                if (ForcedNames != "") ForcedNames += ",";
                ForcedNames += FName;
            }

            name = "BlocksToNumber";
            _config.Set(sec, name, _appendDriveTypes);
            _config.SetComment(sec, name, "comma seperated list of block names to be numbered at init");

            // Misc -----------------------------------------------------------------

            sec = "Misc";

            name = "DisableLightingControl";
            _config.Set(sec, name, _disableLightingControl);
            _config.SetComment(sec, name, "disable all lighting control");

            name = "DisableLcdColourControl";
            _config.Set(sec, name, _disableLcdColourControl);
            _config.SetComment(sec, name, "disable text colour control for all LCDs");

            name = "ShowBasicTelemetry";
            _config.Set(sec, name, _showBasicTelemetry);
            _config.SetComment(sec, name, "show basic telemetry data on advanced thrust LCDs");

            string DecelPercents = "";

            foreach (double Percent in _decelPercentages)
            {
                if (DecelPercents != "") DecelPercents += ",";
                DecelPercents += (Percent * 100).ToString();
            }

            name = "DecelerationPercentages";
            _config.Set(sec, name, DecelPercents);
            _config.SetComment(sec, name, "thrust percentages to show on advanced thrust LCDs");

            // Performance & Debugging -----------------------------------------------------------------

            sec = "Debug";

            name = "VerboseDebugging";
            _config.Set(sec, name, _d);
            _config.SetComment(sec, name, "prints more logging info to PB details");

            name = "RuntimeProfiling";
            _config.Set(sec, name, _p);
            _config.SetComment(sec, name, "prints script runtime profiling info to PB details");

            name = "BlockRefreshFreq";
            _config.Set(sec, name, _blockRefreshFreq);
            _config.SetComment(sec, name, "ticks x100 between block refreshes");

            name = "StallCount";
            _config.Set(sec, name, _loopStallCount);
            _config.SetComment(sec, name, "ticks x100 to stall between runs");

            // System -----------------------------------------------------------------

            sec = "System";

            name = "VerboseDebugging";
            _config.Set(sec, name, _d);
            _config.SetComment(sec, name, "prints more logging info to PB details");

            foreach (ITEM item in ITEMS)
            {
                name = item.Type.SubtypeId;
                _config.Set(sec, name, item.InitQty);
            }

            _config.SetSectionComment(sec, "set automatically at init.");

            // Save it -----------------------------------------------------------------

            Me.CustomData = _config.ToString();
        }


        void parseLegacyCustomData(string toParse)
        {
            // if this is a legacy config
            // update defaults from that config
            // using the old parsing method...

            string[] sections = toParse.Split(
                new string[] { "[Stances]" },
                StringSplitOptions.None
                );
            string[] legacyVars = sections[0].Split('\n');
            string legacyStances = sections[1];

            for (int i = 1; i < legacyVars.Length; i++)
            {
                if (legacyVars[i].Contains("="))
                {
                    //string[] cleanup = parse_dat[i].Split('=');
                    string value = legacyVars[i].Substring(1);

                    // so if we contain an =, the item prior is my setting name.
                    switch (legacyVars[(i - 1)])
                    {
                        case "Ship name. Blocks without this name will be ignored":
                            _shipName = value;
                            break;

                        case "Block name delimiter, used by init. One character only!":
                            _nameDelimiter = char.Parse(value.Substring(0, 1));
                            break;

                        case "Keyword used to identify RSM LCDs.":
                            _keywordRsmLcds = value;
                            break;

                        case "Keyword used to identify autorepair systems":
                        case "Keyword used to identify auxiliary blocks":
                            _keywordAuxBlocks = value;
                            break;

                        case "Keyword used to identify defence PDCs.":
                            _keywordDefPdcs = value;
                            break;

                        case "Keyword used to identify minimum epstein drives.":
                            _keywordThrustersMinimum = value;
                            break;

                        case "Keyword used to identify docking epstein drives.":
                            _keywordThrustersDocking = value;
                            break;

                        case "Keyword to ignore block.":
                            _keywordIgnore = value;
                            break;

                        case "Automatically configure PDCs, Railguns, Torpedoes.":
                            _autoConfigWeapons = bool.Parse(value);
                            break;

                        case "Disable lighting all control.":
                            _disableLightingControl = bool.Parse(value);
                            break;
                        case "Disable LCD Text Colour Enforcement.":
                            _disableLcdColourControl = bool.Parse(value);
                            break;

                        case "Enable Weapon Autoload Functionality.":
                            _autoLoad = bool.Parse(value);
                            break;


                        case "Number these blocks at init.":
                            _enumerateTheseBlocks.Clear();
                            string[] FNames = value.Split(',');
                            foreach (string FName in FNames)
                            {
                                if (FName != "")
                                    _enumerateTheseBlocks.Add(FName);
                            }
                            break;

                        case "Add type names to weapons at init.":
                            _appendWeaponTypes = bool.Parse(value);
                            break;

                        case "Only set batteries to discharge on active railgun/coilgun target.":
                            _manageBatteryDischarge = bool.Parse(value);
                            break;


                        case "Show basic telemetry.":
                            _showBasicTelemetry = bool.Parse(value);
                            break;
                        case "Show Decel Percentages (comma seperated).":
                            _decelPercentages.Clear();
                            string[] Percents = value.Split(',');
                            foreach (string Percent in Percents)
                            {
                                _decelPercentages.Add(double.Parse(Percent) / 100);
                            }
                            break;



                        case "Fusion Fuel count":
                            ITEMS[0].InitQty = int.Parse(value);
                            break;

                        case "Fuel tank count":
                            ITEMS[1].InitQty = int.Parse(value);
                            break;

                        case "Jerry can count":
                            ITEMS[2].InitQty = int.Parse(value);
                            break;

                        case "40mm PDC Magazine count":
                            ITEMS[3].InitQty = int.Parse(value);
                            break;
                        case "40mm Teflon Tungsten PDC Magazine count":
                            ITEMS[4].InitQty = int.Parse(value);
                            break;

                        case "220mm Torpedo count":
                        case "Torpedo count":
                            ITEMS[5].InitQty = int.Parse(value);
                            break;

                        case "220mm MCRN torpedo count":
                            ITEMS[6].InitQty = int.Parse(value);
                            break;

                        case "220mm UNN torpedo count":
                            ITEMS[7].InitQty = int.Parse(value);
                            break;

                        case "Ramshackle torpedo count":
                        case "Ramshackle torpedo Count":
                            ITEMS[8].InitQty = int.Parse(value);
                            break;

                        case "Large ramshacke torpedo count":
                            ITEMS[9].InitQty = int.Parse(value);
                            break;

                        case "Zako 120mm Railgun rounds count":
                        case "Railgun rounds count":
                            ITEMS[10].InitQty = int.Parse(value);
                            break;

                        case "Dawson 100mm UNN Railgun rounds count":
                            ITEMS[11].InitQty = int.Parse(value);
                            break;

                        case "Stiletto 100mm MCRN Railgun rounds count":
                            ITEMS[12].InitQty = int.Parse(value);
                            break;

                        case "T-47 80mm Railgun rounds count":
                            ITEMS[13].InitQty = int.Parse(value);
                            break;

                        case "Foehammer 120mm MCRN rounds count":
                            ITEMS[14].InitQty = int.Parse(value);
                            break;

                        case "Farren 120mm UNN Railgun rounds count":
                            ITEMS[15].InitQty = int.Parse(value);
                            break;

                        case "Kess 180mm rounds count":
                            ITEMS[16].InitQty = int.Parse(value);
                            break;

                        case "Steel plate count":
                            ITEMS[17].InitQty = int.Parse(value);
                            break;

                        case "Doors open timer (x100 ticks, default 3)":
                            _doorCloseTimer = int.Parse(value);
                            break;

                        case "Airlock doors disabled timer (x100 ticks, default 6)":
                            _airlockDoorDisableTimer = int.Parse(value);
                            break;

                        case "Throttle script (x100 ticks pause between loops, default 0)":
                            _loopStallCount = int.Parse(value);
                            break;

                        case "Full refresh frequency (x100 ticks, default 50)":
                            _blockRefreshFreq = int.Parse(value);
                            break;

                        case "Verbose script debugging. Prints more logging info to PB details.":
                            _d = bool.Parse(value);
                            break;

                        case "Private spawn (don't inject faction tag into SK custom data).":
                            _privateSpawns = bool.Parse(value);
                            break;

                        case "Comma seperated friendly factions or steam ids for survival kits.":
                            _friendlyTags = string.Join("\n", value.Split(','));
                            break;

                        case "Current Stance":
                            STANCE = value;
                            break;

                        case "Reactor Integrity":
                            INIT_REACTORs = float.Parse(value);
                            break;
                        case "Battery Integrity":
                            INIT_BATTERIEs = float.Parse(value);
                            break;
                        case "PDC Integrity":
                            INIT_PDCs = int.Parse(value);
                            break;
                        case "Torpedo Integrity":
                            INIT_TORPs = int.Parse(value);
                            break;
                        case "Railgun Integrity":
                            INIT_RAILs = int.Parse(value);
                            break;
                        case "H2 Tank Integrity":
                            INIT_H2 = double.Parse(value);
                            break;
                        case "O2 Tank Integrity":
                            INIT_O2 = double.Parse(value);
                            break;
                        case "Epstein Integrity":
                            INIT_THRUSTERs_MAIN = float.Parse(value);
                            break;
                        case "RCS Integrity":
                            INIT_THRUSTERs_RCS = float.Parse(value);
                            break;
                        case "Gyro Integrity":
                            INIT_GYROs = int.Parse(value);
                            break;
                        case "Cargo Integrity":
                            INIT_CARGOs = double.Parse(value);
                            break;
                        case "Welder Integrity":
                            INIT_WELDERs = int.Parse(value);
                            break;

                    }
                }
            }
        }

        void updateCustomData(bool dontParse)
        {

            parseCustomData();
            setCustomData();

            return;

            // this function updates some of the variables from custom data of the prog block
            // first attempt to parse custom data.
            // if it works, update vars.
            // If it fails, reset from current vars.

            bool parsedVars = false;
            bool parsedStances = false;

            if (_d) Echo("updateCustomData(dontParse = " + dontParse + ");\n");

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
                    if (_d) Echo("Custom Data Error! Custom data invalid or blank.");
                }

                // so now we attempt to parse the variables part.
                try
                {

                    string[] parse_dat = varSection.Split('\n');
                    int config_count = 0;

                    for (int i = 1; i < parse_dat.Length; i++)
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
                                    _shipName = value;

                                    break;
                                case "Block name delimiter, used by init. One character only!":

                                    config_count++;
                                    _nameDelimiter = char.Parse(value.Substring(0, 1));

                                    if (_d) Echo("DELIMITER = " + _nameDelimiter);

                                    break;
                                case "Keyword used to identify RSM LCDs.":
                                    config_count++;
                                    _keywordRsmLcds = value;

                                    break;
                                case "Keyword used to identify autorepair systems":
                                case "Keyword used to identify auxiliary blocks":
                                    config_count++;
                                    _keywordAuxBlocks = value;

                                    break;
                                case "Keyword used to identify defence PDCs.":
                                    config_count++;
                                    _keywordDefPdcs = value;

                                    break;
                                case "Keyword used to identify minimum epstein drives.":
                                    config_count++;
                                    _keywordThrustersMinimum = value;
                                    break;
                                case "Keyword used to identify docking epstein drives.":
                                    config_count++;
                                    _keywordThrustersDocking = value;
                                    break;
                                case "Keyword to ignore block.":
                                    config_count++;
                                    _keywordIgnore = value;
                                    break;
                                case "Automatically configure PDCs, Railguns, Torpedoes.":
                                    config_count++;
                                    _autoConfigWeapons = bool.Parse(value);
                                    break;

                                case "Disable lighting all control.":
                                    config_count++;
                                    _disableLightingControl = bool.Parse(value);
                                    break;
                                case "Disable LCD Text Colour Enforcement.":
                                    config_count++;
                                    _disableLcdColourControl = bool.Parse(value);
                                    break;

                                case "Enable Weapon Autoload Functionality.":
                                    config_count++;
                                    _autoLoad = bool.Parse(value);
                                    break;


                                case "Number these blocks at init.":
                                    config_count++;
                                    _enumerateTheseBlocks.Clear();
                                    string[] FNames = value.Split(',');
                                    foreach (string FName in FNames)
                                    {
                                        if (FName != "")
                                            _enumerateTheseBlocks.Add(FName);
                                    }
                                    break;

                                case "Add type names to weapons at init.":
                                    config_count++;
                                    _appendWeaponTypes = bool.Parse(value);
                                    break;

                                case "Only set batteries to discharge on active railgun/coilgun target.":
                                    config_count++;
                                    _manageBatteryDischarge = bool.Parse(value);
                                    break;


                                case "Show basic telemetry.":
                                    config_count++;
                                    _showBasicTelemetry = bool.Parse(value);
                                    break;
                                case "Show Decel Percentages (comma seperated).":
                                    config_count++;
                                    _decelPercentages.Clear();
                                    string[] Percents = value.Split(',');
                                    foreach (string Percent in Percents)
                                    {
                                        _decelPercentages.Add(double.Parse(Percent) / 100);
                                    }
                                    break;



                                case "Fusion Fuel count":
                                    config_count++;
                                    ITEMS[0].InitQty = int.Parse(value);
                                    break;

                                case "Fuel tank count":
                                    config_count++;
                                    ITEMS[1].InitQty = int.Parse(value);
                                    break;

                                case "Jerry can count":
                                    config_count++;
                                    ITEMS[2].InitQty = int.Parse(value);
                                    break;

                                case "40mm PDC Magazine count":
                                    config_count++;
                                    ITEMS[3].InitQty = int.Parse(value);
                                    break;
                                case "40mm Teflon Tungsten PDC Magazine count":
                                    config_count++;
                                    ITEMS[4].InitQty = int.Parse(value);
                                    break;

                                case "220mm Torpedo count":
                                // was like this in versions prior to 0.5.0
                                case "Torpedo count":
                                    config_count++;
                                    ITEMS[5].InitQty = int.Parse(value);
                                    break;

                                case "220mm MCRN torpedo count":
                                    config_count++;
                                    ITEMS[6].InitQty = int.Parse(value);
                                    break;

                                case "220mm UNN torpedo count":
                                    config_count++;
                                    ITEMS[7].InitQty = int.Parse(value);
                                    break;

                                case "Ramshackle torpedo count":
                                // was like this in versions prior to 0.4.0
                                case "Ramshackle torpedo Count":
                                    config_count++;
                                    ITEMS[8].InitQty = int.Parse(value);
                                    break;

                                case "Large ramshacke torpedo count":
                                    config_count++;
                                    ITEMS[9].InitQty = int.Parse(value);
                                    break;

                                case "Zako 120mm Railgun rounds count":
                                // was like this in versions prior to 0.5.0
                                case "Railgun rounds count":
                                    config_count++;
                                    ITEMS[10].InitQty = int.Parse(value);
                                    break;

                                case "Dawson 100mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[11].InitQty = int.Parse(value);
                                    break;

                                case "Stiletto 100mm MCRN Railgun rounds count":
                                    config_count++;
                                    ITEMS[12].InitQty = int.Parse(value);
                                    break;

                                case "T-47 80mm Railgun rounds count":
                                    config_count++;
                                    ITEMS[13].InitQty = int.Parse(value);
                                    break;

                                case "Foehammer 120mm MCRN rounds count":
                                    config_count++;
                                    ITEMS[14].InitQty = int.Parse(value);
                                    break;

                                case "Farren 120mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[15].InitQty = int.Parse(value);
                                    break;


                                case "Kess 180mm rounds count":
                                    config_count++;
                                    ITEMS[16].InitQty = int.Parse(value);
                                    break;

                                case "Steel plate count":
                                    config_count++;
                                    ITEMS[17].InitQty = int.Parse(value);
                                    break;


                                case "Doors open timer (x100 ticks, default 3)":
                                    config_count++;
                                    _doorCloseTimer = int.Parse(value);
                                    break;
                                case "Airlock doors disabled timer (x100 ticks, default 6)":
                                    config_count++;
                                    _airlockDoorDisableTimer = int.Parse(value);
                                    break;
                                case "Throttle script (x100 ticks pause between loops, default 0)":
                                    config_count++;
                                    _loopStallCount = int.Parse(value);
                                    break;
                                case "Full refresh frequency (x100 ticks, default 50)":
                                    config_count++;
                                    _blockRefreshFreq = int.Parse(value);
                                    break;
                                case "Verbose script debugging. Prints more logging info to PB details.":
                                    config_count++;
                                    _d = bool.Parse(value);
                                    break;


                                case "Private spawn (don't inject faction tag into SK custom data).":
                                    config_count++;
                                    _privateSpawns = bool.Parse(value);
                                    break;


                                case "Comma seperated friendly factions or steam ids for survival kits.":
                                    config_count++;
                                    _friendlyTags = string.Join("\n", value.Split(','));
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

                if (_privateSpawns)
                {
                    if (SPAWN_OPEN)
                        SK_DATA = _friendlyTags;
                    else
                        SK_DATA = "";

                }
                else
                {
                    SK_DATA = "                                                                                                                                 " +
                        FACTION_TAG;

                    if (SPAWN_OPEN)
                        SK_DATA += "\n" + _friendlyTags;

                    SK_DATA += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                         FACTION_TAG;
                }



                // alright so now we try to parse stance data
                try
                {
                    string[] stances = stanceSection.Split(new string[] { "Stance:" }, StringSplitOptions.None);

                    if (_d) Echo("Parsing " + (stances.Length - 1) + " stances");

                    int data_length = STANCES[0].Length;

                    List<string> new_name_list = new List<string>();
                    List<int[]> new_data_list = new List<int[]>();

                    for (int i = 1; i < stances.Length; i++)
                    {
                        string[] stance_vars = stances[i].Split('=');

                        string new_name = "";
                        int[] new_data = new int[data_length];

                        new_name = stance_vars[0].Split(' ')[0];
                        if (_d) Echo("Parsing '" + new_name + "'");
                        for (int j = 0; j < new_data.Length; j++)
                        {
                            string[] cleanup = stance_vars[(j + 1)].Split('\n');
                            new_data[j] = int.Parse(cleanup[0]);
                            //if (_d) Echo(new_data[j].ToString());
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
                        if (_d) Echo("Finished parsing " + STANCE_NAMES.Count + " stances.");

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

            if (STANCE_NAMES.Count < 1 && _d)
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

            foreach (double Percent in _decelPercentages)
            {
                if (DecelPercents != "") DecelPercents += ",";
                DecelPercents += (Percent * 100).ToString();
            }

            string ForcedNames = "";

            foreach (string FName in _enumerateTheseBlocks)
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
                + "Block name delimiter, used by init. One character only!\n=" + _nameDelimiter + "\n"
                + "Keyword used to identify RSM LCDs.\n=" + _keywordRsmLcds + "\n"
                + "Keyword used to identify auxiliary blocks\n=" + _keywordAuxBlocks + "\n"
                + "Keyword used to identify minimum epstein drives.\n=" + _keywordThrustersMinimum + "\n"
                + "Keyword used to identify docking epstein drives.\n=" + _keywordThrustersDocking + "\n"
                + "Keyword used to identify defence PDCs.\n=" + _keywordDefPdcs + "\n"
                + "Keyword to ignore block.\n=" + _keywordIgnore + "\n"
                + "Enable Weapon Autoload Functionality.\n=" + _autoLoad + "\n"
                + "Automatically configure PDCs, Railguns, Torpedoes.\n=" + _autoConfigWeapons + "\n"
                + "Disable lighting all control.\n=" + _disableLightingControl + "\n"
                + "Disable LCD Text Colour Enforcement.\n=" + _disableLcdColourControl + "\n"
                + "Private spawn (don't inject faction tag into SK custom data).\n=" + _privateSpawns + "\n"
                + "Comma seperated friendly factions or steam ids for survival kits.\n=" + (string.Join(",", _friendlyTags.Split('\n'))) + "\n"
                + "Number these blocks at init.\n=" + ForcedNames + "\n"
                + "Add type names to weapons at init.\n=" + _appendWeaponTypes + "\n"
                + "Only set batteries to discharge on active railgun/coilgun target.\n=" + _manageBatteryDischarge + "\n"

                + "\n---- [Door Timers] ----\n"
                + "Doors open timer (x100 ticks, default 3)\n=" + _doorCloseTimer + "\n"
                + "Airlock doors disabled timer (x100 ticks, default 6)\n=" + _airlockDoorDisableTimer + "\n"

                + "\n---- [Advanced Thrust LCD] ----\n"
                + "Show basic telemetry.\n=" + _showBasicTelemetry + "\n"
                + "Show Decel Percentages (comma seperated).\n=" + DecelPercents + "\n"

                + "\n---- [Performance & Debugging] ----\n"
                + "Throttle script (x100 ticks pause between loops, default 0)\n=" + _loopStallCount + "\n"
                + "Full refresh frequency (x100 ticks, default 50)\n=" + _blockRefreshFreq + "\n"
                + "Verbose script debugging. Prints more logging info to PB details.\n=" + _d + "\n"

                + "\n---- [System] ----\n"
                + "You can edit these if you want...\nbut they are usually populated by the script and saved here.\n"
                + "Ship name. Blocks without this name will be ignored\n=" + _shipName + "\n"
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
                + "Fusion Fuel count\n=" + ITEMS[0].InitQty + "\n"

                + "Fuel tank count\n=" + ITEMS[1].InitQty + "\n"
                + "Jerry can count\n=" + ITEMS[2].InitQty + "\n"

                + "40mm PDC Magazine count\n=" + ITEMS[3].InitQty + "\n"
                + "40mm Teflon Tungsten PDC Magazine count\n=" + ITEMS[4].InitQty + "\n"

                + "220mm Torpedo count\n=" + ITEMS[5].InitQty + "\n"
                + "220mm MCRN torpedo count\n=" + ITEMS[6].InitQty + "\n"
                + "220mm UNN torpedo count\n=" + ITEMS[7].InitQty + "\n"

                + "Ramshackle torpedo count\n=" + ITEMS[8].InitQty + "\n"
                + "Large ramshacke torpedo count\n=" + ITEMS[9].InitQty + "\n"

                + "Zako 120mm Railgun rounds count\n=" + ITEMS[10].InitQty + "\n"
                + "Dawson 100mm UNN Railgun rounds count\n=" + ITEMS[11].InitQty + "\n"
                + "Stiletto 100mm MCRN Railgun rounds count\n=" + ITEMS[12].InitQty + "\n"
                + "T-47 80mm Railgun rounds count\n=" + ITEMS[13].InitQty + "\n"

                + "Foehammer 120mm MCRN rounds count\n=" + ITEMS[14].InitQty + "\n"
                + "Farren 120mm UNN Railgun rounds count\n=" + ITEMS[15].InitQty + "\n"


                + "Kess 180mm rounds count\n=" + ITEMS[16].InitQty + "\n"
                + "Steel plate count\n=" + ITEMS[17].InitQty + "\n"

                + "\n---- [Stances] ----\n"
                + stance_text

                + "-------------------------\n\n\n\n\n";

            return;


        }




    }
}
