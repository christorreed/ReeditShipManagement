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

        // lcd variables.
        const string lcd_divider = "--------------------------------";
        const string lcd_title = "     REEDIT SHIP MANAGEMENT     ";
        string[] lcd_spinners = new string[] { "-", "\\", "|", "/" };
        int lcd_spinner_status = 0;
        const float lcd_font_size = 0.8f;
        Color lcd_font_colour = new Color(30, 144, 255, 255);

        // CUSTOM DATA STUFF
        // these are default values can also be set from custom data
        // name is also set by init.
        string ship_name = "Untitled Ship";
        // the keyword for LCDs to be controlled by this script.
        string lcd_keyword = "[RSM]";
        // the keyword for autorepair systems
        // will be set automatically for welders at Init
        // set rotors etc later as well
        string autorepair_keyword = "[Autorepair]";
        string ignore_keyword = "REEDAV";
        // the keyword for defence PDCs (secondary PDCs group)
        string defence_pdc_keyword = "Repel";
        string min_drives_keyword = "Min";
        bool auto_configure_pdcs = true;

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
        }

        ITEM LG_FUEL_TANKS;
        ITEM SG_FUEL_TANKS;
        ITEM REACTOR_FUEL;

        List<ITEM> ITEMS = new List<ITEM>();

        ITEM buildItem(string LCDName, string SubTypeID, string TypeID)
        {
            ITEM NewItem = new ITEM();
            NewItem.NAME = LCDName;
            NewItem.TYPE = new MyItemType(SubTypeID, TypeID);
            if (TypeID == "Fuel_Tank") LG_FUEL_TANKS = NewItem;
            if (TypeID == "SG_Fuel_Tank") SG_FUEL_TANKS = NewItem;
            if (TypeID == "FusionFuel") REACTOR_FUEL = NewItem;
            return NewItem;
        }


        string faction_tag;

        string friendly_tags = "";

        string sk_data = "";

        bool spawn_open = false;

        int loop_step;
        int wait_step;

        bool need_fuel = false;

        double tank_h2_actual = 0;
        double tank_h2_total = 0;
        double tank_o2_actual = 0;
        double tank_o2_total = 0;

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

        int doors_count = 0;
        int doors_count_closed = 0;
        int autorepair_active = 0;

        string current_stance = "N/A";
        string current_comms = "";
        double current_comms_range = 0;
        double current_sig_range = 0;

        bool airlock_name_error_called = false;

        // how long debug messages stay around for, in LCD refreshes.
        int debug_dwell_max = 4;
        int debug_dwell = 0;
        string debug_msg = "";
        string debug_msg_long = "";

        // the dump string, can be used to dump crap into the custom data for debugging.
        string dump_string = "";

        double velocity;
        float mass;
        float max_thrust;
        float actual_thrust;

        bool build_advanced_thrust_data = false;

        IMyShipController controller;

        // Block lists, built at fullRefresh();
        List<IMyRadioAntenna> antenna_blocks = new List<IMyRadioAntenna>();
        List<IMyTextPanel> lcd_blocks = new List<IMyTextPanel>();
        List<IMyGasTank> tank_blocks = new List<IMyGasTank>();
        List<IMyBatteryBlock> battery_blocks = new List<IMyBatteryBlock>();
        List<IMyDoor> door_blocks = new List<IMyDoor>();
        List<IMyBeacon> beacon_blocks = new List<IMyBeacon>();
        List<IMyShipConnector> connector_blocks = new List<IMyShipConnector>();
        List<IMyProjector> projector_blocks = new List<IMyProjector>();

        // Block lists, also built at fullRefresh(); but differently
        List<IMyTerminalBlock> servers = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> serversEfc = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> pdcs = new List<IMyTerminalBlock>(); // turn on/off at quickRefresh(); setup at stance set
        List<IMyTerminalBlock> defencePdcs = new List<IMyTerminalBlock>(); // turn on/off at quickRefresh(); setup at stance set
        List<IMyTerminalBlock> torps = new List<IMyTerminalBlock>(); // handle at quickRefresh();
        List<IMyTerminalBlock> railguns = new List<IMyTerminalBlock>(); // handle at quickRefresh();
        List<IMyTerminalBlock> thrustersMain = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> thrustersRcs = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> lightsSpotlights = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> lightsNav = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> lightsInterior = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> autorepairers = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> gyros = new List<IMyTerminalBlock>(); // handle at quickRefresh();
        List<IMyTerminalBlock> extractors = new List<IMyTerminalBlock>(); // handle at stance set
        List<IMyTerminalBlock> reactorsSmall = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> reactorsLarge = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> h2Engines = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> cargosSmall = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> cargosLarge = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> tanksH2 = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> tanksO2 = new List<IMyTerminalBlock>();
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

        //List<MyInventoryItem?> fuel_tank_items = new List<MyInventoryItem?>();

        // counter used to prevent refuel from looping.
        int refuel_failure_count = 0;
        int refuel_failure_threshold = 25;

        // these are the EFC set burn percentages.
        int[] burnArray = new int[] { 0, 5, 25, 50, 75, 100 };

        // Inventory and item lists.
        List<IMyInventory> cargo_inventory = new List<IMyInventory>();
        //List<MyItemType> components = new List<MyItemType>();
        //List<int> component_counts = new List<int>();

        double fuel_percentage = 100;
        List<IMyInventory> fuel_tank_inventory = new List<IMyInventory>();
        List<IMyInventory> sg_fuel_tank_inventory = new List<IMyInventory>();

        // Stance data
        int stance_i = 0;
        // these are default values that will be over written by updateCustomData();
        List<string> stance_names = new List<string>(new string[] { "Cruise", "MaxCruise", "Docked", "Docking", "NoAttack", "Coast", "Combat", "CQB", "Sleep", "StealthCruise" });

        List<int[]> stance_data = new List<int[]>
        {
             new int[] { // Cruise
                1,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
                0,      // 5:  spotlights; 0: off, 1: on, 2: on max radius
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
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                2,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, gyros, lcds; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // MaxCruise
                1,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
                0,      // 5:  spotlights; 0: off, 1: on, 2: on max radius
                1,      // 6: exterior lights; 0: off, 1: on
                30,     // 7: Red - Exterior lights colour
                144,    // 8: Green - Exterior lights colour
                255,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                36,     // 12: Red - Interior lights colour
                17,     // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                1,      // 17: EFC boost; 0: off, 1: on
                5,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Docked
                1,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                0,      // 4: rcs thrusters; 0: off, 1: on
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
                0,      // 20: autorepair; 0: off, 1: on
                0,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Docking
                1,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
                2,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                1,      // 6: exterior lights; 0: off, 1: on
                30,     // 7: Red - Exterior lights colour
                144,    // 8: Green - Exterior lights colour
                255,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                158,    // 12: Red - Interior lights colour
                26,     // 13: Green - Interior lights colour
                219,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // NoAttack
                0,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                0,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
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
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Coast
                1,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                0,      // 4: rcs thrusters; 0: off, 1: on
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
                0,      // 20: autorepair; 0: off, 1: on
                0,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },


            new int[] { // Combat
                2,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                2,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
                0,      // 5: spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,      // 7: Red - Exterior lights colour
                0,      // 8: Green - Exterior lights colour
                0,      // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                232,    // 12: Red - Interior lights colour
                55,     // 13: Green - Interior lights colour
                16,     // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                2,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                0,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                1,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // CQB
                2,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                3,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                2,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                1,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
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
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, ; 0: ignore, 1: force on, 2: force off
                2,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },

            new int[] { // Sleep
                0,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                0,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                0,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                0,      // 4: rcs thrusters; 0: off, 1: on
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
                0,      // 20: autorepair; 0: off, 1: on
                0,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                2,      // 22: keep-alives for connectors, gyros, lcds; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },
            new int[] { // StealthCruise
                1,      // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                1,      // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                2,      // 3: epstein drives; 0: off, 1: on, 2: minimum on only
                1,      // 4: rcs thrusters; 0: off, 1: on
                0,      // 5:  spotlights; 0: off, 1: on, 2: on max radius
                0,      // 6: exterior lights; 0: off, 1: on
                0,     // 7: Red - Exterior lights colour
                0,    // 8: Green - Exterior lights colour
                0,    // 9: Blue - Exterior lights colour
                255,    // 10: Alpha - Exterior lights colour
                1,      // 11: interior lights lights; 0: off, 1: on
                30,     // 12: Red - Interior lights colour
                144,    // 13: Green - Interior lights colour
                225,    // 14: Blue - Interior lights colour
                255,    // 15: Alpha - Interior lights colour
                0,      // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts, 2: discharge batts
                0,      // 17: EFC boost; 0: off, 1: on
                2,      // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                0,      // 19: EFC kill; 0: no change, 1: run 'Off' on EFC
                0,      // 20: autorepair; 0: off, 1: on
                3,      // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.
                1,      // 22: keep-alives for connectors, tanks, batteries, gyros, lcds; 0: ignore, 1: force on, 2: force off
                0,      // 23: hangar doors; 0: closed, 1: open, 2: no change
            },
        };

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

            try
            {

                ITEMS.Add(buildItem("Fusion F ", "MyObjectBuilder_Ingot", "FusionFuel")); //0
                ITEMS.Add(buildItem("Fuel Tank", "MyObjectBuilder_Component", "Fuel_Tank")); //1
                ITEMS.Add(buildItem("Jerry Can", "MyObjectBuilder_Component", "SG_Fuel_Tank")); //2

                ITEMS.Add(buildItem("PDC      ", "MyObjectBuilder_AmmoMagazine", "40mmLeadSteelPDCBoxMagazine")); //3
                ITEMS.Add(buildItem("PDC Tefl ", "MyObjectBuilder_AmmoMagazine", "40mmTungstenTeflonPDCBoxMagazine")); //4

                ITEMS.Add(buildItem("220 Torp ", "MyObjectBuilder_AmmoMagazine", "220mmExplosiveTorpedoMagazine")); //5
                ITEMS.Add(buildItem("RS Torp  ", "MyObjectBuilder_AmmoMagazine", "RamshackleTorpedoMagazine")); //6

                ITEMS.Add(buildItem("120mm RG ", "MyObjectBuilder_AmmoMagazine", "120mmLeadSteelSlugMagazine")); //7
                ITEMS.Add(buildItem("Dawson   ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugUNNMagazine")); //8
                ITEMS.Add(buildItem("Stiletto ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugMCRNMagazine")); //9
                ITEMS.Add(buildItem("T-47     ", "MyObjectBuilder_AmmoMagazine", "80mmTungstenUraniumSabotMagazine")); //10
            }
            catch
            {
                debugEcho("Component error!", "It seems like you might be missing one of the required mods?! Failed to build a list of components to check inventories for.");
                return;
            }

            // this is the bit that actually makes it loop, yo
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
        }



        public void Save()
        {

            Storage = current_stance;

            // TODO
            // this works, but doesn't work well with nexus.
            // might need to save stance elsewhere.

        }

        public void Main(string argument, UpdateType updateSource)
        {

            if (updateSource == UpdateType.Update100)
            {
                mainLoop();
                return;
            }

            if (argument == "")
            {
                debugEcho("Command Failed!", "Argument Required!\ne.g.\nStance:Docked\nEvade:1\nComms:Whatsup?");
                return;
            }

            string[] args = argument.Split(':');

            if (args.Length != 2)
            {
                debugEcho("Command Failed!", "Syntax Error!\nWTF is that?\n" + argument);
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
                        debugEcho("SK Open to Allies", "Opened SK to allies as defined in custom data (" + friendly_tags + ").");
                    }
                    else
                    {
                        spawn_open = false;
                        fullRefresh();
                        debugEcho("SK Closed to Allies", "Closed SK to allies.");
                    }
                    break;

                case "projectors":
                    if (args[1].ToLower() == "save")
                    {
                        foreach (IMyProjector Projector in projector_blocks)
                            saveProjectorPosition(Projector);

                        debugEcho("Saved projector positions", projector_blocks.Count + " projector positions were saved to custom data.");
                        return;
                    }
                    else if (args[1].ToLower() == "load")
                    {
                        foreach (IMyProjector Projector in projector_blocks)
                            loadProjectorPosition(Projector);

                        debugEcho("Loaded projector positions", projector_blocks.Count + " projectors were repositioned from custom data.");
                        return;
                    }
                    else
                    {
                        debugEcho("Command Failed!", "Syntax Error!\nNo such projector command.\n" + argument);
                        return;
                    }

                default:
                    debugEcho("Command Failed!", "Syntax Error!\nCommand not recognised\n" + args[0].ToLower());
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

            foreach (IMyTerminalBlock Extractor in extractors)
            {
                if (Extractor != null)
                {
                    thisInventory = Extractor.GetInventory();
                    //Echo("Extractor mass = " + Extractor.Mass);
                    if (Extractor.Mass < 2500)
                    {
                        TankType = "SG_Fuel_Tank";
                        if (debug) Echo("SG Extractor!"); }
                    break;
                }
            }

            if (thisInventory == null)
            {
                debugEcho("NO EXTRACTOR!", "Failed to load a fuel tank! There is no extractor, cannot attempt to refuel!");
                refuel_failure_count = 1;
                return;
            }



            List<IMyInventory> ToSearch;
            if (TankType == "Fuel_Tank") ToSearch = fuel_tank_inventory;
            else ToSearch = sg_fuel_tank_inventory;



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
                            debugEcho("Loaded Fuel Tank", "Fuel levels are low, and management is active. Loaded a fuel tank into extractor.");

                            // dampens extractor filling from going nuts.
                            extractor_mgmt_wait = extractor_mgmt_wait_threshold;

                            return;
                        }
                    }
                }
            }
            refuel_failure_count = 1;
            debugEcho("NO SPARE FUEL!", "Failed to load a fuel tank! Check your fuel levels, you probably have no auxiliary tanks and less than 10% fuel on board.");
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
                debugEcho("Command Failed!", "Syntax Error!\nStance not recognised\n" + stance);
                return;
            }

            current_stance = stance;

            // stores the current stance to persistance
            // allows it to be saved across instances.
            Save();

            if (debug) Echo("Found stance. Setting torpedoes to " + stance_data[stance_i][0]);

            for (int i = 0; i < torps.Count; i++)
            {
                if (torps[i].IsFunctional && torps[i].CustomName.Contains(ship_name))
                {
                    // 0: torpedoes; 0: off, 1: hold fire, 2: AI weapons free;
                    switch (stance_data[stance_i][0])
                    {
                        case 0:
                            torps[i].ApplyAction("OnOff_Off");
                            break;
                        case 1:
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
                            break;
                            /*case 3:
                                torps[i].ApplyAction("OnOff_On");
                                //setBlockFireModeAuto(torps[i]);

                                if (auto_configure_pdcs)
                                {
                                    torps[i].SetValue("WC_FocusFire", true);
                                    torps[i].SetValue("WC_Grids", true);
                                    torps[i].SetValue("WC_LargeGrid", true);
                                    torps[i].SetValue("WC_SmallGrid", false);
                                    torps[i].SetValue("WC_FocusFire", true);
                                    setBlockRepelOff(torps[i]);
                                }

                                break;*/
                    }
                }
            }

            if (debug)
                Echo("Setting " + pdcs.Count + " PDCs, "
                    + defencePdcs.Count + " defence PDCs to "
                    + stance_data[stance_i][1]
                    + ".\nautoconfig = " + auto_configure_pdcs.ToString());

            bool RepelModeFucked = false;

            for (int i = 0; i < pdcs.Count; i++)
            {
                //if (debug) Echo("PDC " + i + "(" + pdcs[i].CustomName + ")");

                if (pdcs[i].IsFunctional && pdcs[i].CustomName.Contains(ship_name))
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
                                    setBlockRepelOn(pdcs[i]);
                                }
                                catch
                                {
                                    if (!RepelModeFucked)
                                    {
                                        RepelModeFucked = true;
                                        debugEcho("PDC Config error!", "Strange bug with your PDCs causing them not to autoconfigure. Recommend grinding and rebuilding them!");
                                    }

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
                                    if (!RepelModeFucked)
                                    {
                                        RepelModeFucked = true;
                                        debugEcho("PDC Config error!", "Strange bug with your PDCs causing them not to autoconfigure. Recommend grinding and rebuilding them!");
                                    }
                                }
                            }
                            break;
                    }
                }




                /*
                // comment out in production!
                // print all properties
                List<ITerminalProperty> resultList = new List<ITerminalProperty>();
                pdcs[i].GetProperties(resultList);
                string result = "\n\nALL PDC PROPERTIES\n";
                for (int j = 0; j < resultList.Count; j++)
                {
                    result += resultList[j].Id + "\n";
                }
                dump_string += result;

                // print all actions
                List<ITerminalAction> actions = new List<ITerminalAction>();
                string result2 = "\n\nALL PDC ACTIONS\n";
                pdcs[i].GetActions(actions, (x) =>
                {
                    result2 += x.Id + "\n";
                    return true;
                }
                );
                dump_string += result2;
                updateCustomData(true);

                bool hmmm = pdcs[i].GetValue<bool>("WC_RepelMode");
                //Echo("GetValue = " + hmmm.ToString());
                return;
                */

            }
            for (int i = 0; i < defencePdcs.Count; i++)
            {

                if (debug) Echo("Def PDC " + i);

                if (defencePdcs[i].IsFunctional && defencePdcs[i].CustomName.Contains(ship_name))
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
                    }
                }
            }

            if (debug) Echo("Setting " + railguns.Count + " railguns to " + stance_data[stance_i][2]);
            for (int i = 0; i < railguns.Count; i++)
            {
                if (railguns[i].IsFunctional && railguns[i].CustomName.Contains(ship_name))
                {
                    // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;

                    switch (stance_data[stance_i][2])
                    {
                        case 0:
                            railguns[i].ApplyAction("OnOff_Off");
                            break;
                        case 1:
                            railguns[i].ApplyAction("OnOff_On");

                            //setBlockFireModeManual(railguns[i]);
                            if (auto_configure_pdcs)
                            {
                                try
                                {

                                    railguns[i].SetValue("WC_Grids", true);
                                    railguns[i].SetValue("WC_LargeGrid", true);
                                    railguns[i].SetValue("WC_SmallGrid", true);
                                    //railguns[i].SetValue("WC_FocusFire", true);

                                    setBlockRepelOff(railguns[i]);
                                }
                                catch
                                {
                                    if (!RepelModeFucked)
                                    {
                                        RepelModeFucked = true;
                                        debugEcho("RG Config error!", "Strange bug with your RGs causing them not to autoconfigure. Recommend grinding and rebuilding them!");
                                    }
                                }
                            }
                            break;
                        case 3:
                            railguns[i].ApplyAction("OnOff_On");
                            //setBlockFireModeAuto(railguns[i]);

                            if (auto_configure_pdcs)
                            {
                                try
                                {

                                    railguns[i].SetValue("WC_Grids", true);
                                    railguns[i].SetValue("WC_LargeGrid", true);
                                    railguns[i].SetValue("WC_SmallGrid", true);
                                    //railguns[i].SetValue("WC_FocusFire", true);


                                    setBlockRepelOff(railguns[i]);
                                }
                                catch
                                {
                                    if (!RepelModeFucked)
                                    {
                                        RepelModeFucked = true;
                                        debugEcho("RG Config error!", "Strange bug with your RGs causing them not to autoconfigure. Recommend grinding and rebuilding them!");
                                    }
                                }
                            }

                            break;
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
                    // 4: rcs thrusters; 0: off, 1: on
                    if (stance_data[stance_i][4] == 0)
                        thrustersRcs[i].ApplyAction("OnOff_Off");
                    else
                        thrustersRcs[i].ApplyAction("OnOff_On");
                }
            }

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
                "Setting " + lightsNav.Count + " exterior lights to " + stance_data[stance_i][6] + ".\n"
                + "Colour (" + stance_data[stance_i][7] + "," + stance_data[stance_i][8]
                + "," + stance_data[stance_i][9] + "," + stance_data[stance_i][10] + ")"
                );
            for (int i = 0; i < lightsNav.Count; i++)
            {
                if (lightsNav[i].IsFunctional && lightsNav[i].CustomName.Contains(ship_name))
                {
                    // 6: exterior lights; 0: off, 1: on
                    if (stance_data[stance_i][6] == 0)
                        lightsNav[i].ApplyAction("OnOff_Off");
                    else
                        lightsNav[i].ApplyAction("OnOff_On");

                    lightsNav[i].SetValue("Color",
                        new Color(
                            stance_data[stance_i][7],
                            stance_data[stance_i][8],
                            stance_data[stance_i][9],
                            stance_data[stance_i][10]
                            )
                        );
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

            if (debug) Echo("Setting " + battery_blocks.Count + " batteries to recharge = " + stance_data[stance_i][16]);

            for (int i = 0; i < battery_blocks.Count; i++)
            {
                if (battery_blocks[i] != null)
                {
                    if (battery_blocks[i].IsFunctional)
                    {
                        // always fucking on
                        battery_blocks[i].Enabled = true;

                        // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                        if (stance_data[stance_i][16] == 0)
                            battery_blocks[i].ChargeMode = ChargeMode.Auto;
                        else if (stance_data[stance_i][16] == 2)
                            battery_blocks[i].ChargeMode = ChargeMode.Discharge;
                        else
                            battery_blocks[i].ChargeMode = ChargeMode.Recharge;
                    }
                }

            }

            if (debug) Echo("Setting " + tank_blocks.Count + " tanks to stockpile = " + stance_data[stance_i][16]);

            for (int i = 0; i < tank_blocks.Count; i++)
            {
                if (tank_blocks[i] != null)
                {
                    if (tank_blocks[i].IsFunctional)
                    {
                        // why would this ever be off
                        tank_blocks[i].Enabled = true;

                        // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                        if (stance_data[stance_i][16] == 1)
                            tank_blocks[i].Stockpile = true;
                        else
                            tank_blocks[i].Stockpile = false;
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

            if (debug) Echo("Setting " + autorepairers.Count + " autorepair units to " + stance_data[stance_i][20]);
            for (int i = 0; i < autorepairers.Count; i++)
            {
                if (autorepairers[i].IsFunctional && autorepairers[i].CustomName.Contains(ship_name))
                {
                    // 20: autorepair; 0: off, 1: on
                    if (stance_data[stance_i][20] == 0)
                        autorepairers[i].ApplyAction("OnOff_Off");
                    else
                        autorepairers[i].ApplyAction("OnOff_On");
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

        void initShip(string ship)
        {

            if (debug) Echo("Initialising a ship as '" + ship + "'.");

            // this rebuilds general that we need here lists.
            // true tells this to rebuild them ALL!
            fullRefresh();

            // i now christen this ship, the RSG whatever the fuck
            // it's now public variable official.
            ship_name = ship;

            // we have to do this again
            // to make sure the name doesn't reset from custom data
            // on the next fullRefresh();
            updateCustomData(true);

            for (int i = 0; i < everythingElse.Count; i++)
            {
                string defaultName = everythingElse[i].DefinitionDisplayNameText;
                string blockId = everythingElse[i].BlockDefinition.ToString();

                // Echo(blockId);

                // name overrides
                //if (blockId.Contains("MyObjectBuilder_TextPanel/"))
                //defaultName = "LCD";
                if (blockId.Contains("Door/"))
                    defaultName = "Door";
                if (blockId.Contains("MyObjectBuilder_AirVent/"))
                    defaultName = "Vent";

                // misc blocks don't need numbers
                everythingElse[i].CustomName =
                    ship_name + name_delimiter +
                    defaultName +
                    retainSuffix(everythingElse[i].CustomName);
            }

            bool EfcLcdFound = false;

            for (int i = 0; i < camerasAndSensorsAndLCDs.Count; i++)
            {
                string defaultName = camerasAndSensorsAndLCDs[i].DefinitionDisplayNameText;

                string blockId = camerasAndSensorsAndLCDs[i].BlockDefinition.ToString();
                if (blockId.Contains("MyObjectBuilder_TextPanel/"))
                {
                    defaultName = "LCD";
                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD1"))
                        camerasAndSensorsAndLCDs[i].CustomData =
                            "Show header=True\nShow Tanks & Batteries=False\nShow Inventory=True\nShow Thrust=False\nShow Comms=False\nShow Autorepair=False\nShow Doors=False\nShow Advanced Thrust=False\nhudlcd:0.29:0.99:0.5";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD2"))
                        camerasAndSensorsAndLCDs[i].CustomData =
                            "Show header=False\nShow Tanks & Batteries=True\nShow Inventory=False\nShow Thrust=True\nShow Comms=False\nShow Autorepair=False\nShow Doors=False\nShow Advanced Thrust=False\nhudlcd:0.53:0.99:0.5";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD3"))
                        camerasAndSensorsAndLCDs[i].CustomData =
                            "Show header=False\nShow Tanks & Batteries=False\nShow Inventory=False\nShow Thrust=False\nShow Comms=True\nShow Autorepair=True\nShow Doors=True\nShow Advanced Thrust=False\nhudlcd:0.77:0.99:0.5";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("HUD4"))
                        camerasAndSensorsAndLCDs[i].CustomData =
                            "Show header=False\nShow Tanks & Batteries=False\nShow Inventory=False\nShow Thrust=False\nShow Comms=False\nShow Autorepair=False\nShow Doors=False\nShow Advanced Thrust=True\nhudlcd:-0.99:0.78:0.5";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("[REEDAV].1"))
                        camerasAndSensorsAndLCDs[i].CustomData =
                            "Show Targeting Info=True\nFirst Missile=0\nLast Missile=0\nExtra Missile Info=False\nhudlcd:0.79:0.31:.50";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("[REEDAV].2"))
                        camerasAndSensorsAndLCDs[i].CustomData =
                            "Show Targeting Info=False\nFirst Missile=1\nLast Missile=24\nExtra Missile Info=False\nhudlcd:0.79:0:.50";

                    if (camerasAndSensorsAndLCDs[i].CustomName.Contains("[EFC]"))
                    {
                        if (EfcLcdFound)
                        {
                            EfcLcdFound = true;
                            camerasAndSensorsAndLCDs[i].CustomData = "hudlcd:-0.99:0.35:0.65";
                        }
                        else
                            camerasAndSensorsAndLCDs[i].CustomData = "";
                    }


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
            processList(cargosSmall, "Cargo Small");
            processList(cargosLarge, "Cargo");
            processList(tanksH2, "Hydrogen Tank");
            processList(tanksO2, "Oxygen Tank");
            processList(thrustersRcs, "RCS");
            processList(thrustersMain, "Epstein");
            processList(pdcs, "PDC");
            processList(defencePdcs, "PDC");
            processList(railguns, "Railgun");
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
            processList(servers, "PB Server", true);
            processList(lightsInterior, "Lights Interior");
            processList(lightsNav, "Lights Exterior");
            processList(lightsSpotlights, "Spotlights");


            debugEcho("Initialised '" + ship + "'", "Good Hunting!");

        }


        /*void setEvade(string state)
        {
            Echo("Setting evade to " + state);
        }*/

        string retainSuffix(string name)
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
                string result = "";
                if (parsed.Length < 3) return "";
                // start loop at 2 because 0 is the ship name and 1 is the block name.
                for (int i = 2; i < parsed.Length; i++) {

                    // sometimes the third bit is just a number
                    // but i'm renumbering
                    // so fuck that cunt off.
                    if (i == 2)
                    {
                        int oldnum = 0;
                        bool isNum = int.TryParse(parsed[2], out oldnum);
                        if (isNum) parsed[2] = "";
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

        void processList(List<IMyTerminalBlock> blocks, string name, bool no_numbers = true)
        {
            int count = 0;
            int padDepth = 2;
            if (blocks.Count < 10) padDepth = 1;
            if (blocks.Count > 99) padDepth = 3;
            for (int i = 0; i < blocks.Count; i++)
            {
                count++;
                string blockNumber = name_delimiter + count.ToString().PadLeft(padDepth, '0');
                if (no_numbers) blockNumber = "";
                if (blocks.Count == 1) blockNumber = "";
                blocks[i].CustomName =
                    ship_name + name_delimiter
                    + name
                    + blockNumber
                    + retainSuffix(blocks[i].CustomName);
            }
        }

        void setComms(string comms)
        {
            current_comms = comms;
            for (int i = 0; i < antenna_blocks.Count; i++)
            {
                antenna_blocks[i].HudText = comms;
            }

            debugEcho("COMMS: " + comms, "Set comms to " + comms);
        }

        void setBlockRepelOn(IMyTerminalBlock block)
        {
            bool repelStatus = block.GetValue<bool>("WC_Repel");
            // Echo("Repel status=" + repelStatus.ToString());
            if (!repelStatus)
                block.ApplyAction("WC_RepelMode");
        }

        void setBlockRepelOff(IMyTerminalBlock block)
        {
            bool repelStatus = block.GetValue<bool>("WC_Repel");
            // Echo("Repel status=" + repelStatus.ToString());
            if (!repelStatus)
                block.ApplyAction("WC_RepelMode");
        }

        void setBlockFireModeManual(IMyTerminalBlock block)
        {
            block.SetValue<Int64>("WC_Shoot Mode", 4);
            if (debug) Echo("Shoot mode = " + block.GetValue<Int64>("WC_Shoot Mode"));
        }

        void setBlockFireModeAuto(IMyTerminalBlock block)
        {
            block.SetValue<Int64>("WC_Shoot Mode", 0);
            if (debug) Echo("Shoot mode = " + block.GetValue<Int64>("WC_Shoot Mode"));
        }

        void mainLoop()
        {
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
                Echo("\nstance_i=" + stance_i);
                Echo("\nstance_names.Count=" + stance_names.Count.ToString());
                Echo("\nstance_data.Count=" + stance_data.Count.ToString());
                Echo("\nStance=" + stance_names[stance_i]);
                Echo("\nstance_data[stance_i].Count=" + stance_data[stance_i].Length.ToString());
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
                    // turn on/off as required
                    if (connector_blocks[i].IsFunctional)
                        connector_blocks[i].Enabled = adjustThemTo;
                }

                // iterate over cameras, sensors, lcds
                if (debug) Echo("Iterating over " + camerasAndSensorsAndLCDs.Count + " cameras...");
                for (int i = 0; i < camerasAndSensorsAndLCDs.Count; i++)
                {
                    // turn on/off as required
                    if (camerasAndSensorsAndLCDs[i].IsFunctional)
                        camerasAndSensorsAndLCDs[i].ApplyAction("OnOff_On");
                }
            }


            current_comms_range = 0;
            // iterate over antennas
            if (debug) Echo("Iterating over " + antenna_blocks.Count + " antennas...");
            for (int i = 0; i < antenna_blocks.Count; i++)
            {
                if (antenna_blocks[i].IsFunctional)
                {
                    float range = antenna_blocks[i].Radius;
                    if (range > current_comms_range) current_comms_range = range;
                }
            }

            tank_h2_total = 0;
            tank_h2_actual = 0;
            tank_o2_total = 0;
            tank_o2_actual = 0;

            // iterate over tanks
            if (debug) Echo("Iterating over " + tank_blocks.Count + " tanks...");
            for (int i = 0; i < tank_blocks.Count; i++)
            {
                if (tank_blocks[i].IsFunctional)
                {
                    // turn on!
                    tank_blocks[i].Enabled = true;

                    string blockId = tank_blocks[i].BlockDefinition.ToString();

                    // update the global tank values.
                    if (blockId.Contains("Hydro"))
                    {
                        tank_h2_total += tank_blocks[i].Capacity;
                        tank_h2_actual += (tank_blocks[i].Capacity * tank_blocks[i].FilledRatio);
                    }
                    else
                    {
                        tank_o2_total += tank_blocks[i].Capacity;
                        tank_o2_actual += (tank_blocks[i].Capacity * tank_blocks[i].FilledRatio);
                    }
                }
            }

            bat_actual = 0;
            bat_total = 0;

            // iterate over batteries
            if (debug) Echo("Iterating over " + battery_blocks.Count + " batteries...");
            for (int i = 0; i < battery_blocks.Count; i++)
            {
                if (battery_blocks[i].IsFunctional)
                {
                    // turn on!
                    battery_blocks[i].Enabled = true;

                    bat_actual += battery_blocks[i].CurrentStoredPower;
                    bat_total += battery_blocks[i].MaxStoredPower;
                }
            }

            // iterate over inventories
            if (debug) Echo("Iterating over " + cargo_inventory.Count + " inventories...");

            // first we have to clear the old component counts
            foreach (ITEM Item in ITEMS)
            {
                Item.COUNT = 0;
            }

            fuel_tank_inventory.Clear();
            sg_fuel_tank_inventory.Clear();

            for (int i = 0; i < cargo_inventory.Count; i++)
            {

                try
                {

                    foreach (ITEM Item in ITEMS)
                    {
                        // don't bother with items that won't be displayed on the LCD.
                        if (Item.TARGET != 0)
                        {
                            MyInventoryItem? check = cargo_inventory[i].FindItem(Item.TYPE);
                            if (check != null)
                            {
                                string[] parse_dat = check.ToString().Split('x');
                                //Echo(">> " + parse_dat[0]);
                                //Echo(">> " + check.ToString());
                                double count = double.Parse(parse_dat[0]);
                                Item.COUNT += (int)Math.Round(count);


                                // if we're counting fuel tanks
                                // and we have more than one
                                if (Item.NAME == "Fuel Tank" && count > 0)
                                    // save this one later for manageExtractors();
                                    fuel_tank_inventory.Add(cargo_inventory[i]);

                                if (Item.NAME == "Jerry Can" && count > 0)
                                    // save this one later for manageExtractors();
                                    sg_fuel_tank_inventory.Add(cargo_inventory[i]);

                            }
                        }

                    }
                }
                catch
                {
                    if (debug) Echo("Failed to check an inventory, i=" + i);
                }
            }

            if (debug) Echo("Iterating over " + torps.Count + " torpedoes...");
            for (int i = 0; i < torps.Count; i++)
            {
                if (torps[i].IsFunctional && torps[i].CustomName.Contains(ship_name))
                {
                    // turn torps on for 1+
                    if (stance_data[stance_i][0] < 1)
                        torps[i].ApplyAction("OnOff_Off");
                    else
                        torps[i].ApplyAction("OnOff_On");
                }

            }
            if (debug) Echo("Iterating over " + pdcs.Count + " PDCs...");
            for (int i = 0; i < pdcs.Count; i++)
            {
                if (pdcs[i].IsFunctional && pdcs[i].CustomName.Contains(ship_name))
                {
                    // turn PDCs off for 2+
                    if (stance_data[stance_i][1] < 2)
                        pdcs[i].ApplyAction("OnOff_Off");
                    else
                        pdcs[i].ApplyAction("OnOff_On");
                }

            }
            if (debug) Echo("Iterating over " + defencePdcs.Count + " defence PDCs...");
            for (int i = 0; i < defencePdcs.Count; i++)
            {
                if (defencePdcs[i].IsFunctional && defencePdcs[i].CustomName.Contains(ship_name))
                {
                    // turn defence pdcs on for 1+
                    if (stance_data[stance_i][1] < 1)
                        defencePdcs[i].ApplyAction("OnOff_Off");
                    else
                        defencePdcs[i].ApplyAction("OnOff_On");
                }
            }

            if (debug) Echo("Iterating over " + railguns.Count + " railguns...");
            for (int i = 0; i < railguns.Count; i++)
            {
                if (railguns[i].IsFunctional && railguns[i].CustomName.Contains(ship_name))
                {
                    // turn railguns on for 1+
                    if (stance_data[stance_i][2] < 1)
                        railguns[i].ApplyAction("OnOff_Off");
                    else
                        railguns[i].ApplyAction("OnOff_On");
                }
            }
            if (adjustKeepAlives)
            {
                if (debug) Echo("Iterating over " + gyros.Count + " gyros...");
                for (int i = 0; i < gyros.Count; i++)
                {
                    if (adjustThemTo)
                        gyros[i].ApplyAction("OnOff_On");
                    else
                        gyros[i].ApplyAction("OnOff_Off");
                }
            }


            // calculate current thrust.
            max_thrust = 0;
            actual_thrust = 0;
            foreach (IMyTerminalBlock thruster in thrustersMain)
            {
                if (thruster.IsFunctional && thruster.CustomName.Contains(ship_name))
                {
                    max_thrust += (thruster as IMyThrust).MaxThrust;
                    actual_thrust += (thruster as IMyThrust).CurrentThrust;
                }

            }

            try
            {
                // calculate current mass and velocity
                velocity = controller.GetShipSpeed();
                mass = controller.CalculateShipMass().PhysicalMass;
            } catch { }




            manageExtractors();
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
            tank_blocks.Clear();
            battery_blocks.Clear();
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

            if (debug) Echo("Building LCDs list (" + lcd_keyword + ")...");

            // recalculate LCD list
            List<IMyTextPanel> lcds = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(lcds);

            for (int i = 0; i < lcds.Count; i++)
            {
                // block is an LCD we're going to write our data too.
                if (lcds[i].CustomName.Contains(lcd_keyword) && lcds[i].CustomName.Contains(ship_name) && !lcds[i].CustomName.Contains(ignore_keyword))
                {
                    lcd_blocks.Add(lcds[i]);

                    // tidy up the LCD as well.
                    lcds[i].ContentType = ContentType.TEXT_AND_IMAGE;
                    lcds[i].FontColor = lcd_font_colour;
                    lcds[i].FontSize = lcd_font_size;
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

            if (debug) Echo("Building tanks list...");

            // recalculate Tank list
            List<IMyGasTank> tanks = new List<IMyGasTank>();
            GridTerminalSystem.GetBlocksOfType<IMyGasTank>(tanks);

            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CustomName.Contains(ship_name) && !tanks[i].CustomName.Contains(ignore_keyword))
                {
                    tank_blocks.Add(tanks[i]);
                }
            }

            if (debug) Echo("Building batteries list...");

            // recalculate Battery list
            List<IMyBatteryBlock> batteriez = new List<IMyBatteryBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(batteriez);

            for (int i = 0; i < batteriez.Count; i++)
            {

                if (batteriez[i].CustomName.Contains(ship_name) && !batteriez[i].CustomName.Contains(ignore_keyword))
                {
                    battery_blocks.Add(batteriez[i]);
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

            if (debug) Echo("Building connector list...");

            // recalculate Connector list
            List<IMyShipConnector> connectors = new List<IMyShipConnector>();
            GridTerminalSystem.GetBlocksOfType<IMyShipConnector>(connectors);

            for (int i = 0; i < connectors.Count; i++)
            {
                if (connectors[i].CustomName.Contains(ship_name) && !connectors[i].CustomName.Contains(ignore_keyword))
                {
                    connector_blocks.Add(connectors[i]);
                }
            }

            if (debug) Echo("Building inventories list...");

            // > recalculate the cargo_inventory list.
            // we check cargo containers first, then cockpits, then reactors.
            List<IMyCargoContainer> cargos = new List<IMyCargoContainer>();
            GridTerminalSystem.GetBlocksOfType<IMyCargoContainer>(cargos);

            for (int i = 0; i < cargos.Count; i++)
            {
                if (cargos[i].CustomName.Contains(ship_name) && !cargos[i].CustomName.Contains(ignore_keyword))
                {
                    cargo_inventory.Add(cargos[i].GetInventory());
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

            if (debug) Echo("Building reactors list...");

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
            lightsNav.Clear();
            lightsInterior.Clear();
            autorepairers.Clear();
            gyros.Clear();
            extractors.Clear();
            reactorsSmall.Clear();
            reactorsLarge.Clear();
            h2Engines.Clear();
            cargosSmall.Clear();
            cargosLarge.Clear();
            tanksH2.Clear();
            tanksO2.Clear();
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
            int disownedCount = 0;

            List<IMyTerminalBlock> allBlocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(allBlocks);

            for (int i = 0; i < allBlocks.Count; i++)
            {

                // we build the general lists by parsing this little string...
                string blockId = allBlocks[i].BlockDefinition.ToString();

                // handle spawns
                if (blockId.Contains("LargeMedicalRoom") || blockId.Contains("SurvivalKit"))
                {
                    allBlocks[i].CustomData = sk_data;
                    if (!allBlocks[i].CustomName.Contains(ignore_keyword))
                        allBlocks[i].ApplyAction("OnOff_On");
                }

                // only do this for items on my 'construct' not connected ships.
                if (Me.IsSameConstructAs(allBlocks[i]))
                /*&& allBlocks[i].CustomName.Contains(ship_name)*/ // this breaks init of course lol
                {
                    // check for unowned blocks
                    string Tag = allBlocks[i].GetOwnerFactionTag();
                    if (Tag != faction_tag && Tag != "")
                    {
                        Echo(">>>" + Tag + "<<<");
                        disownedCount++;
                    }

                    // ignore blocks with the ignore keyword.
                    if (allBlocks[i].CustomName.Contains(ignore_keyword))
                        ignoreCount++;

                    // Reactors
                    // MyObjectBuilder_Reactor/LargeBlockSmallGenerator_Belter
                    // MyObjectBuilder_Reactor/LargeBlockLargeGenerator
                    // MyObjectBuilder_Reactor/LargeBlockLargeGeneratorWarfare2
                    // MyObjectBuilder_Reactor/LargeBlockSmallGeneratorWarfare2

                    else if (blockId.Contains("MyObjectBuilder_Reactor/"))
                    {
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

                    else if (
                        blockId.Contains("MyObjectBuilder_CargoContainer/")
                        &&
                        // weird edge case: lockers and other cargo containers that actually suck.
                        blockId.Split('/')[1].Contains("Container")
                        )
                    {
                        if (blockId.Contains("SmallContainer"))
                            cargosSmall.Add(allBlocks[i]);
                        else
                            cargosLarge.Add(allBlocks[i]);
                    }

                    // Tanks
                    // MyObjectBuilder_OxygenTank/LargeHydrogenTankSmall
                    // MyObjectBuilder_OxygenTank/TychoCompressedHydroTank

                    else if (blockId.Contains("MyObjectBuilder_OxygenTank/"))
                    {
                        if (blockId.Contains("Hydro"))
                            tanksH2.Add(allBlocks[i]);
                        else
                            tanksO2.Add(allBlocks[i]);
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

                    // PDCs (old)
                    // MyObjectBuilder_LargeMissileTurret/Ostman-Jazinski Flak Cannon
                    // MyObjectBuilder_LargeGatlingTurret/Nariman Dynamics PDC
                    // MyObjectBuilder_LargeGatlingTurret/Redfields Ballistics PDC
                    // MyObjectBuilder_LargeGatlingTurret/Voltaire Collective Anti Personnel PDC
                    // MyObjectBuilder_LargeGatlingTurret/Outer Planets Alliance Point Defence Cannon





                    /* PDCs NEW
                    ConveyorSorter/Ostman-Jazinski Flak Cannon
                    ConveyorSorter/Nariman Dynamics PDC
                    ConveyorSorter/Nariman Dynamics PDC Slope Base
                    ConveyorSorter/Voltaire Collective Anti Personnel PDC
                    ConveyorSorter/Outer Planets Alliance Point Defence Cannon
                    ConveyorSorter/Redfields Ballistics PDC
                    ConveyorSorter/Redfields Ballistics PDC Slope Base
                    */



                    else if (
                        blockId.Contains("Ostman-Jazinski Flak Cannon")
                        ||
                        blockId.Contains("Nariman Dynamics PDC")
                        ||
                        blockId.Contains("Voltaire Collective Anti Personnel PDC")
                        ||
                        blockId.Contains("Outer Planets Alliance Point Defence Cannon")
                        ||
                        blockId.Contains("Redfields Ballistics PDC")
                        )
                    {
                        if (allBlocks[i].CustomName.Contains(defence_pdc_keyword))
                            defencePdcs.Add(allBlocks[i]);
                        else
                            pdcs.Add(allBlocks[i]);
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

                    // Torpedoes (old)
                    // MyObjectBuilder_SmallMissileLauncherReload/Tycho Class Torpedo Mount
                    // MyObjectBuilder_SmallMissileLauncherReload/Apollo Class Torpedo Launcher
                    // MyObjectBuilder_SmallMissileLauncherReload/Ares_Class_Torpedo_Launcher_F
                    // MyObjectBuilder_SmallMissileLauncherReload/Ares_Class_TorpedoLauncher
                    // MyObjectBuilder_SmallMissileLauncherReload/ZeusClass_Rapid_Torpedo_Launcher

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
                        )
                        torps.Add(allBlocks[i]);

                    else if (allBlocks[i].CustomName.Contains("Torpedo")) { Echo(">>" + blockId + "<<"); }

                    // Railguns 
                    // MyObjectBuilder_LargeMissileTurret/Mounted Zakosetara Heavy Railgun
                    // MyObjectBuilder_LargeMissileTurret/Farren-Pattern Heavy Railgun
                    // MyObjectBuilder_LargeMissileTurret/Dawson-Pattern Medium Railgun
                    // MyObjectBuilder_LargeMissileTurret/V-14 Stiletto Light Railgun
                    // MyObjectBuilder_LargeMissileTurret/VX-12 Foehammer Ultra-Heavy Railgun

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
                    else if (blockId.Contains("Railgun"))
                        railguns.Add(allBlocks[i]);

                    // Batteries
                    // MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlockWarfare2
                    // MyObjectBuilder_BatteryBlock/LargeBlockBatteryBlock

                    else if (blockId.Contains("MyObjectBuilder_BatteryBlock/"))
                        batteries.Add(allBlocks[i]);

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
                        if (allBlocks[i].CustomName.ToUpper().Contains("INTERIOR"))
                            lightsInterior.Add(allBlocks[i]);
                        else
                            lightsNav.Add(allBlocks[i]);
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

            if (disownedCount > 0)
            {
                debugEcho("!!UNOWNED BLOCKS!!", "!!UNOWNED BLOCKS!! RUN !claim.  Some blocks on the current construct are owned by a player in another faction!");

                // TODO
                // add other actions if unowned blocks detected.

            }

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

            if (debug) Echo("Parsing PB custom data...");

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
                    debugEcho("Custom Data Error!", "Custom data invalid or blank.");
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
                                    config_count++;
                                    autorepair_keyword = value;

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
                                case "Ramshackle torpedo count":
                                // was like this in versions prior to 0.4.0
                                case "Ramshackle torpedo Count":
                                    config_count++;
                                    ITEMS[6].TARGET = int.Parse(value);
                                    break;

                                case "Zako 120mm Railgun rounds count":
                                // was like this in versions prior to 0.5.0
                                case "Railgun rounds count":
                                    config_count++;
                                    ITEMS[7].TARGET = int.Parse(value);
                                    break;

                                case "Dawson 100mm UNN Railgun rounds count":
                                    config_count++;
                                    ITEMS[8].TARGET = int.Parse(value);
                                    break;

                                case "Stiletto 100mm MCRN Railgun rounds count":
                                    config_count++;
                                    ITEMS[9].TARGET = int.Parse(value);
                                    break;

                                case "T-47 80mm Railgun rounds count":
                                    config_count++;
                                    ITEMS[10].TARGET = int.Parse(value);
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


                                case "Comma seperated friendly factions or steam ids for survival kits.":
                                    config_count++;
                                    friendly_tags = string.Join("\n", value.Split(','));
                                    //debug = bool.Parse(value);
                                    break;
                            }
                        }
                    }

                    if (config_count == 25)
                    {
                        parsedVars = true;
                    }
                    else
                    {
                        if (debug) Echo("Did not get enough config items (" + config_count + ") from custom data, resetting.");
                    }

                    //if (debug) Echo("Custom data variables array length =" + parse_dat.Length);

                    /*ship_name = parse_dat[1];
                    lcd_keyword = parse_dat[2];
                    autorepair_keyword = parse_dat[3];
                    defence_pdc_keyword = parse_dat[4];
                    ignore_keyword = parse_dat[5];
                    auto_configure_pdcs = bool.Parse(parse_dat[6]);
                    target_fusion_count = int.Parse(parse_dat[7]);
                    //if (target_fusion_count == 0) target_fusion_count++;
                    target_pdc_count = int.Parse(parse_dat[8]);
                    //if (target_pdc_count == 0) target_pdc_count++;
                    target_railgun_count = int.Parse(parse_dat[9]);
                    //if (target_railgun_count == 0) target_railgun_count++;
                    target_torp_count = int.Parse(parse_dat[10]);
                    //if (target_torp_count == 0) target_torp_count++;
                    target_torp_rs_count = int.Parse(parse_dat[11]);
                    //if (target_torp_rs_count == 0) target_torp_rs_count++;
                    target_tank_count = int.Parse(parse_dat[12]);
                    //if (target_tank_count == 0) target_tank_count++;
                    door_open_time = int.Parse(parse_dat[13]);
                    door_airlock_time = int.Parse(parse_dat[14]);
                    wait_count = int.Parse(parse_dat[15]);
                    refresh_freq = int.Parse(parse_dat[16]);
                    debug = bool.Parse(parse_dat[17]);
                    name_delimiter = char.Parse(parse_dat[18]);*/
                    // if we got here, all the parsing worked and we didn't crash! yay!

                }
                catch
                {
                    debugEcho("Custom Data Error! (vars)", "Failed to parse all the variables from custom data.");
                }

                sk_data = "                                                                                                                                 " +
                    faction_tag;

                if (spawn_open)
                    sk_data += "\n" + friendly_tags;

                sk_data += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                     //"                                                                                                                                 " + 
                     faction_tag;

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
                    debugEcho("Custom Data Error! (stances)", "Failed to parse all the stance variables from custom data.");
                }
            }

            // STOP HERE IF EVERYTHING PARSED WELL!
            if (parsedVars && parsedStances) return;

            string stance_text = "";

            if (stance_names.Count != stance_data.Count) debugEcho("Weird Error!", "Um, so...\nstance_names.Count != stance_data.Count");

            if (stance_names.Count < 1 && debug)
            {
                Echo("No stances!");
            }

            debugEcho("RESET CUSTOM DATA!", "Something went wrong, so custom data was reset.\nVars Parsed=" + parsedVars + "\nStances Parsed=" + parsedStances);

            for (int i = 0; i < stance_names.Count; i++)
            {
                stance_text += " - Stance:" + stance_names[i] + " - \n"
                    + "torpedoes; 0: off, 1: on;\n="
                    + stance_data[i][0] + "\n"
                    + "pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence\n="
                    + stance_data[i][1] + "\n"
                    + "railguns; 0: off, 1: hold fire, 2: AI weapons free;\n="
                    + stance_data[i][2] + "\n"
                    + "epstein drives; 0: off, 1: on, 2: minimum on only\n="
                    + stance_data[i][3] + "\n"
                    + "rcs thrusters; 0: off, 1: on\n="
                    + stance_data[i][4] + "\n"
                    + "spotlights; 0: off, 1: on, 2: on max radius\n="
                    + stance_data[i][5] + "\n"

                    + "exterior lights; 0: off, 1: on\n="
                    + stance_data[i][6]
                    + "\nred=" + stance_data[i][7] + "\ngreen=" + stance_data[i][8]
                    + "\nblue=" + stance_data[i][9] + "\nalpha=" + stance_data[i][10] + "\n"

                    + "interior lights lights; 0: off, 1: on\n="
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
                    + "autorepair; 0: off, 1: on\n="
                    + stance_data[i][20] + "\n"
                    + "extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.\n="
                    + stance_data[i][21] + "\n"
                    + "keep-alives for connectors, gyros, lcds, cameras, sensors; 0: ignore, 1: force on, 2: force off\n="
                    + stance_data[i][22] + "\n"
                    + "hangar doors; 0: closed, 1: open, 2: no change\n="
                    + stance_data[i][23] + "\n\n"
                    ;
            }


            Me.CustomData =
                "-------------------------\n"
                + "Reedit Ship Management" + "\n"
                + "-------------------------\n"
                + "If this data can't be parsed, it will be reset!" + "\n"

                + "\n---- [General Settings] ----\n"
                + "Ship name. Blocks without this name will be ignored\n=" + ship_name + "\n"
                + "Block name delimiter, used by init. One character only!\n=" + name_delimiter + "\n"
                + "Keyword used to identify RSM LCDs.\n=" + lcd_keyword + "\n"
                + "Keyword used to identify autorepair systems\n=" + autorepair_keyword + "\n"
                + "Keyword used to identify minimum epstein drives.\n=" + min_drives_keyword + "\n"
                + "Keyword used to identify defence PDCs.\n=" + defence_pdc_keyword + "\n"
                + "Keyword to ignore block.\n=" + ignore_keyword + "\n"
                + "Automatically configure PDCs, Railguns, Torpedoes.\n=" + auto_configure_pdcs + "\n"
                + "Comma seperated friendly factions or steam ids for survival kits.\n=" + (string.Join(",", friendly_tags.Split('\n'))) + "\n"

                + "\n---- [Target Item Quantities] ----\n"
                + "> Set to 0 to remove from LCD.\n"
                + "Fusion Fuel count\n=" + ITEMS[0].TARGET + "\n"

                + "Fuel tank count\n=" + ITEMS[1].TARGET + "\n"
                + "Jerry can count\n=" + ITEMS[2].TARGET + "\n"

                + "40mm PDC Magazine count\n=" + ITEMS[3].TARGET + "\n"
                + "40mm Teflon Tungsten PDC Magazine count\n=" + ITEMS[4].TARGET + "\n"

                + "220mm Torpedo count\n=" + ITEMS[5].TARGET + "\n"
                + "Ramshackle torpedo count\n=" + ITEMS[6].TARGET + "\n"

                + "Zako 120mm Railgun rounds count\n=" + ITEMS[7].TARGET + "\n"
                + "Dawson 100mm UNN Railgun rounds count\n=" + ITEMS[8].TARGET + "\n"
                + "Stiletto 100mm MCRN Railgun rounds count\n=" + ITEMS[9].TARGET + "\n"
                + "T-47 80mm Railgun rounds count\n=" + ITEMS[10].TARGET + "\n"

                + "\n---- [Door Timers] ----\n"
                + "Doors open timer (x100 ticks, default 3)\n=" + door_open_time + "\n"
                + "Airlock doors disabled timer (x100 ticks, default 6)\n=" + door_airlock_time + "\n"

                + "\n---- [Performance & Debugging] ----\n"
                + "Throttle script (x100 ticks pause between loops, default 0)\n=" + wait_count + "\n"
                + "Full refresh frequency (x100 ticks, default 50)\n=" + refresh_freq + "\n"
                + "Verbose script debugging. Prints more logging info to PB details.\n=" + debug + "\n"
                + "\n---- [Stances] ----\n"
                + stance_text
                + "-------------------------\n\n\n\n\n" + dump_string;

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

        void manageDoors()
        {

            // TODO
            // this could be so much better
            // do I have to use custom data? maybe yes due to nexus
            // I should add more advanced airlock functionality, integration with vent etc.

            if (debug) Echo("Managing doors...");

            string marked_for_disabling = "";
            doors_count = 0;
            doors_count_closed = 0;

            if (debug) Echo("Interating over doors...");

            for (int i = 0; i < door_blocks.Count; i++)
            {
                doors_count++;
                // is the door off or open?
                // if not we kinda don't care
                if (!door_blocks[i].Enabled == true || door_blocks[i].OpenRatio != 0)
                {
                    //int open_timer_count
                    //int off_timer_count

                    int open_timer_count = 0;
                    int off_timer_count = 0;

                    try
                    {
                        // parse custom data for timer values.
                        string[] parse_dat = door_blocks[i].CustomData.Split('=');
                        for (int j = 0; j < parse_dat.Length; j++)
                        {
                            string[] cleanup = parse_dat[j].Split('\n');
                            parse_dat[j] = cleanup[0];
                        }
                        open_timer_count = int.Parse(parse_dat[1]);
                        off_timer_count = int.Parse(parse_dat[2]);
                    }
                    catch
                    {
                        if (debug) Echo("Failed to parse custom data (" + door_blocks[i].CustomName + ").");
                    }

                    // if the door is open, continue the timer
                    // if the timer is door_open_time, close the door.

                    if (door_blocks[i].OpenRatio != 0)
                    {
                        // door is open.
                        if (open_timer_count == 0 /*&& door_blocks[i].CustomName.Contains(".Airlock.")*/)
                        {
                            // this door only just opened, and it's an airlock door.
                            // so lets mark other doors in this airlock for disabling.

                            if (debug) Echo("Door just opened... (" + door_blocks[i].CustomName + ")");
                            try
                            {

                                string[] name_bits = door_blocks[i].CustomName.Split('.');


                                // ShipName.Door.Airlock.<Airlock_ID>.Door Name
                                // 0        1    2       3            4

                                if (!marked_for_disabling.Contains(name_bits[3]))
                                {
                                    marked_for_disabling += name_bits[3] + ",";
                                }


                            }
                            catch
                            {
                                if (airlock_name_error_called)
                                {
                                    airlock_name_error_called = true;
                                    debugEcho("Airlock door naming!", "There's a door block marked as .Airlock. that isn't named correctly. Please use ShipName.Door.Airlock.<Airlock_ID>.Door Name");
                                }

                            }
                        }

                        // force the door on if it's already open
                        door_blocks[i].Enabled = true;
                        open_timer_count++;
                        if (open_timer_count >= door_open_time)
                        {
                            open_timer_count = 0;
                            door_blocks[i].CloseDoor();
                        }
                    }

                    // if the door is off, continue the timer
                    // if the timer is door_airlock_time, turn on the door.

                    if (!door_blocks[i].Enabled)
                    {
                        //Echo("manageDoors 3");
                        // door is off.
                        off_timer_count++;
                        if (off_timer_count >= door_airlock_time)
                        {
                            off_timer_count = 0;
                            door_blocks[i].Enabled = true;
                        }

                    }

                    door_blocks[i].CustomData = buildDoorData(open_timer_count, off_timer_count);

                }
                else
                {
                    // it's not open or off so nothing to do really.
                    // will reset custom data.
                    door_blocks[i].CustomData = buildDoorData(0, 0);
                    if (door_blocks[i].OpenRatio == 0) doors_count_closed++;

                }
            }



            if (marked_for_disabling != "")
            {

                if (debug) Echo("Disabling doors...");

                //Echo("Starting 2nd door loop");
                string[] to_disable = marked_for_disabling.Split(',');

                // now we run through them again, dealing with those marked for disabling...
                for (int i = 0; i < door_blocks.Count; i++)
                {
                    //Echo("manageDoors 4");
                    bool disable = false;
                    for (int j = 0; j < to_disable.Length; j++)
                    {
                        //Echo("Testing for " + to_disable[j]);
                        if (
                            // to_disable isn't blank
                            to_disable[j] != ""
                            &&
                            // + it's a marked door.
                            door_blocks[i].CustomName.Contains(to_disable[j])
                            &&
                            // + it's on
                            door_blocks[i].Enabled == true
                            &&
                            // + its closed
                            door_blocks[i].OpenRatio == 0
                            )
                            disable = true;
                    }
                    if (disable == true)
                    {
                        door_blocks[i].Enabled = false;
                        if (debug) Echo("Disabled door + (" + door_blocks[i].CustomName + ")");
                    }
                }
            }

            return;
        }

        string buildDoorData(int open, int disabled)
        {
            return "-------------------------\n"
                + "Reedit Ship Management" + "\n"
                + "-------------------------\n"
                + "Timer count values, don't touch!" + "\n"
                + "-------------------------\n"
                + "Open Timer=" + open.ToString() + "\n"
                + "Disabled Timer=" + disabled.ToString() + "\n"
                + "-------------------------\n";
        }

        int DotCount = 1;

        void updateLcd()
        {
            if (debug) Echo("Updating LCDs...");

            lcd_spinner_status++;
            if (lcd_spinner_status >= lcd_spinners.Length) lcd_spinner_status = 0;
            string spinner = lcd_spinners[lcd_spinner_status];

            string debug_text = "";
            string debug_lcd = new String('.', DotCount); ;

            DotCount++;
            if (DotCount > 3) DotCount = 1;



            if (debug_msg != "")
            {
                debug_lcd = debug_msg;
                debug_dwell++;
                if (debug_dwell >= debug_dwell_max)
                {
                    debug_dwell = 0;
                    debug_msg = "";
                }
                else
                {
                    debug_text = "\n\n" + debug_msg + "\n"
                        + (debug_msg_long.Length <= 100 ? debug_msg_long : debug_msg_long.Substring(0, 100) + "...");
                }
            }
            // add padding for nice formatting on screen...
            string output_comms = current_comms;

            if (antenna_blocks.Count > 0)
                if (antenna_blocks[0] != null)
                    output_comms = antenna_blocks[0].HudText.PadLeft(15);

            string output_comms_range = (Math.Round((current_comms_range / 1000)).ToString() + " km").PadLeft(15);

            string output_sig_range = (Math.Round((current_sig_range / 1000)).ToString() + " km").PadLeft(15);

            string output_ar = "      ACTIVE";
            if (autorepair_active == 1)
                output_ar = "     INACTIVE";

            string output_doors = (doors_count_closed + "/" + doors_count).PadLeft(15);


            // this bit prevents adding stuff with target counts of 0.
            string sec_inventory_counts = lcd_divider + "\n\n";

            foreach (ITEM Item in ITEMS)
            {
                if (Item.TARGET != 0)
                {
                    //if (debug) Echo("NAME = " + Item.NAME);

                    double percentage = (100 * ((double)Item.COUNT / (double)Item.TARGET));
                    string val = Item.COUNT + "/" + Item.TARGET;
                    if (val.Length < 9) val += new string(' ', (9 - val.Length));
                    if (val.Length > 9) val = val.Substring(0, 9);
                    sec_inventory_counts += Item.NAME + " [" + generateBar(percentage) + "] " + val + "\n";
                }
            }

            sec_inventory_counts += "\n";

            if (current_stance == "N/A")
                if (Storage != "") current_stance = Storage;

            double vel = Math.Round(velocity);
            string vel_msg = "Velocity:        ";

            if (vel < 1)
            {
                vel = 500;
                vel_msg = "Velocity (Max):  ";
            }

            double AccelMax = Math.Round((max_thrust / mass / 9.81), 2);
            double AccelActual = Math.Round((actual_thrust / mass / 9.81), 2);

            string output_decel_short;
            if (actual_thrust > 0)
            {
                output_decel_short = "Decel (Actual):  " + stopDistance(actual_thrust, vel) +
                    "\nAccel (Actual):  " + (AccelActual + " Gs").PadLeft(15);
            }
            else
            {
                output_decel_short = "Decel (Best):    " + stopDistance(max_thrust, vel) +
                    "\nAccel (Best):    " + (AccelMax + " Gs").PadLeft(15);
            }

            string sec_header =
                lcd_divider + "\n"
                + centreText(spinner + " " + ship_name.ToUpper() + " " + spinner, 32) + "\n"
                //+ lcd_title + "\n" 
                + lcd_divider + "\n"
                + centreText("STANCE: " + current_stance.ToUpper(), 32) + "\n"
                + lcd_divider + "\n"
                + centreText(debug_lcd, 32) + "\n";

            string sec_tanks_and_batts =
                lcd_divider + "\n\n"
                + "Fuel     " + barMe("H2") + "\n"
                + "Oxygen   " + barMe("O2") + "\n"
                + "Battery  " + barMe("Battery") + "\n\n";

            string sec_thrust =
                lcd_divider + "\n\n"
                + output_decel_short
                + "\nDrive Signature: " + output_sig_range + "\n\n";

            string sec_comms =
                lcd_divider + "\n\n"
                + "Comms:           " + output_comms + "\n"
                + "Comms Range:     " + output_comms_range + "\n\n";

            string sec_autorepair =
                lcd_divider + "\n\n"
                + "Autorepair:         " + output_ar + "\n\n";

            string sec_doors =
                lcd_divider + "\n\n"
               + "Doors Closed:    " + output_doors + "\n\n";

            string sec_thrust_advanced = "";

            if (build_advanced_thrust_data)
            {

                sec_thrust_advanced =
                    lcd_divider + "\n" +
                    "\nMass:            " + (Math.Round((mass / 1000000), 2) + " Mkg").PadLeft(15) +
                    "\n" + vel_msg + (vel + " ms").PadLeft(15) +
                    "\nMax Accel:       " + (AccelMax + " Gs").PadLeft(15) +
                    "\nActual Accel:    " + (AccelActual + " Gs").PadLeft(15) +
                    "\nMax Thrust:      " + ((max_thrust / 1000000) + " MN").PadLeft(15) +
                    "\nActual Thrust:   " + ((actual_thrust / 1000000) + " MN").PadLeft(15) +
                    "\nDecel (Best):    " + stopDistance(max_thrust, vel) +
                    "\nDecel (Actual):  " + stopDistance(actual_thrust, vel) +
                    "\nDecel (90%):     " + stopDistance((float)(max_thrust * 0.9), vel) +
                    "\nDecel (80%):     " + stopDistance((float)(max_thrust * 0.8), vel) +
                    "\nDecel (70%):     " + stopDistance((float)(max_thrust * 0.7), vel) +
                    "\nDecel (60%):     " + stopDistance((float)(max_thrust * 0.6), vel) +
                    "\nDecel (50%):     " + stopDistance((float)(max_thrust * 0.5), vel) +
                    "\nDecel (40%):     " + stopDistance((float)(max_thrust * 0.4), vel) +
                    "\nDecel (30%):     " + stopDistance((float)(max_thrust * 0.3), vel) +
                    "\nDecel (20%):     " + stopDistance((float)(max_thrust * 0.2), vel) +
                    "\nDecel (10%):     " + stopDistance((float)(max_thrust * 0.1), vel) + "\n\n";
            }







            for (int i = 0; i < lcd_blocks.Count; i++)
            {
                bool show_header = true;
                bool show_tanks_and_batts = true;
                bool show_inventory = true;
                bool show_thrust = true;
                bool show_comms = true;
                bool show_autorepair = false;
                bool show_doors = false;
                bool show_thrust_advanced = false;

                bool AllGood = false;
                try
                {
                    // Parse LCD Panel Data
                    string[] LcdConfigs = lcd_blocks[i].CustomData.Split('\n');

                    LcdConfigs = Array.FindAll(LcdConfigs, item => (!item.Contains("hudlcd") && !item.Contains("hudXlcd")));

                    if (LcdConfigs.Length == 8)
                    {
                        foreach (string LcdConfig in LcdConfigs)
                        {
                            string[] Parsed = LcdConfig.Split('=');
                            if (Parsed[0] == "Show Tanks & Batteries")
                                show_tanks_and_batts = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show header")
                                show_header = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show Inventory")
                                show_inventory = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show Thrust")
                                show_thrust = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show Comms")
                                show_comms = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show Autorepair")
                                show_autorepair = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show Doors")
                                show_doors = bool.Parse(Parsed[1]);
                            else if (Parsed[0] == "Show Advanced Thrust")
                                show_thrust_advanced = bool.Parse(Parsed[1]);
                        }
                        AllGood = true;
                    }
                }
                catch { }

                if (AllGood != true)
                {
                    lcd_blocks[i].CustomData =
                        "Show header=" + show_header +
                        "\nShow Tanks & Batteries=" + show_tanks_and_batts +
                        "\nShow Inventory=" + show_inventory +
                        "\nShow Thrust=" + show_thrust +
                        "\nShow Comms=" + show_comms +
                        "\nShow Autorepair=" + show_autorepair +
                        "\nShow Doors=" + show_doors +
                        "\nShow Advanced Thrust=" + show_thrust_advanced;
                }

                string output_text = "";

                if (show_header) output_text += sec_header;
                if (show_tanks_and_batts) output_text += sec_tanks_and_batts;
                if (show_inventory) output_text += sec_inventory_counts;
                if (show_thrust) output_text += sec_thrust;
                if (show_comms) output_text += sec_comms;
                if (show_autorepair) output_text += sec_autorepair;
                if (show_doors) output_text += sec_doors;
                if (show_thrust_advanced)
                {
                    output_text += sec_thrust_advanced;
                    build_advanced_thrust_data = true;
                }
                output_text += lcd_divider;

                //Echo("Wrote to " + lcd_blocks[i].CustomName);
                lcd_blocks[i].WriteText(output_text, false);
            }

            if (debug) Echo("Finished updating " + lcd_blocks.Count.ToString() + " LCDs...");


            // write to PB details.
            Echo(sec_header + debug_text);


            return;
        }

        string stopDistance(float thrust, double speed)
        {

            if (thrust <= 0) return ("N/A").PadLeft(15);

            //s = 1/2 * v ^ 2 * (m / F)
            double result = 0.5 * (Math.Pow(speed, 2) * (mass / thrust));

            //t = v / (F / mass)
            double time = speed / (thrust / mass);
            string unit = "m";
            if (result > 1000)
            {
                unit = "km";
                result = result / 1000;
            }

            return (Math.Round(result) + unit + " " + Math.Round(time) + "s").PadLeft(15);
        }

        string barMe(string bar_type)
        {
            string bar;
            string val = "";
            double percentage = 0;


            switch (bar_type)
            {
                case "H2":
                    percentage = Math.Round(100 * (tank_h2_actual / tank_h2_total));
                    val = percentage.ToString() + " %";
                    fuel_percentage = percentage;
                    break;
                case "O2":
                    percentage = Math.Round(100 * (tank_o2_actual / tank_o2_total));
                    val = percentage.ToString() + " %";
                    break;
                case "Battery":
                    // Echo("Battery actual = " + bat_actual);
                    // Echo("Battery max = " + bat_total);
                    percentage = Math.Round(100 * (bat_actual / bat_total));
                    val = percentage.ToString() + " %";
                    break;

            }

            bar = generateBar(percentage);

            if (val.Length < 9) val += new string(' ', (9 - val.Length));
            if (val.Length > 9) val = val.Substring(0, 9);

            return " [" + bar + "] " + val;
        }

        void debugEcho(string msg, string msg_long)
        {

            if (debug)
                Echo(msg + "\n" + msg_long);

            if (debug_msg != "")
            {
                msg_long = msg_long + "\n\n" + debug_msg + "\n" + debug_msg_long;
            }

            debug_dwell = 0;
            debug_msg = msg;
            debug_msg_long = msg_long;
        }

        string generateBar(double percentage)
        {
            int ones_count = 0;
            if (percentage > 0)
            {
                int try_this = (int)percentage / 10;
                if (try_this > 10) return new string('=', 10);
                if (try_this != 0) ones_count = try_this;
            }

            string ones = new string('=', ones_count);
            string zeros = new string(' ', 10 - ones_count);
            return ones + zeros;

        }

        string centreText(string Text, int Width)
        {
            int spaces = Width - Text.Length;
            int padLeft = spaces / 2 + Text.Length;
            return Text.PadLeft(padLeft).PadRight(Width);
        }

        void runProgramable(IMyTerminalBlock Pb, string Argument)
        {
            if (debug)
                Echo("Running '" + Argument + "' on '" + Pb.CustomName + "'");
            bool Success = (Pb as IMyProgrammableBlock).TryRun(Argument);
            if (Success)
                Echo("Failed to run '"+ Argument + "' on '" + Pb.CustomName + "'");
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
