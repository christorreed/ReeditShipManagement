using Sandbox.Engine.Utils;
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
            
            string div = " -------------------------\n";

            // this is the bit at the top of the custom data
            _config.SetSectionComment(sec, 
                div + 
                " Reedit Ship Management\n" + 
                div + 
                " Config.ini\n Recompile to apply changes!\n" + div );
            
            // Spawns -----------------------------------------------------------------

            sec = "Spawns";

            name = "PrivateSpawns";
            _config.Set(sec, name, _privateSpawns);
            _config.SetComment(sec, name, "don't inject faction tag into spawn custom data");

            name = "FriendlyTags";
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

            // Stances -----------------------------------------------------------------

            sec = "Stance";

            name = "CurrentStance";
            _config.Set(sec, name, _currentStance);

            _config.SetSectionComment(sec, div + " Stances\n Add or remove as required\n" + div);

            for (int i = 0; i < _stanceNames.Count; i++)
            {
                sec = "Stance." + _stanceNames[i];

                _config.Set(sec, "Torps",                   _stances[i][0]);
                _config.Set(sec, "Pdcs",                    _stances[i][1]);
                _config.Set(sec, "Kinetics",                _stances[i][2]);
                _config.Set(sec, "MainThrust",              _stances[i][3]);
                _config.Set(sec, "ManeuveringThrust",       _stances[i][4]);
                _config.Set(sec, "Spotlights",              _stances[i][5]);
                _config.Set(sec, "ExteriorLights",          _stances[i][6]);
                _config.Set(sec, "ExteriorColour",          _stances[i][7] + "," + 
                                                            _stances[i][8] + "," + 
                                                            _stances[i][9] + "," + 
                                                            _stances[i][10]);
                _config.Set(sec, "InteriorLights",          _stances[i][11]);
                _config.Set(sec, "InteriorAndLcdColour",    _stances[i][12] + "," + 
                                                            _stances[i][13] + "," +
                                                            _stances[i][14] + "," + 
                                                            _stances[i][15]);
                _config.Set(sec, "StockpileAndRecharge",    _stances[i][16]);
                _config.Set(sec, "EfcBoost",                _stances[i][17]);
                _config.Set(sec, "NavOsBurnPercent",        _stances[i][18]);
                _config.Set(sec, "NavOsAbort",              _stances[i][19]);
                _config.Set(sec, "AuxiliaryBlocks",         _stances[i][20]);
                _config.Set(sec, "Extractor",               _stances[i][21]);
                _config.Set(sec, "KeepAlives",              _stances[i][20]);
                _config.Set(sec, "HangarDoors",             _stances[i][21]);

                // comment the first stance only.
                if (i == 0)
                {
                    _config.SetComment(sec, "Torps",                    "torpedoes; 0: off, 1: on;");
                    _config.SetComment(sec, "Pdcs",                     "pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only");
                    _config.SetComment(sec, "Kinetics",                 "railguns etc; 0: off, 1: hold fire, 2: AI weapons free;");
                    _config.SetComment(sec, "MainThrust",               "main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change");
                    _config.SetComment(sec, "ManeuveringThrust",        "maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change");
                    _config.SetComment(sec, "Spotlights",               "spotlights; 0: off, 1: on, 2: on max radius");
                    _config.SetComment(sec, "ExteriorLights",           "exterior lights; 0: off, 1: on");
                    _config.SetComment(sec, "ExteriorColour",           "colour for exterior lights");
                    _config.SetComment(sec, "InteriorLights",           "interior lights lights; 0: off, 1: on");
                    _config.SetComment(sec, "InteriorAndLcdColour",     "colour for interior lights, LCD text");
                    _config.SetComment(sec, "StockpileAndRecharge",     "stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts");
                    _config.SetComment(sec, "EfcBoost",                 "EFC boost; 0: off, 1: on");
                    _config.SetComment(sec, "NavOsBurnPercent",         "EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%");
                    _config.SetComment(sec, "NavOsAbort",               "EFC kill; 0: no change, 1: run 'Off' on EFC");
                    _config.SetComment(sec, "AuxiliaryBlocks",          "auxiliary blocks; 0: off, 1: on");
                    _config.SetComment(sec, "Extractor",                "extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.");
                    _config.SetComment(sec, "KeepAlives",               "keep-alives for connectors, tanks, batteries, gyros, lcds, reactors; 0: ignore, 1: force on, 2: force off");
                    _config.SetComment(sec, "HangarDoors",              "hangar doors; 0: closed, 1: open, 2: no change");
                }
            }

            // System -----------------------------------------------------------------

            sec = "System";

            name = "ShipName";
            _config.Set(sec, name, _shipName);

            _config.SetSectionComment(sec, div + " System\n All items below this point are\n set automatically when running init\n" + div);

            // InitItems -----------------------------------------------------------------

            sec = "InitItems";

            foreach (ITEM item in ITEMS)
            {
                name = item.Type.SubtypeId;
                _config.Set(sec, name, item.InitQty);
            }

            //_config.SetSectionComment(sec, "set automatically at init.");

            // InitSubSystems -----------------------------------------------------------------

            sec = "InitSubSystems";

            _config.Set(sec, "Reactors", _initReactors);
            _config.Set(sec, "Batteries", _initReactors);
            _config.Set(sec, "PDCs", _initPdcs);
            _config.Set(sec, "TorpLaunchers", _initTorpLaunchers);
            _config.Set(sec, "KineticWeapons", _initKinetics);
            _config.Set(sec, "H2Storage", _initH2);
            _config.Set(sec, "O2Storage", _initO2);
            _config.Set(sec, "MainThrust", _initThrustMain);
            _config.Set(sec, "RCSThrust", _initThrustRCS);
            _config.Set(sec, "Gyros", _initGyros);
            _config.Set(sec, "CargoStorage", _initCargos);
            _config.Set(sec, "Welders", _initWelders);

            //_config.SetSectionComment(sec, "set automatically at init.");

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

            try
            {
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
                                _currentStance = value;
                                break;

                            case "Reactor Integrity":
                                _initReactors = float.Parse(value);
                                break;
                            case "Battery Integrity":
                                _initBatteries = float.Parse(value);
                                break;
                            case "PDC Integrity":
                                _initPdcs = int.Parse(value);
                                break;
                            case "Torpedo Integrity":
                                _initTorpLaunchers = int.Parse(value);
                                break;
                            case "Railgun Integrity":
                                _initKinetics = int.Parse(value);
                                break;
                            case "H2 Tank Integrity":
                                _initH2 = double.Parse(value);
                                break;
                            case "O2 Tank Integrity":
                                _initO2 = double.Parse(value);
                                break;
                            case "Epstein Integrity":
                                _initThrustMain = float.Parse(value);
                                break;
                            case "RCS Integrity":
                                _initThrustRCS = float.Parse(value);
                                break;
                            case "Gyro Integrity":
                                _initGyros = int.Parse(value);
                                break;
                            case "Cargo Integrity":
                                _initCargos = double.Parse(value);
                                break;
                            case "Welder Integrity":
                                _initWelders = int.Parse(value);
                                break;

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Echo("Custom Data Error (vars)\n" + ex.Message);
            }

            // alright so now we try to parse stance data
            try
            {
                string[] stances = legacyStances.Split(new string[] { "Stance:" }, StringSplitOptions.None);

                if (_d) Echo("Parsing " + (stances.Length - 1) + " stances");

                int data_length = _stances[0].Length;

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
                    _stanceNames = new_name_list;
                    _stances = new_data_list;
                    //parsedStances = true;
                    if (_d) Echo("Finished parsing " + _stanceNames.Count + " stances.");

                    // update the S value as well so lights and colours aren't effected.
                    for (int j = 0; j < _stanceNames.Count; j++)
                    {
                        if (_currentStance == _stanceNames[j]) S = j;
                    }
                }
                else
                {
                    Echo("Didn't find any stances!");
                }
            }
            catch (Exception ex)
            {
                Echo("Custom Data Error (stances)\n" + ex.Message);
            }
        }

        void prepCustomData()
        {

            bool success = parseCustomData();
            if (!success)
            {
                ALERTS.Add(new ALERT(
                    "RESET CUSTOM DATA!",
                    "Something went wrong, so custom data was reset."
                    , 3
                    ));

                setCustomData();
            }

            // prep spawn data
            string start = "";
            string end = "";

            if (!_privateSpawns)
            {
                start = " ".PadRight(129, ' ') + _factionTag + "\n";
                end = "\n".PadRight(19, '\n');
            }

            _survivalKitData = start + end;
            _survivalKitOpenData = start + _friendlyTags + end; ;
        }
    }
}
