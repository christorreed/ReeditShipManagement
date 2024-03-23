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

        List<string> AIRLOCK_LOOP_PREVENTION = new List<string>();

        int doors_count = 0;
        int doors_count_closed = 0;
        int doors_count_unlocked = 0;

        // todo
        // manageDoors() is a cluster fuck
        // fix it
        // - remove reliance on door custom data, clear this shit out
        // - make airlocks easier to configure, more fool proof. Autodetecting?

        void refreshDoors()
        {

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
                    // if the timer is DOOR_OPEN_TIME, close the door.

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
                        if (open_timer_count >= DOOR_OPEN_TIME)
                        {
                            open_timer_count = 0;
                            DOORs[i].CloseDoor();
                        }
                    }

                    // if the door is off, continue the timer
                    // if the timer is DOOR_AIRLOCK_TIME, turn on the door.

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
                        if (off_timer_count >= DOOR_AIRLOCK_TIME)
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
