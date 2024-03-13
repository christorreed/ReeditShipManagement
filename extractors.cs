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
        // Extractors -----------------------------------------------------------------

        void setExtractors(int state)
        {
            // 21: extractor; 0: off, 1: on, 2: auto load below 10%, 3: keep ship tanks full.

            foreach (IMyTerminalBlock Extractor in EXTRACTORs)
            {
                if (Extractor == null) continue;

                if (state == 0)
                    Extractor.ApplyAction("OnOff_Off");
                else
                {
                    Extractor.ApplyAction("OnOff_On");

                    // do I really need to do this here?
                    // can't we just wait for the next tick?
                    // removing, for now
                    //if (state > 1)
                        //manageExtractors();
                }
            }
        }

        // todo
        // review this method
        void manageExtractors()
        {
            if (D) Echo("manageExtractors();");

            if (stance_data[stance_i][21] < 2)
            {
                if (D) Echo("Management disabled.");
            }
            else if (EXTRACTOR_WAIT > 0)
            {
                EXTRACTOR_WAIT--;
                if (D) Echo("waiting (" + EXTRACTOR_WAIT + ")...");
            }
            else if (TANKs_H2.Count < 1)
            {
                if (D) Echo("No tanks!");
            }
            else if (stance_data[stance_i][21] == 2 && fuel_percentage < TOP_UP_PERCENTAGE)
            // refuel at 10%
            {
                if (D) Echo("Fuel low! (" + fuel_percentage + "% / " + TOP_UP_PERCENTAGE + "%)");
                NEED_FUEL = true;
            }
            else if (stance_data[stance_i][21] == 3 && ACTUAL_H2 < (TOTAL_H2 - EXTACTOR_KEEP_FULL_THRESH))
            // refuel to keep tanks full.
            {
                if (D) Echo("Fuel ready for top up (" + ACTUAL_H2 + " < " + (TOTAL_H2 - EXTACTOR_KEEP_FULL_THRESH) + ")");
                NEED_FUEL = true;
            }
            else if (D)
            {
                Echo("Fuel level OK (" + fuel_percentage + "%).");

                if (stance_data[stance_i][21] == 3)
                    Echo("Keeping tanks full\n(" + ACTUAL_H2 + " < " + (TOTAL_H2 - EXTACTOR_KEEP_FULL_THRESH) + ")");
            }
        }

        // todo
        // review this method
        void fillExtractors()
        {

            if (D)
                Echo("Fuel low, filling extractors...");

            // don't want to get stuck in a loop trying this.
            NEED_FUEL = false;

            IMyInventory thisInventory = null;
            string TankType = "Fuel_Tank";

            NO_EXTRACTOR = false;
            NO_SPARE_TANKS = false;

            foreach (IMyTerminalBlock Extractor in EXTRACTORs)
            {
                if (Extractor != null)
                {
                    thisInventory = Extractor.GetInventory();
                    //Echo("Extractor mass = " + Extractor.Mass);
                    if (Extractor.Mass < 2500)
                    {
                        TankType = "SG_Fuel_Tank";
                        if (D) Echo("SG Extractor!");
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



            if (D)
                Echo(ToSearch.Count + " possible fuel tank inventories.");


            for (int j = 0; j < ToSearch.Count; j++)
            // check max of 3.
            //for (int j = 0; j < 3; j++)
            {
                List<MyInventoryItem> inventoryItems = new List<MyInventoryItem>();
                ToSearch[j].GetItems(inventoryItems/* ,a => a.ToString() == "Fuel_Tank"*/);

                if (D)
                    Echo(inventoryItems.Count + " fuel tanks in inventory " + j);

                for (int k = 0; k < inventoryItems.Count; k++)
                {
                    if (
                        (inventoryItems[k].ToString().Contains(TankType))

                        )
                    {
                        if (D)
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
                            EXTRACTOR_WAIT = EXTRACTOR_WAIT_THRESH;

                            return;
                        }
                    }
                }
            }
            // no spare tanks...
            refuel_failure_count = 1;
            NO_SPARE_TANKS = true;
        }
    }
}
