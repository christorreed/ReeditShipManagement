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

            if (D) Echo("Initialising a ship as '" + ship + "'.");

            // this rebuilds general that we need here lists.
            fullRefresh();

            // i now christen this ship, the RSG whatever the fuck
            // it's now public variable official.
            SHIP_NAME = ship;

            // setup LCDs.
            initLcds();

            if (!basic)
            {
                // now I calculate subsystem total capacities in order to check for damage later.

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

                initItems();
            }

            updateCustomData(true);

            initBlockNames();

            ALERTS.Add(new ALERT(
                "Init:" + ship,
                "Initialised '" + ship + "'\nGood Hunting!"
                , 3
                ));
        }




        void initBlockNames()
        {
            // todo
            // adapt and tidy up the old method below
            // and rebuild it here.
            // iterating over the dictionary INIT_NAMEs
        }

        void processList(List<IMyTerminalBlock> blocks, string name, bool numbers = false)
        {
            if (FORCE_ENUMERATION.Count > 0)
            {
                foreach (string NumName in FORCE_ENUMERATION)
                {
                    if (name.Contains(NumName))
                    {
                        if (D) Echo("Forcing enumeration '" + NumName + "' on " + name);
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

                string blockId = blocks[i].BlockDefinition.ToString();
                string this_name = name;

                if (NAME_WEAPON_TYPES)
                {
                    // some special name appendments.
                    if (name == "PDC")
                    {
                        if (blockId.Contains("Flak")) this_name += ".Flak";
                        else if (blockId.Contains("Voltaire")) this_name += ".Volt";
                        else if (blockId.Contains("Outer Planets Alliance")) this_name += ".OPA";
                        else if (blockId.Contains("Nariman")) this_name += ".Nari";
                        else if (blockId.Contains("Redfields")) this_name += ".Red";
                    }
                    else if (name == "Torpedo")
                    {

                        if (blockId.Contains("Apollo")) this_name += ".Apollo";
                        else if (blockId.Contains("Tycho")) this_name += ".Tycho";
                        else if (blockId.Contains("Ares")) this_name += ".Ares";
                        else if (blockId.Contains("Artemis")) this_name += ".Art";

                    }
                    else if (name == "Railgun")
                    {

                        //if (blockId == "MyObjectBuilder_ConveyorSorter/Kess Hashari Cannon") this_name = "Kess";
                        //else if (blockId == "MyObjectBuilder_ConveyorSorter/UNN MA-15 Coilgun") this_name = "Coilgun";
                        if (blockId == "MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun") this_name += ".Stiletto";
                        else if (blockId == "MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun") this_name += ".Dawson";
                        else if (blockId == "MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun") this_name += ".Foehammer";
                        else if (blockId == "MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun") this_name += ".Farren";
                        else if (blockId == "MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun") this_name += ".Roci";
                        else if (blockId.Contains("Zakosetara")) this_name += ".Zako";
                    }
                }


                // do this anyway
                // handle names for coils, kess
                if (blockId == "MyObjectBuilder_ConveyorSorter/Kess Hashari Cannon") this_name = "Kess";
                else if (blockId == "MyObjectBuilder_ConveyorSorter/UNN MA-15 Coilgun") this_name = "Coilgun";

                // for chem thrusters.
                if (name == "Epstein")
                {

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

                else if (name == "Light" + NAME_DELIMITER + "Interior")
                {
                    if (blockId.Contains("Kitchen")) this_name += ".Kitchen";
                    else if (blockId.Contains("Aquarium")) this_name += ".Aquarium";
                }

                count++;
                string blockNumber = NAME_DELIMITER + count.ToString().PadLeft(padDepth, '0');
                if (!numbers) blockNumber = "";
                else if (blocks.Count == 1) blockNumber = "";
                blocks[i].CustomName =
                    SHIP_NAME + NAME_DELIMITER
                    + this_name
                    + blockNumber
                    + retainSuffix(blocks[i].CustomName, this_name);
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
