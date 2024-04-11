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
        // the _extractorKeepFullMultiplier depending on
        // if this is SG or LG
        double _extractorKeepFullThreshold;

        // dampening for extractor management
        int _extractorWaitCount = 0;

        // threshold for above
        // not a constant, will be modified
        // to speed up fueling.
        int _extractorWaitThreshold = 8;

        // if extractor is topping up,
        // fill when fuel % falls below this value.
        int _topUpPercentage = 10;

        // if extractor is keeping full,
        // fill when there is this many times
        // one tank's space left in the ship.
        double _extractorKeepFullMultiplier = 3;

        // litres of fuel in a fuel tank
        double _fuelTankCapacity = 245000;
        // litres of fuel in a jerry can
        double _jerryCanCapacity = 50000;

        // the current ship calculated fuel percentage.
        // starts at 100 so we don't refuel before we check.
        double _fuelPercentage = 100;

        void setExtractors(ExtractorModes mode)
        {
            foreach (IMyTerminalBlock Extractor in _largeExtractors)
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
            if (_largeExtractors.Count < 1 && _smallExtractors.Count > 1)
                // we have no large extractors and at least one small one
                // so base the keep full thresh off a jerry can's capacity
                _extractorKeepFullThreshold = (_extractorKeepFullMultiplier * _jerryCanCapacity);
            else
                // otherwise, use a normal fuel tank's capacity.
                _extractorKeepFullThreshold = (_extractorKeepFullMultiplier * _fuelTankCapacity);
        }

        void refreshRefuelStatus()
        {
            // this method basically determines, based on the current stance
            // if we _needFuel...

            if (
                _currentStance.ExtractorMode == ExtractorModes.Off
                ||
                _currentStance.ExtractorMode == ExtractorModes.On
                )
            {
                if (_d) Echo("Extractor management disabled.");
            }
            else if (_extractorWaitCount > 0)
            {
                _extractorWaitCount--;
                if (_d) Echo("waiting (" + _extractorWaitCount + ")...");
            }
            else if (_h2Tanks.Count < 1)
            {
                if (_d) Echo("No tanks!");
            }
            else if (
                _currentStance.ExtractorMode == ExtractorModes.FillWhenLow
                &&
                _fuelPercentage < _topUpPercentage
                )
            // refuel at 10%
            {
                if (_d) Echo("Fuel low! (" + _fuelPercentage + "% / " + _topUpPercentage + "%)");
                _needFuel = true;
                calculateExtractorWaitThreshold();
            }
            else if (
                _currentStance.ExtractorMode == ExtractorModes.KeepFull
                &&
                _actualH2 < (_totalH2 - _extractorKeepFullThreshold)
                )
            // refuel to keep tanks full.
            {
                _needFuel = true;
                calculateExtractorWaitThreshold();
                if (_d) Echo("Fuel ready for top up (" + _actualH2 + " < " + (_totalH2 - _extractorKeepFullThreshold) + ")");
            }
            else if (_d)
            {
                Echo("Fuel level OK (" + _fuelPercentage + "%).");

                if (_currentStance.ExtractorMode == ExtractorModes.KeepFull)
                    Echo("Keeping tanks full\n(" + _actualH2 + " < " + (_totalH2 - _extractorKeepFullThreshold) + ")");
            }
        }

        void calculateExtractorWaitThreshold()
        {
            string speed = "";
            int newThresh = 8;

            if (_fuelPercentage < 5)
            {
                newThresh = 0;
                if (_extractorWaitThreshold != newThresh)
                    speed = "v fast";
            }
            else if (_fuelPercentage < 10)
            {
                newThresh = 2;
                if (_extractorWaitThreshold != newThresh)
                    speed = "fast";
            } 
            else if (_fuelPercentage < 60)
            {
                newThresh = 4;
                if (_extractorWaitThreshold != newThresh)
                    speed = "medium";
            }
            else if(_extractorWaitThreshold != newThresh)
                speed = "slow";





            if (speed != "")
            {
                _extractorWaitThreshold = newThresh;
                _alerts.Add(new Alert(
                    "Extractor loading " + speed,
                    "Extractor load speed has been set to " + speed + " automatically)",
                    0
                    ));
            }
            


        }

        void loadExtractors()
        {
            // don't want to get stuck in a loop trying this.
            _needFuel = false;

            // choose the extractor to load
            IMyTerminalBlock TheChosenOne = null;

            // the item to load
            int Item = 1;

            // check for an LG extractor first...
            foreach (IMyTerminalBlock Extractor in _largeExtractors)
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
                foreach (IMyTerminalBlock Extractor in _smallExtractors)
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
                    _noExtractor = true;
                    return;
                }
            }

            // we have an extractor
            _noExtractor = false;

            // do we have fuel tanks to load?
            if (_items[Item].ActualQty < 1)
            {
                _noSpareTanks = true;
                if (_d) Echo("No spare " + _items[Item].Type.SubtypeId + " to load!" );
                return;
            }

            // alright, we're doing this, lets prep for it...

            // set the wait threshold
            // so we don't keep trying to do this over and over again.
            _extractorWaitCount = _extractorWaitThreshold;

            // build an INVENTORY for the loadInventories method
            Inventory Inv = new Inventory();
            Inv.Block = TheChosenOne;
            Inv.Inv = TheChosenOne.GetInventory();

            // make sure it is on
            TheChosenOne.ApplyAction("OnOff_On");

            // build a list of inventories for the loadInventories method
            // only one extractor in there at a time tho.
            List<Inventory> Invs = new List<Inventory>();
            Invs.Add(Inv);

            if (_d) Echo("Attempting to load extractor " + TheChosenOne.CustomName);
            bool success = loadInventories(_items[Item].Inventories, Invs, _items[Item].Type);

            string typeName = "fuel tank";
            if (Item == 2) typeName = "jerry can";
            
            if (success)
                _alerts.Add(new Alert(
                    "Loaded a " + typeName,
                    "Sucessfully loaded a " + typeName + " into an extractor.",
                    0
                    ));
            

        }
    }
}
