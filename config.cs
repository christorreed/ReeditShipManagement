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
        bool _requireShipName = false;

        // Enable Autoload Functionality.
        bool _autoLoad = true;

        // Enable autoload functionality for reactors.
        bool _autoLoadReactors = true; 

        // Automatically configure _normalPdcs, Railguns, Torpedoes.
        bool _autoConfigWeapons = true;

        // set turret fire mode based on stance
        bool _setTurretFireMode = true;

        // Only set batteries to discharge on active railgun/coilgun target.
        //bool _manageBatteryDischarge = true; 

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
        string _keywordRsmLcds = "[RSM]"; // for RSM _allLcds
        string _keywordColourSyncLcds = "[CS]"; // for LCD colour sync
        string _keywordAuxBlocks = "Autorepair"; // for auxiliary blocks
        string _keywordDefPdcs = "Repel"; // for _normalPdcs marked for permanent defence
        string _keywordThrustersMinimum = "Min"; // for epsteins enabled at min
        string _keywordThrustersDocking = "Docking"; // for epsteins enabled with RCS
        string _keywordLightNavigation = "Nav"; // for Nav lights
        string _keywordAirlock = "Airlock"; // for airlocks

        string _keywordLcdEfc = "[EFC]"; // for EFC PBs/_allLcds
        string _keywordLcdNavOs = "[NavOS]"; // for NavOS PBs/_allLcds

        // Init & Block Naming -----------------------------------------------------------------

        // single char delimiter for names
        char _nameDelimiter = '.';

        // append type names to all weapons during init.
        bool _appendWeaponTypes = true;

        // append type names to all drives during init.
        bool _appendDriveTypes = true;

        // blocks which will be enumerated at init.
        List<string> _enumerateTheseBlocks = new List<string>();

        // Misc -----------------------------------------------------------------

        // disable lighting all control.
        bool _disableLightingControl = false;

        // disable text colour control for all _allLcds 
        bool _disableLcdColourControl = false;

        // show basic telemetry data on advanced thrust LCD
        bool _showBasicTelemetry = true;

        // thrust percentages to show on the Advanced Thrust LCD
        List<double> _decelPercentages = new List<double>();

        // use m/s^2 rather than G's for thrust values.
        bool _isWeirdAboutThrustLikeGerm = false;

        // how much should we fill reactors? (3% wiggle room)
        double _reactorFillRatio = 0.5;

        // Performance & Debugging -----------------------------------------------------------------

        // verbose debugging enabled
        bool _d = true;

        // performance profiling enabled
        bool _p = false;

        // ticks x100 to stall between runs
        int _loopStallCount = 0;

        //ticks x100 between block refreshes
        int _blockRefreshFreq = 100;

        // System -----------------------------------------------------------------

        string _shipName = "";

        // Parse -----------------------------------------------------------------
        bool parseCustomData()
        {
            string toParse = Me.CustomData;

            string sec = "";
            bool success = true;

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

            try
            {
                // Main -----------------------------------------------------------------

                sec = "RSM.Main"; Echo(sec);

                _requireShipName = _config.Get(sec, "RequireShipName").ToBoolean(_requireShipName);
                _autoLoad = _config.Get(sec, "EnableAutoload").ToBoolean(_autoLoad);
                _autoLoadReactors = _config.Get(sec, "AutoloadReactors").ToBoolean(_autoLoadReactors);
                _autoConfigWeapons = _config.Get(sec, "AutoConfigWeapons").ToBoolean(_autoConfigWeapons);
                _setTurretFireMode = _config.Get(sec, "SetTurretFireMode").ToBoolean(_setTurretFireMode);
                
                // Spawns -----------------------------------------------------------------

                sec = "RSM.Spawns"; Echo(sec);

                _privateSpawns = _config.Get(sec, "PrivateSpawns").ToBoolean(_privateSpawns);
                _friendlyTags = _config.Get(sec, "FriendlyTags").ToString(_friendlyTags);

                // Doors -----------------------------------------------------------------

                sec = "RSM.Doors"; Echo(sec);

                _manageDoors = _config.Get(sec, "EnableDoorManagement").ToBoolean(_manageDoors);
                _doorCloseTimer = _config.Get(sec, "DoorCloseTimer").ToInt32(_doorCloseTimer);
                _doorCloseTimer = _config.Get(sec, "AirlockDoorDisableTimer").ToInt32(_doorCloseTimer);

                // Keywords -----------------------------------------------------------------

                sec = "RSM.Keywords"; Echo(sec);

                _keywordIgnore = _config.Get(sec, "Ignore").ToString(_keywordIgnore);
                _keywordRsmLcds = _config.Get(sec, "RsmLcds").ToString(_keywordRsmLcds);
                _keywordColourSyncLcds = _config.Get(sec, "ColourSyncLcds").ToString(_keywordColourSyncLcds);
                _keywordAuxBlocks = _config.Get(sec, "AuxiliaryBlocks").ToString(_keywordAuxBlocks);
                _keywordDefPdcs = _config.Get(sec, "DefensivePdcs").ToString(_keywordDefPdcs);
                _keywordThrustersMinimum = _config.Get(sec, "MinimumThrusters").ToString(_keywordThrustersMinimum);
                _keywordThrustersDocking = _config.Get(sec, "DockingThrusters").ToString(_keywordThrustersDocking);
                _keywordLightNavigation = _config.Get(sec, "NavLights").ToString(_keywordLightNavigation);
                _keywordAirlock = _config.Get(sec, "Airlock").ToString(_keywordAirlock);

                // Init & Block Naming -----------------------------------------------------------------

                sec = "RSM.InitNaming"; Echo(sec);

                string delim = _config.Get(sec, "NameDelimiter").ToString(_nameDelimiter.ToString());
                int parseCharAt = 0;
                if (delim.Length > 1) parseCharAt = 1;
                _nameDelimiter = char.Parse(delim.Substring(parseCharAt, 1));

                _appendWeaponTypes = _config.Get(sec, "NameWeaponTypes").ToBoolean(_appendWeaponTypes);
                _appendDriveTypes = _config.Get(sec, "NameDriveTypes").ToBoolean(_appendDriveTypes);

                string names = _config.Get(sec, "BlocksToNumber").ToString("");
                string[] namesArr = names.Split(',');
                _enumerateTheseBlocks.Clear();
                foreach (string name in namesArr)
                    if (name != "") _enumerateTheseBlocks.Add(name);

                // Misc -----------------------------------------------------------------

                sec = "RSM.Misc"; Echo(sec);

                _disableLightingControl = _config.Get(sec, "DisableLightingControl").ToBoolean(_disableLightingControl);
                _disableLcdColourControl = _config.Get(sec, "DisableLcdColourControl").ToBoolean(_disableLcdColourControl);
                _showBasicTelemetry = _config.Get(sec, "ShowBasicTelemetry").ToBoolean(_showBasicTelemetry);

                string percs = _config.Get(sec, "DecelerationPercentages").ToString("");
                string[] percsArr = percs.Split(',');
                if (percsArr.Length > 1)
                {
                    _decelPercentages.Clear();
                    foreach (string perc in percsArr)
                    {
                        _decelPercentages.Add(double.Parse(perc) / 100);
                    }
                }

                _isWeirdAboutThrustLikeGerm = _config.Get(sec, "ShowThrustInMetric").ToBoolean(_isWeirdAboutThrustLikeGerm);
                _reactorFillRatio = _config.Get(sec, "ReactorFillRatio").ToDouble(_reactorFillRatio);
                _items[0].MaxFillRatio = _reactorFillRatio;

                // Performance & Debugging -----------------------------------------------------------------

                sec = "RSM.Debug"; Echo(sec);

                _d = _config.Get(sec, "VerboseDebugging").ToBoolean(_d);
                _p = _config.Get(sec, "RuntimeProfiling").ToBoolean(_p);
                _blockRefreshFreq = _config.Get(sec, "BlockRefreshFreq").ToInt32(_blockRefreshFreq);
                _loopStallCount = _config.Get(sec, "StallCount").ToInt32(_loopStallCount);

                // System -----------------------------------------------------------------

                sec = "RSM.System"; Echo(sec);

                _shipName = _config.Get(sec, "ShipName").ToString(_shipName);

                // InitItems -----------------------------------------------------------------

                sec = "RSM.InitItems"; Echo(sec);

                foreach (Item item in _items)
                {
                    item.InitQty = _config
                        .Get(sec, item.Type.SubtypeId)
                        .ToInt32(item.InitQty);
                }

                // InitSubSystems -----------------------------------------------------------------

                sec = "RSM.InitSubSystems"; Echo(sec);

                _initReactors = _config.Get(sec, "Reactors").ToDouble(_initReactors);
                _initReactors = _config.Get(sec, "Batteries").ToDouble(_initBatteries);
                _initPdcs = _config.Get(sec, "Pdcs").ToInt32(_initPdcs);
                _initTorpLaunchers = _config.Get(sec, "TorpLaunchers").ToInt32(_initTorpLaunchers);
                _initKinetics = _config.Get(sec, "KineticWeapons").ToInt32(_initKinetics);
                _initH2 = _config.Get(sec, "H2Storage").ToDouble(_initH2);
                _initO2 = _config.Get(sec, "O2Storage").ToDouble(_initO2);
                _initThrustMain = _config.Get(sec, "MainThrust").ToSingle(_initThrustMain);
                _initThrustRCS = _config.Get(sec, "RCSThrust").ToSingle(_initThrustRCS);
                _initGyros = _config.Get(sec, "Gyros").ToDouble(_initGyros);
                _initCargos = _config.Get(sec, "CargoStorage").ToDouble(_initCargos);
                _initWelders = _config.Get(sec, "Welders").ToInt32(_initWelders);
            }
            catch (Exception ex)
            {
                throwConfigParsingError (ex, "Failed to parse section\n" +sec);
            }

            // Stances -----------------------------------------------------------------

            Echo("Parsing stances...");

            Dictionary<string, Stance> newStances = new Dictionary<string, Stance>();

            // get all sections
            List<string> sections = new List<string>();
            _config.GetSections(sections);

            // iterate all sections
            foreach (string sect in sections)
            {
                // ignore sections which are not stances
                if (sect.Contains("RSM.Stance."))
                {
                    // get the stance name
                    string newName = sect.Substring(11);
                    Echo(newName);

                    Stance newStance = new Stance();

                    // strings used for parsing
                    string working, key = "";

                    // used for parsing colours
                    string[] c;
                    int r = 33, g = 144, b = 255, a = 255;

                    bool inherits = false;
                    Stance inheritee = null;

                    // check for an Inherits value first...
                    key = "Inherits";

                    if (_config.ContainsKey(sect, key))
                    {
                        // we have an inheriter.
                        inherits = true;
                        try
                        {
                            inheritee = newStances[_config.Get(sect, key).ToString()];
                            Echo("Inherits " + _config.Get(sect, key).ToString());
                        }
                        catch (Exception ex)
                        {
                            throwConfigParsingError(ex, "Failed to find inheritee for\n" + sect + "\nEnsure inheritee stances are\nlisted before their heirs");
                        }
                    }

                    try
                    {
                        // now we parse out all of the properties of this stance...

                        if (inherits) Echo(inheritee.TorpedoMode.ToString());

                        key = "Torps";
                        if (_config.ContainsKey(sect, key))
                        {
                            newStance.TorpedoMode =
                                (ToggleModes)Enum.Parse(typeof(ToggleModes), _config.Get(sect, key).ToString());
                            Echo("1");
                        }
                        else if (inherits)
                        {
                            newStance.TorpedoMode = inheritee.TorpedoMode;
                            Echo("2");
                        }
                        else
                        {
                            newStance.TorpedoMode = _defaultTorpedoMode;
                            Echo("3");
                        }


                        key = "Pdcs";
                        if (_config.ContainsKey(sect, key))
                            newStance.PdcMode =
                                (PdcModes)Enum.Parse(typeof(PdcModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.PdcMode = inheritee.PdcMode;
                        else
                            newStance.PdcMode = _defaultPdcMode;

                        key = "Kinetics";
                        if (_config.ContainsKey(sect, key))
                            newStance.RailgunMode =
                                (RailgunModes)Enum.Parse(typeof(RailgunModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.RailgunMode = inheritee.RailgunMode;
                        else
                            newStance.RailgunMode = _defaultRailgunMode;

                        key = "MainThrust";
                        if (_config.ContainsKey(sect, key))
                            newStance.MainDriveMode =
                                (MainDriveModes)Enum.Parse(typeof(MainDriveModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.MainDriveMode = inheritee.MainDriveMode;
                        else
                            newStance.MainDriveMode = _defaultMainDriveMode;

                        key = "ManeuveringThrust";
                        if (_config.ContainsKey(sect, key))
                            newStance.ManeuveringThrusterMode =
                                (ManeuveringThrusterModes)Enum.Parse(typeof(ManeuveringThrusterModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.ManeuveringThrusterMode = inheritee.ManeuveringThrusterMode;
                        else
                            newStance.ManeuveringThrusterMode = _defaultManeuveringThrusterMode;

                        key = "Spotlights";
                        if (_config.ContainsKey(sect, key))
                            newStance.SpotlightMode =
                                (SpotlightModes)Enum.Parse(typeof(SpotlightModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.SpotlightMode = inheritee.SpotlightMode;
                        else
                            newStance.SpotlightMode = _defaultSpotlightMode;

                        key = "ExteriorLights";
                        if (_config.ContainsKey(sect, key))
                            newStance.ExteriorLightMode =
                                (LightToggleModes)Enum.Parse(typeof(LightToggleModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.ExteriorLightMode = inheritee.ExteriorLightMode;
                        else
                            newStance.ExteriorLightMode = _defaultExteriorLightMode;

                        key = "ExteriorLightColour";
                        if (_config.ContainsKey(sect, key))
                        {
                            working = _config.Get(sect, key).ToString();
                            c = working.Split(',');
                            r = int.Parse(c[0]);
                            g = int.Parse(c[1]);
                            b = int.Parse(c[2]);
                            a = int.Parse(c[3]);
                            newStance.ExteriorLightColour = new Color(r, g, b, a);
                        }
                        else if
                            (inherits) newStance.ExteriorLightColour = inheritee.ExteriorLightColour;
                        else
                            newStance.ExteriorLightColour = _defaultExteriorLightColour;

                        key = "InteriorLights";
                        if (_config.ContainsKey(sect, key))
                            newStance.InteriorLightMode =
                                (LightToggleModes)Enum.Parse(typeof(LightToggleModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.InteriorLightMode = inheritee.InteriorLightMode;
                        else
                            newStance.InteriorLightMode = _defaultInteriorLightMode;

                        key = "InteriorLightColour";
                        if (_config.ContainsKey(sect, key))
                        {
                            working = _config.Get(sect, key).ToString();
                            c = working.Split(',');
                            r = int.Parse(c[0]);
                            g = int.Parse(c[1]);
                            b = int.Parse(c[2]);
                            a = int.Parse(c[3]);
                            newStance.InteriorLightColour = new Color(r, g, b, a);
                        }
                        else if
                            (inherits) newStance.InteriorLightColour = inheritee.InteriorLightColour;
                        else
                            newStance.InteriorLightColour = _defaultInteriorLightColour;

                        key = "NavLights";
                        if (_config.ContainsKey(sect, key))
                            newStance.NavLightMode =
                                (LightToggleModes)Enum.Parse(typeof(LightToggleModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.NavLightMode = inheritee.NavLightMode;
                        else
                            newStance.NavLightMode = _defaultNavLightMode;

                        key = "LcdTextColour";
                        if (_config.ContainsKey(sect, key))
                        {
                            working = _config.Get(sect, key).ToString();
                            c = working.Split(',');
                            r = int.Parse(c[0]);
                            g = int.Parse(c[1]);
                            b = int.Parse(c[2]);
                            a = int.Parse(c[3]);
                            newStance.LcdTextColour = new Color(r, g, b, a);
                        }
                        else if
                            (inherits) newStance.LcdTextColour = inheritee.LcdTextColour;
                        else
                            newStance.LcdTextColour = _defaultLcdTextColour;

                        key = "TanksAndBatteries";
                        if (_config.ContainsKey(sect, key))
                            newStance.TankAndBatteryMode =
                                (TankAndBatteryModes)Enum.Parse(typeof(TankAndBatteryModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.TankAndBatteryMode = inheritee.TankAndBatteryMode;
                        else
                            newStance.TankAndBatteryMode = _defaultTankAndBatteryMode;

                        key = "NavOsEfcBurnPercentage";
                        if (_config.ContainsKey(sect, key))
                            newStance.BurnPercentage = _config.Get(sect, "NavOsEfcBurnPercentage").ToInt32(_defaultBurnPercentage);
                        else if
                            (inherits) newStance.BurnPercentage = inheritee.BurnPercentage;
                        else
                            newStance.BurnPercentage = _defaultBurnPercentage;

                        key = "EfcBoost";
                        if (_config.ContainsKey(sect, key))
                            newStance.EfcBoost =
                                (ToggleModes)Enum.Parse(typeof(ToggleModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.EfcBoost = inheritee.EfcBoost;
                        else
                            newStance.EfcBoost = _defaultEfcBoost;

                        key = "NavOsAbortEfcOff";
                        if (_config.ContainsKey(sect, key))
                            newStance.KillOrAbortNavigation =
                                (KillOrAbortNavigationModes)Enum.Parse(typeof(KillOrAbortNavigationModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.KillOrAbortNavigation = inheritee.KillOrAbortNavigation;
                        else
                            newStance.KillOrAbortNavigation = _defaultKillOrAbortNavigation;

                        key = "NavOsAbortEfcOff";
                        if (_config.ContainsKey(sect, key))
                            newStance.KillOrAbortNavigation =
                                (KillOrAbortNavigationModes)Enum.Parse(typeof(KillOrAbortNavigationModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.KillOrAbortNavigation = inheritee.KillOrAbortNavigation;
                        else
                            newStance.KillOrAbortNavigation = _defaultKillOrAbortNavigation;

                        key = "AuxMode";
                        if (_config.ContainsKey(sect, key))
                            newStance.AuxMode =
                                (ToggleModes)Enum.Parse(typeof(ToggleModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.AuxMode = inheritee.AuxMode;
                        else
                            newStance.AuxMode = _defaultAuxMode;

                        key = "Extractor";
                        if (_config.ContainsKey(sect, key))
                            newStance.ExtractorMode =
                                (ExtractorModes)Enum.Parse(typeof(ExtractorModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.ExtractorMode = inheritee.ExtractorMode;
                        else
                            newStance.ExtractorMode = _defaultExtractorMode;

                        key = "KeepAlives";
                        if (_config.ContainsKey(sect, key))
                            newStance.KeepAlives =
                                (ToggleModes)Enum.Parse(typeof(ToggleModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.KeepAlives = inheritee.KeepAlives;
                        else
                            newStance.KeepAlives = _defaultKeepAlives;

                        key = "HangarDoors";
                        if (_config.ContainsKey(sect, key))
                            newStance.HangarDoorsMode =
                                (HangarDoorModes)Enum.Parse(typeof(HangarDoorModes), _config.Get(sect, key).ToString());
                        else if
                            (inherits) newStance.HangarDoorsMode = inheritee.HangarDoorsMode;
                        else
                            newStance.HangarDoorsMode = _defaultHangarDoorMode;

                        newStances.Add(newName, newStance);
                    }
                    catch (Exception ex)
                    {
                        throwConfigParsingError(ex, "Failed to parse stance\n" + newName + "\nproperty\n" + key);
                    }
                }
            }

            if (newStances.Count < 1)
            {
                Echo("Failed to parse any stances!\nStances reset to default!");
                success = false;
            }
            else
            { // parsed at least one stance.
                Echo("Finished parsing " + newStances.Count + " stances.");
                _stances = newStances;
            }

            sec = "RSM.Stance"; Echo(sec);

            _currentStanceName = _config.Get(sec, "CurrentStance").ToString(_currentStanceName);

            // set the _currentStance var
            Stance newCurrentStance;
            if (!_stances.TryGetValue(_currentStanceName, out newCurrentStance))
            {
                // the key isn't in the dictionary.
                _currentStanceName = "N/A";
                _currentStance = null;
            } // otherwise, we found our guy.
            else _currentStance = newCurrentStance;


            return success;
        }

        void setCustomData()
        {
            _config.Clear();
            
            string sec, name;

            // Main -----------------------------------------------------------------

            sec = "RSM.Main";

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

            // Header -----------------------------------------------------------------
            
            // this is the bit at the top of the custom data
            _config.SetSectionComment(sec,
                _configDiv + 
                " Reedit Ship Management\n" +
                _configDiv + 
                " Config.ini\n Recompile to apply changes!\n" + _configDiv);
            
            // Spawns -----------------------------------------------------------------

            sec = "RSM.Spawns";

            name = "PrivateSpawns";
            _config.Set(sec, name, _privateSpawns);
            _config.SetComment(sec, name, "don't inject faction tag into spawn custom data");

            name = "FriendlyTags";
            _config.Set(sec, name, _friendlyTags);
            _config.SetComment(sec, name, "Comma seperated friendly factions or steam ids");

            // Doors -----------------------------------------------------------------

            sec = "RSM.Doors";

            name = "EnableDoorManagement";
            _config.Set(sec, name, _manageDoors);
            _config.SetComment(sec, name, "enable door management functionality");

            name = "DoorCloseTimer";
            _config.Set(sec, name, _doorCloseTimer);
            _config.SetComment(sec, name, "door open timer (x100 ticks)");

            name = "AirlockDoorDisableTimer";
            _config.Set(sec, name, _airlockDoorDisableTimer);
            _config.SetComment(sec, name, "airlock door disable timer (x100 ticks)");

            // Keywords -----------------------------------------------------------------

            sec = "RSM.Keywords";

            name = "Ignore";
            _config.Set(sec, name, _keywordIgnore);
            _config.SetComment(sec, name, "to identify blocks which RSM should ignore");

            name = "RsmLcds";
            _config.Set(sec, name, _keywordRsmLcds);
            _config.SetComment(sec, name, "to identify RSM lcds");

            name = "ColourSyncLcds";
            _config.Set(sec, name, _keywordColourSyncLcds);
            _config.SetComment(sec, name, "to identify non RSM lcds for colour sync");

            name = "AuxiliaryBlocks";
            _config.Set(sec, name, _keywordAuxBlocks);
            _config.SetComment(sec, name, "to identify aux blocks");

            name = "DefensivePdcs";
            _config.Set(sec, name, _keywordDefPdcs);
            _config.SetComment(sec, name, "to identify defensive _normalPdcs");

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

            sec = "RSM.InitNaming";

            name = "NameDelimiter";
            _config.Set(sec, name, '"' + _nameDelimiter.ToString() + '"');
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

            sec = "RSM.Misc";

            name = "DisableLightingControl";
            _config.Set(sec, name, _disableLightingControl);
            _config.SetComment(sec, name, "disable all lighting control");

            name = "DisableLcdColourControl";
            _config.Set(sec, name, _disableLcdColourControl);
            _config.SetComment(sec, name, "disable text colour control for all lcds");

            name = "ShowBasicTelemetry";
            _config.Set(sec, name, _showBasicTelemetry);
            _config.SetComment(sec, name, "show basic telemetry data on advanced thrust lcds");

            string DecelPercents = "";

            foreach (double Percent in _decelPercentages)
            {
                if (DecelPercents != "") DecelPercents += ",";
                DecelPercents += (Percent * 100).ToString();
            }

            name = "DecelerationPercentages";
            _config.Set(sec, name, DecelPercents);
            _config.SetComment(sec, name, "thrust percentages to show on advanced thrust lcds");

            name = "ShowThrustInMetric";
            _config.Set(sec, name, _isWeirdAboutThrustLikeGerm);
            _config.SetComment(sec, name, "show basic telemetry data on advanced thrust lcds");

            name = "ReactorFillRatio";
            _config.Set(sec, name, _reactorFillRatio);
            _config.SetComment(sec, name, "0-1, fill ratio for reactors");

            // Performance & Debugging -----------------------------------------------------------------

            sec = "RSM.Debug";

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

            sec = "RSM.Stance";

            name = "CurrentStance";
            _config.Set(sec, name, _currentStanceName);

            _config.SetSectionComment(sec, _configDiv + " Stances\n Add or remove as required\n" + _configDiv);

            string colourComment = "Red, Green, Blue, Alpha";

            foreach (var stanceDict in _stances)
            {
                sec = "RSM.Stance." + stanceDict.Key;

                Stance stance = stanceDict.Value;
                Stance inheritee = null;
                if (stance.Inherits != "")
                {
                    inheritee = _stances[stance.Inherits];
                    name = "Inherits";
                    _config.Set(sec, name, stance.Inherits);
                    _config.SetComment(sec, name, "Use stance of this name as a template for settings");
                }


                name = "Torps";
                if (inheritee != null && stance.TorpedoMode == inheritee.TorpedoMode)
                { // this value matches it's inheritor,
                    // so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                } 
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.TorpedoMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(ToggleModes)));
                }

                name = "Pdcs";
                if (inheritee != null && stance.PdcMode == inheritee.PdcMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                } 
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.PdcMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(PdcModes)));
                }

                name = "Kinetics";
                if (inheritee != null && stance.RailgunMode == inheritee.RailgunMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.RailgunMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(RailgunModes)));
                }

                name = "MainThrust";
                if (inheritee != null && stance.MainDriveMode == inheritee.MainDriveMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.MainDriveMode.ToString());
                    _config.SetComment(sec, "MainThrust", getAllEnumValues(typeof(MainDriveModes)));
                }

                name = "ManeuveringThrust";
                if (inheritee != null && stance.ManeuveringThrusterMode == inheritee.ManeuveringThrusterMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.ManeuveringThrusterMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(ManeuveringThrusterModes)));
                }

                name = "Spotlights";
                if (inheritee != null && stance.SpotlightMode == inheritee.SpotlightMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.SpotlightMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(SpotlightModes)));
                }

                name = "ExteriorLights";
                if (inheritee != null && stance.ExteriorLightMode == inheritee.ExteriorLightMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.ExteriorLightMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(LightToggleModes)));
                }

                name = "ExteriorLightColour";
                if (inheritee != null && stance.ExteriorLightColour == inheritee.ExteriorLightColour)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, buildColourString(stance.ExteriorLightColour));
                    _config.SetComment(sec, name, colourComment);
                }

                name = "InteriorLights";
                if (inheritee != null && stance.InteriorLightMode == inheritee.InteriorLightMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.InteriorLightMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(LightToggleModes)));
                }

                name = "InteriorLightColour";
                if (inheritee != null && stance.InteriorLightColour == inheritee.InteriorLightColour)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, buildColourString(stance.InteriorLightColour));
                    _config.SetComment(sec, name, colourComment);
                }

                name = "NavLights";
                if (inheritee != null && stance.NavLightMode == inheritee.NavLightMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.NavLightMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(LightToggleModes)));
                }

                name = "LcdTextColour";
                if (inheritee != null && stance.LcdTextColour == inheritee.LcdTextColour)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, buildColourString(stance.LcdTextColour));
                    _config.SetComment(sec, name, colourComment);
                }

                name = "TanksAndBatteries";
                if (inheritee != null && stance.TankAndBatteryMode == inheritee.TankAndBatteryMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.TankAndBatteryMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(TankAndBatteryModes)));
                }

                name = "NavOsEfcBurnPercentage";
                if (inheritee != null && stance.BurnPercentage == inheritee.BurnPercentage)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.BurnPercentage.ToString());
                    _config.SetComment(sec, name, "Burn % 0-100, -1 for no change");
                }

                name = "EfcBoost";
                if (inheritee != null && stance.EfcBoost == inheritee.EfcBoost)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.EfcBoost.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(ToggleModes)));
                }

                name = "NavOsAbortEfcOff";
                if (inheritee != null && stance.KillOrAbortNavigation == inheritee.KillOrAbortNavigation)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.KillOrAbortNavigation.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(KillOrAbortNavigationModes)));
                }

                name = "AuxMode";
                if (inheritee != null && stance.AuxMode == inheritee.AuxMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.AuxMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(ToggleModes)));
                }

                name = "Extractor";
                if (inheritee != null && stance.ExtractorMode == inheritee.ExtractorMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.ExtractorMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(ExtractorModes)));
                }

                name = "KeepAlives";
                if (inheritee != null && stance.KeepAlives == inheritee.KeepAlives)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.KeepAlives.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(ToggleModes)));
                }

                name = "HangarDoors";
                if (inheritee != null && stance.HangarDoorsMode == inheritee.HangarDoorsMode)
                { // this value matches it's inheritor, so delete it from the ini.
                    if (_config.ContainsKey(sec, name)) _config.Delete(sec, name);
                }
                else
                { // otherwise, load it up
                    _config.Set(sec, name, stance.HangarDoorsMode.ToString());
                    _config.SetComment(sec, name, getAllEnumValues(typeof(HangarDoorModes)));
                }       

            }

            // System -----------------------------------------------------------------

            sec = "RSM.System";

            name = "ShipName";
            _config.Set(sec, name, _shipName);

            _config.SetSectionComment(sec, _configDiv + " System\n All items below this point are\n set automatically when running init\n" + _configDiv);

            // InitItems -----------------------------------------------------------------

            sec = "RSM.InitItems";

            foreach (Item item in _items)
            {
                name = item.Type.SubtypeId;
                _config.Set(sec, name, item.InitQty);
            }

            //_config.SetSectionComment(sec, "set automatically at init.");

            // InitSubSystems -----------------------------------------------------------------

            sec = "RSM.InitSubSystems";

            _config.Set(sec, "Reactors", _initReactors);
            _config.Set(sec, "Batteries", _initReactors);
            _config.Set(sec, "Pdcs", _initPdcs);
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

                            case "Keyword used to identify RSM _allLcds.":
                                _keywordRsmLcds = value;
                                break;

                            case "Keyword used to identify autorepair systems":
                            case "Keyword used to identify auxiliary blocks":
                                _keywordAuxBlocks = value;
                                break;

                            case "Keyword used to identify defence _normalPdcs.":
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

                            case "Automatically configure _normalPdcs, Railguns, Torpedoes.":
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

                            /*case "Add type names to weapons at init.":
                                _appendWeaponTypes = bool.Parse(value);
                                break;*/
                            // lol no, they will be forced to try it.

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
                                _items[0].InitQty = int.Parse(value);
                                break;

                            case "Fuel tank count":
                                _items[1].InitQty = int.Parse(value);
                                break;

                            case "Jerry can count":
                                _items[2].InitQty = int.Parse(value);
                                break;

                            case "40mm PDC Magazine count":
                                _items[3].InitQty = int.Parse(value);
                                break;
                            case "40mm Teflon Tungsten PDC Magazine count":
                                _items[4].InitQty = int.Parse(value);
                                break;

                            case "220mm Torpedo count":
                            case "Torpedo count":
                                _items[5].InitQty = int.Parse(value);
                                break;

                            case "220mm MCRN torpedo count":
                                _items[6].InitQty = int.Parse(value);
                                break;

                            case "220mm UNN torpedo count":
                                _items[7].InitQty = int.Parse(value);
                                break;

                            case "Ramshackle torpedo count":
                            case "Ramshackle torpedo Count":
                                _items[8].InitQty = int.Parse(value);
                                break;

                            case "Large ramshacke torpedo count":
                                _items[9].InitQty = int.Parse(value);
                                break;

                            case "Zako 120mm Railgun rounds count":
                            case "Railgun rounds count":
                                _items[10].InitQty = int.Parse(value);
                                break;

                            case "Dawson 100mm UNN Railgun rounds count":
                                _items[11].InitQty = int.Parse(value);
                                break;

                            case "Stiletto 100mm MCRN Railgun rounds count":
                                _items[12].InitQty = int.Parse(value);
                                break;

                            case "T-47 80mm Railgun rounds count":
                                _items[13].InitQty = int.Parse(value);
                                break;

                            case "Foehammer 120mm MCRN rounds count":
                                _items[14].InitQty = int.Parse(value);
                                break;

                            case "Farren 120mm UNN Railgun rounds count":
                                _items[15].InitQty = int.Parse(value);
                                break;

                            case "Kess 180mm rounds count":
                                _items[16].InitQty = int.Parse(value);
                                break;

                            case "Steel plate count":
                                _items[17].InitQty = int.Parse(value);
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
                                _currentStanceName = value;

                                // set the _currentStance var
                                Stance newCurrentStance;
                                if (!_stances.TryGetValue(_currentStanceName, out newCurrentStance))
                                {
                                    // the key isn't in the dictionary.
                                    _currentStanceName = "N/A";
                                    _currentStance = null;

                                } // otherwise, we found our guy.
                                else _currentStance = newCurrentStance;
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

                int data_length = 24;

                Dictionary<string, Stance> newStances = new Dictionary<string, Stance>();

                // EFC/NavOS set burn percentages
                int[] burnPercs = new int[] { 0, 5, 25, 50, 75, 100 };

                //List<string> new_name_list = new List<string>();
                //List<int[]> new_data_list = new List<int[]>();

                for (int i = 1; i < stances.Length; i++)
                {


                    string[] stance_vars = stances[i].Split('=');

                    string newName = "";
                    int[] newData = new int[data_length];



                    newName = stance_vars[0].Split(' ')[0];
                    if (_d) Echo("Parsing '" + newName + "'");
                    for (int j = 0; j < newData.Length; j++)
                    {
                        string[] cleanup = stance_vars[(j + 1)].Split('\n');
                        newData[j] = int.Parse(cleanup[0]);
                        //if (_d) Echo(new_data[j].ToString());
                    }
                    //new_name_list.Add(new_name);
                    //new_data_list.Add(new_data);

                    /*
                    new int[] { // Cruise 0
                        1,      // 0: torpedoes; 0: off, 1: on;
                        2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                        1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                        1,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                        2,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                        0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                        1,      // 6: exterior lights; 0: off, 1: on
                        30,     // 7: Red - Exterior lights colour
                        144,    // 8: Green - Exterior lights colour
                        255,    // 9: Blue - Exterior lights colour
                        255,    // 10: Alpha - Exterior lights colour
                        1,      // 11: interior lights lights; 0: off, 1: on
                        30,     // 12: Red - Interior lights colour
                        144,    // 13: Green - Interior lights colour
                        225,    // 14: Blue - Interior lights colour
                        255,    // 15: Alpha - Interior lights colour
                        0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                        0,      // 17: EFC boost; 0: off, 1: on
                        2,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                        0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC
                        0,      // 20: auxiliary blocks; 0: off, 1: on
                        3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                        1,      // 22: keep-alives for connectors, tanks, batteries, gyros, lcds; 0: ignore, 1: force on, 2: force off
                        0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
                     */

                    // convert the legacy int array into a stance class.

                    Stance newStance = new Stance();

                    if (newData[0] == 0) newStance.TorpedoMode = ToggleModes.Off;
                    else newStance.TorpedoMode = ToggleModes.On;

                    if (newData[1] == 0) newStance.PdcMode = PdcModes.Off;
                    else if (newData[1] == 1) newStance.PdcMode = PdcModes.MinDefence;
                    else if (newData[1] == 2) newStance.PdcMode = PdcModes.AllDefence;
                    else if (newData[1] == 3) newStance.PdcMode = PdcModes.Offence;
                    else if (newData[1] == 4) newStance.PdcMode = PdcModes.AllOnOnly;

                    if (newData[2] == 0) newStance.RailgunMode = RailgunModes.Off;
                    else if (newData[2] == 1) newStance.RailgunMode = RailgunModes.HoldFire;
                    else if (newData[2] == 2) newStance.RailgunMode = RailgunModes.OpenFire;

                    if (newData[3] == 0) newStance.MainDriveMode = MainDriveModes.Off;
                    else if(newData[3] == 1) newStance.MainDriveMode = MainDriveModes.On;
                    else if(newData[3] == 2) newStance.MainDriveMode = MainDriveModes.Minimum;

                    if (newData[4] == 0) newStance.ManeuveringThrusterMode = ManeuveringThrusterModes.Off;
                    else if (newData[4] == 1) newStance.ManeuveringThrusterMode = ManeuveringThrusterModes.On;
                    else if (newData[4] == 2) newStance.ManeuveringThrusterMode = ManeuveringThrusterModes.ForwardOff;
                    else if (newData[4] == 3) newStance.ManeuveringThrusterMode = ManeuveringThrusterModes.ReverseOff;

                    if (newData[5] == 0) newStance.SpotlightMode = SpotlightModes.Off;
                    else if (newData[5] == 1) newStance.SpotlightMode = SpotlightModes.On;
                    else if (newData[5] == 2) newStance.SpotlightMode = SpotlightModes.OnMax;

                    if (newData[6] == 0) newStance.ExteriorLightMode = LightToggleModes.Off;
                    else newStance.ExteriorLightMode = LightToggleModes.On;

                    newStance.ExteriorLightColour = new Color(newData[7], newData[8], newData[9], newData[10]);

                    if (newData[11] == 0) newStance.InteriorLightMode = LightToggleModes.Off;
                    else newStance.InteriorLightMode = LightToggleModes.On;

                    newStance.InteriorLightColour = new Color(newData[12], newData[13], newData[14], newData[15]);

                    if (newData[16] == 0) newStance.TankAndBatteryMode = TankAndBatteryModes.Auto;
                    else if (newData[16] == 1) newStance.TankAndBatteryMode = TankAndBatteryModes.StockpileRecharge;
                    else if (newData[16] == 2) newStance.TankAndBatteryMode = TankAndBatteryModes.Discharge;

                    if (newData[17] == 0) newStance.EfcBoost = ToggleModes.Off;
                    else newStance.EfcBoost = ToggleModes.On;

                    newStance.BurnPercentage = burnPercs[newData[18]];

                    if (newData[19] == 0) newStance.KillOrAbortNavigation = KillOrAbortNavigationModes.NoChange;
                    else newStance.KillOrAbortNavigation = KillOrAbortNavigationModes.Abort;

                    if (newData[20] == 0) newStance.AuxMode = ToggleModes.Off;
                    else newStance.AuxMode = ToggleModes.On;

                    if (newData[21] == 0) newStance.ExtractorMode = ExtractorModes.Off;
                    else if (newData[21] == 1) newStance.ExtractorMode = ExtractorModes.On;
                    else if (newData[21] == 2) newStance.ExtractorMode = ExtractorModes.FillWhenLow;
                    else if (newData[21] == 3) newStance.ExtractorMode = ExtractorModes.KeepFull;

                    if (newData[22] == 0) newStance.KeepAlives = ToggleModes.Off;
                    else newStance.KeepAlives = ToggleModes.On;

                    if (newData[23] == 0) newStance.HangarDoorsMode = HangarDoorModes.Closed;
                    else if (newData[23] == 1) newStance.HangarDoorsMode = HangarDoorModes.Open;
                    else newStance.HangarDoorsMode = HangarDoorModes.NoChange;

                    newStances.Add(newName, newStance);

                }
                if (newStances.Count >= 1)
                {
                    // we did it.
                    if (_d) Echo("Finished parsing " + newStances.Count + " stances.");
                    _stances = newStances;
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
            // attempt to parse the config
            bool noResetNeeded = parseCustomData();
            if (!noResetNeeded)
            {
                // looks like we need to reset the custom data.

                // build our default stances
                buildDefaultStance();

                // build the ini Stance object and write it to custom data.
                setCustomData();
            }

            // build stances from inheritance
            // this completes each of the stance objects
            // using the marked inheritance.


            // if we don't have a current stance,
            // still show N/A
            // but put the first stance values into the
            // _currentStance for test purposes later.
            if (_currentStance == null)
            {
                _currentStance = _stances.First().Value;
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
            _survivalKitOpenData = 
                start + 
                string.Join("\n", _friendlyTags.Split(',')) + 
                end;


            // if we have no ship name,
            // try and get it from the pb name
            if (_shipName == "")
            {
                if (_d) Echo("No ship name, trying to pull it from PB name...");
                string defaultName = "Untitled Ship";
                try
                {
                    string[] nameBits = Me.CustomName.Split(_nameDelimiter);
                    if (nameBits.Length > 1)
                    {
                        _shipName = nameBits[0];
                        if (_d) Echo(_shipName);
                    }
                    else _shipName = defaultName;
                }
                catch
                {
                    _shipName = defaultName;
                }
            }

        }

        void setSystemData(bool setStance = true, bool setSubsystems = false, bool setInventory = false)
        {
            MyIni config = new MyIni();
            string toParse = Me.CustomData;

            // attempt to parse ini from the custom data
            MyIniParseResult result;
            if (!config.TryParse(toParse, out result))
            {
                _alerts.Add(new Alert(
                    "CONFIG ERROR!!",
                    "Failed to save to custom data due to a parsing error!\nFix and recompile!",
                    3
                    ));
                return;
            }

            string sec, name;

            if (setStance)
            {
                sec = "RSM.Stance";
                name = "CurrentStance";

                config.Set(sec, name, _currentStanceName);
            }
            else
            {
                // if we're not setting stance
                // this is an init.
                // so we have to save the ship name...
                sec = "RSM.System";
                name = "ShipName";

                config.Set(sec, name, _shipName);
            }

            if (setSubsystems)
            {
                sec = "RSM.InitSubSystems";

                config.Set(sec, "Reactors", _initReactors);
                config.Set(sec, "Batteries", _initBatteries);
                config.Set(sec, "Pdcs", _initPdcs);
                config.Set(sec, "TorpLaunchers", _initTorpLaunchers);
                config.Set(sec, "KineticWeapons", _initKinetics);
                config.Set(sec, "H2Storage", _initH2);
                config.Set(sec, "O2Storage", _initO2);
                config.Set(sec, "MainThrust", _initThrustMain);
                config.Set(sec, "RCSThrust", _initThrustRCS);
                config.Set(sec, "Gyros", _initGyros);
                config.Set(sec, "CargoStorage", _initCargos);
                config.Set(sec, "Welders", _initWelders);
            }

            if (setInventory)
            {
                sec = "RSM.InitItems";

                foreach (Item item in _items)
                {
                    name = item.Type.SubtypeId;
                    config.Set(sec, name, item.InitQty);
                }
            }

            // Save it -----------------------------------------------------------------

            Me.CustomData = config.ToString();

        }

        string getAllEnumValues(Type enumType)
        {
            string vals = "";
            foreach (var val in Enum.GetValues(enumType))
            {
                if (vals != "") vals += ", ";
                vals += val.ToString();
            }
            return vals;
        }

        string buildColourString(Color colour)
        {
            return colour.R + ", " + colour.G + ", " + colour.B + ", " + colour.A;
        }

        void throwConfigParsingError(Exception ex, string desc)
        {
            // stop looping
            Runtime.UpdateFrequency = UpdateFrequency.None;

            // build our error
            string fuckUp = 
                "\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n" + 
                desc + 
                "\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";

            // put it in block details
            Echo(fuckUp);

            // put it on every RSM screen
            List<IMyTextPanel> rsmLcds = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(rsmLcds, b => b.CustomName.Contains(_keywordRsmLcds));
            foreach (IMyTextPanel Lcd in  rsmLcds)
            {
                Lcd.WriteText(fuckUp);
                Lcd.FontColor = new Color(193,0,197,255); // make the text pink.
            }

            // throw a tantrum
            // refuse to continue.
            throw ex;
        }
    }
}
