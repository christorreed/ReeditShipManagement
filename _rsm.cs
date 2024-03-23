﻿using Sandbox.Game.EntityComponents;
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
        string Version = "1.99.6 $MDK_DATE$";
        #endregion
        #endregion

        // StarCpt's Profiler
        // https://github.com/StarCpt/SERuntimeProfiler/blob/main/RuntimeProfiler.cs
        private Profiler PROFILER;

        // Loop Counters -----------------------------------------------------------------

        int BOOT_STEP = 0;
        int WAIT_STEP = 0;
        int OCCASIONAL_STEP = 0;
        //int INFREQUENT_STEP = 0;
        int RARE_STEP;

        bool BOOTING = true;

        bool ADJUST_KEEP_ALIVES = false;
        bool ADJUST_KEEP_ALIVES_TO = false;

        // dampening for extractor management
        int EXTRACTOR_WAIT = 0;

        // threshold for above
        // not a constant, will be modified
        // to speed up fueling.
        int EXTRACTOR_WAIT_THRESH = 9;

        // Constants -----------------------------------------------------------------

        // if extractor is topping up,
        // fill when fuel % falls below this value.
        const int TOP_UP_PERCENTAGE = 10;

        // if extractor is keeping full,
        // fill when there is this many times
        // one tank's space left in the ship.
        const double KEEP_FULL_MULTIPLIER = 3;

        // litres of fuel in a fuel tank
        const double CAPACITY_FUEL_TANK = 245000;
        // litres of fuel in a jerry can
        const double CAPACITY_JERRY_CAN = 50000;

        // EFC/NavOS set burn percentages
        int[] BURN_PERCENTAGES = new int[] { 0, 5, 25, 50, 75, 100 };

        // Warning Variables -----------------------------------------------------------------

        bool NEED_FUEL = false;
        bool SPAWN_OPEN = false;
        bool NO_EXTRACTOR = false;
        bool NO_SPARE_TANKS = false;
        int UNOWNED_BLOCKS = 0;
        int AUX_ACTIVE_COUNT = 0;

        // Misc Globals -----------------------------------------------------------------

        // the current stance index
        // of the STANCES & STANCE_NAMES lists
        int S = 0;

        // the name of the current stance.
        string STANCE = "N/A";

        // the current ship calculated fuel percentage.
        // starts at 100 so we don't refuel before we check.
        double FUEL_PERCENTAGES = 100;

        // ship telemetry values
        double VELOCITY;
        float MASS;

        // the faction tag of the PB owner
        string FACTION_TAG;

        // this is the SK custom data string
        // we will build it and force it into SK custom data
        string SK_DATA;

        // this reduces the LCD output build overhead
        // if you are not using an advanced thrust LCD
        bool BUILD_ADVANCED_THRUST = false;

        // instructions count
        int INSTRUCTIONS = 0;
        // highest instruction count since recompile
        int INSTRUCTIONS_MAX = 0;

        public Program()
        {
            Echo("Welcome to RSM\nV " + Version);
            if (_p) msSinceLast();

            RARE_STEP = _blockRefreshFreq;

            FACTION_TAG = Me.GetOwnerFactionTag();

            PROFILER = new Profiler(Runtime);

            buildItemsList();

            // default thrust percentages.
            ADVANCED_THRUST_PERCENTS.Add(0.5);
            ADVANCED_THRUST_PERCENTS.Add(0.25);
            ADVANCED_THRUST_PERCENTS.Add(0.1);
            ADVANCED_THRUST_PERCENTS.Add(0.05);

            // this is the bit that actually makes it loop, yo
            Runtime.UpdateFrequency = UpdateFrequency.Update100;

            if (_d) Echo("Parsing custom data...");
            updateCustomData(false);
            if (_p) Echo("Took " + msSinceLast());
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

            if (argument == "")
            {
                ALERTS.Add(new ALERT(
                    "COMMAND FAILED: Arg Required!",
                    "A command was ignored because the argument was blank."
                    , 3
                    ));
                return;
            }

            string[] args = argument.Split(':');

            if (args.Length < 2)
            {

                ALERTS.Add(new ALERT(
                    "COMMAND FAILED: Syntax Error!",
                    "A command was ignored because it wasn't recognised."
                    , 3
                    ));
                return;
            }

            // removes spaces except for comms commands
            if (args[0].ToLower() != "comms")
                args[1] = args[1].Replace(" ", string.Empty);

            switch (args[0].ToLower())
            {
                case "init":
                    initShip(args[1]);
                    return;

                case "initbasic":
                    initShip(args[1], true);
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
                        SPAWN_OPEN = true;

                        // force a block refresh now.
                        RARE_STEP = _blockRefreshFreq;

                        ALERTS.Add(new ALERT(
                            "Spawns were opened to friends",
                            "Spawns are now opened to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    else
                    {
                        SPAWN_OPEN = false;

                        // force a block refresh now.
                        RARE_STEP = _blockRefreshFreq;

                        ALERTS.Add(new ALERT(
                            "Spawns were closed to friends",
                            "Spawns are now closed to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    return;

                case "projectors":
                    if (args[1].ToLower() == "save")
                    {
                        foreach (IMyProjector Projector in PROJECTORs)
                            saveProjectorPosition(Projector);

                        ALERTS.Add(new ALERT(
                            "Projector positions saved",
                            "Projector positions were saved and stored to their custom data."
                            , 2
                            ));
                        return;
                    }
                    else
                    {
                        foreach (IMyProjector Projector in PROJECTORs)
                            loadProjectorPosition(Projector);

                        ALERTS.Add(new ALERT(
                            "Projector positions loaded",
                            "Projector positions were loaded from custom data."
                            , 2
                            ));
                        return;
                    }

                default:
                    ALERTS.Add(new ALERT(
                        "COMMAND FAILED: Syntax Error!",
                        "A command was ignored because it wasn't recognised."
                        , 3
                        ));
                    return;
            }
        }

        void mainLoop()
        {
            // do we need to wait before we loop?
            if (WAIT_STEP < _loopStallCount)
            {
                WAIT_STEP++;
                return;
            }
            WAIT_STEP = 0;

            // write to the console.
            isThereAnEchoInHere();

            // get max instruction count.
            INSTRUCTIONS = Runtime.CurrentInstructionCount;
            if (INSTRUCTIONS > INSTRUCTIONS_MAX)
                INSTRUCTIONS_MAX = Runtime.CurrentInstructionCount;

            // if we're profiling
            // set the start time
            // no point logging the first one out
            if (_p) msSinceLast();

            // prep keep alives
            // lots of block refreshes use this
            // to determine if to enforce power status on those blocks
            // 22: keep-alives; 0: ignore, 1: force on, 2: force off
            if (STANCES[S][22] == 1)
            {
                ADJUST_KEEP_ALIVES = true;
                ADJUST_KEEP_ALIVES_TO = true;
            }
            else if (STANCES[S][22] == 2)
            {
                ADJUST_KEEP_ALIVES = true;
            }

            // okay now let's actually do some stuff...

            // what kind of stuff are we going to do?
            if (RARE_STEP >= _blockRefreshFreq)
            {
                RARE_STEP = 0;
                doThisStuffRarely();

                // update the LCDs
                //refreshLcds();
                // removed this for now bc it takes too long

                return;
            }
            RARE_STEP++;

            // run these things every time
            doThisStuffOften();
            // it actually does these things 
            // one at a time the first time.
            // ie, its BOOTING.
            // splitting it up like this because 
            // SE seems to cache the PB api results,
            // or something like that bc i see much
            // slow results the first time round...

            // if we are booting, don't do the unimportant stuff yet...
            if (BOOTING) return;

            // we run this method every time as well
            // but it always runs in steps.
            doThisStuffOccasionally();
            // the final step above runs
            // doThisStuffInfrequently()

            // update the LCDs
            refreshLcds();
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

            switch (BOOT_STEP)
            {
                case 0:
                    if (_d) Echo("Refreshing " + RAILs.Count + " railguns...");
                    refreshRailguns();
                    // checks integrity, sets power, gets target status for discharge mgmt

                    if (_p) Echo("Took " + msSinceLast());

                    if (BOOTING) break;
                    else goto case 1;

                case 1:
                    if (_d) Echo("Refreshing " + REACTORs.Count + " reactors & " + BATTERIEs.Count + " batteries...");
                    refreshPowerBlocks(STANCES[S][16]);
                    // checks integrity, sets power on,
                    // calcs power, batt discharge mgmt

                    if (_p) Echo("Took " + msSinceLast());

                    if (BOOTING) break;
                    else goto case 2;

                case 2:
                    if (_d) Echo("Refreshing " + THRUSTERs_EPSTEIN.Count + " epsteins...");
                    refreshMainThrusters();
                    // checks integrity, thrust

                    if (_p) Echo("Took " + msSinceLast());

                    if (BOOTING) break;
                    else goto case 3;

                case 3:
                    if (_d) Echo("Refreshing " + LIDARs.Count + " lidars...");
                    refreshLidars(ADJUST_KEEP_ALIVES_TO, ADJUST_KEEP_ALIVES);
                    // checks integrity

                    if (_p) Echo("Took " + msSinceLast());

                    if (BOOTING) break;
                    else goto case 4;

                case 4:
                    if (_d) Echo("Refreshing " + DOORs.Count + " doors...");
                    refreshDoors();
                    // manages doors, airlocks

                    if (_p) Echo("Took " + msSinceLast());

                    break;

                default:
                    if (_d) Echo("Booting complete");
                    BOOTING = false;
                    BOOT_STEP = 0;

                    return;
            }
            if (BOOTING) BOOT_STEP++;
        }

        void doThisStuffOccasionally()
        {
            switch (OCCASIONAL_STEP)
            {
                case 0:
                    if (_d) Echo("Clearing temp inventories...");
                    clearTempInventories();
                    // before we check torps
                    // clear temp inventories from all items...

                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing " + TORPs.Count + " torpedo launchers...");
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
                    if (_d) Echo("Refreshing " + TANKs_H2.Count + " H2 tanks...");
                    refreshH2Tanks();
                    // > priority low
                    // checks integrity, filled ratio

                    if (_p) Echo("Took " + msSinceLast());

                    if (_d) Echo("Refreshing refuel status...");
                    refreshRefuelStatus();
                    // checks if we NEED_FUEL?

                    // if we do...
                    if (NEED_FUEL)
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

                    OCCASIONAL_STEP = 0;
                    return;
            }

            OCCASIONAL_STEP++;
        }

        void doThisStuffInfrequently()
        {

            if (_d) Echo("Refreshing " + THRUSTERs_RCS.Count + " rcs...");
            refreshRcsThrusters();
            // checks integrity

            if (_d) Echo("Refreshing " + PDCs.Count + " PDCs & " + PDCs_DEF.Count + " defensive PDCs...");
            refreshPDCs();
            // checks integrity, sets power on

            if (_d) Echo("Refreshing " + GYROs.Count + " gyros...");
            refreshGyros(ADJUST_KEEP_ALIVES_TO, ADJUST_KEEP_ALIVES);
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + TANKs_O2.Count + " O2 tanks...");
            refreshO2Tanks();
            // checks integrity, filled ratio

            if (_d) Echo("Refreshing " + ANTENNAs.Count + " antennas...");
            refreshAntennas();
            // checks msg, range

            if (_d) Echo("Refreshing " + CARGOs.Count + " cargos...");
            refreshCargos();
            // checks integrity

            if (_d) Echo("Refreshing " + VENTs.Count + " vents...");
            refreshVents(ADJUST_KEEP_ALIVES_TO, ADJUST_KEEP_ALIVES);
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + AUXILIARIEs.Count + " auxiliary blocks...");
            iterateAuxiliaries();
            // checks integrity, sets power

            if (_d) Echo("Refreshing " + WELDERs.Count + " welders...");
            iterateWelders();
            // checks integrity, sets power

            // these ones are only keep alives
            // and so only need to happen if we are adjusting those.
            if (ADJUST_KEEP_ALIVES)
            {
                if (_d) Echo("Refreshing " + CONNECTORs.Count + " connectors...");
                refreshConnectors(ADJUST_KEEP_ALIVES_TO);
                // > priority low
                // checks integrity, sets power

                if (_d) Echo("Refreshing " + CAMERAs.Count + " cameras...");
                refreshCameras(ADJUST_KEEP_ALIVES_TO);
                // > priority low
                // sets power

                if (_d) Echo("Refreshing " + SENSORs.Count + " sensors...");
                refreshSensors(ADJUST_KEEP_ALIVES_TO);
                // > priority low
                // sets power
            }


            /*
                        switch (INFREQUENT_STEP)
                        {
                            case 0:



                                break;

                            case 1:



                                break;

                            case 2:



                                break;

                            case 3:
                                INFREQUENT_STEP = 0;
                                return;
                        }

                        INFREQUENT_STEP++;
            */
        }


        void doThisStuffRarely()
        {



            if (_d) Echo("Clearing block lists...");
            clearBlockLists();

            if (_p) Echo("Took " + msSinceLast());

            if (_d) Echo("Refreshing block lists...");
            GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null, sortBlockLists);

            if (_p) Echo("Took " + msSinceLast());

            if (_d)
            {
                if (I) Echo("Total blocks to rename: " + INIT_NAMEs.Count);
                Echo("Setting KeepFull threshold");
            }
            setKeepFullThresh();

            if (CONTROLLER == null)
            {
                if (CONTROLLERs.Count > 0)
                    CONTROLLER = CONTROLLERs[0];

                else
                    ALERTS.Add(new ALERT(
                        "NO SHIP CONTROLLER!",
                        "No ship controller was found on this grid. Some functionality will not operate correctly.",
                        3
                        ));
            }

            if (_d) Echo("Finished block refresh.");

            if (_p) Echo("Took " + msSinceLast());
        }


        // todo
        // review this
        // make it run commands over sperate ticks
        // work through a commands log
        void runProgramable(IMyTerminalBlock Pb, string Argument)
        {
            if (_d)
                Echo("Running '" + Argument + "' on '" + Pb.CustomName + "'");
            bool Success = (Pb as IMyProgrammableBlock).TryRun(Argument);
            if (Success)
                Echo("Failed to run '" + Argument + "' on '" + Pb.CustomName + "'");
        }

        void spinUpWcPbApi()
        {
            // spin up wc.
            // note, this is only needed for refreshing torps/rails
            try
            {
                WC_PB_API = new WcPbApi();
                WC_PB_API.Activate(Me);
            }
            catch (Exception ex)
            {
                WC_PB_API = null;
                Echo("WcPbAPI failed to activate!");
                Echo(ex.Message);
                return;
            }
        }

        void isThereAnEchoInHere() // Outputs stuff to the console.
        {
            
            string Output = 
                "REEDIT SHIP MANAGEMENT \n\n|- Version: " + Version +
                "\n|- Stance: " + STANCE_NAMES[S] + "(" + S + ")";

            if (BOOTING)
                Output += "\n|- Booting " + BOOT_STEP;

            else
                Output += "\n|- Step: " + RARE_STEP + "/" + _blockRefreshFreq + " (" + OCCASIONAL_STEP + ")";
                

            if (_p)
            {
                PROFILER.Run();

                Output +=
                    "\n|- Runtime Av/Tick: " + (Math.Round(PROFILER.RunningAverageMs, 2) / 100) + " ms" +
                    "\n|- Runtime Max: " + Math.Round(PROFILER.MaxRuntimeMs, 4) + " ms" +
                    "\n|- Instructions: " + INSTRUCTIONS + " (" + INSTRUCTIONS_MAX + ")";
            }



            Echo(Output + "\n");


        }
        long TIME = 0;
        string msSinceLast()
        {
            //if (!_p) return "";

            long Now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            if (TIME == 0)
            {
                TIME = Now;
                return "0 ms";
            }

            long Res = Now - TIME;
            TIME = Now;

            return Res + " ms";
        }
    }
}
