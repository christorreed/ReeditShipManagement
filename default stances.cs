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
        Dictionary<string, Stance> _stances = new Dictionary<string, Stance>();

        void buildDefaultStance()
        {
            _stances = new Dictionary<string, Stance>
            {
                {
                    "Cruise",
                    new Stance{
                        TorpedoMode = ToggleModes.On,
                        PdcMode = PdcModes.AllDefence,
                        RailgunMode = RailgunModes.HoldFire,
                        MainDriveMode = MainDriveModes.EpsteinOnly,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.ForwardOff,
                        SpotlightMode = SpotlightModes.Off,
                        ExteriorLightMode = LightToggleModes.On,
                        ExteriorLightColour = new Color(33, 144, 255, 255),
                        InteriorLightMode = LightToggleModes.On,
                        InteriorLightColour = new Color(255, 214, 170, 255),
                        LcdTextColour = new Color(33, 144, 255, 255),
                        TankAndBatteryMode = TankAndBatteryModes.Auto,
                        BurnPercentage = 50,
                        EfcBoost = ToggleModes.NoChange,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.Abort,
                        AuxMode = ToggleModes.NoChange,
                        ExtractorMode = ExtractorModes.KeepFull,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                },
                {
                    "StealthCruise",
                    new Stance{
                        Inherits = "Cruise", 
                        MainDriveMode = MainDriveModes.Minimum,
                        ExteriorLightMode = LightToggleModes.Off,
                        ExteriorLightColour = new Color(0, 0, 0, 255),
                        InteriorLightColour = new Color(23, 73, 186, 255),
                        LcdTextColour = new Color(23, 73, 186, 255),
                        BurnPercentage = 5,
                        EfcBoost = ToggleModes.Off,

                    }
                },
                {
                    "Docked",
                    new Stance{
                        TorpedoMode = ToggleModes.On,
                        PdcMode = PdcModes.AllDefence,
                        RailgunMode = RailgunModes.HoldFire,
                        MainDriveMode = MainDriveModes.Off,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.Off,
                        SpotlightMode = SpotlightModes.Off,
                        ExteriorLightMode = LightToggleModes.On,
                        ExteriorLightColour = new Color(33, 144, 255, 255),
                        InteriorLightMode = LightToggleModes.On,
                        InteriorLightColour = new Color(255, 240, 225, 255),
                        NavLightMode = LightToggleModes.On,
                        LcdTextColour = new Color(255, 255, 255, 255),
                        TankAndBatteryMode = TankAndBatteryModes.StockpileRecharge,
                        BurnPercentage = -1,
                        EfcBoost = ToggleModes.NoChange,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.Abort,
                        AuxMode = ToggleModes.Off,
                        ExtractorMode = ExtractorModes.On,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                },
                {
                    "Docking",
                    new Stance{
                        TorpedoMode = ToggleModes.On,
                        PdcMode = PdcModes.AllDefence,
                        RailgunMode = RailgunModes.HoldFire,
                        MainDriveMode = MainDriveModes.Off,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.On,
                        SpotlightMode = SpotlightModes.OnMax,
                        ExteriorLightMode = LightToggleModes.On,
                        ExteriorLightColour = new Color(33, 144, 255, 255),
                        InteriorLightMode = LightToggleModes.On,
                        InteriorLightColour = new Color(212, 170, 83, 255),
                        NavLightMode = LightToggleModes.On,
                        LcdTextColour = new Color(212, 170, 83, 255),
                        TankAndBatteryMode = TankAndBatteryModes.Auto,
                        BurnPercentage = -1,
                        EfcBoost = ToggleModes.NoChange,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.Abort,
                        AuxMode = ToggleModes.Off,
                        ExtractorMode = ExtractorModes.KeepFull,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                },
                {
                    "NoAttack",
                    new Stance{
                        TorpedoMode = ToggleModes.Off,
                        PdcMode = PdcModes.Off,
                        RailgunMode = RailgunModes.Off,
                        MainDriveMode = MainDriveModes.On,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.On,
                        SpotlightMode = SpotlightModes.Off,
                        ExteriorLightMode = LightToggleModes.On,
                        ExteriorLightColour = new Color(255, 255, 255, 255),
                        InteriorLightMode = LightToggleModes.On,
                        InteriorLightColour = new Color(84, 157, 82, 255),
                        NavLightMode = LightToggleModes.NoChange,
                        LcdTextColour = new Color(84, 157, 82, 255),
                        TankAndBatteryMode = TankAndBatteryModes.NoChange,
                        BurnPercentage = -1,
                        EfcBoost = ToggleModes.NoChange,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.NoChange,
                        AuxMode = ToggleModes.NoChange,
                        ExtractorMode = ExtractorModes.KeepFull,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                },
                {
                    "Combat",
                    new Stance{
                        TorpedoMode = ToggleModes.On,
                        PdcMode = PdcModes.AllDefence,
                        RailgunMode = RailgunModes.OpenFire,
                        MainDriveMode = MainDriveModes.On,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.On,
                        SpotlightMode = SpotlightModes.Off,
                        ExteriorLightMode = LightToggleModes.Off,
                        ExteriorLightColour = new Color(0, 0, 0, 255),
                        InteriorLightMode = LightToggleModes.On,
                        InteriorLightColour = new Color(210, 98, 17, 255),
                        NavLightMode = LightToggleModes.On,
                        LcdTextColour = new Color(210, 98, 17, 255),
                        TankAndBatteryMode = TankAndBatteryModes.Discharge,
                        BurnPercentage = 100,
                        EfcBoost = ToggleModes.On,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.Abort,
                        AuxMode = ToggleModes.On,
                        ExtractorMode = ExtractorModes.KeepFull,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                },
                {
                    "CQB",
                    new Stance{
                        TorpedoMode = ToggleModes.On,
                        PdcMode = PdcModes.Offence,
                        RailgunMode = RailgunModes.OpenFire,
                        MainDriveMode = MainDriveModes.On,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.On,
                        SpotlightMode = SpotlightModes.Off,
                        ExteriorLightMode = LightToggleModes.Off,
                        ExteriorLightColour = new Color(0, 0, 0, 255),
                        InteriorLightMode = LightToggleModes.On,
                        InteriorLightColour = new Color(243, 18, 18, 255),
                        NavLightMode = LightToggleModes.On,
                        LcdTextColour = new Color(243, 18, 18, 255),
                        TankAndBatteryMode = TankAndBatteryModes.Discharge,
                        BurnPercentage = 100,
                        EfcBoost = ToggleModes.On,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.Abort,
                        AuxMode = ToggleModes.On,
                        ExtractorMode = ExtractorModes.KeepFull,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                },
                {
                    "WeaponsHot",
                    new Stance{
                        TorpedoMode = ToggleModes.On,
                        PdcMode = PdcModes.Offence,
                        RailgunMode = RailgunModes.OpenFire,
                        MainDriveMode = MainDriveModes.NoChange,
                        ManeuveringThrusterMode = ManeuveringThrusterModes.NoChange,
                        SpotlightMode = SpotlightModes.NoChange,
                        ExteriorLightMode = LightToggleModes.NoChange,
                        ExteriorLightColour = new Color(0, 0, 0, 255),
                        InteriorLightMode = LightToggleModes.NoChange,
                        InteriorLightColour = new Color(243, 18, 18, 255),
                        NavLightMode = LightToggleModes.NoChange,
                        LcdTextColour = new Color(243, 18, 18, 255),
                        TankAndBatteryMode = TankAndBatteryModes.Discharge,
                        BurnPercentage = -1,
                        EfcBoost = ToggleModes.NoChange,
                        KillOrAbortNavigation = KillOrAbortNavigationModes.NoChange,
                        AuxMode = ToggleModes.NoChange,
                        ExtractorMode = ExtractorModes.KeepFull,
                        KeepAlives = ToggleModes.On,
                        HangarDoorsMode = HangarDoorModes.NoChange
                    }
                }
            };
        }
    






        // these are default values that will be over written by updateCustomData();
        /*List<string> _stanceNames = new List<string>(new string[] { 
            "Cruise", 
            //"MaxCruise", 
            "Docked", 
            "Docking", 
            "NoAttack",
            //"Coast", 
            "Combat", 
            "CQB", 
            //"Sleep", 
            "StealthCruise",
            "WeaponsHot"
        });*/

        /*
        List<int[]> _stances = new List<int[]>
        {
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
            },

            new int[] { // MaxCruise
                1,      // 0: torpedoes; 0: off, 1: on;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                2,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5:  spotlights; 0: off, 1: on, 2: on max radius
                1,      // 6: exterior lights; 0: off, 1: on
                30,     // 7: Red - Exterior lights colour
                144,    // 8: Green - Exterior lights colour
                255,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                36,     // 12: Red - Interior lights colour
                69,     // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                1,      // 17: EFC boost; 0: off, 1: on
                5,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Docked 1
                1,      // 0: torpedoes; 0: off, 1: on;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                0,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                1,      // 6: exterior lights; 0: off, 1: on
                30,     // 7: Red - Exterior lights colour
                144,    // 8: Green - Exterior lights colour
                255,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                255,    // 12: Red - Interior lights colour
                240,    // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                1,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: auxiliary blocks; 0: off, 1: on
                0,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Docking 2
                1,      // 0: torpedoes; 0: off, 1: on;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                1,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                2,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                1,      // 6: exterior lights; 0: off, 1: on
                30,     // 7: Red - Exterior lights colour
                144,    // 8: Green - Exterior lights colour
                255,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                212,    // 12: Red - Interior lights colour
                170,    // 13: Green - Interior lights colour
                83,     // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // NoAttack 3
                0,      // 0: torpedoes; 0: off, 1: on;
                0,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                0,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                1,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                1,      // 6: exterior lights; 0: off, 1: on
                255,    // 7: Red - Exterior lights colour
                255,    // 8: Green - Exterior lights colour
                255,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                255,    // 12: Red - Interior lights colour
                255,    // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Coast
                1,      // 0: torpedoes; 0: off, 1: on;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                0,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,      // 7: Red - Exterior lights colour
                0,      // 8: Green - Exterior lights colour
                0,      // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                33,     // 12: Red - Interior lights colour
                144,    // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                50,     // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: auxiliary blocks; 0: off, 1: on
                0,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },


            new int[] { // Combat 4
                1,      // 0: torpedoes; 0: off, 1: on;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                2,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                1,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,      // 7: Red - Exterior lights colour
                0,      // 8: Green - Exterior lights colour
                0,      // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                210,    // 12: Red - Interior lights colour
                98,     // 13: Green - Interior lights colour
                17,     // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                2,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                1,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // CQB 5
                1,      // 0: torpedoes; 0: off, 1: on;
                3,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                2,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                1,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,      // 7: Red - Exterior lights colour
                0,      // 8: Green - Exterior lights colour
                0,      // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                243,    // 12: Red - Interior lights colour
                18,     // 13: Green - Interior lights colour
                18,     // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                2,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                1,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Sleep
                0,      // 0: torpedoes; 0: off, 1: on;
                0,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                0,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                0,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,      // 7: Red - Exterior lights colour
                0,      // 8: Green - Exterior lights colour
                0,      // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                255,    // 12: Red - Interior lights colour
                240,    // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                15,     // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: auxiliary blocks; 0: off, 1: on
                0,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                2,      // 22: keep-alives for connectors, gyros, lcds; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // StealthCruise 6
                1,      // 0: torpedoes; 0: off, 1: on;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                2,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5:  spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,     // 7: Red - Exterior lights colour
                0,    // 8: Green - Exterior lights colour
                0,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                23,     // 12: Red - Interior lights colour
                73,    // 13: Green - Interior lights colour
                186,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                2,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC
                0,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, gyros, lcds; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // WeaponsHot 7
                1,      // 0: torpedoes; 0: off, 1: on;
                3,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only
                2,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                9,      // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
                9,      // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,      // 7: Red - Exterior lights colour
                0,      // 8: Green - Exterior lights colour
                0,      // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                243,    // 12: Red - Interior lights colour
                18,     // 13: Green - Interior lights colour
                18,     // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                2,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                1,      // 20: auxiliary blocks; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for reactors, connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },
        };
        */
    }
}
