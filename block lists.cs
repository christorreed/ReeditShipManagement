using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
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
        // Ship Controller
        IMyShipController _shipController;

        // General Block Lists
        private List<IMyRadioAntenna> _antennas = new List<IMyRadioAntenna>();
        private List<IMyBatteryBlock> _batteries = new List<IMyBatteryBlock>();
        private List<IMyCameraBlock> _cameras = new List<IMyCameraBlock>();
        private List<IMyCargoContainer> _cargos = new List<IMyCargoContainer>();
        private List<IMyShipConnector> _connectors = new List<IMyShipConnector>();
        private List<IMyShipController> _controllers = new List<IMyShipController>();
        private List<IMyAirtightHangarDoor> _hangarDoors = new List<IMyAirtightHangarDoor>();
        private List<IMyTerminalBlock> _largeExtractors = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> _smallExtractors = new List<IMyTerminalBlock>();
        private List<IMyGyro> _gyroscopes = new List<IMyGyro>();
        private List<IMyProjector> _projectors = new List<IMyProjector>();
        private List<IMyReactor> _reactors = new List<IMyReactor>();
        private List<IMySensorBlock> _sensors = new List<IMySensorBlock>();
        private List<IMyTerminalBlock> _spawns = new List<IMyTerminalBlock>();
        private List<IMyGasTank> _h2Tanks = new List<IMyGasTank>();
        private List<IMyGasTank> _o2Tanks = new List<IMyGasTank>();
        private List<IMyAirVent> _vents = new List<IMyAirVent>();
        private List<IMyTerminalBlock> _welders = new List<IMyTerminalBlock>();

        // Weapons Lists
        private List<IMyConveyorSorter> _lidars = new List<IMyConveyorSorter>();
        private List<IMyTerminalBlock> _normalPdcs = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> _defensivePdcs = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> _kineticWeapons = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> _torpedoLaunchers = new List<IMyTerminalBlock>();

        // Thruster Lists
        private List<IMyThrust> _epsteinThrusters = new List<IMyThrust>();
        private List<IMyThrust> _rcsThrusters = new List<IMyThrust>();
        private List<IMyThrust> _chemicalThrusters = new List<IMyThrust>();
        private List<IMyThrust> _atmoThrusters = new List<IMyThrust>();

        // PB Lists
        private List<IMyProgrammableBlock> _pbsEfc = new List<IMyProgrammableBlock>();
        private List<IMyProgrammableBlock> _pbsNavOs = new List<IMyProgrammableBlock>();

        // LCD Lists
        private List<IMyTextPanel> _allLcds = new List<IMyTextPanel>();
        private List<IMyTextPanel> _colourSyncLcds = new List<IMyTextPanel>();
        private List<RsmLcd> _rsmLcds = new List<RsmLcd>();

        // Light Lists
        private List<IMyLightingBlock> _exteriorLights = new List<IMyLightingBlock>();
        private List<IMyLightingBlock> _interiorLights = new List<IMyLightingBlock>();
        private List<IMyLightingBlock> _portNavLights = new List<IMyLightingBlock>();
        private List<IMyLightingBlock> _starboardNavLights = new List<IMyLightingBlock>();
        private List<IMyReflectorLight> _spotlights = new List<IMyReflectorLight>();

        // Aux List
        private List<IMyTerminalBlock> _auxiliaries = new List<IMyTerminalBlock>();

        // Doors
        private List<Door> _doors = new List<Door>();
        private List<Airlock> _airlocks = new List<Airlock>();

        // INIT
        private bool I = false;
        // set to true during an init.

        // Init Names List
        private Dictionary<IMyTerminalBlock, string> _initNames = new Dictionary<IMyTerminalBlock, string>();
        // built if I = true

        private bool sortBlockLists(IMyTerminalBlock b) 
        {
            // this function sorts each block into the appropriate list.
            // it will always return false
            // it will also build the _initNames dictionary in the case that I = true

            // tried to roughly sort these by occurance to reduce the amount of processing on average.
            // note some are before or after the ignore keyword check.

            try
            {
                // Ignore blocks not on the same construct...
                if (!Me.IsSameConstructAs(b)) return false;

                // test for unowned blocks...
                string Tag = b.GetOwnerFactionTag();
                if (Tag != _factionTag && Tag != "")
                {
                    Echo("!" + Tag + ": " + b.CustomName);
                    _unownedBlockCount++;
                    return false;
                }

                // IGNORE KEYWORD CHECK -----------------------------------------------------------------

                // Ignore blocks with the ignore keyword...
                if (b.CustomName.Contains(_keywordIgnore))
                    return false;

                // SHIP NAME CHECK -----------------------------------------------------------------

                if (!I && _requireShipName && !b.CustomName.Contains(_shipName))
                    // if we are not running init
                    // and we _requireShipName
                    // and the ship name isn't included
                    return false; // ignore this block

                // Aux -----------------------------------------------------------------

                // grab aux blocks
                if (b.CustomName.Contains(_keywordAuxBlocks))
                    _auxiliaries.Add(b);

                //if (_d) Echo("Sorting " + b.CustomName);

                string blockId = b.BlockDefinition.ToString();

                // Spawns -----------------------------------------------------------------

                // Medical Rooms
                if (blockId.Contains("MedicalRoom/"))
                {
                    if (_spawnOpen) b.CustomData = _survivalKitOpenData;
                    else b.CustomData = _survivalKitData;

                    _spawns.Add(b);
                    if (I) _initNames.Add(b, "Medical Room");
                    return false;
                }

                // Survival Kits
                if (blockId.Contains("SurvivalKit/"))
                {
                    if (_spawnOpen) b.CustomData = _survivalKitOpenData;
                    else b.CustomData = _survivalKitData;

                    _spawns.Add(b);
                    if (I) _initNames.Add(b, "Survival Kit");
                    return false;
                }

                // Refill Stations
                if (blockId == "MyObjectBuilder_MedicalRoom/LargeRefillStation")
                {
                    if (I) _initNames.Add(b, "Refill Station");
                    return false;
                }

                // LCDs -----------------------------------------------------------------

                var TempLCD = b as IMyTextPanel;
                if (TempLCD != null)
                {
                    _allLcds.Add(TempLCD);

                    if (I) _initNames.Add(b, "LCD");

                    if (TempLCD.CustomName.Contains(_keywordRsmLcds))
                    {
                        RsmLcd rsmlcd = new RsmLcd();
                        rsmlcd.Block = TempLCD;
                        _rsmLcds.Add(sortRsmLcd(rsmlcd));
                    }

                    else if (!_disableLcdColourControl && TempLCD.CustomName.Contains(_keywordColourSyncLcds))
                        _colourSyncLcds.Add(TempLCD);

                    return false;
                }

                // _normalPdcs -----------------------------------------------------------------

                // Flak
                if (blockId == "MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")
                    return sortPDC(b, "Flak", 3);

                // OPA
                if (blockId == "MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")
                    return sortPDC(b, "OPA", 3);

                // Voltaire
                if (blockId == "MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")
                    return sortPDC(b, "Voltaire", 3);

                // Nari
                if (blockId.Contains("Nariman Dynamics PDC"))
                    return sortPDC(b, "Nari", 4);

                // Red
                if (blockId.Contains("Redfields Ballistics PDC"))
                    return sortPDC(b, "Red", 4);

                // Torpedoes -----------------------------------------------------------------

                // Apollo
                if (blockId == "MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")
                    return sortTorp(b, "Apollo");

                // Tycho
                if (blockId == "MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")
                    return sortTorp(b, "Tycho");

                // Zeus
                if (blockId == "MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")
                    return sortTorp(b, "Zeus");

                // Tycho
                if (blockId == "MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")
                    return sortTorp(b, "Tycho");

                // Ares
                if (blockId.Contains("Ares_Class"))
                    return sortTorp(b, "Ares");

                // Artemis
                if (blockId.Contains("Artemis_Torpedo_Tube"))
                    return sortTorp(b, "Artemis");

                // Railguns -----------------------------------------------------------------

                // Dawson
                if (blockId == "MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")
                    return sortRail(b, "Dawson", 11);

                // Stiletto
                if (blockId == "MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")
                    return sortRail(b, "Stiletto", 12);

                // Roci
                if (blockId == "MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")
                    return sortRail(b, "Roci", 13);

                // Foehammer
                if (blockId == "MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")
                    return sortRail(b, "Foehammer", 14);

                // Farren
                if (blockId == "MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")
                    return sortRail(b, "Farren", 15);

                // Zako
                if (blockId.Contains("Zakosetara"))
                    return sortRail(b, "Zako", 10);

                // Kess
                if (blockId.Contains("Kess Hashari Cannon"))
                    return sortRail(b, "Kess", 16);

                // Coilgun
                if (blockId.Contains("Coilgun"))
                    return sortRail(b, "Coilgun", 13);

                // Glapion
                if (blockId.Contains("Glapion"))
                    return sortRail(b, "Glapion", 3);

                // Thrusters -----------------------------------------------------------------

                var TempThruster = b as IMyThrust;
                if (TempThruster != null)
                {
                    if (blockId.ToUpper().Contains("RCS"))
                    {
                        _rcsThrusters.Add(TempThruster);
                        if (I) _initNames.Add(b, "RCS");
                    }
                    else if (blockId.Contains("Hydro"))
                    {
                        _chemicalThrusters.Add(TempThruster);
                        if (I) _initNames.Add(b, "Chem");
                    }
                    else if (blockId.Contains("Atmospheric"))
                    {
                        _atmoThrusters.Add(TempThruster);
                        if (I) _initNames.Add(b, "Atmo");
                    }
                    else
                    {
                        _epsteinThrusters.Add(TempThruster);

                        if (I) 
                        {
                            string append = "";

                            if (_appendDriveTypes)
                            {
                                try
                                {
                                    append = b.DefinitionDisplayNameText.Split('"')[1];
                                    append =
                                        _nameDelimiter +
                                        append[0].ToString().ToUpper() +
                                        append.Substring(1).ToLower();
                                }
                                catch
                                {
                                    if (_d) Echo("Failed to get drive type from " + b.DefinitionDisplayNameText);
                                }

                            }
                            _initNames.Add(b, "Epstein" + append);
                        }

                    }
                    return false;
                }

                // Cargos -----------------------------------------------------------------

                var TempCargo = b as IMyCargoContainer;
                if (TempCargo != null)
                {
                    // below is needed cause locker rooms etc.
                    // let those filter through to the bottom instead.
                    string blockIdTwo = blockId.Split('/')[1];
                    if (blockIdTwo.Contains("Container") || blockIdTwo.Contains("Cargo"))
                    {
                        _cargos.Add(TempCargo);
                        addInventory(b); // check this block for stored items

                        if (I)
                        {
                            double Max = b.GetInventory().MaxVolume.RawValue;
                            double VolumeFactor = Math.Round(Max / 1265625024, 1);
                            if (VolumeFactor == 0) VolumeFactor = 0.1;
                            _initNames.Add(b, "Cargo [" + VolumeFactor + "]");
                        }
                        return false;
                    }
                }

                // Gyros -----------------------------------------------------------------
                var TempGyro = b as IMyGyro;
                if (TempGyro != null)
                {
                    _gyroscopes.Add(TempGyro);
                    if (I) _initNames.Add(b, "Gyroscope");
                    return false;
                }

                // Batteries -----------------------------------------------------------------
                var TempBatts = b as IMyBatteryBlock;
                if (TempBatts != null)
                {
                    _batteries.Add(TempBatts);
                    if (I) _initNames.Add(b, "Power" + _nameDelimiter + "Battery");
                    return false;
                }

                // Spotlights -----------------------------------------------------------------
                // Must go before Lights.
                var TempSpot = b as IMyReflectorLight;
                if (TempSpot != null)
                {
                    _spotlights.Add(TempSpot);
                    if (I) _initNames.Add(b, "Spotlight");
                    return false;
                }

                // Lights -----------------------------------------------------------------
                var TempLight = b as IMyLightingBlock;
                if (TempLight != null)
                {
                    // use name to determine grouping for lights
                    if (
                        b.CustomName.ToUpper().Contains("INTERIOR")
                        ||
                        blockId.Contains("Kitchen")
                        ||
                        blockId.Contains("Aquarium")
                        )
                    {
                        _interiorLights.Add(TempLight);
                        if (I) _initNames.Add(b, "Light" + _nameDelimiter + "Interior");
                    }

                    // nav lights
                    else if (b.CustomName.Contains(_keywordLightNavigation))
                    {
                        if (b.CustomName.ToUpper().Contains("STARBOARD"))
                        {
                            _starboardNavLights.Add(TempLight);
                            if (I) _initNames.Add(b, "Light" + _nameDelimiter + "Nav" + _nameDelimiter + "Starboard");
                        }
                        else
                        {
                            _portNavLights.Add(TempLight);
                            if (I) _initNames.Add(b, "Light" + _nameDelimiter + "Nav" + _nameDelimiter + "Port");
                        }
                    }

                    // exterior lights
                    else
                    {
                        _exteriorLights.Add(TempLight);
                        if (I) _initNames.Add(b, "Light" + _nameDelimiter + "Exterior");
                    }

                    return false;
                }

                // Tanks -----------------------------------------------------------------
                var TempTank = b as IMyGasTank;
                if (TempTank != null)
                {

                    if (blockId.Contains("Hydro"))
                    {
                        _h2Tanks.Add(TempTank);
                        if (I) _initNames.Add(b, "Tank" + _nameDelimiter + "Hydrogen");
                    }
                    else
                    {
                        _o2Tanks.Add(TempTank);
                        if (I) _initNames.Add(b, "Tank" + _nameDelimiter + "Oxygen");
                    }
                    return false;
                }


                // Reactors -----------------------------------------------------------------
                var TempReactor = b as IMyReactor;
                if (TempReactor != null)
                {
                    _reactors.Add(TempReactor);
                    addInventory(b, 0);

                    if (I)
                    {
                        string AppendReactor = "Lg";
                        if (blockId.Contains("SmallGenerator"))
                            AppendReactor = "Sm";
                        else if (blockId.Contains("MCRN"))
                            AppendReactor = "MCRN";

                        _initNames.Add(b, "Power" + _nameDelimiter + "Reactor" + _nameDelimiter + AppendReactor);
                    }
                    return false;
                }

                // Ship Controllers -----------------------------------------------------------------
                var TempController = b as IMyShipController;
                if (TempController != null)
                {
                    _controllers.Add(TempController);

                    if (_shipController == null && b.CustomName.Contains("Nav"))
                        _shipController = TempController;

                    if (TempController.HasInventory)
                        addInventory(b);

                    if (I && blockId.Contains("Cockpit/"))
                    {
                        if (blockId.Contains("StandingCockpit") || blockId.Contains("Console"))
                        {
                            _initNames.Add(b, "Console");
                            return false;
                        }
                        else if (blockId.Contains("Cockpit"))
                        {
                            _initNames.Add(b, "Cockpit");
                            return false;
                        }
                    }
                }

                // Doors -----------------------------------------------------------------
                var TempDoor = b as IMyDoor;
                if (TempDoor != null)
                {
                    Door d = new Door();
                    d.Block = TempDoor;
                    if (b.CustomName.Contains(_keywordAirlock))
                    {
                        try
                        {
                            string airlockId = b.CustomName.Split(_nameDelimiter)[3];
                            d.IsAirlock = true;

                            bool found = false;
                            foreach (Airlock airlock in _airlocks)
                            {
                                if (airlockId == airlock.Id)
                                {
                                    airlock.Doors.Add(d);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Airlock al = new Airlock();
                                al.Id = airlockId;
                                al.Doors.Add(d);
                                _airlocks.Add(al);
                            }
                        }
                        catch
                        {
                            if (_d) Echo("Error with airlock door name " + b.CustomName);
                            _doors.Add(d);
                        }
                    }
                    else
                    {
                        _doors.Add(d);
                    }
                    
                    if (I) _initNames.Add(b, "Door");
                    return false;
                }

                // Vents -----------------------------------------------------------------
                var TempVent = b as IMyAirVent;
                if (TempVent != null)
                {
                    _vents.Add(TempVent);
                    if (b.CustomName.Contains(_keywordAirlock))
                    {
                        try
                        {
                            string airlockId = b.CustomName.Split(_nameDelimiter)[3];

                            bool found = false;
                            foreach (Airlock airlock in _airlocks)
                            {
                                if (airlockId == airlock.Id)
                                {
                                    airlock.Vents.Add(TempVent);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                // set to depressurise


                                Airlock al = new Airlock();
                                al.Id = airlockId; 
                                al.Vents.Add(TempVent);
                                _airlocks.Add(al);
                            }
                        }
                        catch
                        {
                            if (_d) Echo("Error with airlock vent name " + b.CustomName);
                        }
                    }
                    if (I) _initNames.Add(b, "Vent");
                    return false;
                }

                // Cameras -----------------------------------------------------------------
                var TempCam = b as IMyCameraBlock;
                if (TempCam != null)
                {
                    _cameras.Add(TempCam);
                    if (I) _initNames.Add(b, "Camera");
                    return false;
                }

                // Connectors -----------------------------------------------------------------
                var TempConnector = b as IMyShipConnector;
                if (TempConnector != null)
                {
                    _connectors.Add(TempConnector);
                    addInventory(b);

                    if (I)
                    {
                        string ConnectorAppend = "";
                        if (blockId.Contains("Passageway"))
                            ConnectorAppend = _nameDelimiter + "Passageway";
                        _initNames.Add(b, "Connector" + ConnectorAppend);
                    }
                    return false;
                }

                // Hangar Doors -----------------------------------------------------------------
                var TempHangars = b as IMyAirtightHangarDoor;
                if (TempHangars != null)
                {
                    _hangarDoors.Add(TempHangars);
                    if (I) _initNames.Add(b, "Door" + _nameDelimiter + "Hangar");
                    return false;
                }

                // LiDAR -----------------------------------------------------------------
                if (blockId.Contains("Lidar"))
                {
                    var TempLidar = b as IMyConveyorSorter;
                    if (TempLidar != null)
                    {
                        _lidars.Add(TempLidar);
                        if (I) _initNames.Add(b, "LiDAR");
                        return false;
                    }
                }

                // Extractor -----------------------------------------------------------------
                if (blockId == "MyObjectBuilder_OxygenGenerator/Extractor")
                {
                    _largeExtractors.Add(b);
                    if (I) _initNames.Add(b, "Extractor");
                    return false;
                }
                if (blockId == "MyObjectBuilder_OxygenGenerator/ExtractorSmall")
                {
                    _smallExtractors.Add(b);
                    if (I) _initNames.Add(b, "Extractor");
                    return false;
                }

                // Antennas -----------------------------------------------------------------
                var TempAntenna = b as IMyRadioAntenna;
                if (TempAntenna != null)
                {
                    _antennas.Add(TempAntenna);
                    if (I) _initNames.Add(b, "Antenna");
                    return false;
                }

                // PBs -----------------------------------------------------------------
                var TempPB = b as IMyProgrammableBlock;
                if (TempPB != null)
                {
                    if (I) _initNames.Add(b, "PB Server");

                    // don't bother checking the RSM pb
                    // for other PBs.
                    if (TempPB == Me) return false;

                    try
                    {
                        if (b.CustomData.Contains("Sigma_Draconis_Expanse_Server "))
                            _pbsEfc.Add(TempPB);
                        else if (b.CustomData.Contains("NavConfig"))
                            _pbsNavOs.Add(TempPB);

                        return false;
                    }
                    catch {} // do nothing, no error here.

                }

                // Projectors -----------------------------------------------------------------
                var TempProjectors = b as IMyProjector;
                if (TempProjectors != null)
                {
                    _projectors.Add(TempProjectors);
                    if (I) _initNames.Add(b, "Projectors");
                    return false;
                }

                // Sensors -----------------------------------------------------------------
                var TempSensor = b as IMySensorBlock;
                if (TempSensor != null)
                {
                    _sensors.Add(TempSensor);
                    if (I) _initNames.Add(b, "Sensor");
                    return false;
                }

                // Collector -----------------------------------------------------------------
                var TempCollectors = b as IMyCollector;
                if (TempCollectors != null)
                {
                    addInventory(b);
                    if (I) _initNames.Add(b, "Collector");
                    return false;
                }

                // Welders -----------------------------------------------------------------

                if (blockId.Contains("Welder"))
                {
                    //if (_d) Echo(b.CustomName);
                    _welders.Add(b);
                    if (I) _initNames.Add(b, "Tool" + _nameDelimiter + "Welder");
                    return false;
                }

                // INIT CHECKS ONLY -----------------------------------------------------------------
                // blocks which are not iterated over later
                // only need to be processed at init.

                if (I)
                {
                    if (blockId.Contains("LandingGear/"))
                    {
                        if (blockId.Contains("Clamp")) _initNames.Add(b, "Clamp");
                        else if (blockId.Contains("Magnetic")) _initNames.Add(b, "Mag Lock");
                        else _initNames.Add(b, "Gear");
                        return false;
                    }

                    if (blockId.Contains("Drill"))
                    {
                        _initNames.Add(b, "Tool" + _nameDelimiter + "Drill");
                        return false;
                    }

                    if (blockId.Contains("Grinder"))
                    {
                        _initNames.Add(b, "Tool" + _nameDelimiter + "Grinder");
                        return false;
                    }

                    if (blockId.Contains("Solar"))
                    {
                        _initNames.Add(b, "Solar");
                        return false;
                    }

                    if (blockId.Contains("ButtonPanel"))
                    {
                        _initNames.Add(b, "Button Panel");
                        return false;
                    }

                    var TempSorter = b as IMyConveyorSorter;
                    if (TempSorter != null)
                    {
                        _initNames.Add(b, "Sorter");
                        return false;
                    }

                    var TempSuspension = b as IMyMotorSuspension;
                    if (TempSuspension != null)
                    {
                        _initNames.Add(b, "Suspension");
                        return false;
                    }

                    var TempGravs = b as IMyGravityGenerator;
                    if (TempGravs != null)
                    {
                        _initNames.Add(b, "Grav Gen");
                        return false;
                    }

                    var TempTimer = b as IMyTimerBlock;
                    if (TempTimer != null)
                    {
                        _initNames.Add(b, "Timer");
                        return false;
                    }

                    var TempEngine = b as IMyGasGenerator;
                    if (TempEngine != null)
                    {
                        _initNames.Add(b, "H2 Engine");
                        return false;
                    }

                    var TempBeacon = b as IMyBeacon;
                    if (TempBeacon != null)
                    {
                        _initNames.Add(b, "Beacon");
                        return false;
                    }

                    // catch all for blocks types without overrides.
                    _initNames.Add(b, b.DefinitionDisplayNameText);
                }

                // and we're done
                return false;
            }
            catch (Exception Ex)
            {
                if (_d)
                {
                    Echo("Failed to sort " + b.CustomName + "\nAdded " + _initNames.Count + " so far.");
                    Echo(Ex.Message);
                }
                return false;
            }
        }

        void clearBlockLists() 
        {
            _shipController = null;

            // General Block Lists
            _antennas.Clear();
            _batteries.Clear();
            _cameras.Clear();
            _cargos.Clear();
            _connectors.Clear();
            _controllers.Clear();
            _doors.Clear();
            _airlocks.Clear();
            _hangarDoors.Clear();
            _largeExtractors.Clear();
            _smallExtractors.Clear();
            _gyroscopes.Clear();
            _projectors.Clear();
            _reactors.Clear();   
            _sensors.Clear();
            _h2Tanks.Clear();
            _o2Tanks.Clear();
            _vents.Clear();
            _welders.Clear();

            // Weapons Lists
            _lidars.Clear();
            _normalPdcs.Clear();
            _defensivePdcs.Clear();
            _kineticWeapons.Clear();
            _torpedoLaunchers.Clear();

            // Thruster Lists
            _epsteinThrusters.Clear();
            _rcsThrusters.Clear();
            _chemicalThrusters.Clear();
            _atmoThrusters.Clear();

            // PB Lists
            _pbsEfc.Clear();
            _pbsNavOs.Clear();

            // LCD Lists
            _allLcds.Clear();
            _rsmLcds.Clear();
            _colourSyncLcds.Clear();

            // Light Lists
            _exteriorLights.Clear();
            _interiorLights.Clear();
            _portNavLights.Clear();
            _starboardNavLights.Clear();
            _spotlights.Clear();

            // Aux List
            _auxiliaries.Clear();

            // Cargo Inventories
            foreach (var Item in _items)
                Item.Inventories.Clear();
            

            // Init Names List
            if (I) _initNames.Clear();
            // built if I = true
        }

        bool sortPDC(IMyTerminalBlock b, string init, int ammo)
        {

            // sort _normalPdcs from _defensivePdcs
            if (b.CustomName.Contains(_keywordDefPdcs))
                _defensivePdcs.Add(b);
            else
                _normalPdcs.Add(b);

            addInventory(b, ammo);

            // if we're running init
            // setup the block naming...
            if (I)
            {
                string append = "";
                if (_appendWeaponTypes) append = _nameDelimiter + init;
                _initNames.Add(b, "PDC" + append);
            }

            return false;
        }


        bool sortTorp(IMyTerminalBlock b, string init)
        {
            // add to the main list.
            _torpedoLaunchers.Add(b);

            // we add torps to inventory as we iterate them later
            // because ammo types can change.

            // if we're running init
            // setup the block naming...
            if (I)
            {
                string Append = "";
                if (_appendWeaponTypes) Append = _nameDelimiter + init;
                _initNames.Add(b, "Torpedo" + Append);
            }

            return false;
        }

        bool sortRail(IMyTerminalBlock b, string init, int ammo)
        {

            _kineticWeapons.Add(b);

            addInventory(b, ammo);

            // if we're running init
            // setup the block naming...
            if (I)
            {
                string Append = "";
                if (_appendWeaponTypes) Append = _nameDelimiter + init;
                _initNames.Add(b, "Railgun" + Append);
            }

            return false;
        }

        RsmLcd sortRsmLcd(RsmLcd lcd, string hudLcdSafe = "")
        {
            bool
                attemptParse = hudLcdSafe == "",
                resetConfig = !attemptParse;

            string
                toParse = lcd.Block.CustomData,
                sec =  "RSM.LCD";

            string[] toParseLines = null;

            MyIni config = new MyIni();
            MyIniParseResult result;

            // if we're not parsing
            // we want to reset custom data
            if (!attemptParse) resetConfig = true;
            else
            {
                // legacy custom data
                if (toParse.Substring(0, 12) == "Show Header=")
                {
                    try // attempt legacy parse
                    {
                        toParseLines = toParse.Split('\n');

                        foreach (string line in toParseLines)
                        {
                            // split like this bc hudXlcd
                            if (line.Contains("hud"))
                            {
                                if (line.Contains("lcd"))
                                {
                                    // found the hudlcd string
                                    hudLcdSafe = line;
                                    break;
                                }
                            }
                            else if (line.Contains("="))
                            {
                                string[] Parsed = line.Split('=');

                                if (Parsed[0] == "Show Tanks & Batteries")
                                    lcd.ShowPowerAndTanks = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show header" || Parsed[0] == "Show Header")
                                    lcd.ShowHeader = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show Header Overlay")
                                    lcd.ShowHeaderOverlay = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show Warnings")
                                    lcd.ShowWarnings = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show Inventory")
                                    lcd.ShowInventory = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show Thrust")
                                    lcd.ShowThrust = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show Subsystem Integrity")
                                    lcd.ShowIntegrity = bool.Parse(Parsed[1]);

                                else if (Parsed[0] == "Show Advanced Thrust")
                                    lcd.ShowAdvancedThrust = bool.Parse(Parsed[1]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (_d) Echo("Failed to parse legacy config.\n" + ex.Message);
                        resetConfig = true;
                        // oh well, we tried.
                    }
                }


                else if (!config.TryParse(toParse, out result))
                {
                    // parse failed

                    // we want to reset the custom data
                    resetConfig = true;
                }
                else
                {
                    // parse worked, get values
                    lcd.ShowHeader =            config.Get(sec, "ShowHeader").ToBoolean(            lcd.ShowHeader);
                    lcd.ShowHeaderOverlay =     config.Get(sec, "ShowHeaderOverlay").ToBoolean(     lcd.ShowHeaderOverlay);
                    lcd.ShowWarnings =          config.Get(sec, "ShowWarnings").ToBoolean(          lcd.ShowWarnings);
                    lcd.ShowPowerAndTanks =     config.Get(sec, "ShowPowerAndTanks").ToBoolean(     lcd.ShowPowerAndTanks);
                    lcd.ShowInventory =         config.Get(sec, "ShowInventory").ToBoolean(         lcd.ShowInventory);
                    lcd.ShowThrust =            config.Get(sec, "ShowThrust").ToBoolean(            lcd.ShowThrust);
                    lcd.ShowIntegrity =         config.Get(sec, "ShowIntegrity").ToBoolean(         lcd.ShowIntegrity);
                    lcd.ShowAdvancedThrust =    config.Get(sec, "ShowAdvancedThrust").ToBoolean(    lcd.ShowAdvancedThrust);
                }
            }

            // header, or overlay
            // can't be both bro.
            if (lcd.ShowHeader && lcd.ShowHeaderOverlay) 
            {
                // save it
                lcd.ShowHeader = false;
                resetConfig = true;
            }
                

            if (resetConfig)
            {
                // failed to parse, so lets reset.

                // save the hudlcd component
                if (toParseLines == null)
                    toParseLines = toParse.Split('\n');

                config.Set(sec, "ShowHeader", lcd.ShowHeader);
                config.Set(sec, "ShowHeaderOverlay", lcd.ShowHeaderOverlay);
                config.Set(sec, "ShowWarnings", lcd.ShowWarnings);
                config.Set(sec, "ShowPowerAndTanks", lcd.ShowPowerAndTanks);
                config.Set(sec, "ShowInventory", lcd.ShowInventory);
                config.Set(sec, "ShowThrust", lcd.ShowThrust);
                config.Set(sec, "ShowIntegrity", lcd.ShowIntegrity);
                config.Set(sec, "ShowAdvancedThrust", lcd.ShowAdvancedThrust);
                config.Set(sec, "Hud", hudLcdSafe);

                lcd.Block.CustomData = config.ToString();

                // only throw an alert during the block building process
                if (attemptParse)
                    _alerts.Add(new Alert(
                        "LCD CONFIG ERROR!!",
                        "Failed to parse LCD config for " + lcd.Block.CustomName + "!\nLCD config was reset!",
                        3
                        ));
            }

            return lcd;
        }
    }
}
