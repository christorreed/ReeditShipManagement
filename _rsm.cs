using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
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
    partial class Program : MyGridProgram
    {
        #region mdk preserve
        #region mdk macros
        string Version = "1.99.53 ($MDK_DATE$)";
        #endregion
        #endregion

        // StarCpt's Profiler
        // https://github.com/StarCpt/SERuntimeProfiler/blob/main/RuntimeProfiler.cs
        private Profiler _profiler;

        // Loop Counters -----------------------------------------------------------------

        int _stepBoot = 0;
        int _stepWait = 0;
        int _stepOccasional = 0;
        int _stepRare;
        int _stepInit = 0;

        bool _isParsing = true;
        bool _isBooting = true;
        bool _isIniting = false;

        bool _adjustKeepAlives = false;
        bool _adjustKeepAlivesTo = false;

        //IEnumerator<bool> _stateMachine;

        // Warning Variables -----------------------------------------------------------------

        bool _needFuel = false;
        bool _spawnOpen = false;
        bool _spawnsDead = false;
        bool _noExtractor = false;
        bool _noSpareTanks = false;
        int _unownedBlockCount = 0;
        int _activeAuxBlockCount = 0;

        // Misc Globals -----------------------------------------------------------------

        // ship telemetry values
        double _shipVelocity;
        float _shipMass;

        // the faction tag of the PB owner
        string _factionTag;

        // this is the SK custom data string
        // we will build it and force it into SK custom data
        string _survivalKitData;
        string _survivalKitOpenData;

        // this reduces the LCD output build overhead
        // if you are not using an advanced thrust LCD
        bool _buildAdvancedThrust = false;

        // instructions count
        int _instructionsCount = 0;
        // highest instruction count since recompile
        int _maxInstructionsCount = 0;

        // init bools
        bool _initingSubSystems;
        bool _initingInventory;
        bool _initingBlockNames;

        public Program()
        {
            Echo("Welcome to RSM\nV " + Version);
            msSinceLast();

            // this forces a block refresh first.
            _stepRare = _blockRefreshFreq;

            _factionTag = Me.GetOwnerFactionTag();

            _profiler = new Profiler(Runtime);

            buildItemsList();

            // default thrust percentages.
            _decelPercentages.Add(0.5);
            _decelPercentages.Add(0.25);
            _decelPercentages.Add(0.1);
            _decelPercentages.Add(0.05);

            // build some strings that we will use over and over again.
            buildRepeatingStrings();

            Runtime.UpdateFrequency = UpdateFrequency.Update100;

            Echo("Took " + msSinceLast());
        }

        public void Main(string argument, UpdateType updateSource)
        {
            if (updateSource == UpdateType.Update100)
                mainLoop();
            else
                processCommand(argument);
        }

        void processCommand(string argument)
        {
            if (_d) Echo("Processing command '" + argument + "'...");

            if (_isBooting)
            {
                commandFailed(argument, "RSM is still booting");
                return;
            }

            if (_isIniting)
            {
                commandFailed(argument, "RSM is still initialising");
                return;
            }

            if (argument == "")
            {
                commandFailed(argument, "the argument was blank");
                return;
            }

            string[] args = argument.Split(':');

            if (args.Length < 2)
            {
                commandFailed(argument, "the argument wasn't recognised");
                return;
            }

            // removes spaces except for comms commands
            if (args[0].ToLower() != "comms")
                args[1] = args[1].Replace(" ", string.Empty);

            switch (args[0].ToLower())
            {
                case "init":

                    bool nameBlocks = true, setSubSystems = true, setInventory = true;
                    
                    if (args.Length > 2)
                    {
                        foreach (string arg in args)
                        {
                            if (arg.ToLower() == "nonames") nameBlocks = false;
                            else if (arg.ToLower() == "nosubs") setSubSystems = false;
                            else if (arg.ToLower() == "noinv") setInventory = false;
                        }
                    }

                    initShip(args[1], nameBlocks, setSubSystems, setInventory);

                    return;

                case "stance":
                    setStance(args[1]);
                    return;

                case "hudlcd":
                    string hud_filter = "";
                    if (args.Length > 2)
                        hud_filter = args[2];
                    setHudLcd(args[1], hud_filter);
                    return;

                case "doors":
                    string door_filter = "";
                    if (args.Length > 2)
                        door_filter = args[2];
                    setDoorsLock(args[1], door_filter);
                    return;

                case "comms":
                    setAntennaComms(args[1]);
                    return;

                case "printblockids":
                    printBlockIds();
                    return;

                case "printblockprops":
                    printBlockProps(args[1]);
                    return;

                case "spawn":
                    if (args[1].ToLower() == "open")
                    {
                        _spawnOpen = true;

                        // force a block refresh now.
                        _stepRare = _blockRefreshFreq;

                        _alerts.Add(new Alert(
                            "Spawns were opened to friends",
                            "Spawns are now opened to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    else
                    {
                        _spawnOpen = false;

                        // force a block refresh now.
                        _stepRare = _blockRefreshFreq;

                        _alerts.Add(new Alert(
                            "Spawns were closed to friends",
                            "Spawns are now closed to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    return;

                case "projectors":
                    if (args[1].ToLower() == "save")
                    {
                        foreach (IMyProjector Projector in _projectors)
                            saveProjectorPosition(Projector);

                        _alerts.Add(new Alert(
                            "Projector positions saved",
                            "Projector positions were saved and stored to their custom data."
                            , 2
                            ));
                        return;
                    }
                    else
                    {
                        foreach (IMyProjector Projector in _projectors)
                            loadProjectorPosition(Projector);

                        _alerts.Add(new Alert(
                            "Projector positions loaded",
                            "Projector positions were loaded from custom data."
                            , 2
                            ));
                        return;
                    }

                default:
                    commandFailed(argument, "the argument wasn't recognised");
                    return;
            }
        }

        void commandFailed(string argument, string reason)
        {
            _alerts.Add(new Alert(
                "COMMAND FAILED!",
                "Command '" + argument + "' was ignored because " + reason,
                3
                ));
        }

        void mainLoop()
        {
            // if we're profiling
            // set the start time
            // no point logging the first one out
            if (_p) msSinceLast();

            // do we need to wait before we loop?
            if (_stepWait < _loopStallCount)
            {
                _stepWait++;
                return;
            }
            _stepWait = 0;

            // the point of this is to stall the config parsing
            // away from the first tick ie Program()
            // to spread out the startup load
            if (_isParsing)
            {
                Echo("Parsing custom data...");
                prepCustomData();

                _isParsing = false;
                return;
            }
            else if (_isIniting)
            {
                runInitStep();

                // update the _allLcds
                if (_d) Echo("Updating " + _rsmLcds.Count + " RSM Lcds");
                refreshLcds();
            }

            // write to the console.
            isThereAnEchoInHere();

            // get max instruction count.
            _instructionsCount = Runtime.CurrentInstructionCount;
            if (_instructionsCount > _maxInstructionsCount)
                _maxInstructionsCount = Runtime.CurrentInstructionCount;

            // prep keep alives
            // lots of block refreshes use this
            // to determine if to enforce power status on those blocks
            // 22: keep-alives; 0: ignore, 1: force on, 2: force off

            if (_currentStance.KeepAlives == ToggleModes.On)
            {
                _adjustKeepAlives = true;
                _adjustKeepAlivesTo = true;
            }
            else if (_currentStance.KeepAlives == ToggleModes.Off)
            {
                _adjustKeepAlives = true;
            }

            // okay now let's actually do some stuff...

            // what kind of stuff are we going to do?
            if (_stepRare >= _blockRefreshFreq)
            {
                _stepRare = 0;
                doThisStuffRarely();

                // update the _allLcds
                // refreshLcds();
                // removed this for now bc it takes too long

                return;
            }
            _stepRare++;

            // run these things every time
            doThisStuffOften();

            // it actually does the above things one at a time, the first time.
            // ie, it _isBooting.
            // splitting it up like this because SE seems to cache the PB api
            // results, or something like that bc i see much slow results the
            // first time round...

            // we run this method every time as well
            // but it always runs in steps.
            doThisStuffOccasionally();

            if (_p) Echo("Took " + msSinceLast());

            // update the _allLcds
            if (_d) Echo("Updating " + _rsmLcds.Count + " RSM Lcds");
            refreshLcds();

            if (_p) Echo("Took " + msSinceLast());
        }


        void doThisStuffOften()
        {
            // startup WcPbApi
            // needed for refreshRailguns & refreshTorpedoes
            spinUpWcPbApi();

            // booting checks below
            // do each item one at a time,
            // the first time only.

            // this is because performance of these refreshes seems
            // to get much better on subsequent runs
            // due to some kind of caching or something

            switch (_stepBoot)
            {
                case 0:
                    if (_d) Echo("Refreshing " + _kineticWeapons.Count + " railguns...");
                    refreshRailguns();
                    // checks integrity, sets power, gets target status for discharge mgmt

                    if (_p) Echo("Took " + msSinceLast());

                    if (_isBooting) break;
                    else goto case 1;

                case 1:
                    if (_d) Echo("Refreshing " + _reactors.Count + " reactors & " + _batteries.Count + " batteries...");
                    refreshPowerBlocks(_currentStance.TankAndBatteryMode);
                    // checks integrity, sets power on,
                    // calcs power, batt discharge mgmt

                    if (_p) Echo("Took " + msSinceLast());

                    if (_isBooting) break;
                    else goto case 2;

                case 2:
                    if (_d) Echo("Refreshing " + _epsteinThrusters.Count + " epsteins...");
                    refreshMainThrusters();
                    // checks integrity, thrust

                    if (_p) Echo("Took " + msSinceLast());

                    if (_isBooting) break;
                    else goto case 3;

                case 3:
                    if (_d) Echo("Refreshing " + _lidars.Count + " lidars...");
                    refreshLidars(_adjustKeepAlivesTo, _adjustKeepAlives);
                    // checks integrity
                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing pb servers...");
                    refreshPbServers();
                    // checks for buffered commands and sends them
                    if (_p) Echo("Took " + msSinceLast());

                    if (_isBooting) break;
                    else goto case 4;

                case 4:
                    if (_d) Echo("Refreshing " + _doors.Count + " doors...");
                    refreshDoors();
                    // manages doors
                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing " + _airlocks.Count + " airlocks...");
                    refreshAirlocks();
                    // manage airlocks
                    if (_p) Echo("Took " + msSinceLast());

                    break;

                default:
                    if (_d) Echo("Booting complete");
                    _isBooting = false;
                    _stepBoot = 0;

                    return;
            }
            if (_isBooting) _stepBoot++;
        }

        void doThisStuffOccasionally()
        {
            switch (_stepOccasional)
            {
                case 0:
                    if (_d) Echo("Clearing temp inventories...");
                    clearTempInventories();
                    // before we check torps
                    // clear temp inventories from all items...

                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing " + _torpedoLaunchers.Count + " torpedo launchers...");
                    refreshTorpedoes();
                    // checks integrity, sets power, gets torpedo inventories

                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing items...");
                    refreshItems();
                    // count each of the checked items in each inventory

                    if (_p) Echo("Took " + msSinceLast());
                    break;

                case 1:
                    if (_d) Echo("Running autoload...");
                    runAutoLoad();
                    // count each of the checked items in each inventory

                    if (_p) Echo("Took " + msSinceLast());
                    break;

                case 2:
                    if (_d) Echo("Refreshing " + _h2Tanks.Count + " H2 tanks...");
                    refreshH2Tanks();
                    // > priority low
                    // checks integrity, filled ratio

                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing refuel status...");
                    refreshRefuelStatus();
                    // checks if we _needFuel?

                    // if we do...
                    if (_needFuel)
                    {
                        // ...load extractors
                        if (_d) Echo("Fuel low, filling extractors...");
                        loadExtractors();

                        if (_p) Echo("Took " + msSinceLast());

                        return; // come back to the below if we load extractors instead.
                    }
                    else
                    {
                        // if we don't need fuel,
                        // do something low priority instead
                        doThisStuffInfrequently();

                        if (_p) Echo("Took " + msSinceLast());
                    }

                    _stepOccasional = 0;
                    return;
            }

            _stepOccasional++;
        }

        void doThisStuffInfrequently()
        {

            if (_d) Echo("Refreshing " + _rcsThrusters.Count + " rcs...");
            refreshRcsThrusters();
            // checks integrity

            if (_d) Echo("Refreshing " + _normalPdcs.Count + " Pdcs & " + _defensivePdcs.Count + " defensive Pdcs...");
            refresh_normalPdcs();
            // checks integrity, sets power on

            if (_d) Echo("Refreshing " + _gyroscopes.Count + " gyros...");
            refreshGyros(_adjustKeepAlivesTo, _adjustKeepAlives);
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + _o2Tanks.Count + " O2 tanks...");
            refreshO2Tanks();
            // checks integrity, filled ratio

            if (_d) Echo("Refreshing " + _antennas.Count + " antennas...");
            refreshAntennas();
            // checks msg, range

            if (_d) Echo("Refreshing " + _cargos.Count + " cargos...");
            refreshCargos();
            // checks integrity

            if (_d) Echo("Refreshing " + _vents.Count + " vents...");
            refreshVents(_adjustKeepAlivesTo, _adjustKeepAlives);
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + _auxiliaries.Count + " auxiliary blocks...");
            iterateAuxiliaries();
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + _welders.Count + " welders...");
            iterateWelders();
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + _allLcds.Count + " lcds...");
            iterateLcds();
            // sets power

            if (_d) Echo("Refreshing " + _spawns.Count + " lcds...");
            refreshSpawns();
            // sets power

            // these ones are only keep alives
            // and so only need to happen if we are adjusting those.
            if (_adjustKeepAlives)
            {
                if (_d) Echo("Refreshing " + _connectors.Count + " connectors...");
                refreshConnectors(_adjustKeepAlivesTo);
                // > priority low
                // checks integrity, sets power

                if (_d) Echo("Refreshing " + _cameras.Count + " cameras...");
                refreshCameras(_adjustKeepAlivesTo);
                // > priority low
                // sets power

                if (_d) Echo("Refreshing " + _sensors.Count + " sensors...");
                refreshSensors(_adjustKeepAlivesTo);
                // > priority low
                // sets power
            }
        }


        void doThisStuffRarely()
        {

            if (_d) Echo("Clearing block lists...");
            clearBlockLists();
            if (_p) Echo("Took " + msSinceLast());

            if (_d) Echo("Refreshing block lists...");
            GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null, sortBlockLists);
            if (_p) Echo("Took " + msSinceLast());

            if (_d) Echo("Setting KeepFull threshold");
            setKeepFullThresh();



            if (_shipController == null)
            {
                if (_controllers.Count > 0)
                    _shipController = _controllers[0];

                else
                    _alerts.Add(new Alert(
                        "NO SHIP _shipController!",
                        "No ship controller was found on this grid. Some functionality will not operate correctly.",
                        3
                        ));
            }

            if (_d) Echo("Finished block refresh.");

            if (_p) Echo("Took " + msSinceLast());
        }

        void spinUpWcPbApi()
        {
            // spin up wc.
            // note, this is only needed for refreshing torps/rails
            try
            {
                _wcPbApi = new WcPbApi();
                _wcPbApi.Activate(Me);
            }
            catch (Exception ex)
            {
                _wcPbApi = null;

                _alerts.Add(new Alert(
                    "WcPbApi Error!",
                    "WcPbApi failed to start!\n" + ex.Message
                    , 1
                    ));

                Echo("WcPbAPI failed to activate!");
                Echo(ex.Message);
                return;
            }
        }

        void isThereAnEchoInHere() // Outputs stuff to the console.
        {
            string Output = 
                "REEDIT SHIP MANAGEMENT \n\n|- V " + Version +
                "\n|- Ship Name: " + _shipName +
                "\n|- Stance: " + _currentStanceName +
                "\n|- Step: " + _stepRare + "/" + _blockRefreshFreq + " (" + _stepOccasional + ")";

            if (_isBooting)
                Output += "\n|- Booting " + _stepBoot;              

            if (_p) // if we are profiling, profile...
            {
                _profiler.Run();

                Output +=
                    "\n|- Runtime Av/Tick: " + (Math.Round(_profiler.RunningAverageMs, 2) / 100) + " ms" +
                    "\n|- Runtime Max: " + Math.Round(_profiler.MaxRuntimeMs, 4) + " ms" +
                    "\n|- Instructions: " + _instructionsCount + " (" + _maxInstructionsCount + ")";
            }
            Echo(Output + "\n");
        }

        long _lastTimeStamp = 0;
        string msSinceLast()
        {
            long Now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            if (_lastTimeStamp == 0)
            {
                _lastTimeStamp = Now;
                return "0 ms";
            }

            long Res = Now - _lastTimeStamp;
            _lastTimeStamp = Now;

            return Res + " ms";
        }
    }
}
