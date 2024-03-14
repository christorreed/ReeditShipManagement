﻿using EmptyKeys.UserInterface.Generated.StoreBlockView_Bindings;
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

        void initShip(string ship, bool basic = false)
        {
            // todo
            // review this method
            // tidy it up more.
            // add more options, like without naming?

            if (D) Echo("Initialising a ship as '" + ship + "'...");

            // set init mode on
            I = true;

            // this rebuilds general that we need here lists.
            fullRefresh();

            I = false;

            // i now christen this ship, the RSG whatever the fuck
            // it's now public variable official.
            SHIP_NAME = ship;

            if (D) Echo("Initialising lcds...");
            // setup LCDs.
            initLcds();

            if (!basic)
            {
                // now I calculate subsystem total capacities in order to check for damage later.
                if (D) Echo("Initialising subsystem values...");
                initMainThrusters();
                initRcsThrusters();
                initBatteries();
                initReactors();
                initH2Tanks();
                initO2Tanks();
                initCargos();

                INIT_PDCs = PDCs.Count + PDCs_DEF.Count;
                INIT_TORPs = TORPs.Count;
                INIT_RAILs = RAILs.Count;
                INIT_GYROs = GYROs.Count;
                INIT_WELDERs = WELDERs.Count;

                if (D) Echo("Initialising item values...");
                initItems();
            }

            updateCustomData(true);

            if (D) Echo("Initialising block names...");
            initBlockNames();


            ALERTS.Add(new ALERT(
                "Init:" + ship,
                "Initialised '" + ship + "'\nGood Hunting!"
                , 3
                ));
        }


        class NamingCategory
        {
            public int Count = 0;
            public int Total = 0;
            public int PadDepth = 0;
        }

        void initBlockNames()
        {
            // this dictionary will store our block counts for each matching name.
            Dictionary<string, NamingCategory> NamesWithNumbers = new Dictionary<string, NamingCategory>();

            // if we're numbering stuff, more to do.
            if (FORCE_ENUMERATION.Count > 0)
            {
                // lets build our dictionary
                foreach (string Name in FORCE_ENUMERATION)
                {
                    if (D) Echo("Numbering " + Name);
                    NamesWithNumbers.Add(Name, new NamingCategory());
                }

                // now lets count up totals for each category
                // this is needed so we know how to pad our numbering.
                foreach (var BlockName in INIT_NAMEs)
                {
                    NamingCategory Cat;
                    if (NamesWithNumbers.TryGetValue(BlockName.Value, out Cat))
                    {
                        NamesWithNumbers[BlockName.Value].Total++;
                    }
                }

                // now set pad values for each
                foreach (var Catty in NamesWithNumbers)
                {
                    if (Catty.Value.Total < 10) Catty.Value.PadDepth = 1;
                    else if (Catty.Value.Total > 99) Catty.Value.PadDepth = 3;
                    else Catty.Value.PadDepth = 2;
                }
            }
            // finally, we're ready to iterate.
            foreach (var BlockName in INIT_NAMEs)
            {
                string BlockNumber = "";
                string ThisName = BlockName.Value;
                NamingCategory Category;
                if (NamesWithNumbers.TryGetValue(BlockName.Value, out Category))
                {
                    // number this block.

                    // so long as there is more than one block in the category...
                    if (Category.Total > 1)
                    {
                        // increment and stringify block number
                        Category.Count++;
                        BlockNumber = NAME_DELIMITER + Category.Count.ToString().PadLeft(Category.PadDepth, '0');

                    }
                }

                BlockName.Key.CustomName =
                    SHIP_NAME + NAME_DELIMITER
                    + ThisName
                    + BlockNumber
                    + retainSuffix(BlockName.Key.CustomName, ThisName);

            }
        }

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
                string[] parsed = name.Split(NAME_DELIMITER);

                string[] new_name_bits = new_name.Split(NAME_DELIMITER);

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
                        result += NAME_DELIMITER + parsed[i];
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

    }
}
