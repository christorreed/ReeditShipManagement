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
    partial class Program : MyGridProgram
    {

        // CUSTOM DATA STUFF
        // these are default values can also be set from custom data
        // name is also set by init.
        string ship_name = "Untitled Ship";
        // the keyword for LCDs to be controlled by this script.
        string lcd_keyword = "[RSM]";
        // the keyword for aux systems
        // will be set automatically for welders at Init
        // set rotors etc later as well
        string aux_keyword = "[Autorepair]";
        string ignore_keyword = "REEDAV";
        // the keyword for defence PDCs (secondary PDCs group)
        string defence_pdc_keyword = "Repel";
        string min_drives_keyword = "Min";
        bool auto_configure_pdcs = true;
        bool disable_lighting = false; // ew, why disable.  silly germ.
        bool disable_text_colour_enforcement; // ew, why disable.  silly germ.

        // number of loops before each door will be closed
        int door_open_time = 3;
        // number of loops before airlock doors will be unlocked.
        int door_airlock_time = 6;
        // number of runs to wait between loops
        // each run is triggered every 100 ticks
        // for throttling CPU usage
        int wait_count = 0;
        // number of loops between complete refreshes.
        int refresh_freq = 50;
        // verbose debugging to PB details
        bool debug = false;
        // delimiter
        char name_delimiter = '.';

        class ITEM
        {
            public string NAME = "";
            public int TARGET = 10;
            public int COUNT = 0;
            public MyItemType TYPE;
            public double PERCENTAGE;
            public List<IMyInventory> STORED_IN = new List<IMyInventory>();

            public bool AMMO = false;
            public bool IS_TORP = false;
            public bool AMMO_LOW = false;
            public List<IMyInventory> ARMED_IN = new List<IMyInventory>();

        }

        List<ITEM> ITEMS = new List<ITEM>();

        ITEM buildItem(string LCDName, string SubTypeID, string TypeID, bool Ammo = false, bool Torp = false)
        {
            ITEM NewItem = new ITEM();
            NewItem.NAME = LCDName;
            NewItem.TYPE = new MyItemType(SubTypeID, TypeID);
            NewItem.IS_TORP = Torp;
            return NewItem;
        }

        bool AUTOLOAD = true;
        List<IMyTerminalBlock> TO_LOAD = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> TO_BALANCE_LOAD = new List<IMyTerminalBlock>();

       List<string> FORCE_ENUMERATION = new List<string>();

        string faction_tag;

        string friendly_tags = "";

        string sk_data = "";

        bool spawn_open = false;
        bool spawn_private = false;

        int loop_step;
        int wait_step;

        bool need_fuel = false;

        int UNOWNED_BLOCKS = 0;

        double tank_h2_actual = 0;
        double tank_h2_total = 0;
        double tank_h2_init = 0;
        double tank_o2_actual = 0;
        double tank_o2_total = 0;
        double tank_o2_init = 0;

        float reactors_init = 0;
        float thrust_main_init = 0;
        float thrust_rcs_init = 0;

        int pdcs_init = 0;
        int torps_init = 0;
        int railguns_init = 0;
        int gyros_init = 0;

        double integrity_tanks_H2 = 0;
        double integrity_tanks_O2 = 0;
        double integrity_bats = 0;
        double integrity_pdcs = 0;
        double integrity_torps = 0;
        double integrity_railguns = 0;
        double integrity_main_thrust = 0;
        double integrity_rcs_thrust = 0;
        double integrity_gyros = 0;
        double integrity_reactors = 0;

        int min_fuel = 10;

        // prevents extractor management from getting too excited.
        int extractor_mgmt_wait = 0;
        int extractor_mgmt_wait_threshold = 30;

        //int min_fuel_lean = 10;

        double extractor_keep_full_threshold = 0;

        double fuel_tank_keep_full_multiplier = 3;
        double fuel_tank_capacity = 245000;
        double jerry_can_capacity = 24500;

        double bat_actual = 0;
        double bat_total = 0;
        float bat_init = 0;

        double max_power = 0;

        int doors_count = 0;
        int doors_count_closed = 0;

        int vents_sealed = 0;

        int aux_active = 0;

        string current_stance = "N/A";
        string current_comms = "";
        double current_comms_range = 0;
        bool COMMS_ON = false;

        double current_sig_range = 0;

        double velocity;
        float mass;
        float max_thrust;
        float actual_thrust;

        bool build_advanced_thrust_data = false;
        bool ADVANCED_THRUST_SHOW_BASICS = true;
        List<double> ADVANCED_THRUST_PERCENTS = new List<double>();

        bool NAME_WEAPON_TYPES = false;

        IMyShipController controller;

        // Block lists, built at fullRefresh();
        List<IMyRadioAntenna> antenna_blocks = new List<IMyRadioAntenna>();
        List<IMyTextPanel> lcd_blocks = new List<IMyTextPanel>();
        List<IMyDoor> door_blocks = new List<IMyDoor>();
        List<IMyAirVent> airlock_vents = new List<IMyAirVent>();
        List<string> airlock_loop_prevention = new List<string>();
        List<IMyBeacon> beacon_blocks = new List<IMyBeacon>();
        List<IMyShipConnector> connector_blocks = new List<IMyShipConnector>();
        List<IMyProjector> projector_blocks = new List<IMyProjector>();

        // Block lists, also built at fullRefresh(); but differently
        List<IMyTerminalBlock> servers = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> serversEfc = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> pdcs = new List<IMyTerminalBlock>(); // turn on/off at quickRefresh(); setup at stance set
        List<IMyTerminalBlock> defencePdcs = new List<IMyTerminalBlock>(); // turn on/off at quickRefresh(); setup at stance set
        List<IMyTerminalBlock> torps = new List<IMyTerminalBlock>(); // handle at quickRefresh();
        List<IMyTerminalBlock> coilguns = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> railguns = new List<IMyTerminalBlock>(); // handle at quickRefresh();
        List<IMyTerminalBlock> thrustersMain = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> thrustersRcs = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> lightsSpotlights = new List<IMyTerminalBlock>(); // handle at stance set

        List<IMyTerminalBlock> lightsNavPort = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> lightsNavStarboard = new List<IMyTerminalBlock>(); // handle at stance set

        List<IMyTerminalBlock> lightsInterior = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> lightsExterior = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> auxiliaries = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> gyros = new List<IMyTerminalBlock>(); // handle at quickRefresh();
        List<IMyTerminalBlock> extractors = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> reactorsSmall = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> reactorsLarge = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> reactorsAll = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> h2Engines = new List<IMyTerminalBlock>();
        //List<IMyTerminalBlock> cargosSmall = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> cargos = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> tanksH2 = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> tanksO2 = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> vents = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> allTanks = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> antennas = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> beacons = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> drills = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> welders = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> grinders = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> hangarDoors = new List<IMyTerminalBlock>();
        // grouped together bc i'm only keeping them alive.
        List<IMyTerminalBlock> camerasAndSensorsAndLCDs = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> everythingElse = new List<IMyTerminalBlock>();

        // empty reactors to be loaded with fusion fuel
        List<IMyTerminalBlock> reactorsEmpty = new List<IMyTerminalBlock>();

        //List<MyInventoryItem?> fuel_tank_items = new List<MyInventoryItem?>();

        // counter used to prevent refuel from looping.
        int refuel_failure_count = 0;
        int refuel_failure_threshold = 25;
        bool NO_EXTRACTOR = false;
        bool NO_SPARE_TANKS = false;

        string missing_ammo = "";
        //int ammo_warning_count = 0;

        // these are the EFC set burn percentages.
        int[] burnArray = new int[] { 0, 5, 25, 50, 75, 100 };

        // Inventory and item lists.
        List<IMyInventory> cargo_inventory = new List<IMyInventory>();
        //List<MyItemType> components = new List<MyItemType>();
        //List<int> component_counts = new List<int>();

        double fuel_percentage = 100;
        //List<IMyInventory> fuel_tank_inventory = new List<IMyInventory>();
        //List<IMyInventory> sg_fuel_tank_inventory = new List<IMyInventory>();

        // Stance data
        int stance_i = 0;

        private Profiler PROFILER;

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
            loop_step = refresh_freq;
            wait_step = 0;

            faction_tag = Me.GetOwnerFactionTag();

            PROFILER = new Profiler(Runtime);

            try
            {
                // this order is important, don't change it.

                ITEMS.Add(buildItem("Fusion F ", "MyObjectBuilder_Ingot", "FusionFuel")); //0
                ITEMS.Add(buildItem("Fuel Tank", "MyObjectBuilder_Component", "Fuel_Tank")); //1
                ITEMS.Add(buildItem("Jerry Can", "MyObjectBuilder_Component", "SG_Fuel_Tank")); //2

                ITEMS.Add(buildItem("PDC      ", "MyObjectBuilder_AmmoMagazine", "40mmLeadSteelPDCBoxMagazine", true)); //3
                ITEMS.Add(buildItem("PDC Tefl ", "MyObjectBuilder_AmmoMagazine", "40mmTungstenTeflonPDCBoxMagazine", true)); //4

                ITEMS.Add(buildItem("220 Torp ", "MyObjectBuilder_AmmoMagazine", "220mmExplosiveTorpedoMagazine", true, true)); //5
                ITEMS.Add(buildItem("220 MCRN ", "MyObjectBuilder_AmmoMagazine", "220mmMCRNTorpedoMagazine", true, true)); //6
                ITEMS.Add(buildItem("220 MCRN ", "MyObjectBuilder_AmmoMagazine", "220mmUNNTorpedoMagazine", true, true)); //7
                ITEMS.Add(buildItem("RS Torp  ", "MyObjectBuilder_AmmoMagazine", "RamshackleTorpedoMagazine", true, true)); //8
                ITEMS.Add(buildItem("LRS Torp ", "MyObjectBuilder_AmmoMagazine", "LargeRamshackleTorpedoMagazine", true, true)); //9

                ITEMS.Add(buildItem("120mm RG ", "MyObjectBuilder_AmmoMagazine", "120mmLeadSteelSlugMagazine", true)); //10
                ITEMS.Add(buildItem("Dawson   ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugUNNMagazine", true)); //11
                ITEMS.Add(buildItem("Stiletto ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugMCRNMagazine", true)); //12
                ITEMS.Add(buildItem("80mm     ", "MyObjectBuilder_AmmoMagazine", "80mmTungstenUraniumSabotMagazine", true)); //13

                ITEMS.Add(buildItem("Foehammr ", "MyObjectBuilder_AmmoMagazine", "120mmTungstenUraniumSlugMCRNMagazine", true)); //14
                ITEMS.Add(buildItem("Farren   ", "MyObjectBuilder_AmmoMagazine", "120mmTungstenUraniumSlugUNNMagazine", true)); //15
            }
            catch
            {
                Echo("It seems like you might be missing one of the required mods?! Failed to build a list of components to check inventories for.");
                return;
            }

            // default thrust percentages.
            ADVANCED_THRUST_PERCENTS.Add(0.5);
            ADVANCED_THRUST_PERCENTS.Add(0.25);
            ADVANCED_THRUST_PERCENTS.Add(0.1);
            ADVANCED_THRUST_PERCENTS.Add(0.05);

            // this is the bit that actually makes it loop, yo
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
        }



        /*public void Save()
        {

            //Storage = current_stance;
            // not using this cause it doesn't work very well with nexus
            // thus using custom data instead.

        }*/

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

            if (args.Length != 2)
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

            if (debug) Echo("Running " + args[0] + ":" + args[1]);

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
                    setHudLcd(args[1]);
                    return;
                /*case "evade":
                    setEvade(args[1]);
                    break;*/
                case "comms":
                    setComms(args[1]);
                    break;

                case "spawn":
                    if (args[1].ToLower() == "open")
                    {
                        spawn_open = true;
                        fullRefresh();

                        ALERTS.Add(new ALERT(
                            "Spawns were opened to friends",
                            "Spawns are now opened to the friends list as defined in PB custom data."
                            , 2
                            ));
                    }
                    else
                    {
                        spawn_open = false;
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

        void fillExtractors()
        {

            if (debug)
                Echo("Fuel low, filling extractors...");

            // don't want to get stuck in a loop trying this.
            need_fuel = false;

            IMyInventory thisInventory = null;
            string TankType = "Fuel_Tank";

            NO_EXTRACTOR = false;
            NO_SPARE_TANKS = false;

            foreach (IMyTerminalBlock Extractor in extractors)
            {
                if (Extractor != null)
                {
                    thisInventory = Extractor.GetInventory();
                    //Echo("Extractor mass = " + Extractor.Mass);
                    if (Extractor.Mass < 2500)
                    {
                        TankType = "SG_Fuel_Tank";
                        if (debug) Echo("SG Extractor!");
                    }
                    break;
                }
            }

            if (thisInventory == null)
            {
                refuel_failure_count = 1;
                NO_EXTRACTOR = true;
                return;
            }



            List<IMyInventory> ToSearch;
            if (TankType == "Fuel_Tank") ToSearch = ITEMS[1].STORED_IN;
            else ToSearch = ITEMS[2].STORED_IN;



            if (debug)
                Echo(ToSearch.Count + " possible fuel tank inventories.");


            for (int j = 0; j < ToSearch.Count; j++)
            // check max of 3.
            //for (int j = 0; j < 3; j++)
            {
                List<MyInventoryItem> inventoryItems = new List<MyInventoryItem>();
                ToSearch[j].GetItems(inventoryItems/* ,a => a.ToString() == "Fuel_Tank"*/);

                if (debug)
                    Echo(inventoryItems.Count + " fuel tanks in inventory " + j);

                for (int k = 0; k < inventoryItems.Count; k++)
                {
                    if (
                        (inventoryItems[k].ToString().Contains(TankType))

                        )
                    {
                        if (debug)
                            Echo(inventoryItems[k].ToString());

                        //if (inventoryItems[k].ToString().Contains("Fuel_Tank"))
                        //{
                        bool success = thisInventory.TransferItemFrom(
                            ToSearch[j],
                            inventoryItems[k],
                            1
                        );

                        if (success)
                        {

                            ALERTS.Add(new ALERT(
                                "Loaded Fuel Tank",
                                "Fuel levels are low, and management is active. Successfully loaded a fuel tank into an extractor."
                                , 1, 10
                                ));

                            // dampens extractor filling from going nuts.
                            extractor_mgmt_wait = extractor_mgmt_wait_threshold;

                            return;
                        }
                    }
                }
            }
            // no spare tanks...
            refuel_failure_count = 1;
            NO_SPARE_TANKS = true;
        }

        void saveProjectorPosition(IMyProjector Projector)
        {
            Projector.CustomData =

                Projector.ProjectionOffset.X + "\n" +
                Projector.ProjectionOffset.Y + "\n" +
                Projector.ProjectionOffset.Z + "\n" +

                Projector.ProjectionRotation.X + "\n" +
                Projector.ProjectionRotation.Y + "\n" +
                Projector.ProjectionRotation.Z + "\n";
        }

        void loadProjectorPosition(IMyProjector Projector)
        {
            if (!Projector.IsFunctional)
                return;

            try
            {
                string[] data = Projector.CustomData.Split('\n');
                Vector3I Offset = new Vector3I(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                Vector3I Rotation = new Vector3I(int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]));
                // if parsed succesfully, turn it on and set the values.
                Projector.Enabled = true;
                Projector.ProjectionOffset = Offset;
                Projector.ProjectionRotation = Rotation;
                Projector.UpdateOffsetAndRotation();
            }
            catch
            {
                // do fuck all
            }
        }


        void setStance(string stance)
        {

            if (debug) Echo("Setting stance '" + stance + "'.");

            bool found = false;
            for (int i = 0; i < stance_names.Count; i++)
            {
                //Echo("? "+ stance + " == " + stance_names[i] + "");
                if (stance == stance_names[i])
                {
                    stance_i = i;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                ALERTS.Add(new ALERT(
                    "NO SUCH STANCE!",
                    "A command was ignored because the provided stance doens't exist. Stance names are case sensitive!"
                    , 3
                    ));
                return;
            }

            current_stance = stance;

            updateCustomData(true);

            // stores the current stance to persistance
            // allows it to be saved across instances.
            //Save();
            // lol no, persistance is shit, this just simply doens't always work
            // i think it's a nexus thing, also server seems to clear this on boot maybe
            // custom data instead.


            if (debug) Echo("Found stance. Setting torpedoes to " + stance_data[stance_i][0]);

            for (int i = 0; i < torps.Count; i++)
            {
                if (torps[i].IsFunctional && torps[i].CustomName.Contains(ship_name) && !torps[i].CustomName.Contains(ignore_keyword))
                {
                    // 0: torpedoes; 0: off, 1: on;

                    if (stance_data[stance_i][0] == 0)
                    {
                        torps[i].ApplyAction("OnOff_Off");
                        break;
                    }
                    else
                    {
                        torps[i].ApplyAction("OnOff_On");

                        //setBlockFireModeManual(torps[i]);
                        if (auto_configure_pdcs)
                        {
                            torps[i].SetValue("WC_FocusFire", true);
                            torps[i].SetValue("WC_Grids", true);
                            torps[i].SetValue("WC_LargeGrid", true);
                            torps[i].SetValue("WC_SmallGrid", false);
                            torps[i].SetValue("WC_FocusFire", true);
                            setBlockRepelOff(torps[i]);
                        }
                    }
                }
            }

            if (debug)
                Echo("Setting " + pdcs.Count + " PDCs, "
                    + defencePdcs.Count + " defence PDCs to "
                    + stance_data[stance_i][1]
                    + ".\nautoconfig = " + auto_configure_pdcs.ToString());

            //bool RepelModeFucked = false;

            for (int i = 0; i < pdcs.Count; i++)
            {
                //if (debug) Echo("PDC " + i + "(" + pdcs[i].CustomName + ")");

                if (pdcs[i].IsFunctional && pdcs[i].CustomName.Contains(ship_name) && !pdcs[i].CustomName.Contains(ignore_keyword))
                {
                    // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                    switch (stance_data[stance_i][1])
                    {
                        case 0:
                            pdcs[i].ApplyAction("OnOff_Off");
                            break;
                        case 1:
                            pdcs[i].ApplyAction("OnOff_Off");
                            break;
                        case 2:
                            pdcs[i].ApplyAction("OnOff_On");
                            if (auto_configure_pdcs)
                            {

                                try
                                {

                                    //if (debug) Echo("Focus Fire");
                                    pdcs[i].SetValue("WC_FocusFire", false);
                                    //if (debug) Echo("Target Projectiles");
                                    pdcs[i].SetValue("WC_Projectiles", true);

                                    //if (debug) Echo("Target grids");
                                    // accounts for PMWs 
                                    pdcs[i].SetValue("WC_Grids", true);
                                    //if (debug) Echo("Target LG");
                                    pdcs[i].SetValue("WC_LargeGrid", false);
                                    //if (debug) Echo("Target SG");
                                    pdcs[i].SetValue("WC_SmallGrid", true);

                                    //if (debug) Echo("Repel mode");
                                    //setBlockRepelOn(pdcs[i]);

                                    // removing default repel mode as per daniamal's recommendation
                                    // less effective now that torpedoes spread.
                                    setBlockRepelOff(pdcs[i]);
                                }
                                catch
                                {
                                    Echo("Strange PDC config error! Possible WC crash!");
                                }
                            }
                            break;
                        case 3:
                            pdcs[i].ApplyAction("OnOff_On");
                            if (auto_configure_pdcs) 
                            {
                                try
                                {
                                    pdcs[i].SetValue("WC_Grids", true);
                                    pdcs[i].SetValue("WC_LargeGrid", true);
                                    pdcs[i].SetValue("WC_SmallGrid", true);
                                    //pdcs[i].SetValue("WC_FocusFire", true);


                                    setBlockRepelOff(pdcs[i]);
                                }
                                catch
                                {
                                    Echo("Strange PDC config error! Possible WC crash!");
                                }
                            }
                            break;

                        case 4:
                            // switch on only...
                            pdcs[i].ApplyAction("OnOff_On");
                            break;

                    }
                }
            }
            for (int i = 0; i < defencePdcs.Count; i++)
            {

                if (debug) Echo("Def PDC " + i);

                if (defencePdcs[i].IsFunctional && defencePdcs[i].CustomName.Contains(ship_name) && !defencePdcs[i].CustomName.Contains(ignore_keyword))
                {
                    // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                    switch (stance_data[stance_i][1])
                    {
                        case 0:
                            defencePdcs[i].ApplyAction("OnOff_Off");
                            break;
                        case 1:
                        case 2:
                        case 3:
                            defencePdcs[i].ApplyAction("OnOff_On");
                            if (auto_configure_pdcs)
                            {
                                setBlockRepelOn(defencePdcs[i]);

                                // accounts for PMWs
                                defencePdcs[i].SetValue("WC_Grids", true);
                                defencePdcs[i].SetValue("WC_LargeGrid", false);
                                defencePdcs[i].SetValue("WC_SmallGrid", true);

                                defencePdcs[i].SetValue("WC_FocusFire", false);
                                defencePdcs[i].SetValue("WC_Projectiles", true);
                                defencePdcs[i].SetValue("WC_Biologicals", true);


                            }
                            break;
                        case 4:
                            defencePdcs[i].ApplyAction("OnOff_On");
                            break;
                    }
                }
            }

            if (debug) Echo("Setting " + railguns.Count + " railguns to " + stance_data[stance_i][2]);
            for (int i = 0; i < railguns.Count; i++)
            {
                if (railguns[i].IsFunctional && railguns[i].CustomName.Contains(ship_name) && !railguns[i].CustomName.Contains(ignore_keyword))
                {
                    // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;

                    if (stance_data[stance_i][2] == 0)
                    {
                        railguns[i].ApplyAction("OnOff_Off");
                    }
                    else
                    {
                        railguns[i].ApplyAction("OnOff_On");
                        setBlockRepelOff(railguns[i]);

                        if (auto_configure_pdcs)
                        {
                            railguns[i].SetValue("WC_Grids", true);
                            railguns[i].SetValue("WC_LargeGrid", true);
                            railguns[i].SetValue("WC_SmallGrid", true);
                            //railguns[i].SetValue("WC_FocusFire", true);
                            if (stance_data[stance_i][2] < 2) // hold fire if less than 2
                            {
                                setBlockFireModeManual(railguns[i]);
                            }
                            else // weapons free
                            {
                                setBlockFireModeAuto(railguns[i]);
                            }
                        }

                    }
                }
            }

            if (debug) Echo("Setting " + thrustersMain.Count + " Epsteins to " + stance_data[stance_i][3]);
            for (int i = 0; i < thrustersMain.Count; i++)
            {
                if (thrustersMain[i].IsFunctional && thrustersMain[i].CustomName.Contains(ship_name))
                {
                    // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                    if (stance_data[stance_i][3] == 0
                        ||
                        (stance_data[stance_i][3] == 2 && !thrustersMain[i].CustomName.Contains(min_drives_keyword))
                        )
                        thrustersMain[i].ApplyAction("OnOff_Off");
                    else
                        thrustersMain[i].ApplyAction("OnOff_On");
                }
            }

            if (debug) Echo("Setting " + thrustersRcs.Count + " RCS to " + stance_data[stance_i][4]);
            for (int i = 0; i < thrustersRcs.Count; i++)
            {
                if (thrustersRcs[i].IsFunctional && thrustersRcs[i].CustomName.Contains(ship_name))
                {
                    // 4: rcs thrusters; 0: off, 1: on, 2: forward off, 3: reverse off
                    if (stance_data[stance_i][4] == 0)
                        thrustersRcs[i].ApplyAction("OnOff_Off");
                    else if (stance_data[stance_i][4] == 1 ||
                        (stance_data[stance_i][4] > 1) && thrustersMain.Count < 1)
                        thrustersRcs[i].ApplyAction("OnOff_On");
                    else if (stance_data[stance_i][4] == 2) // all on, fwd off.
                    {
                        if ((thrustersRcs[i] as IMyThrust).GridThrustDirection == Vector3I.Backward)
                            thrustersRcs[i].ApplyAction("OnOff_Off");
                        else
                            thrustersRcs[i].ApplyAction("OnOff_On");
                    }
                    else if (stance_data[stance_i][4] == 3) // all on, reverse off.
                    {
                        if ((thrustersRcs[i] as IMyThrust).GridThrustDirection == Vector3I.Forward)
                            thrustersRcs[i].ApplyAction("OnOff_Off");
                        else
                            thrustersRcs[i].ApplyAction("OnOff_On");
                    }
                }
            }

            if (disable_lighting)
            {
                if (debug) Echo("No lighting commands were processed because the disable all lighting control option is enabled.");
            }
            else
            {
                if (debug) Echo("Setting " + lightsSpotlights.Count + " spotlights to " + stance_data[stance_i][5]);
                for (int i = 0; i < lightsSpotlights.Count; i++)
                {
                    if (lightsSpotlights[i].IsFunctional && lightsSpotlights[i].CustomName.Contains(ship_name))
                    {
                        // 5: spotlights; 0: off, 1: on, 2: on max radius
                        if (stance_data[stance_i][5] == 0)
                            lightsSpotlights[i].ApplyAction("OnOff_Off");
                        else
                        {
                            if (stance_data[stance_i][5] == 2)
                                (lightsSpotlights[i] as IMyLightingBlock).Radius = 9999;
                            lightsSpotlights[i].ApplyAction("OnOff_On");
                        }
                    }
                }

                if (debug) Echo(
                    "Setting " + lightsExterior.Count + " exterior lights to " + stance_data[stance_i][6] + ".\n"
                    + "Colour (" + stance_data[stance_i][7] + "," + stance_data[stance_i][8]
                    + "," + stance_data[stance_i][9] + "," + stance_data[stance_i][10] + ")"
                    );
                for (int i = 0; i < lightsExterior.Count; i++)
                {
                    if (lightsExterior[i].IsFunctional && lightsExterior[i].CustomName.Contains(ship_name))
                    {
                        // 6: exterior lights; 0: off, 1: on
                        if (stance_data[stance_i][6] == 0)
                            lightsExterior[i].ApplyAction("OnOff_Off");
                        else
                            lightsExterior[i].ApplyAction("OnOff_On");


                        lightsExterior[i].SetValue("Color",
                            new Color(
                                stance_data[stance_i][7],
                                stance_data[stance_i][8],
                                stance_data[stance_i][9],
                                stance_data[stance_i][10]
                                )
                            );
                    }
                }

                // handle nav lights
                for (int i = 0; i < lightsNavPort.Count; i++)
                {
                    // 6: exterior lights; 0: off, 1: on
                    if (stance_data[stance_i][6] == 0)
                    {
                        lightsNavPort[i].ApplyAction("OnOff_Off");
                        lightsNavPort[i].SetValue("Color", new Color(0, 0, 0, 255)); // black
                    }
                    else
                    {
                        lightsNavPort[i].ApplyAction("OnOff_On");
                        lightsNavPort[i].SetValue("Color", new Color(255, 0, 0, 255)); // red
                    }
                }
                for (int i = 0; i < lightsNavStarboard.Count; i++)
                {
                    // 6: exterior lights; 0: off, 1: on
                    if (stance_data[stance_i][6] == 0)
                    {
                        lightsNavStarboard[i].ApplyAction("OnOff_Off");
                        lightsNavStarboard[i].SetValue("Color", new Color(0, 0, 0, 255)); // black
                    }
                    else
                    {
                        lightsNavStarboard[i].ApplyAction("OnOff_On");
                        lightsNavStarboard[i].SetValue("Color", new Color(0, 255, 0, 255)); // green
                    }
                }

                if (debug) Echo(
                    "Setting " + lightsInterior.Count + " exterior lights to " + stance_data[stance_i][11] + ".\n"
                    + "Colour (" + stance_data[stance_i][12] + "," + stance_data[stance_i][13]
                    + "," + stance_data[stance_i][14] + "," + stance_data[stance_i][15] + ")"
                    );
                for (int i = 0; i < lightsInterior.Count; i++)
                {
                    if (lightsInterior[i].IsFunctional && lightsInterior[i].CustomName.Contains(ship_name))
                    {
                        // 11: interior lights lights; 0: off, 1: on
                        if (stance_data[stance_i][11] == 0)
                            lightsInterior[i].ApplyAction("OnOff_Off");
                        else
                            lightsInterior[i].ApplyAction("OnOff_On");

                        lightsInterior[i].SetValue("Color",
                            new Color(
                                stance_data[stance_i][12],
                                stance_data[stance_i][13],
                                stance_data[stance_i][14],
                                stance_data[stance_i][15]
                                )
                            );
                    }
                }
            }


            if (debug) Echo("Setting " + batteries.Count + " batteries to recharge = " + stance_data[stance_i][16]);

            for (int i = 0; i < batteries.Count; i++)
            {
                if (batteries[i] != null)
                {
                    if (batteries[i].IsFunctional)
                    {
                        IMyBatteryBlock Battery = batteries[i] as IMyBatteryBlock;
                        // always fucking on
                        Battery.Enabled = true;

                        // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                        if (stance_data[stance_i][16] == 0)
                            Battery.ChargeMode = ChargeMode.Auto;
                        else if (stance_data[stance_i][16] == 2)
                            Battery.ChargeMode = ChargeMode.Discharge;
                        else
                            Battery.ChargeMode = ChargeMode.Recharge;
                    }
                }

            }

            if (debug) Echo("Setting " + allTanks.Count + " tanks to stockpile = " + stance_data[stance_i][16]);

            for (int i = 0; i < allTanks.Count; i++)
            {
                if (allTanks[i] != null)
                {
                    if (allTanks[i].IsFunctional)
                    {
                        IMyGasTank Tank = allTanks[i] as IMyGasTank;
                        // why would this ever be off
                        Tank.Enabled = true;

                        // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                        if (stance_data[stance_i][16] == 1)
                            //if (!Tank.Stockpile)
                            Tank.Stockpile = true;
                        else
                            //if (Tank.Stockpile)
                            Tank.Stockpile = false;
                    }
                }

            }



            if (debug) Echo("Setting " + serversEfc.Count + " [EFC] servers to boost = " + stance_data[stance_i][17]
                /*+ ".\nburn % = " + burnArray[stance_data[stance_i][18]]
                + ".\nkill = " + stance_data[stance_i][19]+*/
                );
            for (int i = 0; i < serversEfc.Count; i++)
            {
                if (serversEfc[i].IsFunctional && serversEfc[i].CustomName.Contains(ship_name))
                {

                    // 17: EFC boost; 0: off, 1: on
                    if (stance_data[stance_i][17] == 1)
                        runProgramable(serversEfc[i], "Boost On");
                    else
                        runProgramable(serversEfc[i], "Boost Off");

                    // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                    if (stance_data[stance_i][18] > 0)
                    {
                        runProgramable(serversEfc[i], "Set Burn " + burnArray[stance_data[stance_i][18]]);
                    }


                    // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                    if (stance_data[stance_i][19] == 1)
                        runProgramable(serversEfc[i], "Off");
                }
            }

            if (debug) Echo("Setting " + auxiliaries.Count + " aux block to " + stance_data[stance_i][20]);
            for (int i = 0; i < auxiliaries.Count; i++)
            {
                if (auxiliaries[i].IsFunctional && auxiliaries[i].CustomName.Contains(ship_name))
                {
                    // 20: auxiliary blocks; 0: off, 1: on
                    if (stance_data[stance_i][20] == 0)
                        auxiliaries[i].ApplyAction("OnOff_Off");
                    else
                        auxiliaries[i].ApplyAction("OnOff_On");
                }
            }

            if (debug) Echo("Setting " + extractors.Count + " extrators to " + stance_data[stance_i][21]);
            for (int i = 0; i < extractors.Count; i++)
            {
                if (extractors[i].IsFunctional && extractors[i].CustomName.Contains(ship_name))
                {
                    // 21: extractor; 0: off, 1: on, 2: auto load below 10%
                    if (stance_data[stance_i][21] == 0)
                        extractors[i].ApplyAction("OnOff_Off");
                    else
                        extractors[i].ApplyAction("OnOff_On");

                    if (stance_data[stance_i][21] >= 2)
                        manageExtractors();
                }
            }


            if (debug) Echo("Setting " + hangarDoors.Count + " hangar doors units to " + stance_data[stance_i][23]);
            for (int i = 0; i < hangarDoors.Count; i++)
            {
                if (hangarDoors[i].IsFunctional && hangarDoors[i].CustomName.Contains(ship_name))
                {
                    // 23: hangar doors; 0: closed, 1: open, 2: no change
                    if (stance_data[stance_i][23] == 0)
                        hangarDoors[i].ApplyAction("Open_Off");
                    else if (stance_data[stance_i][23] == 1)
                        hangarDoors[i].ApplyAction("Open_On");
                }
            }

        }

        void setHudLcd(string state)
        {
            state = state.ToLower();
            List<IMyTextPanel> all_lcds = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(all_lcds);

            for (int i = 0; i < all_lcds.Count; i++)
            {
                string cd = all_lcds[i].CustomData;
                if (cd.Contains("hudlcd") && (state == "off" || state == "toggle"))
                    all_lcds[i].CustomData = cd.Replace("hudlcd", "hudXlcd");

                if (cd.Contains("hudXlcd") && (state == "on" || state == "toggle"))
                    all_lcds[i].CustomData = cd.Replace("hudXlcd", "hudlcd");
            }
        }

        void initShip(string ship, bool basic = false)
        {

            if (debug) Echo("Initialising a ship as '" + ship + "'.");

            // this rebuilds general that we need here lists.
            fullRefresh();

            // i now christen this ship, the RSG whatever the fuck
            // it's now public variable official.
            ship_name = ship;

            if (!basic)
            {

                // now I calculate subsystem total capacities in order to check for damage later.
                bat_init = 0;
                for (int i = 0; i < batteries.Count; i++)
                    bat_init += (batteries[i] as IMyBatteryBlock).MaxOutput;

                tank_h2_init = 0;
                for (int i = 0; i < tanksH2.Count; i++)
                    tank_h2_init += (tanksH2[i] as IMyGasTank).Capacity;

                tank_o2_init = 0;
                for (int i = 0; i < tanksO2.Count; i++)
                    tank_o2_init += (tanksO2[i] as IMyGasTank).Capacity;

                reactors_init = 0;
                for (int i = 0; i < reactorsAll.Count; i++)
                    reactors_init += (reactorsAll[i] as IMyReactor).MaxOutput;

                thrust_main_init = 0;
                for (int i = 0; i < thrustersMain.Count; i++)
                    thrust_main_init += (thrustersMain[i] as IMyThrust).MaxThrust;

                thrust_rcs_init = 0;
                for (int i = 0; i < thrustersRcs.Count; i++)
                    thrust_rcs_init += (thrustersRcs[i] as IMyThrust).MaxThrust;

                pdcs_init = pdcs.Count + defencePdcs.Count;
                torps_init = torps.Count;
                railguns_init = railguns.Count;
                gyros_init = gyros.Count;

                // now lets set current item counts as the target.
                foreach (ITEM Item in ITEMS)
                {
                    Item.TARGET = Item.COUNT;
                }
            }

            updateCustomData(true);

            for (int i = 0; i < everythingElse.Count; i++)
            {
                string defaultName = everythingElse[i].DefinitionDisplayNameText;
                string blockId = everythingElse[i].BlockDefinition.ToString();

                // Echo(blockId);

                // name overrides

                if (blockId.Contains("Door/")) defaultName = "Door";
                else if (blockId.Contains("Solar")) defaultName = "Solar";
                else if (blockId.Contains("Lidar")) defaultName = "Lidar";
                else if (blockId.Contains("TimerBlock/")) defaultName = "Timer";
                else if (blockId.Contains("Sorter/")) defaultName = "Sorter";
                else if (blockId.Contains("MedicalRoom/")) defaultName = "Medical";
                else if (blockId.Contains("MotorSuspension/")) defaultName = "Suspension";
                else if (blockId.Contains("GravityGenerator")) defaultName = "Grav Gen";
                else if (blockId.Contains("ButtonPanel")) defaultName = "Button Panel";

                else if (blockId.Contains("/Glapion")) defaultName = "Gatling Cannon";
                else if (blockId.Contains("/Kess")) defaultName = "Cannon";

                else if (blockId.Contains("Connector/"))
                {
                    defaultName = "Connector";
                    if (blockId.Contains("Passageway")) defaultName += ".Passageway";
                }
                else if (blockId.Contains("LandingGear/"))
                {
                    if (blockId.Contains("Clamp")) defaultName = "Clamp";
                    else if (blockId.Contains("Magnetic")) defaultName = "Mag Lock";
                    else defaultName = "Gear";
                }

                else if (blockId.Contains("Cockpit/")) 
                {
                    if (blockId.Contains("Console") || blockId.Contains("StandingCockpit")) defaultName = "Console";
                    else defaultName = "Cockpit";
                }

                //Echo(blockId);

                everythingElse[i].CustomName =
                    ship_name + name_delimiter +
                    defaultName +
                    retainSuffix(everythingElse[i].CustomName, defaultName);
            }

            bool EfcLcdFound = false;

            // this is just for extra hudlcd defaults.
            List<IMyTextPanel> AllOtherLCDs = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(AllOtherLCDs);
            for (int i = 0; i < AllOtherLCDs.Count; i++)
            {
                if (AllOtherLCDs[i].CustomName.Contains("[REEDAV].1"))
                    AllOtherLCDs[i].CustomData =
                        "Show Targeting Info=True\nFirst Missile=0\nLast Missile=0\nExtra Missile Info=False\nhudlcd:0.56:0:.48";

                if (AllOtherLCDs[i].CustomName.Contains("[REEDAV].2"))
                    AllOtherLCDs[i].CustomData =
                        "Show Targeting Info=False\nFirst Missile=1\nLast Missile=24\nExtra Missile Info=False\nhudlcd:0.56:-.26:.48";

                if (AllOtherLCDs[i].CustomName.Contains("[EFC]") || AllOtherLCDs[i].CustomName.ToUpper().Contains("[NAVOS]"))
                {
                    if (!EfcLcdFound)
                    {
                        EfcLcdFound = true;
                        AllOtherLCDs[i].CustomData = "hudlcd:-0.52:-0.7:0.52";
                    }
                    else AllOtherLCDs[i].CustomData = ""; // prevent double ups in case there are two EFC PBs.
                }
            }

            for (int i = 0; i < camerasAndSensorsAndLCDs.Count; i++)
            {
                string defaultName = camerasAndSensorsAndLCDs[i].DefinitionDisplayNameText;

                string blockId = camerasAndSensorsAndLCDs[i].BlockDefinition.ToString();
                if (blockId.Contains("MyObjectBuilder_TextPanel/"))
                {
                    defaultName = "LCD";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD1"))
                        setLcdCustomData(camerasAndSensorsAndLCDs[i],
                            new bool[] {
                                 true, // show_header
                                 false, // show_header_overlay
                                 false, // show_warnings
                                 false, // show_tanks_and_batts
                                 false, // show_inventory
                                 false, // show_thrust
                                 false, // show_integrity
                                 false, // show_thrust_advanced
                            }, "hudlcd:-0.55:0.99:0.7"); // hudlcd


                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD2"))
                        setLcdCustomData(camerasAndSensorsAndLCDs[i],
                            new bool[] {
                                 false, // show_header
                                 false, // show_header_overlay
                                 true, // show_warnings
                                 false, // show_tanks_and_batts
                                 false, // show_inventory
                                 false, // show_thrust
                                 false, // show_integrity
                                 false, // show_thrust_advanced
                             }, "hudlcd:0.22:0.99:0.55"); // hudlcd


                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD3"))
                        setLcdCustomData(camerasAndSensorsAndLCDs[i],
                            new bool[] {
                                 false, // show_header
                                 false, // show_header_overlay
                                 false, // show_warnings
                                 true, // show_tanks_and_batts
                                 false, // show_inventory
                                 true, // show_thrust
                                 false, // show_integrity
                                 false, // show_thrust_advanced
                            }, "hudlcd:0.48:0.99:0.55"); // hudlcd


                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD4"))
                        setLcdCustomData(camerasAndSensorsAndLCDs[i],
                            new bool[] {
                                 false, // show_header
                                 false, // show_header_overlay
                                 false, // show_warnings
                                 false, // show_tanks_and_batts
                                 false, // show_inventory
                                 false, // show_thrust
                                 true, // show_integrity
                                 false, // show_thrust_advanced
                            }, "hudlcd:0.74:0.99:0.55"); // hudlcd


                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD5"))
                        setLcdCustomData(camerasAndSensorsAndLCDs[i],
                            new bool[] {
                                 false, // show_header
                                 false, // show_header_overlay
                                 false, // show_warnings
                                 false, // show_tanks_and_batts
                                 true, // show_inventory
                                 false, // show_thrust
                                 false, // show_integrity
                                 true, // show_thrust_advanced
                            }, "hudlcd:0.75:0:.54"); // hudlcd

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD6"))
                        setLcdCustomData(camerasAndSensorsAndLCDs[i],
                            new bool[] {
                                 false, // show_header
                                 true, // show_header_overlay
                                 false, // show_warnings
                                 false, // show_tanks_and_batts
                                 false, // show_inventory
                                 false, // show_thrust
                                 false, // show_integrity
                                 false, // show_thrust_advanced
                            }, "hudlcd:-0.55:0.99:0.7"); // hudlcd


                }
                else if (blockId.Contains("MyObjectBuilder_CameraBlock/"))
                    defaultName = "Camera";
                else if (blockId.Contains("MyObjectBuilder_SensorBlock/"))
                    defaultName = "Sensor";
                camerasAndSensorsAndLCDs[i].CustomName =
                    ship_name + name_delimiter +
                    defaultName +
                    retainSuffix(camerasAndSensorsAndLCDs[i].CustomName);
            }

            processList(reactorsSmall, "Reactor Small");
            processList(reactorsLarge, "Reactor");
            processList(h2Engines, "H2 Engine");
            //processList(cargosSmall, "Cargo Small");
            processList(cargos, "Cargo");
            processList(tanksH2, "Hydrogen Tank");
            processList(tanksO2, "Oxygen Tank");
            processList(vents, "Vent");
            processList(thrustersRcs, "RCS");
            processList(thrustersMain, "Epstein");
            processList(pdcs, "PDC");
            processList(defencePdcs, "PDC");
            processList(railguns, "Railgun");
            processList(coilguns, "Coilgun");
            processList(antennas, "Antenna");
            processList(hangarDoors, "Hangar Door");
            processList(gyros, "Gyroscope");
            processList(beacons, "Beacon");
            processList(torps, "Torpedo");
            processList(batteries, "Battery");
            processList(extractors, "Extractor");
            processList(drills, "Drill");
            processList(welders, "Welder");
            processList(grinders, "Grinder");
            processList(servers, "PB Server");
            processList(lightsInterior, "Light"+ name_delimiter + "Interior");
            processList(lightsExterior, "Light" + name_delimiter + "Exterior");
            processList(lightsNavStarboard, "Light" + name_delimiter + "Nav" + name_delimiter + "Starboard");
            processList(lightsNavPort, "Light" + name_delimiter + "Nav" + name_delimiter + "Port");
            processList(lightsSpotlights, "Spotlights");

            ALERTS.Add(new ALERT(
                "Init:" + ship,
                "Initialised '" + ship + "'\nGood Hunting!"
                , 3
                ));

        }


        /*void setEvade(string state)
        {
            Echo("Setting evade to " + state);
        }*/

        string retainSuffix(string name, string new_name = "")
        {
            // Syntax            
            // <ship name>.<block type>.<padded count> for most blocks that you have a lot of
            // eg Tachi.Gyroscope.69
            // <ship name>.<block type>.<friendly name> for more specifically named blocks lke connectors
            // eg Tachi.Connector.Upper Aft
            // <ship name>.Door.Airlock.<Airlock_ID>.<friendly name>' for airlock doors (important)
            // eg Tachi.Door.Airlock.Starboard.Inner


            // this function tries to recover the
            // previous extra data that had been added to a block's name.
            // so that you can rename a ship without having to redo customimsed names.
            // so long as the correct syntax has been used...

            try
            {
                string[] parsed = name.Split(name_delimiter);

                string[] new_name_bits = new_name.Split(name_delimiter);

                string result = "";
                if (parsed.Length < 3) return "";
                // start loop at 2 because 0 is the ship name and 1 is the block name.
                for (int i = 2; i < parsed.Length; i++)
                {

                    // sometimes the third bit is just a number
                    // but i'm renumbering
                    // so fuck that cunt off.

                    // actually now we're fucking off all numbers.
                    // this is so we can have names with delimiters in them
                    // (ie numbers aren't always i=2)
                    int oldnum = 0;
                    bool isNum = int.TryParse(parsed[i], out oldnum);
                    if (isNum) parsed[i] = "";


                    // this lets me have delimiters in the names fed into processList
                    // basically it will ignore bits which are part of it's new name.
                    foreach (string new_name_bit in new_name_bits)
                    {
                        if (new_name_bit == parsed[i]) parsed[i] = "";
                    }


                    if (parsed[i] != "")
                        result += name_delimiter + parsed[i];
                }
                return result;
            }
            catch
            {
                // if the parsing fails
                // just reset.
                return "";
            }
        }

        void processList(List<IMyTerminalBlock> blocks, string name, bool numbers = false)
        {
            if (FORCE_ENUMERATION.Count > 0)
            {
                foreach (string NumName in FORCE_ENUMERATION)
                {
                    if (name.Contains(NumName))
                    {
                        if (debug) Echo("Forcing enumeration '" + NumName + "' on " + name);
                        numbers = true;
                        break;
                    }
                }
            }




            int count = 0;
            int padDepth = 2;
            if (blocks.Count < 10) padDepth = 1;
            if (blocks.Count > 99) padDepth = 3;
            for (int i = 0; i < blocks.Count; i++)
            {

                string this_name = name;

                if (NAME_WEAPON_TYPES)
                {
                    // some special name appendments.
                    if (name == "PDC")
                    {
                        string blockId = blocks[i].BlockDefinition.ToString();
                        if (blockId.Contains("Flak")) this_name += ".Flak";
                        else if (blockId.Contains("Voltaire")) this_name += ".Volt";
                        else if (blockId.Contains("Outer Planets Alliance")) this_name += ".OPA";
                        else if (blockId.Contains("Nariman")) this_name += ".Nari";
                        else if (blockId.Contains("Redfields")) this_name += ".Red";
                    }
                    else if (name == "Torpedo")
                    {
                        string blockId = blocks[i].BlockDefinition.ToString();
                        if (blockId.Contains("Apollo")) this_name += ".Apollo";
                        else if (blockId.Contains("Tycho")) this_name += ".Tycho";
                        else if (blockId.Contains("Ares")) this_name += ".Ares";
                        else if (blockId.Contains("Artemis")) this_name += ".Art";

                    }
                }

                // for chem thrusters.
                if (name == "Epstein")
                {
                    string blockId = blocks[i].BlockDefinition.ToString();
                    if (blockId.Contains("Hydro")) this_name = "Chemical";
                }

                // for cargos
                else if (name == "Cargo")
                {

                    double Max = blocks[i].GetInventory().MaxVolume.RawValue;
                    double VolumeFactor = Math.Round(Max / 1265625024, 1);
                    if (VolumeFactor == 0) VolumeFactor = 0.1;

                    this_name += " [" + VolumeFactor + "]";
                }

                else if (name == "Light" + name_delimiter + "Interior")
                {
                    string blockId = blocks[i].BlockDefinition.ToString();
                    if (blockId.Contains("Kitchen")) this_name += ".Kitchen";
                    else if (blockId.Contains("Aquarium")) this_name += ".Aquarium";
                }

                count++;
                string blockNumber = name_delimiter + count.ToString().PadLeft(padDepth, '0');
                if (!numbers) blockNumber = "";
                else if (blocks.Count == 1) blockNumber = "";
                blocks[i].CustomName =
                    ship_name + name_delimiter
                    + this_name
                    + blockNumber
                    + retainSuffix(blocks[i].CustomName, this_name);
            }
        }

        void setComms(string comms)
        {
            current_comms = comms;
            for (int i = 0; i < antenna_blocks.Count; i++)
            {
                antenna_blocks[i].HudText = comms;
            }
        }

        void setBlockRepelOn(IMyTerminalBlock block)
        {
            bool repelStatus = block.GetValue<bool>("WC_Repel");
            //Echo("Repel status=" + repelStatus);
            if (!repelStatus)
                block.ApplyAction("WC_RepelMode");
        }

        void setBlockRepelOff(IMyTerminalBlock block)
        {
            bool repelStatus = block.GetValue<bool>("WC_Repel");
            //Echo("Repel status=" + repelStatus);
            if (repelStatus)
                block.ApplyAction("WC_RepelMode");
        }

        void setBlockFireModeManual(IMyTerminalBlock block)
        {
            try
            {
                block.SetValue<Int64>("WC_Shoot Mode", 3);
                if (debug) Echo("Shoot mode = " + block.GetValue<Int64>("WC_Shoot Mode"));
            }
            catch
            {
                Echo("Failed to set fire mode to manual on " + block.CustomName);
            }
        }

        void setBlockFireModeAuto(IMyTerminalBlock block)
        {
            try
            {
                block.SetValue<Int64>("WC_Shoot Mode", 0);
                if (debug) Echo("Shoot mode = " + block.GetValue<Int64>("WC_Shoot Mode"));
            }
            catch
            {
                Echo("Failed to set fire mode to auto on " + block.CustomName);
            }
        }

        void mainLoop()
        {


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
            if (wait_step < wait_count)
            {
                wait_step++;
                return;
            }
            wait_step = 0;

            // okay so we're looping
            // what kind of loop are we going to do?
            if (loop_step >= refresh_freq)
            {
                loop_step = 0;
                fullRefresh();
                return;
            }
            // if we need fuel, do that instead.
            if (need_fuel)
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

            if (debug)
            {
                Echo("quickRefresh();");
                Echo("\nstance = " + stance_names[stance_i] + "(" + stance_i + ")");
            }


            // goals of the quick refresh:
            // > recalcuate tank values
            // > recalculate battery value
            // > manage doors
            // > Update Comms Range
            // > Update Signature Range
            // > update LCDs & Echo
            // > turn on batteries, doors, connectors, tanks
            // > recalculate ammo values
            // > recalculate fusion value
            // > Turn on PDCs, turrets 
            // > Turn on Torpedeos (change in stances as well) 
            // > turn on LCDs 

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

            // iterate over beacons
            if (debug) Echo("Iterating over " + beacon_blocks.Count + " beacons...");
            for (int i = 0; i < beacon_blocks.Count; i++)
            {
                if (beacon_blocks[i].IsWorking == true)
                {
                    // i don't need to turn beacons on or anything
                    // just want to find the first one that's working and save it's radius value.
                    current_sig_range = beacon_blocks[i].Radius;
                    break;
                }
            }


            if (adjustKeepAlives)
            {
                // iterate over connectors
                if (debug) Echo("Iterating over " + connector_blocks.Count + " connectors...");
                for (int i = 0; i < connector_blocks.Count; i++)
                {
                    if (connector_blocks[i] != null)
                        // turn on/off as required
                        if (connector_blocks[i].IsFunctional)
                            connector_blocks[i].Enabled = adjustThemTo;
                }

                // iterate over cameras, sensors, lcds
                if (debug) Echo("Iterating over " + camerasAndSensorsAndLCDs.Count + " cameras...");
                for (int i = 0; i < camerasAndSensorsAndLCDs.Count; i++)
                {
                    if (camerasAndSensorsAndLCDs[i] != null)
                        // turn on/off as required
                        if (camerasAndSensorsAndLCDs[i].IsFunctional)
                            camerasAndSensorsAndLCDs[i].ApplyAction("OnOff_On");
                }
            }

            COMMS_ON = false;

            current_comms_range = 0;
            // iterate over antennas
            if (debug) Echo("Iterating over " + antenna_blocks.Count + " antennas...");
            for (int i = 0; i < antenna_blocks.Count; i++)
            {
                if (antenna_blocks[i] != null)
                {
                    if (antenna_blocks[i].IsFunctional)
                    {
                        float range = antenna_blocks[i].Radius;
                        if (range > current_comms_range) current_comms_range = range;
                        if (antenna_blocks[i].IsBroadcasting && antenna_blocks[i].Enabled)
                            COMMS_ON = true;
                    }
                }

            }

            tank_h2_total = 0;
            tank_h2_actual = 0;
            tank_o2_total = 0;
            tank_o2_actual = 0;

            // iterate over tanks
            if (debug) Echo("Iterating over " + allTanks.Count + " tanks...");
            for (int i = 0; i < allTanks.Count; i++)
            {

                if (allTanks[i] != null)
                {
                    IMyGasTank Tank = allTanks[i] as IMyGasTank;
                    string blockId = Tank.BlockDefinition.ToString();

                    if (Tank.IsFunctional)
                    {
                        // turn on!
                        Tank.Enabled = true;

                        // update the global tank values.
                        if (blockId.Contains("Hydro"))
                        {
                            tank_h2_total += Tank.Capacity;
                            tank_h2_actual += (Tank.Capacity * Tank.FilledRatio);
                        }
                        else
                        {
                            tank_o2_total += Tank.Capacity;
                            tank_o2_actual += (Tank.Capacity * Tank.FilledRatio);
                        }
                    }
                }
            }

            integrity_tanks_H2 = Math.Round(100 * (tank_h2_total / tank_h2_init));
            integrity_tanks_O2 = Math.Round(100 * (tank_o2_total / tank_o2_init));

            bat_actual = 0;
            bat_total = 0;

            max_power = 0;

            // iterate over batteries
            if (debug) Echo("Iterating over " + batteries.Count + " batteries...");
            for (int i = 0; i < batteries.Count; i++)
            {
                if (batteries[i] != null)
                {
                    if (batteries[i].IsFunctional)
                    {
                        IMyBatteryBlock Battery = batteries[i] as IMyBatteryBlock;
                        // turn on!
                        Battery.Enabled = true;

                        bat_actual += Battery.CurrentStoredPower;
                        bat_total += Battery.MaxStoredPower;
                        max_power += Battery.MaxOutput;
                    }
                }
            }

            integrity_bats = Math.Round(100 * (max_power / bat_init));

            // iterate over inventories
            if (debug) Echo("Iterating over " + cargo_inventory.Count + " inventories...");

            // first we have to clear the old component counts
            foreach (ITEM Item in ITEMS)
            {
                Item.COUNT = 0;
                Item.STORED_IN.Clear();

                // torps are harder because they can change ammo type.
                if (Item.IS_TORP)
                    Item.ARMED_IN.Clear();

                // count PDCs, Railgun inventories for ammo.
                // don't do torps; they can change, so we calculate them as we iterate over torps.
                if (Item.AMMO && !Item.IS_TORP)
                {
                    foreach (IMyInventory WeapInv in Item.ARMED_IN)
                    {
                        Item.COUNT += WeapInv.GetItemAmount(Item.TYPE).ToIntSafe();
                    }
                }
            }

            for (int i = 0; i < cargo_inventory.Count; i++)
            {

                try
                {

                    foreach (ITEM Item in ITEMS)
                    {

                        int Count = cargo_inventory[i].GetItemAmount(Item.TYPE).ToIntSafe();
                        if (Count > 0)
                        {
                            Item.STORED_IN.Add(cargo_inventory[i]);
                            Item.COUNT += Count;
                        }
                            

                        /*MyInventoryItem? check = cargo_inventory[i].FindItem(Item.TYPE);
                        if (check != null)
                        {
                            string[] parse_dat = check.ToString().Split('x');
                            //Echo(">> " + parse_dat[0]);
                            //Echo(">> " + check.ToString());
                            double count = double.Parse(parse_dat[0]);
                            Item.COUNT += (int)Math.Round(count);


                            if (count > 0)
                                Item.STORED_IN.Add(cargo_inventory[i]);
                        }*/


                    }
                }
                catch
                {
                    if (debug) Echo("Failed to check an inventory, i=" + i);
                }
            }

            if (debug) Echo("Iterating over " + vents.Count + " vents...");
            vents_sealed = 0;
            for (int i = 0; i < vents.Count; i++)
            {
                IMyAirVent this_vent = vents[i] as IMyAirVent;
                if (this_vent.CanPressurize) vents_sealed++;
            }

            if (debug) Echo("Iterating over " + torps.Count + " torpedoes...");
            double FunctionalTorps = 0;
            for (int i = 0; i < torps.Count; i++)
            {
                if (torps[i] != null)
                {
                    if (torps[i].IsFunctional)
                    {
                        FunctionalTorps++;
                        if (!inventorySomewhatFull(torps[i])) TO_LOAD.Add(torps[i]);

                        string AmmoType = WC_PB_API.GetActiveAmmo(torps[i], 0);
                        string OutputAmmoType = getOutputAmmoType(AmmoType);
                        IMyInventory WeapInv = torps[i].GetInventory();

                        if (debug) Echo("Launcher " + torps[i].CustomName + " needs " + OutputAmmoType);

                        foreach (ITEM Item in ITEMS)
                        {

                            if (Item.IS_TORP)
                            {
                                //if (debug) Echo("Checking for " + Item.NAME);

                                // this counts torps in launchers.
                                int Count = WeapInv.GetItemAmount(Item.TYPE).ToIntSafe();
                                Item.COUNT += Count;

                                if (Item.TYPE.SubtypeId == OutputAmmoType)
                                {
                                    Item.ARMED_IN.Add(WeapInv);
                                }
                                else if (Count > 0)
                                {
                                    if (debug) Echo("Attempting to unload " + Count + "x " + Item.TYPE.SubtypeId + " from " + torps[i].CustomName + "...");

                                    List<MyInventoryItem> Items = new List<MyInventoryItem>();
                                    WeapInv.GetItems(Items);

                                    foreach (MyInventoryItem InvItem in Items)
                                    {
                                        if (InvItem.ToString().Contains(Item.TYPE.SubtypeId))
                                        {
                                            foreach (IMyInventory CargoInv in cargo_inventory)
                                            {
                                                bool Success = CargoInv.TransferItemFrom(WeapInv, InvItem, Count);
                                                if (Success)
                                                {
                                                    if (WeapInv.GetItemAmount(Item.TYPE).ToIntSafe() < 1)
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (torps[i].CustomName.Contains(ship_name) && !torps[i].CustomName.Contains(ignore_keyword))
                        {
                            // turn torps on for 1+
                            if (stance_data[stance_i][0] < 1)
                                torps[i].ApplyAction("OnOff_Off");
                            else
                                torps[i].ApplyAction("OnOff_On");
                        }
                    }
                }


            }
            integrity_torps = Math.Round(100 * (FunctionalTorps / torps_init));


            if (debug) Echo("Iterating over " + pdcs.Count + " PDCs...");
            double FunctionalPDCs = 0;
            for (int i = 0; i < pdcs.Count; i++)
            {
                if (pdcs[i] != null)
                {
                    if (pdcs[i].IsFunctional)
                    {
                        FunctionalPDCs++;
                        if (AUTOLOAD)
                        {

                            if (AUTOLOAD)
                                if (!inventorySomewhatFull(pdcs[i])) TO_LOAD.Add(pdcs[i]);

                            // rofl.
                            // IsFull doesn't work because volume of a full inner PDC is...
                            // 1000000 / 1000002
                            // so instead now I just confirm that it's > 95% full.

                            /*IMyInventory thisInventory = pdcs[i].GetInventory();
                            bool SomewhatFull = thisInventory.CurrentVolume.RawValue > (thisInventory.MaxVolume.RawValue * 0.95);
                            Echo("CurrentVolume:" + thisInventory.CurrentVolume.RawValue + ", Threshold:" + (thisInventory.MaxVolume.RawValue * 0.9) + ", Max:" + thisInventory.MaxVolume.RawValue);
                            Echo("full:" + thisInventory.IsFull);
                            Echo("somewhat full:" + SomewhatFull);
                            if (!SomewhatFull) TO_LOAD.Add(pdcs[i]);*/
                        }

                        if (pdcs[i].CustomName.Contains(ship_name) && !pdcs[i].CustomName.Contains(ignore_keyword))
                        {

                            // turn PDCs off for 2+
                            if (stance_data[stance_i][1] < 2)
                                pdcs[i].ApplyAction("OnOff_Off");
                            else
                                pdcs[i].ApplyAction("OnOff_On");
                        }

                    }
                }


            }
            if (debug) Echo("Iterating over " + defencePdcs.Count + " defence PDCs...");
            for (int i = 0; i < defencePdcs.Count; i++)
            {
                if (defencePdcs[i] != null)
                {
                    if (defencePdcs[i].IsFunctional)
                    {
                        FunctionalPDCs++;
                        if (AUTOLOAD)
                            if (!inventorySomewhatFull(defencePdcs[i])) TO_LOAD.Add(defencePdcs[i]);

                        if (defencePdcs[i].CustomName.Contains(ship_name) && !defencePdcs[i].CustomName.Contains(ignore_keyword))
                        {

                            // turn defence pdcs on for 1+
                            if (stance_data[stance_i][1] < 1)
                                defencePdcs[i].ApplyAction("OnOff_Off");
                            else
                                defencePdcs[i].ApplyAction("OnOff_On");
                        }
                    }
                }

            }
            integrity_pdcs = Math.Round(100 * (FunctionalPDCs / pdcs_init));

            if (debug) Echo("Iterating over " + railguns.Count + " railguns...");
            double FunctionalRailguns = 0;
            for (int i = 0; i < railguns.Count; i++)
            {
                if (railguns[i] != null)
                {
                    if (railguns[i].IsFunctional)
                    {
                        FunctionalRailguns++;
                        if (AUTOLOAD)
                            if (!inventorySomewhatFull(railguns[i])) TO_LOAD.Add(railguns[i]);

                        if (railguns[i].CustomName.Contains(ship_name) && !railguns[i].CustomName.Contains(ignore_keyword))
                        {

                            // turn railguns on for 1+
                            if (stance_data[stance_i][2] < 1)
                                railguns[i].ApplyAction("OnOff_Off");
                            else
                                railguns[i].ApplyAction("OnOff_On");
                        }
                    }
                }
            }
            integrity_railguns = Math.Round(100 * (FunctionalRailguns / railguns_init));

            if (debug) Echo("Iterating over " + gyros.Count + " gyros...");
            double FunctionalGyros = 0;
            for (int i = 0; i < gyros.Count; i++)
            {
                if (gyros[i] != null)
                {
                    if (gyros[i].IsFunctional && gyros[i].CustomName.Contains(ship_name))
                    {
                        FunctionalGyros++;
                        if (adjustKeepAlives)
                        {
                            if (adjustThemTo)
                                gyros[i].ApplyAction("OnOff_On");
                            else
                                gyros[i].ApplyAction("OnOff_Off");
                        }


                        
                    }
                }
            }
            integrity_gyros = Math.Round(100 * (FunctionalGyros / gyros_init));

            if (debug) Echo("Iterating over " + reactorsAll.Count + " reactors...");
            reactorsEmpty.Clear();
            double FunctionalReactors = 0;
            for (int i = 0; i < reactorsAll.Count; i++)
            {
                if (reactorsAll[i].IsFunctional && reactorsAll[i].CustomName.Contains(ship_name))
                {
                    if (inventoryEmpty(reactorsAll[i]))
                    {
                        reactorsEmpty.Add(reactorsAll[i]);
                    }
                    else
                    {
                        FunctionalReactors += (reactorsAll[i] as IMyReactor).MaxOutput;
                    }
                }
                    


            }

            max_power += FunctionalReactors;

            integrity_reactors = Math.Round(100 * (FunctionalReactors / reactors_init));

            float total_max = 0;
            float on_max = 0;
            float total_actual = 0;
            float on_actual = 0;

            foreach (IMyTerminalBlock thruster in thrustersMain)
            {
                if (thruster != null)
                {
                    if (thruster.IsFunctional && thruster.CustomName.Contains(ship_name))
                    {
                        IMyThrust Drive = thruster as IMyThrust;

                        total_max += Drive.MaxThrust;
                        total_actual += Drive.CurrentThrust;

                        if (Drive.Enabled)
                        {
                            on_max += Drive.MaxThrust;
                            on_actual += Drive.CurrentThrust;
                        }
                    }
                }
            }
            // calculate current thrust.
            // if nothing is on, we want to show numbers for all drives
            if (on_max == 0)
            {
                max_thrust = total_max;
                actual_thrust = total_actual;
            }
            // but if some drives are on, show numbers for those drives only.
            else
            {
                max_thrust = on_max;
                actual_thrust = on_actual;
            }

            integrity_main_thrust = Math.Round(100 * (total_max / thrust_main_init));

            float MaxRcsThrust = 0;
            foreach (IMyTerminalBlock thruster in thrustersRcs)
            {
                if (thruster != null)
                    if (thruster.IsFunctional && thruster.CustomName.Contains(ship_name))
                        MaxRcsThrust += (thruster as IMyThrust).MaxThrust;
            }
            integrity_rcs_thrust = Math.Round(100 * (MaxRcsThrust / thrust_rcs_init));

            try
            {
                // calculate current mass and velocity
                velocity = controller.GetShipSpeed();
                mass = controller.CalculateShipMass().PhysicalMass;
            }
            catch { }

            manageExtractors();
            manageAutoload();
            manageDoors();
            updateLcd();
            return;
        }

        void fullRefresh()
        {
            if (debug) Echo("fullRefresh();");

            // goals of the full refresh:
            // > reparse custom data, reset if required.
            // > clear & recalculate the lcd_blocks list.
            // > clear & recalculate the antenna_blocks list.

            updateCustomData(false);

            List<IMyShipController> controllers = new List<IMyShipController>();
            GridTerminalSystem.GetBlocksOfType<IMyShipController>(controllers);

            if (controllers.Count > 1)
            {
                controller = controllers[0];
            }


            // we're about to rebuild these so shud clear them.
            lcd_blocks.Clear();
            antenna_blocks.Clear();
            door_blocks.Clear();
            cargo_inventory.Clear();
            projector_blocks.Clear();

            if (debug) Echo("Building antenna list...");

            // > recalculate the antenna_blocks list.
            List<IMyRadioAntenna> ants = new List<IMyRadioAntenna>();
            GridTerminalSystem.GetBlocksOfType<IMyRadioAntenna>(ants);

            for (int i = 0; i < ants.Count; i++)
            {
                // block is an antenna for the comms command to control.
                if (ants[i].CustomName.Contains(ship_name) && !ants[i].CustomName.Contains(ignore_keyword))
                {
                    antenna_blocks.Add(ants[i]);
                }
            }

            if (debug) Echo("Building LCDs list...");

            // recalculate LCD list
            List<IMyTextPanel> lcds = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(lcds);

            for (int i = 0; i < lcds.Count; i++)
            {
                // block is an LCD we're going to write our data too.
                if (
                    lcds[i].CustomName.Contains(lcd_keyword)
                    &&
                    lcds[i].CustomName.Contains(ship_name)
                    &&
                    !lcds[i].CustomName.Contains(ignore_keyword))
                {
                    lcd_blocks.Add(lcds[i]);

                    // tidy up the LCD as well.
                    lcds[i].ContentType = ContentType.TEXT_AND_IMAGE;



                    /*if (!disable_text_colour_enforcement)
                        lcds[i].FontColor = new Color(
                                stance_data[stance_i][12],
                                stance_data[stance_i][13],
                                stance_data[stance_i][14],
                                stance_data[stance_i][15]
                                );*/



                    //lcds[i].FontSize = LCD_FONT_SIZE;
                    lcds[i].Font = "Monospace";
                    //lcds[i].TextPadding = 0;
                    lcds[i].Alignment = TextAlignment.CENTER;
                }
            }

            if (debug) Echo("Building doors list...");

            // recalculate Door list
            List<IMyDoor> doors = new List<IMyDoor>();
            GridTerminalSystem.GetBlocksOfType<IMyDoor>(doors);

            for (int i = 0; i < doors.Count; i++)
            {
                if (
                    doors[i].CustomName.Contains(ship_name)
                    &&
                    !doors[i].CustomName.Contains(ignore_keyword)
                    &&
                    !doors[i].BlockDefinition.ToString().Contains("MyObjectBuilder_AirtightHangarDoor/")
                    )
                {
                    door_blocks.Add(doors[i]);
                }
            }

            if (debug) Echo("Building beacon list...");

            // recalculate Beacon list
            List<IMyBeacon> beaconz = new List<IMyBeacon>();
            GridTerminalSystem.GetBlocksOfType<IMyBeacon>(beaconz);

            for (int i = 0; i < beaconz.Count; i++)
            {
                if (beaconz[i].CustomName.Contains(ship_name) && !beaconz[i].CustomName.Contains(ignore_keyword))
                {
                    beacon_blocks.Add(beaconz[i]);
                }
            }

            if (debug) Echo("Building connector and collector lists...");

            // recalculate Connector list
            List<IMyShipConnector> connectors = new List<IMyShipConnector>();
            GridTerminalSystem.GetBlocksOfType<IMyShipConnector>(connectors);

            for (int i = 0; i < connectors.Count; i++)
            {
                if (connectors[i].CustomName.Contains(ship_name) && !connectors[i].CustomName.Contains(ignore_keyword))
                {
                    connector_blocks.Add(connectors[i]);
                    cargo_inventory.Add(connectors[i].GetInventory());
                }
            }

            // also collectors, lets check inventories on them as well.
            List<IMyCollector> collectors = new List<IMyCollector>();
            GridTerminalSystem.GetBlocksOfType<IMyCollector>(collectors);

            for (int i = 0; i < collectors.Count; i++)
            {
                cargo_inventory.Add(collectors[i].GetInventory());
            }

            if (debug) Echo("Building inventories list...");

            // > recalculate the cargo_inventory list.
            // we check cargo containers first, then cockpits, then reactors.
            List<IMyCargoContainer> tempcargos = new List<IMyCargoContainer>();
            GridTerminalSystem.GetBlocksOfType<IMyCargoContainer>(cargos);

            for (int i = 0; i < tempcargos.Count; i++)
            {
                if (tempcargos[i].CustomName.Contains(ship_name) && !tempcargos[i].CustomName.Contains(ignore_keyword))
                {
                    cargo_inventory.Add(tempcargos[i].GetInventory());
                }
            }


            if (debug) Echo("Building cockpits list...");

            List<IMyCockpit> cockpits = new List<IMyCockpit>();
            GridTerminalSystem.GetBlocksOfType<IMyCockpit>(cockpits);

            for (int i = 0; i < cockpits.Count; i++)
            {
                if (
                    cockpits[i].CustomName.Contains(ship_name)
                    &&
                    // weird edge case: helms don't have inventory at all.
                    cockpits[i].HasInventory == true
                    )
                {
                    cargo_inventory.Add(cockpits[i].GetInventory());
                }
            }

            // now_reactors = cargo_inventory.Count;

            if (debug) Echo("Building reactor inventory list...");

            // reactors now. use above var to find these ones later.
            List<IMyReactor> reactors = new List<IMyReactor>();
            GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors);

            for (int i = 0; i < reactors.Count; i++)
            {
                // block is an antenna for the comms command to control.
                if (reactors[i].CustomName.Contains(ship_name))
                {
                    cargo_inventory.Add(reactors[i].GetInventory());
                }
            }

            if (debug) Echo("Building projector list...");

            // projectors
            // TODO make the rest of them tidy like this one!
            projector_blocks.Clear();
            GridTerminalSystem.GetBlocksOfType<IMyProjector>(
                projector_blocks,
                b =>
                    b.CustomName.Contains(ship_name) &&
                    !b.CustomName.Contains(ignore_keyword) &&
                    b.IsSameConstructAs(Me)
                );





            if (debug) Echo("Building general lists...");

            servers.Clear();
            serversEfc.Clear();
            pdcs.Clear();
            defencePdcs.Clear();
            torps.Clear();
            railguns.Clear();
            thrustersMain.Clear();
            thrustersRcs.Clear();
            lightsSpotlights.Clear();
            lightsExterior.Clear();
            lightsInterior.Clear();
            lightsNavPort.Clear();
            lightsNavStarboard.Clear();
            auxiliaries.Clear();
            gyros.Clear();
            extractors.Clear();
            reactorsSmall.Clear();
            reactorsLarge.Clear();
            reactorsAll.Clear();
            h2Engines.Clear();
            //cargosSmall.Clear();
            cargos.Clear();
            tanksH2.Clear();
            tanksO2.Clear();
            vents.Clear();
            allTanks.Clear();
            antennas.Clear();
            beacons.Clear();
            batteries.Clear();
            drills.Clear();
            welders.Clear();
            grinders.Clear();
            hangarDoors.Clear();
            camerasAndSensorsAndLCDs.Clear();

            everythingElse.Clear();

            bool sg_extractors = true;

            int ignoreCount = 0;
            UNOWNED_BLOCKS = 0;

            List<IMyTerminalBlock> allBlocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(allBlocks);

            for (int i = 0; i < allBlocks.Count; i++)
            {



                // only do this for items on my 'construct' not connected ships.
                if (Me.IsSameConstructAs(allBlocks[i]))
                /*&& allBlocks[i].CustomName.Contains(ship_name)*/ // this breaks init of course lol
                {

                    // we build the general lists by parsing this little string...
                    string blockId = allBlocks[i].BlockDefinition.ToString();

                    // handle spawns
                    if (blockId.Contains("MedicalRoom/") || blockId.Contains("SurvivalKit/"))
                    {
                        allBlocks[i].CustomData = sk_data;
                        if (!allBlocks[i].CustomName.Contains(ignore_keyword))
                            allBlocks[i].ApplyAction("OnOff_On");
                    }

                    // check for unowned blocks
                    string Tag = allBlocks[i].GetOwnerFactionTag();
                    if (Tag != faction_tag && Tag != "")
                    {
                        Echo(">>>" + Tag + "<<<");
                        UNOWNED_BLOCKS++;
                    }

                    /* PDCs NEW
                    ConveyorSorter/Ostman-Jazinski Flak Cannon
                    ConveyorSorter/Nariman Dynamics PDC
                    ConveyorSorter/Nariman Dynamics PDC Slope Base
                    ConveyorSorter/Voltaire Collective Anti Personnel PDC
                    ConveyorSorter/Outer Planets Alliance Point Defence Cannon
                    ConveyorSorter/Redfields Ballistics PDC
                    ConveyorSorter/Redfields Ballistics PDC Slope Base
                    */

                    if (
                        blockId.Contains("Ostman-Jazinski Flak Cannon")
                        ||
                        blockId.Contains("Voltaire Collective Anti Personnel PDC")
                        ||
                        blockId.Contains("Outer Planets Alliance Point Defence Cannon")
                        )
                    {
                        if (allBlocks[i].CustomName.Contains(defence_pdc_keyword))
                            defencePdcs.Add(allBlocks[i]);
                        else
                            pdcs.Add(allBlocks[i]);

                        ITEMS[3].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (
                        blockId.Contains("Nariman Dynamics PDC")
                        ||
                        blockId.Contains("Redfields Ballistics PDC")
                        )
                    {
                        if (allBlocks[i].CustomName.Contains(defence_pdc_keyword))
                            defencePdcs.Add(allBlocks[i]);
                        else
                            pdcs.Add(allBlocks[i]);

                        ITEMS[4].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    /* Torpedoes NEW
                    ConveyorSorter/Apollo Class Torpedo Launcher
                    ConveyorSorter/Tycho Class Torpedo Mount
                    ConveyorSorter/Ares_Class_Torpedo_Launcher
                    ConveyorSorter/Ares_Class_Torpedo_Launcher_F
                    ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher
                    */

                    else if (
                        blockId.Contains("Apollo Class Torpedo Launcher")
                        ||
                        blockId.Contains("Tycho Class Torpedo Mount")
                        ||
                        blockId.Contains("Ares_Class_Torpedo_Launcher")
                        ||
                        blockId.Contains("Ares_Class_TorpedoLauncher") // lol
                        ||
                        blockId.Contains("ZeusClass_Rapid_Torpedo_Launcher")
                        ||
                        blockId.Contains("Artemis_Torpedo_Tube")
                        )
                        torps.Add(allBlocks[i]);

                    /* Railguns NEW
                    ConveyorSorter/Zakosetara Heavy Railgun
                    ConveyorSorter/Mounted Zakosetara Heavy Railgun
                    ConveyorSorter/T-47 Roci Light Fixed Railgun
                    ConveyorSorter/Farren-Pattern Heavy Railgun
                    ConveyorSorter/Dawson-Pattern Medium Railgun
                    ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun
                    ConveyorSorter/V-14 Stiletto Light Railgun
                    */

                    // guess this one can stay simple for now.

                    else if (
                        blockId.Contains("Zakosetara Heavy Railgun")
                        ||
                        blockId.Contains("Mounted Zakosetara Heavy Railgun")
                        )
                    {
                        railguns.Add(allBlocks[i]);
                        ITEMS[10].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (blockId.Contains("V-14 Stiletto Light Railgun"))
                    {
                        railguns.Add(allBlocks[i]);
                        ITEMS[12].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (blockId.Contains("Dawson-Pattern Medium Railgun"))
                    {
                        railguns.Add(allBlocks[i]);
                        ITEMS[11].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (blockId.Contains("T-47 Roci Light Fixed Railgun"))
                    {
                        railguns.Add(allBlocks[i]);
                        ITEMS[13].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (blockId.Contains("VX-12 Foehammer Ultra-Heavy Railgun"))
                    {
                        railguns.Add(allBlocks[i]);
                        ITEMS[14].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (blockId.Contains("Farren-Pattern Heavy Railgun"))
                    {
                        railguns.Add(allBlocks[i]);
                        ITEMS[15].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    else if (blockId.Contains("Coilgun"))
                    {
                        // treat these as a railgun
                        railguns.Add(allBlocks[i]);
                        // this just for init
                        coilguns.Add(allBlocks[i]);
                        ITEMS[13].ARMED_IN.Add(allBlocks[i].GetInventory());
                    }

                    // ignore blocks with the ignore keyword.
                    else if (allBlocks[i].CustomName.Contains(ignore_keyword))
                        ignoreCount++;

                    // Reactors
                    // MyObjectBuilder_Reactor/LargeBlockSmallGenerator_Belter
                    // MyObjectBuilder_Reactor/LargeBlockLargeGenerator
                    // MyObjectBuilder_Reactor/LargeBlockLargeGeneratorWarfare2
                    // MyObjectBuilder_Reactor/LargeBlockSmallGeneratorWarfare2

                    else if (blockId.Contains("MyObjectBuilder_Reactor/"))
                    {
                        reactorsAll.Add(allBlocks[i]);
                        if (blockId.Contains("SmallGenerator"))
                            reactorsSmall.Add(allBlocks[i]);
                        else
                            reactorsLarge.Add(allBlocks[i]);
                    }

                    // H2 Engines
                    // MyObjectBuilder_HydrogenEngine/LargeHydrogenEngine

                    else if (blockId.Contains("MyObjectBuilder_HydrogenEngine/"))
                        h2Engines.Add(allBlocks[i]);

                    // Cargo
                    // MyObjectBuilder_CargoContainer/LargeBlockSmallContainer
                    // MyObjectBuilder_CargoContainer/LargeBlockLargeIndustrialContainer
                    // MyObjectBuilder_CargoContainer/LargeBlockLargeContainer
                    // NOTE NOT CARGO
                    // MyObjectBuilder_CargoContainer/LargeBlockLockerRoom

                    else if (blockId.Contains("MyObjectBuilder_CargoContainer/"))
                    {
                        string blockIdTwo = blockId.Split('/')[1];
                        if (blockIdTwo.Contains("Container") || blockIdTwo.Contains("Cargo"))
                            cargos.Add(allBlocks[i]);
                        else
                            everythingElse.Add(allBlocks[i]);
                    }

                    // Tanks
                    // MyObjectBuilder_OxygenTank/LargeHydrogenTankSmall
                    // MyObjectBuilder_OxygenTank/TychoCompressedHydroTank

                    else if (blockId.Contains("MyObjectBuilder_OxygenTank/"))
                    {
                        allTanks.Add(allBlocks[i]);
                        if (blockId.Contains("Hydro"))
                            tanksH2.Add(allBlocks[i]);
                        else
                            tanksO2.Add(allBlocks[i]);
                    }

                    // Vents
                    // MyObjectBuilder_AirVent/...

                    else if (blockId.Contains("MyObjectBuilder_AirVent/"))
                    {
                        vents.Add(allBlocks[i]);
                        if (allBlocks[i].CustomName.Contains("Airlock"))
                            airlock_vents.Add(allBlocks[i] as IMyAirVent);
                    }


                    // Thrusters
                    // MyObjectBuilder_Thrust/ARYLNX_Epstein_Drive
                    // MyObjectBuilder_Thrust/LynxRcsThruster1
                    // MyObjectBuilder_Thrust/AryxRCSHalfRamp

                    else if (blockId.Contains("MyObjectBuilder_Thrust/"))
                    {
                        if (blockId.ToUpper().Contains("RCS"))
                            thrustersRcs.Add(allBlocks[i]);
                        else
                            thrustersMain.Add(allBlocks[i]);
                    }


                    // Antennas
                    // MyObjectBuilder_RadioAntenna/AntennaCube
                    // MyObjectBuilder_RadioAntenna/AntennaCorner

                    else if (blockId.Contains("MyObjectBuilder_RadioAntenna/"))
                        antennas.Add(allBlocks[i]);

                    // Hangar Doors
                    // MyObjectBuilder_AirtightHangarDoor/AirtightHangarDoorWarefare2A
                    // MyObjectBuilder_RadioAntenna/AntennaCorner

                    else if (blockId.Contains("MyObjectBuilder_AirtightHangarDoor/"))
                        hangarDoors.Add(allBlocks[i]);

                    // Gyroscopes
                    // MyObjectBuilder_Gyro/LargeBlockGyro

                    else if (blockId.Contains("MyObjectBuilder_Gyro/"))
                        gyros.Add(allBlocks[i]);

                    // Beacons
                    // MyObjectBuilder_Beacon/LargeBlockBeacon

                    else if (blockId.Contains("MyObjectBuilder_Beacon/"))
                        beacons.Add(allBlocks[i]);

                    // Batteries
                    // MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlockWarfare2
                    // MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlock

                    else if (blockId.Contains("MyObjectBuilder_BatteryBlock/"))
                        batteries.Add(allBlocks[i]);

                    // Extractors
                    // MyObjectBuilder_OxygenGenerator/Extractor

                    else if (blockId == "MyObjectBuilder_OxygenGenerator/Extractor")
                    {
                        extractors.Add(allBlocks[i]);
                        sg_extractors = false;
                    }

                    // MyObjectBuilder_OxygenGenerator/ExtractorSmall
                    else if (blockId == "MyObjectBuilder_OxygenGenerator/ExtractorSmall")
                        extractors.Add(allBlocks[i]);

                    // Drills
                    // MyObjectBuilder_Drill/LargeBlockDrill
                    // MyObjectBuilder_Drill/RamshackleDrill

                    else if (blockId.Contains("MyObjectBuilder_Drill/"))
                        drills.Add(allBlocks[i]);

                    // Welders
                    // MyObjectBuilder_ShipWelder/LargeRamshackleWelder
                    // MyObjectBuilder_ShipWelder/LargeShipWelder

                    else if (blockId.Contains("MyObjectBuilder_ShipWelder/"))
                        welders.Add(allBlocks[i]);

                    // Grinders
                    // MyObjectBuilder_ShipGrinder/LargeShipGrinder
                    // MyObjectBuilder_ShipGrinder/LargeRamshackleGrinder

                    else if (blockId.Contains("MyObjectBuilder_ShipGrinder/"))
                        grinders.Add(allBlocks[i]);

                    // Servers
                    // MyObjectBuilder_MyProgrammableBlock/CommandConsole
                    // MyObjectBuilder_MyProgrammableBlock/LargeProgrammableBlock

                    else if (blockId.Contains("MyObjectBuilder_MyProgrammableBlock/"))
                    {
                        servers.Add(allBlocks[i]);
                        //serversEfc = null;
                        if (allBlocks[i].CustomName.Contains("[EFC]"))
                        {
                            serversEfc.Add(allBlocks[i]);
                        }
                    }


                    // Spotlights
                    // MyObjectBuilder_ReflectorLight/CleanSpotlight_LB
                    // MyObjectBuilder_ReflectorLight/CleanSpotlightSlope2_LB

                    else if (blockId.Contains("MyObjectBuilder_ReflectorLight/"))
                        lightsSpotlights.Add(allBlocks[i]);

                    // Lights
                    // MyObjectBuilder_InteriorLight/RoundInteriorLightOffset
                    // MyObjectBuilder_InteriorLight/LargeLightPanel

                    else if (blockId.Contains("Light/"))
                    {
                        // use name to determine grouping for lights
                        if (
                            allBlocks[i].CustomName.ToUpper().Contains("INTERIOR")
                            ||
                            blockId.Contains("Kitchen")
                            ||
                            blockId.Contains("Aquarium")
                            )
                            lightsInterior.Add(allBlocks[i]);
                        else if (allBlocks[i].CustomName.ToUpper().Contains("NAV"))
                        {
                            if (allBlocks[i].CustomName.ToUpper().Contains("STARBOARD"))
                                lightsNavStarboard.Add(allBlocks[i]);
                            else
                                lightsNavPort.Add(allBlocks[i]);
                        }
                        else
                            lightsExterior.Add(allBlocks[i]);
                    }

                    // Camera
                    // MyObjectBuilder_CameraBlock/LargeCameraBlock
                    // Sensor
                    // MyObjectBuilder_SensorBlock/LargeBlockSensor
                    // LCDs
                    // MyObjectBuilder_TextPanel/ATL_SingleLCDPanel_LG
                    // MyObjectBuilder_TextPanel/ATL_HalfSlopeArmorBlockTipLCD_LG
                    // MyObjectBuilder_TextPanel/ATL_ArmorBlockLCD_LG
                    // MyObjectBuilder_TextPanel/ATL_SlopedArmorBlockLCD_LG
                    else if (
                        blockId.Contains("MyObjectBuilder_CameraBlock/")
                        ||
                        blockId.Contains("MyObjectBuilder_TextPanel/")
                        ||
                        blockId.Contains("MyObjectBuilder_SensorBlock/")
                        )
                        camerasAndSensorsAndLCDs.Add(allBlocks[i]);


                    // Misc blocks
                    // MyObjectBuilder_MotorAdvancedStator/LargeAdvancedStator
                    // MyObjectBuilder_SurvivalKit/SurvivalKitLarge      
                    // MyObjectBuilder_ShipConnector/Connector
                    // MyObjectBuilder_Door/SlidingHatchDoor
                    // MyObjectBuilder_AirVent/AQD_LG_ConveyorVent
                    // MyObjectBuilder_Cockpit/LargeBlockCockpitIndustrial
                    // MyObjectBuilder_RemoteControl/LargeBlockRemoteControl
                    // MyObjectBuilder_CryoChamber/LargeBlockCryoChamber
                    // MyObjectBuilder_Projector/LargeProjector
                    // MyObjectBuilder_TimerBlock/TimerBlockLarge
                    // MyObjectBuilder_GravityGenerator/
                    // MyObjectBuilder_OreDetector/LargeOreDetector
                    // MyObjectBuilder_OreDetector/LargeOreDetector_Belter
                    // MyObjectBuilder_MotorStator/LargeStator
                    // MyObjectBuilder_MotorAdvancedStator/LargeHinge
                    // MyObjectBuilder_ExtendedPistonBase/LargePistonBase
                    // MyObjectBuilder_SoundBlock/LargeBlockSoundBlock
                    // MyObjectBuilder_ShipConnector/Connector_Passageway
                    // MyObjectBuilder_Warhead/LargeWarhead
                    // (Cockpits; also misc)
                    // MyObjectBuilder_Cockpit/LargeBlockCockpitSeat
                    // MyObjectBuilder_Cockpit/LargeBlockStandingCockpit
                    // MyObjectBuilder_Cockpit/EngineerConsole
                    // MyObjectBuilder_Cockpit/NavigationConsole
                    // (Fixed weapons; also misc)
                    // MyObjectBuilder_SmallGatlingGun/Glapion Collective Gatling Cannon
                    // MyObjectBuilder_SmallGatlingGun/Kess Hashari Cannon
                    // MyObjectBuilder_SmallGatlingGun/Zakosetara Heavy Railgun
                    // MyObjectBuilder_SmallMissileLauncherReload/T-47 Roci Light Fixed Railgun
                    // (Railguns; also misc)
                    // MyObjectBuilder_LargeMissileTurret/Mounted Zakosetara Heavy Railgun
                    // MyObjectBuilder_LargeMissileTurret/Farren-Pattern Heavy Railgun
                    // MyObjectBuilder_LargeMissileTurret/Dawson-Pattern Medium Railgun
                    // MyObjectBuilder_LargeMissileTurret/V-14 Stiletto Light Railgun
                    // MyObjectBuilder_LargeMissileTurret/VX-12 Foehammer Ultra-Heavy Railgun
                    // (Hangar doors; also misc)
                    // MyObjectBuilder_AirtightHangarDoor/
                    // MyObjectBuilder_AirtightHangarDoor/AirtightHangarDoorWarfare2A
                    // MyObjectBuilder_AirtightHangarDoor/AirtightHangarDoorWarfare2B
                    // MyObjectBuilder_AirtightHangarDoor/AirtightHangarDoorWarfare2C
                    // MyObjectBuilder_AirtightHangarDoor/shangar3
                    // MyObjectBuilder_AirtightHangarDoor/shangar4
                    // MyObjectBuilder_AirtightHangarDoor/shangar5
                    // MyObjectBuilder_AirtightHangarDoor/shangar6
                    // MyObjectBuilder_AirtightHangarDoor/shangar7
                    // MyObjectBuilder_AirtightHangarDoor/shangar8
                    // MyObjectBuilder_AirtightHangarDoor/shangar9
                    // MyObjectBuilder_AirtightHangarDoor/shangar10

                    else
                    {
                        everythingElse.Add(allBlocks[i]);
                    }
                }
            }

            // set fuel tank/jerry can for extractor management = 3
            if (sg_extractors)
                extractor_keep_full_threshold = (fuel_tank_keep_full_multiplier * jerry_can_capacity);
            else
                extractor_keep_full_threshold = (fuel_tank_keep_full_multiplier * fuel_tank_capacity);


            if (debug) Echo("Finished full refresh.\nIgnored " + ignoreCount + " blocks.");

            return;

        }



        void updateCustomData(bool dontParse)
        {

            // this function updates some of the variables from custom data of the prog block
            // first attempt to parse custom data.
            // if it works, update vars.
            // If it fails, reset from current vars.

            bool parsedVars = false;
            bool parsedStances = false;

            if (debug) Echo("updateCustomData(dontParse = " + dontParse + ");\n");

            if (dontParse == false)
            {

                string varSection = "";
                string stanceSection = "";

                // first we split into our two sections
                // general variables, and stances
                // since stances is iterated over
                // also, I want in different try catch statements
                // also, this makes it easier to add variables
                // so that if u fuck up a stance it doesn't ruin
                // vars and vise versa.
                try
                {
                    string[] sections = Me.CustomData.Split(new string[] { "[Stances]" }, StringSplitOptions.None);
                    varSection = sections[0];
                    stanceSection = sections[1];
                }
                catch
                {
                    if (debug) Echo("Custom Data Error! Custom data invalid or blank.");
                }

                // so now we attempt to parse the variables part.
                try
                {

                    string[] parse_dat = varSection.Split('\n');
                    int config_count = 0;

                    for (int i = 0; i < parse_dat.Length; i++)
                    {
                        if (parse_dat[i].Contains("="))
                        {
                            //string[] cleanup = parse_dat[i].Split('=');
                            string value = parse_dat[i].Substring(1);

                            // so if we contain an =, the item prior is my setting name.
                            switch (parse_dat[(i - 1)])
                            {
                                case "Ship name. Blocks without this name will be ignored":
                                    config_count++;
                                    ship_name = value;

                                    break;
                                case "Block name delimiter, used by init. One character only!":

                                    config_count++;
                                    name_delimiter = char.Parse(value.Substring(0, 1));

                                    if (debug) Echo("DELIMITER = " + name_delimiter);

                                    break;
                                case "Keyword used to identify RSM LCDs.":
                                    config_count++;
                                    lcd_keyword = value;

                                    break;
                                case "Keyword used to identify autorepair systems":
                                case "Keyword used to identify auxiliary blocks":
                                    config_count++;
                                    aux_keyword = value;

                                    break;
                                case "Keyword used to identify defence PDCs.":
                                    config_count++;
                                    defence_pdc_keyword = value;

                                    break;
                                case "Keyword used to identify minimum epstein drives.":
                                    config_count++;
                                    min_drives_keyword = value;
                                    break;
                                case "Keyword to ignore block.":
                                    config_count++;
                                    ignore_keyword = value;
                                    break;
                                case "Automatically configure PDCs, Railguns, Torpedoes.":
                                    config_count++;
                                    auto_configure_pdcs = bool.Parse(value);
                                    break;

                                case "Disable lighting all control.":
                                    config_count++;
                                    disable_lighting = bool.Parse(value);
                                    break;
                                case "Disable LCD Text Colour Enforcement.":
                                    config_count++;
                                    disable_text_colour_enforcement = bool.Parse(value);
                                    break;

                                case "Enable Weapon Autoload Functionality.":
                                    config_count++;
                                    AUTOLOAD = bool.Parse(value);
                                    break;


                                case "Number these blocks at init.":
                                    config_count++;
                                    FORCE_ENUMERATION.Clear();
                                    string[] FNames = value.Split(',');
                                    foreach (string FName in FNames)
                                    {
                                        if (FName != "")
                                            FORCE_ENUMERATION.Add(FName);
                                    }
                                    break;

                                case "Add type names to weapons at init.":
                                    config_count++;
                                    NAME_WEAPON_TYPES = bool.Parse(value);
                                    break;


                                case "Show basic telemetry.":
                                    config_count++;
                                    ADVANCED_THRUST_SHOW_BASICS = bool.Parse(value);
                                    break;
                                case "Show Decel Percentages (comma seperated).":
                                    config_count++;
                                    ADVANCED_THRUST_PERCENTS.Clear();
                                    string[] Percents = value.Split(',');
                                    foreach (string Percent in Percents)
                                    {
                                        ADVANCED_THRUST_PERCENTS.Add(double.Parse(Percent) / 100);
                                    }
                                    break;



                                case "Fusion Fuel count":
                                    config_count++;
                                    ITEMS[0].TARGET = int.Parse(value);
                                    break;

                                case "Fuel tank count":
                                    config_count++;
                                    ITEMS[1].TARGET = int.Parse(value);
                                    break;

                                case "Jerry can count":
                                    config_count++;
                                    ITEMS[2].TARGET = int.Parse(value);
                                    break;

                                case "40mm PDC Magazine count":
                                    config_count++;
                                    ITEMS[3].TARGET = int.Parse(value);
                                    break;
                                case "40mm Teflon Tungsten PDC Magazine count":
                                    config_count++;
                                    ITEMS[4].TARGET = int.Parse(value);
                                    break;

                                case "220mm Torpedo count":
                                // was like this in versions prior to 0.5.0
                                case "Torpedo count":
                                    config_count++;
                                    ITEMS[5].TARGET = int.Parse(value);
                                    break;

                                case "220mm MCRN torpedo count":
                                    config_count++;
                                    ITEMS[6].TARGET = int.Parse(value);
                                    break;

                                case "220mm UNN torpedo count":
                                    config_count++;
                                    ITEMS[7].TARGET = int.Parse(value);
                                    break;

                                case "Ramshackle torpedo count":
                                // was like this in versions prior to 0.4.0
                                case "Ramshackle torpedo Count":
                                    config_count++;
                                    ITEMS[8].TARGET = int.Parse(value);
                                    break;

                                case "Large ramshacke torpedo count":
                                    config_count++;
                                    ITEMS[9].TARGET = int.Parse(value);
                                    break;

                                case "Zako 120mm Railgun rounds count":
                                // was like this in versions prior to 0.5.0
                                case "Railgun rounds count":
                                    config_count++;
                                    ITEMS[10].TARGET = int.Parse(value);
                                    break;

                                case "Dawson 100mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[11].TARGET = int.Parse(value);
                                    break;

                                case "Stiletto 100mm MCRN Railgun rounds count":
                                    config_count++;
                                    ITEMS[12].TARGET = int.Parse(value);
                                    break;

                                case "T-47 80mm Railgun rounds count":
                                    config_count++;
                                    ITEMS[13].TARGET = int.Parse(value);
                                    break;

                                case "Foehammer 120mm MCRN rounds count":
                                    config_count++;
                                    ITEMS[14].TARGET = int.Parse(value);
                                    break;

                                case "Farren 120mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[15].TARGET = int.Parse(value);
                                    break;



                                case "Doors open timer (x100 ticks, default 3)":
                                    config_count++;
                                    door_open_time = int.Parse(value);
                                    break;
                                case "Airlock doors disabled timer (x100 ticks, default 6)":
                                    config_count++;
                                    door_airlock_time = int.Parse(value);
                                    break;
                                case "Throttle script (x100 ticks pause between loops, default 0)":
                                    config_count++;
                                    wait_count = int.Parse(value);
                                    break;
                                case "Full refresh frequency (x100 ticks, default 50)":
                                    config_count++;
                                    refresh_freq = int.Parse(value);
                                    break;
                                case "Verbose script debugging. Prints more logging info to PB details.":
                                    config_count++;
                                    debug = bool.Parse(value);
                                    break;


                                case "Private spawn (don't inject faction tag into SK custom data).":
                                    config_count++;
                                    spawn_private = bool.Parse(value);
                                    break;


                                case "Comma seperated friendly factions or steam ids for survival kits.":
                                    config_count++;
                                    friendly_tags = string.Join("\n", value.Split(','));
                                    //debug = bool.Parse(value);
                                    break;

                                case "Current Stance":
                                    config_count++;
                                    current_stance = value;

                                    // update the stance_i value as well so lights and colours aren't effected.
                                    for (int j = 0; j < stance_names.Count; j++)
                                    {
                                        if (current_stance == stance_names[j]) stance_i = j;
                                    }

                                    break;

                                case "Reactor Integrity":
                                    config_count++;
                                    reactors_init = float.Parse(value);
                                    break;
                                case "PDC Integrity":
                                    config_count++;
                                    pdcs_init = int.Parse(value);
                                    break;
                                case "Torpedo Integrity":
                                    config_count++;
                                    torps_init = int.Parse(value);
                                    break;
                                case "Railgun Integrity":
                                    config_count++;
                                    railguns_init = int.Parse(value);
                                    break;
                                case "H2 Tank Integrity":
                                    config_count++;
                                    tank_h2_init = double.Parse(value);
                                    break;
                                case "O2 Tank Integrity":
                                    config_count++;
                                    tank_o2_init = double.Parse(value);
                                    break;
                                case "Epstein Integrity":
                                    config_count++;
                                    thrust_main_init = float.Parse(value);
                                    break;
                                case "RCS Integrity":
                                    config_count++;
                                    thrust_rcs_init = float.Parse(value);
                                    break;
                                case "Gyro Integrity":
                                    config_count++;
                                    gyros_init = int.Parse(value);
                                    break;

                            }
                        }
                    }

                    if (config_count == 48)
                    {
                        parsedVars = true;
                    }



                    else
                    {
                        Echo("Did not get enough config items (" + config_count + ") from custom data, resetting.");
                    }
                }
                catch
                {
                    Echo("Custom Data Error (vars)");
                }

                if (spawn_private)
                {
                    if (spawn_open)
                        sk_data = friendly_tags;
                    else
                        sk_data = "";

                }
                else
                {
                    sk_data = "                                                                                                                                 " +
                        faction_tag;

                    if (spawn_open)
                        sk_data += "\n" + friendly_tags;

                    sk_data += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                         faction_tag;
                }



                // alright so now we try to parse stance data
                try
                {
                    string[] stances = stanceSection.Split(new string[] { "Stance:" }, StringSplitOptions.None);

                    if (debug) Echo("Parsing " + (stances.Length - 1) + " stances");

                    int data_length = stance_data[0].Length;

                    List<string> new_name_list = new List<string>();
                    List<int[]> new_data_list = new List<int[]>();

                    for (int i = 1; i < stances.Length; i++)
                    {
                        string[] stance_vars = stances[i].Split('=');

                        string new_name = "";
                        int[] new_data = new int[data_length];

                        new_name = stance_vars[0].Split(' ')[0];
                        if (debug) Echo("Parsing '" + new_name + "'");
                        for (int j = 0; j < new_data.Length; j++)
                        {
                            string[] cleanup = stance_vars[(j + 1)].Split('\n');
                            new_data[j] = int.Parse(cleanup[0]);
                            //if (debug) Echo(new_data[j].ToString());
                        }
                        new_name_list.Add(new_name);
                        new_data_list.Add(new_data);
                    }
                    if (new_name_list.Count >= 1 && new_name_list.Count == new_data_list.Count)
                    {
                        // we did it.
                        stance_names = new_name_list;
                        stance_data = new_data_list;
                        parsedStances = true;
                        if (debug) Echo("Finished parsing " + stance_names.Count + " stances.");
                    }
                    else
                    {
                        // lol force a crash
                        // TODO actually throw a proper error instead or something.
                        Echo("Didn't find any stances!");
                        Echo(stances[69420]);
                    }
                }
                catch
                {
                    Echo("Custom Data Error (stances)");
                }

                // STOP HERE IF EVERYTHING PARSED WELL!
                if (parsedVars && parsedStances) return;

            }



            string stance_text = "";

            if (stance_names.Count != stance_data.Count) Echo("Um, so...\nstance_names.Count != stance_data.Count");

            if (stance_names.Count < 1 && debug)
            {
                Echo("No stances!");
            }

            if (!dontParse)
                ALERTS.Add(new ALERT(
                    "RESET CUSTOM DATA!",
                    "Something went wrong, so custom data was reset.\nVars Parsed=" + parsedVars + "\nStances Parsed=" + parsedStances
                    , 3
                    ));

            else
                Echo("Saved custom data.");

            for (int i = 0; i < stance_names.Count; i++)
            {
                stance_text += " - Stance:" + stance_names[i] + " - \n"
                    + "torpedoes; 0: off, 1: on;\n="
                    + stance_data[i][0] + "\n"
                    + "pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence, 4: all on only\n="
                    + stance_data[i][1] + "\n"
                    + "railguns; 0: off, 1: hold fire, 2: AI weapons free;\n="
                    + stance_data[i][2] + "\n"
                    + "epstein drives; 0: off, 1: on, 2: minimum on only\n="
                    + stance_data[i][3] + "\n"
                    + "rcs thrusters; 0: off, 1: on, 2: forward off, 3: reverse off\n="
                    + stance_data[i][4] + "\n"
                    + "spotlights; 0: off, 1: on, 2: on max radius, 3: no change\n="
                    + stance_data[i][5] + "\n"

                    + "exterior lights; 0: off, 1: on, 3: no change\n="
                    + stance_data[i][6]
                    + "\nred=" + stance_data[i][7] + "\ngreen=" + stance_data[i][8]
                    + "\nblue=" + stance_data[i][9] + "\nalpha=" + stance_data[i][10] + "\n"

                    + "interior lights lights; 0: off, 1: on, 3: no change\n="
                    + stance_data[i][11]
                    + "\nred=" + stance_data[i][12] + "\ngreen=" + stance_data[i][13]
                    + "\nblue=" + stance_data[i][14] + "\nalpha=" + stance_data[i][15] + "\n"

                    // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                    + "stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts\n="
                    + stance_data[i][16] + "\n"
                    + "EFC boost; 0: off, 1: on\n="
                    + stance_data[i][17] + "\n"
                    + "EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%\n="
                    + stance_data[i][18] + "\n"
                    + "EFC kill; 0: no change, 1: run 'Off' on EFC.\n="
                    + stance_data[i][19] + "\n"
                    + "auxiliary blocks; 0: off, 1: on\n="
                    + stance_data[i][20] + "\n"
                    + "extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.\n="
                    + stance_data[i][21] + "\n"
                    + "keep-alives for connectors, gyros, lcds, cameras, sensors; 0: ignore, 1: force on, 2: force off\n="
                    + stance_data[i][22] + "\n"
                    + "hangar doors; 0: closed, 1: open, 2: no change\n="
                    + stance_data[i][23] + "\n\n"
                    ;
            }

            string DecelPercents = "";

            foreach (double Percent in ADVANCED_THRUST_PERCENTS)
            {
                if (DecelPercents != "") DecelPercents += ",";
                DecelPercents += (Percent * 100).ToString();
            }

            string ForcedNames = "";

            foreach (string FName in FORCE_ENUMERATION)
            {
                if (ForcedNames != "") ForcedNames += ",";
                ForcedNames += FName;
            }

            Me.CustomData =
                "-------------------------\n"
                + "Reedit Ship Management" + "\n"
                + "-------------------------\n"
                + "If this data can't be parsed, it will be reset!" + "\n"

                + "\n---- [General Settings] ----\n"
                + "Block name delimiter, used by init. One character only!\n=" + name_delimiter + "\n"
                + "Keyword used to identify RSM LCDs.\n=" + lcd_keyword + "\n"
                + "Keyword used to identify auxiliary blocks\n=" + aux_keyword + "\n"
                + "Keyword used to identify minimum epstein drives.\n=" + min_drives_keyword + "\n"
                + "Keyword used to identify defence PDCs.\n=" + defence_pdc_keyword + "\n"
                + "Keyword to ignore block.\n=" + ignore_keyword + "\n"
                + "Enable Weapon Autoload Functionality.\n=" + AUTOLOAD + "\n"
                + "Automatically configure PDCs, Railguns, Torpedoes.\n=" + auto_configure_pdcs + "\n"
                + "Disable lighting all control.\n=" + disable_lighting + "\n"
                + "Disable LCD Text Colour Enforcement.\n=" + disable_text_colour_enforcement + "\n"
                + "Private spawn (don't inject faction tag into SK custom data).\n=" + spawn_private + "\n"
                + "Comma seperated friendly factions or steam ids for survival kits.\n=" + (string.Join(",", friendly_tags.Split('\n'))) + "\n"
                + "Number these blocks at init.\n=" + ForcedNames + "\n"
                + "Add type names to weapons at init.\n=" + NAME_WEAPON_TYPES + "\n"

                + "\n---- [Door Timers] ----\n"
                + "Doors open timer (x100 ticks, default 3)\n=" + door_open_time + "\n"
                + "Airlock doors disabled timer (x100 ticks, default 6)\n=" + door_airlock_time + "\n"

                + "\n---- [Advanced Thrust LCD] ----\n"
                + "Show basic telemetry.\n=" + ADVANCED_THRUST_SHOW_BASICS + "\n"
                + "Show Decel Percentages (comma seperated).\n=" + DecelPercents + "\n"

                + "\n---- [Performance & Debugging] ----\n"
                + "Throttle script (x100 ticks pause between loops, default 0)\n=" + wait_count + "\n"
                + "Full refresh frequency (x100 ticks, default 50)\n=" + refresh_freq + "\n"
                + "Verbose script debugging. Prints more logging info to PB details.\n=" + debug + "\n"

                + "\n---- [System] ----\n"
                + "You can edit these if you want...\nbut they are usually populated by the script and saved here.\n"
                + "Ship name. Blocks without this name will be ignored\n=" + ship_name + "\n"
                + "Current Stance\n=" + current_stance + "\n"
                + "Reactor Integrity\n=" + reactors_init + "\n"
                + "PDC Integrity\n=" + pdcs_init + "\n"
                + "Torpedo Integrity\n=" + torps_init + "\n"
                + "Railgun Integrity\n=" + railguns_init + "\n"
                + "H2 Tank Integrity\n=" + tank_h2_init + "\n"
                + "O2 Tank Integrity\n=" + tank_o2_init + "\n"
                + "Epstein Integrity\n=" + thrust_main_init + "\n"
                + "RCS Integrity\n=" + thrust_rcs_init + "\n"
                + "Gyro Integrity\n=" + gyros_init + "\n"

                + "\n---- [Inventory Counts] ----\n"
                + "You can edit these if you want...\nbut they are usually populated by the script and saved here.\n"
                + "Fusion Fuel count\n=" + ITEMS[0].TARGET + "\n"

                + "Fuel tank count\n=" + ITEMS[1].TARGET + "\n"
                + "Jerry can count\n=" + ITEMS[2].TARGET + "\n"

                + "40mm PDC Magazine count\n=" + ITEMS[3].TARGET + "\n"
                + "40mm Teflon Tungsten PDC Magazine count\n=" + ITEMS[4].TARGET + "\n"

                + "220mm Torpedo count\n=" + ITEMS[5].TARGET + "\n"
                + "220mm MCRN torpedo count\n=" + ITEMS[6].TARGET + "\n"
                + "220mm UNN torpedo count\n=" + ITEMS[7].TARGET + "\n"

                + "Ramshackle torpedo count\n=" + ITEMS[8].TARGET + "\n"
                + "Large ramshacke torpedo count\n=" + ITEMS[9].TARGET + "\n"

                + "Zako 120mm Railgun rounds count\n=" + ITEMS[10].TARGET + "\n"
                + "Dawson 100mm UNN Railgun rounds count\n=" + ITEMS[11].TARGET + "\n"
                + "Stiletto 100mm MCRN Railgun rounds count\n=" + ITEMS[12].TARGET + "\n"
                + "T-47 80mm Railgun rounds count\n=" + ITEMS[13].TARGET + "\n"

                + "Foehammer 120mm MCRN rounds count\n=" + ITEMS[14].TARGET + "\n"
                + "Farren 120mm UNN Railgun rounds count\n=" + ITEMS[15].TARGET + "\n"


                + "\n---- [Stances] ----\n"
                + stance_text

                + "-------------------------\n\n\n\n\n";

            return;


        }



        void manageExtractors()
        {
            if (debug) Echo("manageExtractors();");

            if (stance_data[stance_i][21] < 2)
            {
                if (debug) Echo("Management disabled.");
            }
            else if (extractor_mgmt_wait > 0)
            {
                extractor_mgmt_wait--;
                if (debug) Echo("waiting (" + extractor_mgmt_wait + ")...");
            }
            else if (tanksH2.Count < 1)
            {
                if (debug) Echo("No tanks!");
            }
            else if (stance_data[stance_i][21] == 2 && fuel_percentage < min_fuel)
            // refuel at 10%
            {
                if (debug) Echo("Fuel low! (" + fuel_percentage + "% / " + min_fuel + "%)");
                need_fuel = true;
            }
            else if (stance_data[stance_i][21] == 3 && tank_h2_actual < (tank_h2_total - extractor_keep_full_threshold))
            // refuel to keep tanks full.
            {
                if (debug) Echo("Fuel ready for top up (" + tank_h2_actual + " < " + (tank_h2_total - extractor_keep_full_threshold) + ")");
                need_fuel = true;
            }
            else if (debug)
            {
                Echo("Fuel level OK (" + fuel_percentage + "%).");

                if (stance_data[stance_i][21] == 3)
                    Echo("Keeping tanks full\n(" + tank_h2_actual + " < " + (tank_h2_total - extractor_keep_full_threshold) + ")");
            }
        }

        bool inventorySomewhatFull(IMyTerminalBlock Block) // is a block's inventory > 95% full.
        {
            if (Block == null) return false;
            IMyInventory thisInventory = Block.GetInventory();
            return thisInventory.CurrentVolume.RawValue > (thisInventory.MaxVolume.RawValue * 0.95);
        }

        bool inventoryEmpty(IMyTerminalBlock Block) // is a block's inventory totally empty
        {
            IMyInventory thisInventory = Block.GetInventory();
            return thisInventory.VolumeFillFactor == 0;
        }

        void loadInventory(IMyTerminalBlock ToLoad, List<IMyInventory> SourceInventories, string ItemType, int ItemCount)
        {

            if (debug) Echo("Loading block " + ToLoad.CustomName + " with item type " + ItemType + " from " + SourceInventories.Count + " sources.");

            IMyInventory ToLoadInventory = ToLoad.GetInventory();

            foreach (IMyInventory Source in SourceInventories)
            {
                try
                {
                    List<MyInventoryItem> Items = new List<MyInventoryItem>();
                    Source.GetItems(Items);

                    foreach (MyInventoryItem Item in Items)
                    {
                        if (Item.ToString().Contains(ItemType))
                        {
                            bool success = ToLoadInventory.TransferItemFrom(Source, Item, ItemCount);
                            if (success) return;
                        }
                    }
                }
                catch { }
            }

            if (debug) Echo("Loading failed.");
        }

        void runProgramable(IMyTerminalBlock Pb, string Argument)
        {
            if (debug)
                Echo("Running '" + Argument + "' on '" + Pb.CustomName + "'");
            bool Success = (Pb as IMyProgrammableBlock).TryRun(Argument);
            if (Success)
                Echo("Failed to run '" + Argument + "' on '" + Pb.CustomName + "'");
        }

        void isThereAnEchoInHere() // Outputs stuff to the console.
        {
            PROFILER.Run();
            Echo("REEDIT SHIP MANAGEMENT \n" +
   
                "\n|- Refresh: " + loop_step + "/" + refresh_freq +
                "\n|- Runtime Av/Tick: " + (Math.Round(PROFILER.RunningAverageMs,2) / 100) + " ms" +
                "\n|- Runtime Max: " + Math.Round(PROFILER.MaxRuntimeMs,4) + " ms" +
                "\n|- Instructions: " + INSTRUCTIONS + " (" + INSTRUCTIONS_MAX + ")");

        }
    }
}



/*
ALL PDC PROPERTIES
OnOff
ShowInTerminal
ShowInInventory
ShowInToolbarConfig
Name
ShowOnHUD
Content
ScriptForegroundColor
ScriptBackgroundColor
Font
FontSize
FontColor
alignment
TextPaddingSlider
BackgroundColor
ChangeIntervalSlider
PreserveAspectRatio
Shoot
Range
EnableIdleMovement
TargetMeteors
TargetMissiles
TargetSmallShips
TargetLargeShips
TargetCharacters
TargetStations
TargetNeutrals
TargetFriends
TargetEnemies
EnableTargetLocking
TargetingGroup_Selector
UseConveyor
WC_Advanced
WC_Debug
WC_ShareFireControlEnabled
WC_Shoot
WC_Override
WC_Shoot Mode
Weapon ROF
WC_Overload
Detonation
WC_Arm
WC_ControlModes
WC_PickAmmo
WC_PickSubSystem
WC_TrackingMode
Weapon Range
WC_ReportTarget
WC_Neutrals
WC_Unowned
WC_Biologicals
WC_Projectiles
WC_Meteors
WC_Grids
WC_FocusFire
WC_SubSystems
WC_Repel
WC_LargeGrid
WC_SmallGrid
Burst Count
Burst Delay
Sequence Id
Weapon Group Id
Target Group
Camera Channel


ALL PDC ACTIONS
OnOff
OnOff_On
OnOff_Off
ShowOnHUD
ShowOnHUD_On
ShowOnHUD_Off
IncreaseFontSize
DecreaseFontSize
IncreaseTextPaddingSlider
DecreaseTextPaddingSlider
IncreaseChangeIntervalSlider
DecreaseChangeIntervalSlider
PreserveAspectRatio
ShootOnce
Shoot
Shoot_On
Shoot_Off
Control
IncreaseRange
DecreaseRange
EnableIdleMovement
EnableIdleMovement_On
EnableIdleMovement_Off
TargetMeteors
TargetMeteors_On
TargetMeteors_Off
TargetMissiles
TargetMissiles_On
TargetMissiles_Off
TargetSmallShips
TargetSmallShips_On
TargetSmallShips_Off
TargetLargeShips
TargetLargeShips_On
TargetLargeShips_Off
TargetCharacters
TargetCharacters_On
TargetCharacters_Off
TargetStations
TargetStations_On
TargetStations_Off
TargetNeutrals
TargetNeutrals_On
TargetNeutrals_Off
TargetFriends
TargetFriends_On
TargetFriends_Off
TargetEnemies
TargetEnemies_On
TargetEnemies_Off
EnableTargetLocking
TargetingGroup_Weapons
TargetingGroup_Propulsion
TargetingGroup_PowerSystems
TargetingGroup_MES-TargetingGroup-Communications
TargetingGroup_MES-TargetingGroup-Production
TargetingGroup_CycleSubsystems
CopyTarget
ForgetTarget
UseConveyor
WC_Weapon ROF_Increase
WC_Weapon ROF_Decrease
WC_Overload_Toggle
WC_Overload_Toggle_On
WC_Overload_Toggle_Off
ShootToggle
Shoot_On
Shoot_Off
WCShootMode
ActionFire
WCMouseToggle
SubSystems
ControlModes
WC_CycleAmmo
TrackingMode
ForceReload
FocusTargets
FocusSubSystem
Grids
Neutrals
Friendly
Unowned
Projectiles
Biologicals
Meteors
WC_Increase_CameraChannel
WC_Decrease_CameraChannel
WC_Increase_LeadGroup
WC_Decrease_LeadGroup
WC_RepelMode
MaxSize Increase
MaxSize Decrease
MinSize Increase
MinSize Decrease
ActionFriend
ActionEnemy
LargeGrid
SmallGrid
 */
