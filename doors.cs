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
        class Door
        {
            public IMyDoor Block;
            public int OpenCounter = 0;
            public int DisabledCounter = 0;
            public bool IsAirlock = false;
            public bool IsAirlockFirstOpen = false;
        }

        class Airlock
        {
            public string Id;

            // are we waiting to open a door
            public bool nowCycling = false;

            // how long have we been cycling
            public int nowCyclingTimer = 0;

            // this one prevents looping
            public bool justCycled = false;

            public List<Door> Doors = new List<Door>();
            public List<IMyAirVent> Vents = new List<IMyAirVent>();
        }

        // these are built at refreshDoor
        // but reset at refreshDoors
        int _doorsCount = 0;
        int _doorsCountClosed = 0;
        int _doorsCountUnlocked = 0;

        // returns true if door just opened,
        // or else, false.
        bool refreshDoor(Door door)
        {
            bool justClosed = false;
            if (door.Block == null) return false;

            // is our door at least a little bit open?
            bool open = door.Block.OpenRatio > 0;

            // count not null doors
            _doorsCount++;

            // count unlocked doors
            if (isDoorUnlocked(door.Block))
                _doorsCountUnlocked++;

            if (open)
            {
                // if we're open, we should be on
                door.Block.Enabled = true;

                if (_d && door.OpenCounter == 0)
                    // this door only just opened.
                    Echo("Door just opened... (" + door.Block.CustomName + ")");
                    
                door.OpenCounter++;

                // has the timer reached the threshold?
                if (door.OpenCounter >= _doorCloseTimer)
                {
                    door.OpenCounter = 0;
                    door.Block.CloseDoor();
                    justClosed = true;
                }
            }
            else
            {
                // count closed doors
                _doorsCountClosed++;
            } 

            return justClosed;
        }

        void refreshAirlocks()
        {
            if (!_manageDoors)
            {
                if (_d) Echo("Door management is disabled.");
                return;
            }

            foreach (Airlock airlock in _airlocks)
            {
                // iterate over the doors as normal.
                // doors still close via the normal timer.
                foreach (Door door in airlock.Doors)
                {
                    if (door.Block == null) continue;

                    bool justClosed = refreshDoor(door);
                    door.IsAirlockFirstOpen = true;

                    // if our door just closed, and the airlock didn't just cycle
                    if (justClosed)
                    {
                        // this prevents looping
                        if (airlock.justCycled) airlock.justCycled = false;

                        // then it's time to cycle.
                        else airlock.nowCycling = true;
                    }
                }

                // okay so we're actively cycling
                if (airlock.nowCycling)
                {
                    foreach (Door door in airlock.Doors)
                    {
                        if (door.Block == null) continue;

                        if (door.Block.OpenRatio > 0)
                            // if we're open, close.
                            door.Block.CloseDoor();
                        else
                            // if we're closed, disable.
                            door.Block.Enabled = false;
                    }
                }

                bool cycleDone = false;

                foreach (IMyAirVent vent in airlock.Vents)
                {
                    if (vent ==  null) continue;

                    // force enable
                    if (!vent.Enabled) vent.Enabled = true;

                    // force Depressurize
                    if (!vent.Depressurize) vent.Depressurize = true;

                    // if at least one vent can CanPressurize, has depressurized, and is now cycling
                    if (vent.CanPressurize &&vent.GetOxygenLevel() < .01 && airlock.nowCycling)
                        // cycle is complete
                        cycleDone = true;
                }

                // roll the cycling timer
                airlock.nowCyclingTimer++;

                // most of the time we want to auto open.
                bool autoOpen = true;

                if (airlock.nowCyclingTimer >= _airlockDoorDisableTimer)
                {
                    // alright fine.
                    // airlock *still* hasn't decompressed yet,
                    // ain't nobody got time for that.
                    // so lets unlock the airlock,
                    // but not auto open the door
                    autoOpen = false;
                    cycleDone = true;
                }

                if (cycleDone)
                {
                    airlock.nowCycling = false;
                    airlock.nowCyclingTimer = 0;
                    airlock.justCycled = true;

                    foreach (Door door in airlock.Doors)
                    {
                        if (door.Block == null) continue;

                        // turn them all back on.
                        door.Block.Enabled = true;

                        if (door.IsAirlockFirstOpen)
                            // except for the door that opened first
                            door.IsAirlockFirstOpen = false;
                        else if (autoOpen)
                            // auto open door.
                            door.Block.OpenDoor();
                    }
                }
            }
        }

        void refreshDoors()
        {
            if (!_manageDoors)
            {
                if (_d) Echo("Door management is disabled.");
                return;
            }

            // reset door counters.
            // these also apply to refreshAirlocks,
            // thus that must come after this.
            _doorsCount = 0;
            _doorsCountClosed = 0;
            _doorsCountUnlocked = 0;

            foreach (Door door in _doors) refreshDoor(door);
        }


        // Hangar Doors -----------------------------------------------------------------

        void setHangarDoors(HangarDoorModes mode)
        {
            // 23: hangar doors; 0: closed, 1: open, 2: no change

            if (mode == HangarDoorModes.NoChange) return; // no change

            foreach (IMyAirtightHangarDoor Hangar in _hangarDoors)
            {
                if (Hangar == null)
                    continue;

                if (mode == HangarDoorModes.Closed)
                    Hangar.CloseDoor();
                else
                    Hangar.OpenDoor();
            }
        }


        void setDoorsLock(string state, string filter)
        {
            state = state.ToLower();

            foreach (Door door in _doors)
            {
                if (filter == "" || door.Block.CustomName.Contains(filter))
                {
                    bool unlocked = isDoorUnlocked(door.Block);

                    if (unlocked && (state == "locked" || state == "toggle"))
                        door.Block.ApplyAction("AnyoneCanUse");

                    if (!unlocked && (state == "unlocked" || state == "toggle"))
                        door.Block.ApplyAction("AnyoneCanUse");
                }
            }
        }

        bool isDoorUnlocked(IMyDoor door)
        {
            var action = door.GetActionWithName("AnyoneCanUse");
            StringBuilder status = new StringBuilder();
            action.WriteValue(door, status);
            return (status.ToString() == "On");
        }
    }
}
