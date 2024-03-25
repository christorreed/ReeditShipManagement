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

            // this one prevents looping
            public bool justCycled = false;

            public List<Door> Doors = new List<Door>();
            public List<IMyAirVent> Vents = new List<IMyAirVent>();
        }


        List<string> AIRLOCK_LOOP_PREVENTION = new List<string>();

        int _doorsCount = 0;
        int _doorsCountClosed = 0;
        int _doorsCountUnlocked = 0;

        // todo
        // manageDoors() is a cluster fuck
        // fix it
        // - remove reliance on door custom data, clear this shit out
        // - make airlocks easier to configure, more fool proof. Autodetecting?

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

                if (door.OpenCounter == 0)
                {
                    // this door only just opened.
                    if (_d) Echo("Door just opened... (" + door.Block.CustomName + ")");
                    
                }

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
                foreach (Door door in airlock.Doors)
                {
                    if (door.Block == null) continue;

                    // iterate over the doors as normal.
                    bool justClosed = refreshDoor(door);
                    door.IsAirlockFirstOpen = true;

                    // if our door just closed, and the airlock didn't just cycle
                    if (justClosed)
                    {
                        // this prevents looping
                        if (airlock.justCycled)
                            airlock.justCycled = false;

                        else
                        // then it's time to cycle.
                        airlock.nowCycling = true;
                    }
                }

                // okay so we're actively cycling
                if (airlock.nowCycling)
                {
                    foreach (Door door in airlock.Doors)
                    {
                        if (door.Block == null) continue;

                        if (door.Block.OpenRatio > 0)
                        {
                            // if we're open, close.
                            door.Block.CloseDoor();
                        }
                        else
                        {
                            // if we're closed, disable.
                            door.Block.Enabled = false;
                        }
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
                    {
                        // cycle is complete
                        cycleDone = true;
                    }
                }

                if (cycleDone)
                {
                    airlock.nowCycling = false;
                    airlock.justCycled = true;

                    foreach (Door door in airlock.Doors)
                    {
                        if (door.Block == null) continue;

                        // turn them all back on.
                        door.Block.Enabled = true;

                        if (door.IsAirlockFirstOpen)
                            // except for the door that opened first
                            door.IsAirlockFirstOpen = false;
                        else
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

            _doorsCount = 0;
            _doorsCountClosed = 0;
            _doorsCountUnlocked = 0;

            foreach (Door door in _doors) refreshDoor(door);




            return;

            string marked_for_disabling = "";
            doors_count = 0;
            doors_count_closed = 0;
            doors_count_unlocked = 0;

            if (_d) Echo("Interating over " + DOORs.Count + " doors...");

            for (int i = 0; i < DOORs.Count; i++)
            {
                if (_d) Echo("Door " + i + ": " + DOORs[i].CustomName);

                if (isDoorUnlocked(DOORs[i])) doors_count_unlocked++;

                // ShipName.Door.Airlock.<Airlock_ID>.Door Name
                // 0        1    2       3            4
                string[] name_bits = DOORs[i].CustomName.Split('.');
                bool is_airlock = false;
                string airlock_id = "";
                try
                {

                    if (name_bits[2] == "Airlock")
                    {
                        is_airlock = true;
                        airlock_id = name_bits[3];
                    }

                }
                catch { }
                doors_count++;
                // is the door off or open?
                // if not we kinda don't care
                if (!DOORs[i].Enabled == true || DOORs[i].OpenRatio != 0)
                {
                    //int open_timer_count
                    //int off_timer_count

                    int open_timer_count = 0;
                    int off_timer_count = 0;

                    try
                    {
                        // parse custom data for timer values.
                        string[] parse_dat = DOORs[i].CustomData.Split('=');
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
                        if (_d) Echo("Failed to parse custom data (" + DOORs[i].CustomName + ").");
                    }

                    // if the door is open, continue the timer
                    // if the timer is _doorCloseTimer, close the door.

                    if (DOORs[i].OpenRatio != 0)
                    {
                        // door is open.
                        if (open_timer_count == 0 /*&& door_blocks[i].CustomName.Contains(".Airlock.")*/)
                        {
                            // this door only just opened, and it's an airlock door.
                            // so lets mark other doors in this airlock for disabling.

                            if (_d) Echo("Door just opened... (" + DOORs[i].CustomName + ")");





                            if (is_airlock && !marked_for_disabling.Contains(airlock_id))
                            {
                                marked_for_disabling += airlock_id + ",";
                            }



                        }

                        // force the door on if it's already open
                        DOORs[i].Enabled = true;
                        open_timer_count++;
                        if (open_timer_count >= _doorCloseTimer)
                        {
                            open_timer_count = 0;
                            DOORs[i].CloseDoor();
                        }
                    }

                    // if the door is off, continue the timer
                    // if the timer is _airlockDoorDisableTimer, turn on the door.

                    if (!DOORs[i].Enabled)
                    {
                        //Echo("manageDoors 3");
                        // door is off.

                        foreach (IMyAirVent Vent in VENTs_AIRLOCKS)
                        {

                            // ShipName.Door.Airlock.<Airlock_ID>.Door Name
                            // 0        1    2       3            4

                            try
                            {
                                if (Vent.CustomName.Contains(name_bits[3]))
                                {
                                    if (Vent.Enabled && Vent.CanPressurize && Vent.GetOxygenLevel() < .01)
                                    {
                                        // airlock is sealed and depressurised!
                                        off_timer_count = 0;
                                        DOORs[i].Enabled = true;

                                        // check if we just did this, to prevent looping forever.

                                        bool found = false;

                                        for (int j = 0; j < AIRLOCK_LOOP_PREVENTION.Count; j++)
                                        {
                                            if (AIRLOCK_LOOP_PREVENTION[j] == airlock_id)
                                            {
                                                AIRLOCK_LOOP_PREVENTION.RemoveAt(j);
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (!found)
                                        {
                                            DOORs[i].OpenDoor();
                                            AIRLOCK_LOOP_PREVENTION.Add(name_bits[3]);
                                        }
                                    }

                                    break;
                                }
                            } catch { }


                        }


                        off_timer_count++;
                        if (off_timer_count >= _airlockDoorDisableTimer)
                        {
                            off_timer_count = 0;
                            DOORs[i].Enabled = true;
                        }

                    }

                    DOORs[i].CustomData = buildDoorData(open_timer_count, off_timer_count);

                }
                else
                {
                    // it's not open or off so nothing to do really.
                    // will reset custom data.
                    DOORs[i].CustomData = buildDoorData(0, 0);
                    if (DOORs[i].OpenRatio == 0) doors_count_closed++;

                }

            }

            if (_d) Echo("Done, now disabling doors...");

            if (marked_for_disabling != "")
            {

                if (_d) Echo("Disabling doors...");

                //Echo("Starting 2nd door loop");
                string[] to_disable = marked_for_disabling.Split(',');

                // now we run through them again, dealing with those marked for disabling...
                for (int i = 0; i < DOORs.Count; i++)
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
                            DOORs[i].CustomName.Contains(to_disable[j])
                            &&
                            // + it's on
                            DOORs[i].Enabled == true
                            &&
                            // + its closed
                            DOORs[i].OpenRatio == 0
                            )
                            disable = true;
                    }
                    if (disable == true)
                    {
                        DOORs[i].Enabled = false;
                        if (_d) Echo("Disabled door + (" + DOORs[i].CustomName + ")");
                    }
                }
            }

            if (_d) Echo("Done mangaging doors.");

            return;
        }


        // Hangar Doors -----------------------------------------------------------------

        void setHangarDoors(int state)
        {
            // 23: hangar doors; 0: closed, 1: open, 2: no change

            if (state == 2) return; // no change

            foreach (IMyAirtightHangarDoor Hangar in DOORs_HANGAR)
            {
                if (Hangar == null)
                    continue;

                if (state == 0)
                    Hangar.CloseDoor();
                else
                    Hangar.OpenDoor();
            }
        }

        // todo
        // kill this, with fire.
        // just save it in RAM bro!
        string buildDoorData(int open, int disabled)
        {
            return 
                 "-------------------------\n" +
                 "Reedit Ship Management" + "\n"+
                 "-------------------------\n"+
                 "Timer count values, don't touch!" + "\n"+
                 "-------------------------\n"+
                 "Open Timer=" + open.ToString() + "\n"+
                 "Disabled Timer=" + disabled.ToString() + "\n"+
                 "-------------------------\n";
        }

        void setDoorsLock(string state, string filter)
        {
            state = state.ToLower();

            foreach (IMyDoor door in DOORs)
            {
                if (filter == "" || door.CustomName.Contains(filter))
                {
                    bool unlocked = isDoorUnlocked(door);

                    if (unlocked && (state == "locked" || state == "toggle"))
                        door.ApplyAction("AnyoneCanUse");

                    if (!unlocked && (state == "unlocked" || state == "toggle"))
                        door.ApplyAction("AnyoneCanUse");
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
