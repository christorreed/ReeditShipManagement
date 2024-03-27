using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.CodeDom;
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

        // this value multiplies the capacity by
        // the KEEP_FULL_MULTIPLIER depending on
        // if this is SG or LG
        double EXTACTOR_KEEP_FULL_THRESH;

        void setExtractors(ExtractorModes mode)
        {
            foreach (IMyTerminalBlock Extractor in EXTRACTORs)
            {
                if (Extractor == null) continue;

                if (mode == ExtractorModes.Off)
                    Extractor.ApplyAction("OnOff_Off");
                else
                    Extractor.ApplyAction("OnOff_On");
            }
        }

        void setKeepFullThresh()
        {
            // set fuel tank/jerry can for extractor management = 3
            if (EXTRACTORs.Count < 1 && EXTRACTORs_SMALL.Count > 1)
                // we have no large extractors and at least one small one
                // so base the keep full thresh off a jerry can's capacity
                EXTACTOR_KEEP_FULL_THRESH = (KEEP_FULL_MULTIPLIER * CAPACITY_JERRY_CAN);
            else
                // otherwise, use a normal fuel tank's capacity.
                EXTACTOR_KEEP_FULL_THRESH = (KEEP_FULL_MULTIPLIER * CAPACITY_FUEL_TANK);
        }

        void refreshRefuelStatus()
        {
            // this method basically determines, based on the current stance
            // if we NEED_FUEL...

            if (
                _currentStance.ExtractorMode == ExtractorModes.Off
                ||
                _currentStance.ExtractorMode == ExtractorModes.On
                )
            {
                if (_d) Echo("Extractor management disabled.");
            }
            else if (EXTRACTOR_WAIT > 0)
            {
                EXTRACTOR_WAIT--;
                if (_d) Echo("waiting (" + EXTRACTOR_WAIT + ")...");
            }
            else if (TANKs_H2.Count < 1)
            {
                if (_d) Echo("No tanks!");
            }
            else if (
                _currentStance.ExtractorMode == ExtractorModes.FillWhenLow
                &&
                FUEL_PERCENTAGES < TOP_UP_PERCENTAGE
                )
            // refuel at 10%
            {
                if (_d) Echo("Fuel low! (" + FUEL_PERCENTAGES + "% / " + TOP_UP_PERCENTAGE + "%)");
                NEED_FUEL = true;
            }
            else if (
                _currentStance.ExtractorMode == ExtractorModes.KeepFull
                &&
                ACTUAL_H2 < (TOTAL_H2 - EXTACTOR_KEEP_FULL_THRESH)
                )
            // refuel to keep tanks full.
            {
                if (_d) Echo("Fuel ready for top up (" + ACTUAL_H2 + " < " + (TOTAL_H2 - EXTACTOR_KEEP_FULL_THRESH) + ")");
                NEED_FUEL = true;
            }
            else if (_d)
            {
                Echo("Fuel level OK (" + FUEL_PERCENTAGES + "%).");

                if (_currentStance.ExtractorMode == ExtractorModes.KeepFull)
                    Echo("Keeping tanks full\n(" + ACTUAL_H2 + " < " + (TOTAL_H2 - EXTACTOR_KEEP_FULL_THRESH) + ")");
            }
        }

        void loadExtractors()
        {
            // don't want to get stuck in a loop trying this.
            NEED_FUEL = false;

            // choose the extractor to load
            IMyTerminalBlock TheChosenOne = null;

            // the item to load
            int Item = 1;

            // check for an LG extractor first...
            foreach (IMyTerminalBlock Extractor in EXTRACTORs)
            {
                if (Extractor.IsFunctional)
                {
                    TheChosenOne = Extractor;
                    break;
                }
            }
            if (TheChosenOne == null)
            {
                // no LG extractor, check for SG one.
                foreach (IMyTerminalBlock Extractor in EXTRACTORs_SMALL)
                {
                    if (Extractor.IsFunctional)
                    {
                        TheChosenOne = Extractor;
                        Item = 2;
                        break;
                    }
                }
                if (TheChosenOne == null)
                {
                    // no sg extractor either...
                    if (_d) Echo("No functional extractor to load!");
                    NO_EXTRACTOR = true;
                    return;
                }
            }

            // we have an extractor
            NO_EXTRACTOR = false;

            // do we have fuel tanks to load?
            if (ITEMS[Item].ActualQty < 1)
            {
                NO_SPARE_TANKS = true;
                if (_d) Echo("No spare " + ITEMS[Item].Type.SubtypeId + " to load!" );
                return;
            }

            // alright, we're doing this, lets prep for it...

            // set the wait threshold
            // so we don't keep trying to do this over and over again.
            EXTRACTOR_WAIT = EXTRACTOR_WAIT_THRESH;

            // build an INVENTORY for the loadInventories method
            INVENTORY Inv = new INVENTORY();
            Inv.Block = TheChosenOne;
            Inv.Inv = TheChosenOne.GetInventory();

            // make sure it is on
            TheChosenOne.ApplyAction("OnOff_On");

            // build a list of inventories for the loadInventories method
            // only one extractor in there at a time tho.
            List<INVENTORY> Invs = new List<INVENTORY>();
            Invs.Add(Inv);

            if (_d) Echo("Attempting to load extractor " + TheChosenOne.CustomName);
            loadInventories(ITEMS[Item].Inventories, Invs, ITEMS[Item].Type);

        }
    }
}
