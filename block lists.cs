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
        IMyShipController CONTROLLER;

        // General Block Lists
        private List<IMyRadioAntenna> ANTENNAs = new List<IMyRadioAntenna>();
        private List<IMyBatteryBlock> BATTERIEs = new List<IMyBatteryBlock>();
        private List<IMyCameraBlock> CAMERAs = new List<IMyCameraBlock>();
        private List<IMyCargoContainer> CARGOs = new List<IMyCargoContainer>();
        private List<IMyShipConnector> CONNECTORs = new List<IMyShipConnector>();
        private List<IMyShipController> CONTROLLERs = new List<IMyShipController>();
        private List<IMyDoor> DOORs = new List<IMyDoor>();
        private List<IMyAirtightHangarDoor> DOORs_HANGAR = new List<IMyAirtightHangarDoor>();
        private List<IMyTerminalBlock> EXTRACTORs = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> EXTRACTORs_SMALL = new List<IMyTerminalBlock>();
        private List<IMyGyro> GYROs = new List<IMyGyro>();
        private List<IMyProjector> PROJECTORs = new List<IMyProjector>();
        private List<IMyReactor> REACTORs = new List<IMyReactor>();
        private List<IMySensorBlock> SENSORs = new List<IMySensorBlock>();
        private List<IMyGasTank> TANKs_H2 = new List<IMyGasTank>();
        private List<IMyGasTank> TANKs_O2 = new List<IMyGasTank>();
        private List<IMyAirVent> VENTs = new List<IMyAirVent>();
        private List<IMyAirVent> VENTs_AIRLOCKS = new List<IMyAirVent>();
        private List<IMyTerminalBlock> WELDERs = new List<IMyTerminalBlock>();

        // Weapons Lists
        private List<IMyConveyorSorter> LIDARs = new List<IMyConveyorSorter>();
        private List<IMyTerminalBlock> PDCs = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> PDCs_DEF = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> RAILs = new List<IMyTerminalBlock>();
        private List<IMyTerminalBlock> TORPs = new List<IMyTerminalBlock>();

        // Thruster Lists
        private List<IMyThrust> THRUSTERs_EPSTEIN = new List<IMyThrust>();
        private List<IMyThrust> THRUSTERs_RCS = new List<IMyThrust>();
        private List<IMyThrust> THRUSTERs_CHEM = new List<IMyThrust>();
        private List<IMyThrust> THRUSTERs_ATMO = new List<IMyThrust>();

        // PB Lists
        private List<IMyProgrammableBlock> PBs_EFC = new List<IMyProgrammableBlock>();
        private List<IMyProgrammableBlock> PBs_NAVOS = new List<IMyProgrammableBlock>();

        // LCD Lists
        private List<IMyTextPanel> LCDs = new List<IMyTextPanel>();
        private List<IMyTextPanel> LCDs_RSM = new List<IMyTextPanel>();
        private List<IMyTextPanel> LCDs_CS = new List<IMyTextPanel>();

        // Light Lists
        private List<IMyLightingBlock> LIGHTs_EXTERIOR = new List<IMyLightingBlock>();
        private List<IMyLightingBlock> LIGHTs_INTERIOR = new List<IMyLightingBlock>();
        private List<IMyLightingBlock> LIGHTs_NAV_PORT = new List<IMyLightingBlock>();
        private List<IMyLightingBlock> LIGHTs_NAV_STARBOARD = new List<IMyLightingBlock>();
        private List<IMyReflectorLight> LIGHTs_SPOT = new List<IMyReflectorLight>();

        // Aux List
        private List<IMyTerminalBlock> AUXILIARIEs = new List<IMyTerminalBlock>();

        // INIT
        private bool I = false;
        // set to true during an init.

        // Init Names List
        private Dictionary<IMyTerminalBlock, string> INIT_NAMEs = new Dictionary<IMyTerminalBlock, string>();
        // built if I = true

        private bool sortBlockLists(IMyTerminalBlock b) 
        {
            // this function sorts each block into the appropriate list.
            // it will always return false
            // it will also build the INIT_NAMEs dictionary in the case that I = true

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
                    UNOWNED_BLOCKS++;
                    return false;
                }

                // ship name check.

                if (!I && _requireShipName && !b.CustomName.Contains(_shipName))
                    // if we are not running init
                    // and we _requireShipName
                    // and the ship name isn't included
                    return false; // ignore this block
                
                // grab aux blocks
                if (b.CustomName.Contains(_keywordAuxBlocks))
                    AUXILIARIEs.Add(b);

                //if (_d) Echo("Sorting " + b.CustomName);

                string blockId = b.BlockDefinition.ToString();

                // Spawns -----------------------------------------------------------------

                // Refill Stations
                if (blockId == "MyObjectBuilder_MedicalRoom/LargeRefillStation")
                {
                    if (I) INIT_NAMEs.Add(b, "Refill Station");
                    return false;
                }

                // Medical Rooms
                if (blockId.Contains("MedicalRoom/"))
                {
                    if (_spawnOpen)
                        b.CustomData = _survivalKitOpenData;
                    else
                        b.CustomData = _survivalKitData;

                    if (!b.CustomName.Contains(_keywordIgnore)) b.ApplyAction("OnOff_On");
                    if (I) INIT_NAMEs.Add(b, "Medical Room");
                    return false;
                }

                // Survival Kits
                if (blockId.Contains("SurvivalKit/"))
                {
                    if (_spawnOpen)
                        b.CustomData = _survivalKitOpenData;
                    else
                        b.CustomData = _survivalKitData;

                    if (!b.CustomName.Contains(_keywordIgnore)) b.ApplyAction("OnOff_On");
                    if (I) INIT_NAMEs.Add(b, "Survival Kit");
                    return false;
                }

                // LCDs -----------------------------------------------------------------

                var TempLCD = b as IMyTextPanel;
                if (TempLCD != null)
                {
                    LCDs.Add(TempLCD);

                    if (I) INIT_NAMEs.Add(b, "LCD");

                    if (TempLCD.CustomName.Contains(_keywordRsmLcds))
                        LCDs_RSM.Add(TempLCD);
                    else if (!_disableLcdColourControl && TempLCD.CustomName.Contains(_keywordColourSyncLcds))
                        LCDs_CS.Add(TempLCD);

                    return false;
                }

                // IGNORE KEYWORD CHECK -----------------------------------------------------------------

                // Ignore blocks with the ignore keyword...
                if (b.CustomName.Contains(_keywordIgnore))
                    return false;

                // PDCs -----------------------------------------------------------------

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
                        THRUSTERs_RCS.Add(TempThruster);
                        if (I) INIT_NAMEs.Add(b, "RCS");
                    }
                    else if (blockId.Contains("Hydro"))
                    {
                        THRUSTERs_CHEM.Add(TempThruster);
                        if (I) INIT_NAMEs.Add(b, "Chem");
                    }
                    else if (blockId.Contains("Atmospheric"))
                    {
                        THRUSTERs_ATMO.Add(TempThruster);
                        if (I) INIT_NAMEs.Add(b, "Atmo");
                    }
                    else
                    {
                        THRUSTERs_EPSTEIN.Add(TempThruster);
                        if (I) INIT_NAMEs.Add(b, "Epstein");
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
                        CARGOs.Add(TempCargo);
                        addInventory(b); // check this block for stored items

                        if (I)
                        {
                            double Max = b.GetInventory().MaxVolume.RawValue;
                            double VolumeFactor = Math.Round(Max / 1265625024, 1);
                            if (VolumeFactor == 0) VolumeFactor = 0.1;
                            INIT_NAMEs.Add(b, "Cargo [" + VolumeFactor + "]");
                        }
                        return false;
                    }
                }

                // Gyros -----------------------------------------------------------------
                var TempGyro = b as IMyGyro;
                if (TempGyro != null)
                {
                    GYROs.Add(TempGyro);
                    if (I) INIT_NAMEs.Add(b, "Gyroscope");
                    return false;
                }

                // Batteries -----------------------------------------------------------------
                var TempBatts = b as IMyBatteryBlock;
                if (TempBatts != null)
                {
                    BATTERIEs.Add(TempBatts);
                    if (I) INIT_NAMEs.Add(b, "Battery");
                    return false;
                }

                // Spotlights -----------------------------------------------------------------
                // Must go before Lights.
                var TempSpot = b as IMyReflectorLight;
                if (TempSpot != null)
                {
                    LIGHTs_SPOT.Add(TempSpot);
                    if (I) INIT_NAMEs.Add(b, "Spotlight");
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
                        LIGHTs_INTERIOR.Add(TempLight);
                        if (I) INIT_NAMEs.Add(b, "Light" + _nameDelimiter + "Interior");
                    }

                    // nav lights
                    else if (b.CustomName.Contains(_keywordLightNavigation))
                    {
                        if (b.CustomName.ToUpper().Contains("STARBOARD"))
                        {
                            LIGHTs_NAV_STARBOARD.Add(TempLight);
                            if (I) INIT_NAMEs.Add(b, "Light" + _nameDelimiter + "Nav" + _nameDelimiter + "Starboard");
                        }
                        else
                        {
                            LIGHTs_NAV_PORT.Add(TempLight);
                            if (I) INIT_NAMEs.Add(b, "Light" + _nameDelimiter + "Nav" + _nameDelimiter + "Port");
                        }
                    }

                    // exterior lights
                    else
                    {
                        LIGHTs_EXTERIOR.Add(TempLight);
                        if (I) INIT_NAMEs.Add(b, "Light" + _nameDelimiter + "Exterior");
                    }

                    return false;
                }

                // Tanks -----------------------------------------------------------------
                var TempTank = b as IMyGasTank;
                if (TempTank != null)
                {

                    if (blockId.Contains("Hydro"))
                    {
                        TANKs_H2.Add(TempTank);
                        if (I) INIT_NAMEs.Add(b, "Hydrogen Tank");
                    }
                    else
                    {
                        TANKs_O2.Add(TempTank);
                        if (I) INIT_NAMEs.Add(b, "Oxygen Tank");
                    }
                    return false;
                }


                // Reactors -----------------------------------------------------------------
                var TempReactor = b as IMyReactor;
                if (TempReactor != null)
                {
                    REACTORs.Add(TempReactor);
                    addInventory(b, 0);

                    if (I)
                    {
                        string AppendReactor = "Large";
                        if (blockId.Contains("SmallGenerator"))
                            AppendReactor = "Small";
                        else if (blockId.Contains("MCRN"))
                            AppendReactor = "MCRN";

                        INIT_NAMEs.Add(b, "Reactor" + _nameDelimiter + AppendReactor);
                    }
                    return false;
                }

                // Ship Controllers -----------------------------------------------------------------
                var TempController = b as IMyShipController;
                if (TempController != null)
                {
                    CONTROLLERs.Add(TempController);

                    if (CONTROLLER == null && b.CustomName.Contains("Nav"))
                        CONTROLLER = TempController;

                    if (TempController.HasInventory)
                        addInventory(b);

                    if (I && blockId.Contains("Cockpit/"))
                    {
                        if (blockId.Contains("StandingCockpit") || blockId.Contains("Console"))
                        {
                            INIT_NAMEs.Add(b, "Console");
                            return false;
                        }
                        else if (blockId.Contains("Cockpit"))
                        {
                            INIT_NAMEs.Add(b, "Cockpit");
                            return false;
                        }
                    }
                }

                // Doors -----------------------------------------------------------------
                var TempDoor = b as IMyDoor;
                if (TempDoor != null)
                {
                    DOORs.Add(TempDoor);
                    if (I) INIT_NAMEs.Add(b, "Door");
                    return false;
                }

                // Vents -----------------------------------------------------------------
                var TempVent = b as IMyAirVent;
                if (TempVent != null)
                {
                    VENTs.Add(TempVent);
                    if (b.CustomName.Contains(_keywordAirlock)) VENTs_AIRLOCKS.Add(TempVent);
                    if (I) INIT_NAMEs.Add(b, "Vent");
                    return false;
                }

                // Cameras -----------------------------------------------------------------
                var TempCam = b as IMyCameraBlock;
                if (TempCam != null)
                {
                    CAMERAs.Add(TempCam);
                    if (I) INIT_NAMEs.Add(b, "Camera");
                    return false;
                }

                // Connectors -----------------------------------------------------------------
                var TempConnector = b as IMyShipConnector;
                if (TempConnector != null)
                {
                    CONNECTORs.Add(TempConnector);
                    addInventory(b);

                    if (I)
                    {
                        string ConnectorAppend = "";
                        if (blockId.Contains("Passageway"))
                            ConnectorAppend = _nameDelimiter + "Passageway";
                        INIT_NAMEs.Add(b, "Connector" + ConnectorAppend);
                    }
                    return false;
                }

                // Hangar Doors -----------------------------------------------------------------
                var TempHangars = b as IMyAirtightHangarDoor;
                if (TempHangars != null)
                {
                    DOORs_HANGAR.Add(TempHangars);
                    if (I) INIT_NAMEs.Add(b, "Hangar Door");
                    return false;
                }

                // LiDAR -----------------------------------------------------------------
                if (blockId.Contains("Lidar"))
                {
                    var TempLidar = b as IMyConveyorSorter;
                    if (TempLidar != null)
                    {
                        LIDARs.Add(TempLidar);
                        if (I) INIT_NAMEs.Add(b, "LiDAR");
                        return false;
                    }
                }

                // Extractor -----------------------------------------------------------------
                if (blockId == "MyObjectBuilder_OxygenGenerator/Extractor")
                {
                    EXTRACTORs.Add(b);
                    if (I) INIT_NAMEs.Add(b, "Extractor");
                    return false;
                }
                if (blockId == "MyObjectBuilder_OxygenGenerator/ExtractorSmall")
                {
                    EXTRACTORs_SMALL.Add(b);
                    if (I) INIT_NAMEs.Add(b, "Extractor");
                    return false;
                }

                // Antennas -----------------------------------------------------------------
                var TempAntenna = b as IMyRadioAntenna;
                if (TempAntenna != null)
                {
                    ANTENNAs.Add(TempAntenna);
                    if (I) INIT_NAMEs.Add(b, "Antenna");
                    return false;
                }

                // PBs -----------------------------------------------------------------
                var TempPB = b as IMyProgrammableBlock;
                if (TempPB != null)
                {
                    if (b.CustomName.Contains(KEYWORD_PB_EFC))
                        PBs_EFC.Add(TempPB);
                    else if (b.CustomName.Contains(KEYWORD_PB_NAVOS))
                        PBs_NAVOS.Add(TempPB);
                    if (I) INIT_NAMEs.Add(b, "PB Server");
                    return false;
                }

                // Projectors -----------------------------------------------------------------
                var TempProjectors = b as IMyProjector;
                if (TempProjectors != null)
                {
                    PROJECTORs.Add(TempProjectors);
                    if (I) INIT_NAMEs.Add(b, "Projectors");
                    return false;
                }

                // Sensors -----------------------------------------------------------------
                var TempSensor = b as IMySensorBlock;
                if (TempSensor != null)
                {
                    SENSORs.Add(TempSensor);
                    if (I) INIT_NAMEs.Add(b, "Sensor");
                    return false;
                }

                // Collector -----------------------------------------------------------------
                var TempCollectors = b as IMyCollector;
                if (TempCollectors != null)
                {
                    addInventory(b);
                    if (I) INIT_NAMEs.Add(b, "Collector");
                    return false;
                }

                // Welders -----------------------------------------------------------------

                if (blockId.Contains("Welder"))
                {
                    //if (_d) Echo(b.CustomName);
                    WELDERs.Add(b);
                    if (I) INIT_NAMEs.Add(b, "Welder");
                    return false;
                }

                // INIT CHECKS ONLY -----------------------------------------------------------------
                // blocks which are not iterated over later
                // only need to be processed at init.

                if (I)
                {
                    if (blockId.Contains("LandingGear/"))
                    {
                        if (blockId.Contains("Clamp")) INIT_NAMEs.Add(b, "Clamp");
                        else if (blockId.Contains("Magnetic")) INIT_NAMEs.Add(b, "Mag Lock");
                        else INIT_NAMEs.Add(b, "Gear");
                        return false;
                    }

                    if (blockId.Contains("Drill"))
                    {
                        INIT_NAMEs.Add(b, "Drill");
                        return false;
                    }

                    if (blockId.Contains("Grinder"))
                    {
                        INIT_NAMEs.Add(b, "Grinder");
                        return false;
                    }

                    if (blockId.Contains("Solar"))
                    {
                        INIT_NAMEs.Add(b, "Solar");
                        return false;
                    }

                    if (blockId.Contains("ButtonPanel"))
                    {
                        INIT_NAMEs.Add(b, "Button Panel");
                        return false;
                    }

                    var TempSorter = b as IMyConveyorSorter;
                    if (TempSorter != null)
                    {
                        INIT_NAMEs.Add(b, "Sorter");
                        return false;
                    }

                    var TempSuspension = b as IMyMotorSuspension;
                    if (TempSuspension != null)
                    {
                        INIT_NAMEs.Add(b, "Suspension");
                        return false;
                    }

                    var TempGravs = b as IMyGravityGenerator;
                    if (TempGravs != null)
                    {
                        INIT_NAMEs.Add(b, "Grav Gen");
                        return false;
                    }

                    var TempTimer = b as IMyTimerBlock;
                    if (TempTimer != null)
                    {
                        INIT_NAMEs.Add(b, "Timer");
                        return false;
                    }

                    var TempEngine = b as IMyGasGenerator;
                    if (TempEngine != null)
                    {
                        INIT_NAMEs.Add(b, "H2 Engine");
                        return false;
                    }

                    var TempBeacon = b as IMyBeacon;
                    if (TempBeacon != null)
                    {
                        INIT_NAMEs.Add(b, "Beacon");
                        return false;
                    }

                    // catch all for blocks types without overrides.
                    INIT_NAMEs.Add(b, b.DefinitionDisplayNameText);
                }

                // and we're done
                return false;
            }
            catch (Exception Ex)
            {
                if (_d)
                {
                    Echo("Failed to sort " + b.CustomName + "\nAdded " + INIT_NAMEs.Count + " so far.");
                    Echo(Ex.Message);
                }
                return false;
            }
        }

        private void clearBlockLists() 
        {
            CONTROLLER = null;

            // General Block Lists
            ANTENNAs.Clear();
            BATTERIEs.Clear();
            CAMERAs.Clear();
            CARGOs.Clear();
            CONNECTORs.Clear();
            CONTROLLERs.Clear();
            DOORs.Clear();
            DOORs_HANGAR.Clear();
            EXTRACTORs.Clear();
            EXTRACTORs_SMALL.Clear();
            GYROs.Clear();
            PROJECTORs.Clear();
            REACTORs.Clear();   
            SENSORs.Clear();
            TANKs_H2.Clear();
            TANKs_O2.Clear();
            VENTs.Clear();
            VENTs_AIRLOCKS.Clear();
            WELDERs.Clear();

            // Weapons Lists
            LIDARs.Clear();
            PDCs.Clear();
            PDCs_DEF.Clear();
            RAILs.Clear();
            TORPs.Clear();

            // Thruster Lists
            THRUSTERs_EPSTEIN.Clear();
            THRUSTERs_RCS.Clear();
            THRUSTERs_CHEM.Clear();
            THRUSTERs_ATMO.Clear();

            // PB Lists
            PBs_EFC.Clear();
            PBs_NAVOS.Clear();

            // LCD Lists
            LCDs.Clear();
            LCDs_RSM.Clear();
            LCDs_CS.Clear();

            // Light Lists
            LIGHTs_EXTERIOR.Clear();
            LIGHTs_INTERIOR.Clear();
            LIGHTs_NAV_PORT.Clear();
            LIGHTs_NAV_STARBOARD.Clear();
            LIGHTs_SPOT.Clear();

            // Aux List
            AUXILIARIEs.Clear();

            // Cargo Inventories
            foreach (var Item in ITEMS)
                Item.Inventories.Clear();
            

            // Init Names List
            if (I) INIT_NAMEs.Clear();
            // built if I = true
        }

        private bool sortPDC(IMyTerminalBlock b, string init, int ammo)
        {

            // sort PDCs from PDCs_DEF
            if (b.CustomName.Contains(_keywordDefPdcs))
                PDCs_DEF.Add(b);
            else
                PDCs.Add(b);

            addInventory(b, ammo);

            // if we're running init
            // setup the block naming...
            if (I)
            {
                string Append = "";
                if (_appendWeaponTypes) Append = _nameDelimiter + init;
                INIT_NAMEs.Add(b, "PDC" + Append);
            }

            return false;
        }


        private bool sortTorp(IMyTerminalBlock b, string init)
        {
            // add to the main list.
            TORPs.Add(b);

            // we add torps to inventory as we iterate them later
            // because ammo types can change.

            // if we're running init
            // setup the block naming...
            if (I)
            {
                string Append = "";
                if (_appendWeaponTypes) Append = _nameDelimiter + init;
                INIT_NAMEs.Add(b, "Torpedo" + Append);
            }

            return false;
        }

        private bool sortRail(IMyTerminalBlock b, string init, int ammo)
        {

            RAILs.Add(b);

            addInventory(b, ammo);

            // if we're running init
            // setup the block naming...
            if (I)
            {
                string Append = "";
                if (_appendWeaponTypes) Append = _nameDelimiter + init;
                INIT_NAMEs.Add(b, "Railgun" + Append);
            }

            return false;
        }


        
    }
}
