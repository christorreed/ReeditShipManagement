using EmptyKeys.UserInterface.Generated.StoreBlockView_Bindings;
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

        void initShip(string ship, bool nameBlocks = true, bool setSubSystems = true, bool setInventory = true)
        {
            if (_d) Echo("Initialising a ship as '" + ship + "'...");

            // set init mode on
            _isIniting = true;

            // i now christen this ship, the RSG whatever the fuck
            // it's now variable official.
            _shipName = ship;

            // we use these bools later in the init process.
            _initingBlockNames = nameBlocks;
            _initingSubSystems = setSubSystems;
            _initingInventory = setInventory;

            // rest of the init steps occur at runInitStep();
            // we'll do the first bit now,
            // leave the rest until later...
            runInitStep();
        }

        void runInitStep()
        {
            switch (_stepInit)
            {
                case 0:
                    // force a block refresh.
                    doThisStuffRarely();

                    // also set our step to 0,
                    // reset counter for next rare stuff run
                    _stepRare = 0;
                    if (_p) Echo("Took " + msSinceLast());
                    break;

                case 1:
                    // we need to refresh items to get counts for init values
                    refreshItems();
                    if (_p) Echo("Took " + msSinceLast());
                    break;

                case 2:
                    if (_d) Echo("Initialising lcds...");
                    // setup _allLcds.
                    initLcds();

                    if (_initingSubSystems)
                    {
                        // now I calculate subsystem total capacities in order to check for damage later.
                        if (_d) Echo("Initialising subsystem values...");
                        initMainThrusters();
                        initRcsThrusters();
                        initBatteries();
                        initReactors();
                        initH2Tanks();
                        initO2Tanks();
                        initCargos();
                        _initPdcs = _normalPdcs.Count + _defensivePdcs.Count;
                        _initTorpLaunchers = _torpedoLaunchers.Count;
                        _initKinetics = _kineticWeapons.Count;
                        _initGyros = _gyroscopes.Count;
                        _initWelders = _welders.Count;
                    }

                    if (_initingInventory)
                    {
                        if (_d) Echo("Initialising item values...");
                        initItems();
                    }

                    if (_initingBlockNames)
                    {
                        if (_d) Echo("Initialising block names...");
                        initBlockNames();
                    }

                    // save all of these new values to custom data straight away.
                    setSystemData(false, _initingSubSystems, _initingInventory);

                    _alerts.Add(new Alert(
                        "Init:" + _shipName,
                        "Initialised '" + _shipName + "'\nGood Hunting!"
                        , 3
                        ));

                    // and init is done.
                    _stepInit = 0;
                    _isIniting = false;
                    if (_p) Echo("Took " + msSinceLast());
                    return;
            }
            _stepInit++;
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
            if (_enumerateTheseBlocks.Count > 0)
            {
                // lets build our dictionary
                foreach (string Name in _enumerateTheseBlocks)
                {
                    if (_d) Echo("Numbering " + Name);
                    NamesWithNumbers.Add(Name, new NamingCategory());
                }

                // now lets count up totals for each category
                // this is needed so we know how to pad our numbering.
                foreach (var BlockName in _initNames)
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
            foreach (var BlockName in _initNames)
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
                        BlockNumber = _nameDelimiter + Category.Count.ToString().PadLeft(Category.PadDepth, '0');

                    }
                }

                BlockName.Key.CustomName =
                    _shipName + _nameDelimiter
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
                string[] parsed = name.Split(_nameDelimiter);

                string[] new_name_bits = new_name.Split(_nameDelimiter);

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
                        result += _nameDelimiter + parsed[i];
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
