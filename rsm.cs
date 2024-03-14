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
        // 
        private Profiler PROFILER;

        // Loop Counters -----------------------------------------------------------------

        int LOOP_STEP;
        int WAIT_STEP;

        // dampening for extractor management
        int EXTRACTOR_WAIT = 0;

        // threshold for above
        // not a constant, will be modified
        // to speed up fueling.
        int EXTRACTOR_WAIT_THRESH = 30;

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
            LOOP_STEP = REFRESH_FREQ;
            WAIT_STEP = 0;

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
            if (D) Echo("Processing command '" + argument + "'...");

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
                    break;

                case "printblockids":
                    printBlockIds();
                    break;

                case "printblockprops":
                    printBlockProps(args[1]);
                    break;

                case "spawn":
                    if (args[1].ToLower() == "open")
                    {
                        SPAWN_OPEN = true;
                        fullRefresh();

                        ALERTS.Add(new ALERT(
                            "Spawns were opened to friends",
                            "Spawns are now opened to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    else
                    {
                        SPAWN_OPEN = false;
                        fullRefresh();

                        ALERTS.Add(new ALERT(
                            "Spawns were closed to friends",
                            "Spawns are now closed to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    break;

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
            // todo
            // review and improve the main loop

            isThereAnEchoInHere();
            INSTRUCTIONS = Runtime.CurrentInstructionCount;
            if (INSTRUCTIONS > INSTRUCTIONS_MAX)
                INSTRUCTIONS_MAX = Runtime.CurrentInstructionCount;

            try
            {
                WC_PB_API = new WcPbApi();
                WC_PB_API.Activate(Me);
            }
            catch
            {
                WC_PB_API = null;
                Echo("WcPbAPI failed to activate!");
                return;
            }
            
            // do we need to wait before we loop?
            if (WAIT_STEP < WAIT_COUNT)
            {
                WAIT_STEP++;
                return;
            }
            WAIT_STEP = 0;

            // okay so we're looping
            // what kind of loop are we going to do?
            if (LOOP_STEP >= REFRESH_FREQ)
            {
                LOOP_STEP = 0;
                fullRefresh();
                return;
            }
            // if we need fuel, do that instead.
            if (NEED_FUEL)
            {

                if (REFUEL_FAILURE_COUNT > 0)
                {
                    REFUEL_FAILURE_COUNT++;
                    if (REFUEL_FAILURE_COUNT > REFUEL_FAILURE_THRESH) REFUEL_FAILURE_COUNT = 0;
                    //return;
                }
                else
                {
                    //LOOP_STEP = 0;
                    fillExtractors();
                    return;
                }
            }
            LOOP_STEP++;
            quickRefresh();
            return;

        }

        void quickRefresh()
        {

            // todo
            // split this up better
            // maybe use yield();
            // or just spread out less important tasks
            // to occur less often.

            if (D)
            {
                Echo("quickRefresh();");
                Echo("\nstance = " + STANCE_NAMES[S] + "(" + S + ")");
            }

            // prep keep alives
            bool adjustKeepAlives = false;
            bool adjustThemTo = false;
            if (STANCES[S][22] == 1)
            {
                adjustKeepAlives = true;
                adjustThemTo = true;
            }
            else if (STANCES[S][22] == 2)
            {
                adjustKeepAlives = true;
            }

            // iterate blocks
            if (D) Echo("Checking " + REACTORs.Count + " reactors & " + BATTERIEs.Count + " batteries...");
            iteratePowerBlocks(STANCES[S][16]);

            if (D) Echo("Checking " + PDCs.Count + " PDCs & " + PDCs_DEF.Count + " defensive PDCs...");
            iteratePDCs();

            if (D) Echo("Checking " + TORPs.Count + " torpedo launchers...");
            iterateTorpedoes();

            if (D) Echo("Checking " + RAILs.Count + " railguns...");
            iterateRailguns();

            if (D) Echo("Checking " + THRUSTERs_EPSTEIN.Count + " cargos...");
            iterateMainThrusters();

            if (D) Echo("Checking " + THRUSTERs_RCS.Count + " cargos...");
            iterateRcsThrusters();

            if (D) Echo("Checking " + TANKs_H2.Count + " H2 tanks...");
            iterateH2Tanks();

            if (D) Echo("Checking " + TANKs_O2.Count + " O2 tanks...");
            iterateO2Tanks();

            if (D) Echo("Checking " + ANTENNAs.Count + " antennas...");
            iterateAntennas();

            if (D) Echo("Checking " + CARGOs.Count + " cargos...");
            iterateCargos();

            if (D) Echo("Checking " + LIDARs.Count + " lidars...");
            iterateLidars(adjustThemTo, adjustKeepAlives);

            if (D) Echo("Checking " + GYROs.Count + " gyros...");
            iterateGyros(adjustThemTo, adjustKeepAlives);

            if (D) Echo("Checking " + VENTs.Count + " vents...");
            iterateVents(adjustThemTo, adjustKeepAlives);

            if (D) Echo("Iterating over " + AUXILIARIEs.Count + " auxiliary blocks...");
            iterateAuxiliaries();

            if (D) Echo("Iterating over " + WELDERs.Count + " welders...");
            iterateWelders();

            // these ones are only keep alives
            // and so only need to happen if we are adjusting those.
            if (adjustKeepAlives)
            {
                if (D) Echo("Checking " + CONNECTORs.Count + " connectors...");
                iterateConnectors(adjustThemTo);

                if (D) Echo("Checking " + CAMERAs.Count + " cameras...");
                iterateCameras(adjustThemTo);

                if (D) Echo("Checking " + SENSORs.Count + " sensors...");
                iterateSensors(adjustThemTo);
            }

            // do we NEED_FUEL?
            if (D) Echo("Checking refuel status...");
            checkRefuelStatus();

            if (CONTROLLER != null)
            {
                try
                {
                    // calculate current mass and velocity
                    VELOCITY = CONTROLLER.GetShipSpeed();
                    MASS = CONTROLLER.CalculateShipMass().PhysicalMass;
                }
                catch (Exception exxie)
                {
                    Echo("Failed to get velocity or mass!");
                    Echo(exxie.Message);
                }
            }

            manageAutoload();
            manageDoors();
            updateLcds();

            if (D) Echo("Finished quickRefresh");
        }

        void fullRefresh()
        {
            if (D) Echo("fullRefresh();");

            updateCustomData(false);

            // update all of the block lists.
            updateBlockLists();

            setKeepFullThresh();

            if (D) Echo("Finished full refresh.");
        }

        // todo
        // review this
        // make it run commands over sperate ticks
        // work through a commands log
        void runProgramable(IMyTerminalBlock Pb, string Argument)
        {
            if (D)
                Echo("Running '" + Argument + "' on '" + Pb.CustomName + "'");
            bool Success = (Pb as IMyProgrammableBlock).TryRun(Argument);
            if (Success)
                Echo("Failed to run '" + Argument + "' on '" + Pb.CustomName + "'");
        }

        void isThereAnEchoInHere() // Outputs stuff to the console.
        {
            PROFILER.Run();
            Echo("REEDIT SHIP MANAGEMENT \n" +
   
                "\n|- Refresh: " + LOOP_STEP + "/" + REFRESH_FREQ +
                "\n|- Runtime Av/Tick: " + (Math.Round(PROFILER.RunningAverageMs,2) / 100) + " ms" +
                "\n|- Runtime Max: " + Math.Round(PROFILER.MaxRuntimeMs,4) + " ms" +
                "\n|- Instructions: " + INSTRUCTIONS + " (" + INSTRUCTIONS_MAX + ")");

        }
    }
}

/******************************************************************************************
 
todos

- review and improve the main loop
- review and improve quickRefresh
- fix runProgramable, make it run commands over sperate ticks
- add toolcore welder control (setToolActivate, iterateWelders)
- review and improve manageDoors
- experiment with ini, use for config (updateCustomData)
- confirm if to also check for blocks for ship names
- review and improve updateLcds 
- review and improve setStance

X review and fix extractor management
X finalise init naming initBlockNames

******************************************************************************************/

