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

        int loop_step;
        int wait_step;

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

        // Warnings -----------------------------------------------------------------

        bool NEED_FUEL = false;
        bool SPAWN_OPEN = false;
        bool NO_EXTRACTOR = false;
        bool NO_SPARE_TANKS = false;
        int UNOWNED_BLOCKS = 0;
        int AUX_ACTIVE_COUNT = 0;

        // Misc Globals -----------------------------------------------------------------

        string FACTION_TAG;
        string SK_DATA;

        // this reduces the LCD output build overhead
        // if you are not using an advanced thrust LCD
        bool BUILD_ADVANCED_THRUST = false;

        // this value multiplies the capacity by
        // the KEEP_FULL_MULTIPLIER depending on
        // if this is SG or LG
        double EXTACTOR_KEEP_FULL_THRESH = 0;




        //int welders_init = 0;
        //double integrity_welders = 0;


        

        int doors_count = 0;
        int doors_count_closed = 0;
        int doors_count_unlocked = 0;





        string current_stance = "N/A";




        double velocity;
        float mass;








        //IMyShipController controller;

        // Block lists, built at fullRefresh();
        //List<IMyRadioAntenna> antenna_blocks = new List<IMyRadioAntenna>();
        //List<IMyTextPanel> lcd_blocks = new List<IMyTextPanel>();
        //List<IMyDoor> door_blocks = new List<IMyDoor>();
        //List<IMyAirVent> airlock_vents = new List<IMyAirVent>();
        //List<string> AIRLOCK_LOOP_PREVENTION = new List<string>();
        //List<IMyBeacon> beacon_blocks = new List<IMyBeacon>();

        //List<IMyShipConnector> connector_blocks = new List<IMyShipConnector>();
        List<IMyProjector> projector_blocks = new List<IMyProjector>();




        // empty REACTORs to be loaded with fusion fuel
        //List<IMyTerminalBlock> reactorsEmpty = new List<IMyTerminalBlock>();

        //List<MyInventoryItem?> fuel_tank_items = new List<MyInventoryItem?>();

        // counter used to prevent refuel from looping.
        int refuel_failure_count = 0;
        int refuel_failure_threshold = 25;


        string missing_ammo = "";
        //int ammo_warning_count = 0;



        // Inventory and item lists.
        //List<IMyInventory> cargo_inventory = new List<IMyInventory>();
        //List<MyItemType> components = new List<MyItemType>();
        //List<int> component_counts = new List<int>();

        double fuel_percentage = 100;
        //List<IMyInventory> fuel_tank_inventory = new List<IMyInventory>();
        //List<IMyInventory> sg_fuel_tank_inventory = new List<IMyInventory>();

        // Stance data
        int stance_i = 0;




        public Program()
        {
            // The constructor, called only once every session and
            // always before any other method is called. Use it to
            // initialize your script. 
            //     
            // The constructor is optional and can be removed if not
            // needed.
            // 
            // It's recommended to set Runtime.UpdateFrequency 
            // here, which will allow your script to run itself without a 
            // timer block.
            loop_step = REFRESH_FREQ;
            wait_step = 0;

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

        int INSTRUCTIONS = 0;
        int INSTRUCTIONS_MAX = 0;

        public void Main(string argument, UpdateType updateSource)
        {

            if (updateSource == UpdateType.Update100)
            {
                isThereAnEchoInHere();

                mainLoop();

                INSTRUCTIONS = Runtime.CurrentInstructionCount;
                if (INSTRUCTIONS > INSTRUCTIONS_MAX)
                    INSTRUCTIONS_MAX = Runtime.CurrentInstructionCount;

                return;
            }

            if (argument == "")
            {

                ALERTS.Add(new ALERT(
                    "COMMAND FAILED: Arg Required!", 
                    "A command was ignored because the argument was blank." 
                    ,3
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

            if (D) Echo("Running " + args[0] + ":" + args[1]);

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
                /*case "evade":
                    setEvade(args[1]);
                    break;*/
                case "comms":
                    setAntennaComms(args[1]);
                    break;


                case "printblockids":
                    // prints all block defs on grid to first antenna custom data.

                    List<IMyTerminalBlock> allBlocks = new List<IMyTerminalBlock>();
                    GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(allBlocks);

                    string DefsOut = "";
                    foreach (IMyTerminalBlock ThisBlock in allBlocks)
                    {
                        DefsOut += ThisBlock.BlockDefinition + "\n";
                    }

                    if (ANTENNAs[0] != null) ANTENNAs[0].CustomData = DefsOut;

                    break;

                case "printblockprops":
                    // prints props and actions of the block with the given name
                    // to that block's custom data, and to the first antenna custom data.

                    IMyTerminalBlock Block = GridTerminalSystem.GetBlockWithName(args[1]);

                    List<ITerminalAction> Actions = new List<ITerminalAction>();
                    Block.GetActions(Actions);

                    List<ITerminalProperty> Properties = new List<ITerminalProperty>();
                    Block.GetProperties(Properties);

                    string Out = Block.CustomName + "\n**Actions**\n\n";

                    foreach (ITerminalAction Action in Actions)
                    {
                        Out += Action.Id + " " + Action.Name + "\n";
                    }
                    Out += "\n\n**Properties**\n\n";
                    foreach (ITerminalProperty Prop in Properties)
                    {
                        Out += Prop.Id + " " + Prop.TypeName + "\n";
                    }

                    if (ANTENNAs[0] != null) ANTENNAs[0].CustomData = Out;
                    Block.CustomData = Out;

                    break;

                /*case "activatetool":
                    IMyTerminalBlock Tool = GridTerminalSystem.GetBlockWithName(args[1]);
                    setToolActivate(Tool, true);
                    break;*/

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
                        foreach (IMyProjector Projector in projector_blocks)
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
                        foreach (IMyProjector Projector in projector_blocks)
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
            if (wait_step < WAIT_COUNT)
            {
                wait_step++;
                return;
            }
            wait_step = 0;

            // okay so we're looping
            // what kind of loop are we going to do?
            if (loop_step >= REFRESH_FREQ)
            {
                loop_step = 0;
                fullRefresh();
                return;
            }
            // if we need fuel, do that instead.
            if (NEED_FUEL)
            {

                if (refuel_failure_count > 0)
                {
                    refuel_failure_count++;
                    if (refuel_failure_count > refuel_failure_threshold) refuel_failure_count = 0;
                    //return;
                }
                else
                {
                    //loop_step = 0;
                    fillExtractors();
                    return;
                }
            }
            loop_step++;
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
                Echo("\nstance = " + stance_names[stance_i] + "(" + stance_i + ")");
            }

            // prep keep alives
            bool adjustKeepAlives = false;
            bool adjustThemTo = false;
            if (stance_data[stance_i][22] == 1)
            {
                adjustKeepAlives = true;
                adjustThemTo = true;
            }
            else if (stance_data[stance_i][22] == 2)
            {
                adjustKeepAlives = true;
            }

            // iterate blocks
            if (D) Echo("Checking " + REACTORs.Count + " reactors & " + BATTERIEs.Count + " batteries...");
            iteratePowerBlocks(stance_data[stance_i][16]);

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



            if (CONTROLLER != null)
            {
                try
                {
                    // calculate current mass and velocity
                    velocity = CONTROLLER.GetShipSpeed();
                    mass = CONTROLLER.CalculateShipMass().PhysicalMass;
                }
                catch (Exception exxie)
                {
                    Echo("Failed to get velocity or mass!");
                    Echo(exxie.Message);
                }
            }

            manageExtractors();
            manageAutoload();
            manageDoors();
            updateLcd();
            return;
        }

        void fullRefresh()
        {
            if (D) Echo("fullRefresh();");

            updateCustomData(false);

            // update all of the block lists.
            updateBlockLists();

            int ignoreCount = 0;
            UNOWNED_BLOCKS = 0;

            // todo
            // make this bit better,
            // move into extractors.cs

            // set fuel tank/jerry can for extractor management = 3
            /*bool sg_extractors = true;
            if (sg_extractors)
                EXTACTOR_KEEP_FULL_THRESH = (KEEP_FULL_MULTIPLIER * CAPACITY_JERRY_CAN);
            else
                EXTACTOR_KEEP_FULL_THRESH = (KEEP_FULL_MULTIPLIER * CAPACITY_FUEL_TANK);*/


            if (D) Echo("Finished full refresh.\nIgnored " + ignoreCount + " blocks.");


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
   
                "\n|- Refresh: " + loop_step + "/" + REFRESH_FREQ +
                "\n|- Runtime Av/Tick: " + (Math.Round(PROFILER.RunningAverageMs,2) / 100) + " ms" +
                "\n|- Runtime Max: " + Math.Round(PROFILER.MaxRuntimeMs,4) + " ms" +
                "\n|- Instructions: " + INSTRUCTIONS + " (" + INSTRUCTIONS_MAX + ")");

        }
    }
}



