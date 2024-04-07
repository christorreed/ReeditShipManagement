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
        class Stance
        {
            public string Inherits = "";
            public ToggleModes TorpedoMode;
            public PdcModes PdcMode;
            public RailgunModes RailgunMode;
            public MainDriveModes MainDriveMode;
            public ManeuveringThrusterModes ManeuveringThrusterMode;
            public SpotlightModes SpotlightMode;
            public LightToggleModes ExteriorLightMode;
            public Color ExteriorLightColour;
            public LightToggleModes InteriorLightMode;
            public Color InteriorLightColour;
            public LightToggleModes NavLightMode;
            public Color LcdTextColour;
            public TankAndBatteryModes TankAndBatteryMode;
            public int BurnPercentage;
            public ToggleModes EfcBoost;
            public KillOrAbortNavigationModes KillOrAbortNavigation;
            public ToggleModes AuxMode;
            public ExtractorModes ExtractorMode;
            public ToggleModes KeepAlives;
            public HangarDoorModes HangarDoorsMode;
        }

        // the name of the current stance.
        string _currentStanceName = "N/A";

        // the actual stance object
        Stance _currentStance;

        // default stance mode values
        // strings so they can be used as default values
        // by the MyIni parser
        ToggleModes _defaultTorpedoMode = ToggleModes.On;
        PdcModes _defaultPdcMode = PdcModes.Offence;
        RailgunModes _defaultRailgunMode = RailgunModes.OpenFire;
        MainDriveModes _defaultMainDriveMode = MainDriveModes.On;
        ManeuveringThrusterModes _defaultManeuveringThrusterMode = ManeuveringThrusterModes.On;
        SpotlightModes _defaultSpotlightMode = SpotlightModes.On;
        LightToggleModes _defaultExteriorLightMode = LightToggleModes.On;
        Color _defaultExteriorLightColour = new Color(33, 144, 255, 255); // reedit blue
        LightToggleModes _defaultInteriorLightMode = LightToggleModes.On;
        Color _defaultInteriorLightColour = new Color(255, 214, 170, 255); // 100W Tungsten
        LightToggleModes _defaultNavLightMode = LightToggleModes.On;
        Color _defaultLcdTextColour = new Color(33, 144, 255, 255); // reedit blue
        TankAndBatteryModes _defaultTankAndBatteryMode = TankAndBatteryModes.Auto;
        int _defaultBurnPercentage = -1; // no change
        ToggleModes _defaultEfcBoost = ToggleModes.NoChange;
        KillOrAbortNavigationModes _defaultKillOrAbortNavigation = KillOrAbortNavigationModes.NoChange;
        ToggleModes _defaultAuxMode = ToggleModes.NoChange;
        ExtractorModes _defaultExtractorMode = ExtractorModes.KeepFull;
        ToggleModes _defaultKeepAlives = ToggleModes.On;
        HangarDoorModes _defaultHangarDoorMode = HangarDoorModes.NoChange;


        void setStance(string stance)
        {
            Stance newStance;

            if (!_stances.TryGetValue(stance, out newStance))
            {
                // the key isn't in the dictionary.
                ALERTS.Add(new ALERT(
                    "NO SUCH STANCE!",
                    "A command was ignored because the provided stance doens't exist. Stance names are case sensitive!"
                    , 3
                    ));
                return;
            }

            if (_d) Echo("Setting stance '" + stance + "'.");

            // set the main stance vars
            _currentStance = newStance;
            _currentStanceName = stance;

            // update config
            setSystemData();

            // set rails
            if (_d) Echo("Setting " + _kineticWeapons.Count + " railguns to " + _currentStance.RailgunMode);
            setRails(_currentStance.RailgunMode);

            // set torps
            if (_d) Echo("Setting " + _torpedoLaunchers.Count + " torpedoes to " + _currentStance.TorpedoMode);
            setTorpedoes(_currentStance.TorpedoMode);

            // set pdcs
            if (_d) Echo("Setting " + _normalPdcs.Count + " _normalPdcs, " + _defensivePdcs.Count + " defence _normalPdcs to " + _currentStance.PdcMode);
            setPdcs(_currentStance.PdcMode);

            // set main drives
            if (_d) Echo(
                "Setting "
                + _epsteinThrusters.Count + " epsteins, "
                + _chemicalThrusters.Count + " chems" + " to " + _currentStance.MainDriveMode);
            setMainThrusters(_currentStance.MainDriveMode, _currentStance.ManeuveringThrusterMode);

            // set RCS
            if (_d) Echo(
                "Setting "
                + _rcsThrusters.Count + " rcs, "
                + _atmoThrusters.Count + " atmos" + " to " + _currentStance.ManeuveringThrusterMode);
            setRcsThrusters(_currentStance.ManeuveringThrusterMode);

            // set batteries
            if (_d) Echo("Setting " + _batteries.Count + " batteries to = " + _currentStance.TankAndBatteryMode);
            setBatteries(_currentStance.TankAndBatteryMode);

            // set h2 tanks
            if (_d) Echo("Setting " + _h2Tanks.Count + " H2 tanks to stockpile = " + _currentStance.TankAndBatteryMode);
            setH2Tanks(_currentStance.TankAndBatteryMode);

            // set o2 tanks
            if (_d) Echo("Setting " + _o2Tanks.Count + " O2 tanks to stockpile = " + _currentStance.TankAndBatteryMode);
            setO2Tanks(_currentStance.TankAndBatteryMode);

            // set lighting
            if (_disableLightingControl)
            {
                if (_d) Echo("No lighting was set because lighting control is disabled.");
            }
            else
            {
                // set spotlights
                if (_d) Echo("Setting " + _spotlights.Count + " spotlights to " + _currentStance.SpotlightMode);
                setSpotlights(_currentStance.SpotlightMode);

                // set exterior lights
                if (_d) Echo("Setting " + _exteriorLights.Count + " exterior lights to " + _currentStance.ExteriorLightMode);

                setExteriorLights(_currentStance.ExteriorLightMode, _currentStance.ExteriorLightColour);

                // set nav lights
                if (_d) Echo("Setting " + _interiorLights.Count + " exterior lights to " + _currentStance.InteriorLightMode);
                setInteriorLights(_currentStance.InteriorLightMode, _currentStance.InteriorLightColour);

                if (_d) Echo(
                    "Setting "
                    + _portNavLights.Count + " port nav lights, "
                    + _starboardNavLights.Count + " starboard nav lights to " + _currentStance.NavLightMode);
                setNavLights(_currentStance.NavLightMode);

            }

            // set aux
            if (_d) Echo("Setting " + _auxiliaries.Count + " aux block to " + _currentStance.AuxMode);
            setAuxiliaries(_currentStance.AuxMode);

            // set extractors
            if (_d) Echo("Setting " + _largeExtractors.Count + " extrators to " + _currentStance.ExtractorMode);
            setExtractors(_currentStance.ExtractorMode);

            // set hangar doors
            if (_d) Echo("Setting " + _hangarDoors.Count + " hangar doors units to " + _currentStance.HangarDoorsMode);
            setHangarDoors(_currentStance.HangarDoorsMode);

            // lock doors if we're in close combat
            // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
            if (_currentStance.RailgunMode == RailgunModes.OpenFire)
            {
                if (_d) Echo("Setting " + _doors.Count + " doors to locked because we are in combat (rails set to open fire).");
                setDoorsLock("locked", "");
            }

            // colour sync for non RSM _allLcds
            syncLcdColours();

            // prep pb commands

            // this one first bc it's most important.
            // NavOs/Efc Abort/Kill
            if (_currentStance.KillOrAbortNavigation == KillOrAbortNavigationModes.Abort)
            {
                addPbServerCommand("Off", "EFC");
                addPbServerCommand("Abort", "NavOS");
            }
            
            // NavOs/Efc Burn
            if (_currentStance.BurnPercentage > 0)
            {
                addPbServerCommand("Set Burn " + _currentStance.BurnPercentage, "EFC");
                addPbServerCommand("Thrust Set " + _currentStance.BurnPercentage/100, "NavOS");
            }

            // Efc Boost
            if (_currentStance.EfcBoost == ToggleModes.On)
                addPbServerCommand("Boost On", "EFC");
            else if (_currentStance.EfcBoost == ToggleModes.Off)
                addPbServerCommand("Boost Off", "EFC");

            if (_d) Echo("Finished setting stance.");
        }
    
    }


}
