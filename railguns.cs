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
        // Railguns -----------------------------------------------------------------

        private double ACTUAL_RAILs = 0;
        private int INIT_RAILs = 0;
        private double INTEGRITY_RAILs = 0;

        private bool RAILs_HAVE_TARGET = false;

        private void iterateRailguns()
        {
            // will be used to control battery mode.
            RAILs_HAVE_TARGET = false;

            ACTUAL_RAILs = 0;

            foreach (IMyTerminalBlock Rail in RAILs)
            {
                if (Rail != null && Rail.IsFunctional)
                {
                    ACTUAL_RAILs++;

                    if (AUTOLOAD && !inventorySomewhatFull(Rail))
                        TO_LOAD.Add(Rail);

                    // turn railguns on for 1+ on [2]
                    (Rail as IMyConveyorSorter).Enabled = STANCES[S][2] > 0;

                    if (!RAILs_HAVE_TARGET)
                    {
                        MyDetectedEntityInfo? RailTarget = WC_PB_API.GetWeaponTarget(Rail);
                        if (RailTarget.HasValue)
                        {
                            string Name = RailTarget.Value.Name;
                            if (Name != null && Name != "")
                            {
                                if (D) Echo("At least one rail has a target!");
                                RAILs_HAVE_TARGET = true;
                            }
                        }
                    }
                }
            }

            INTEGRITY_RAILs = Math.Round(100 * (ACTUAL_RAILs / INIT_RAILs));
        }

        private void setRails(int state)
        {
            foreach (IMyTerminalBlock Rail in RAILs)
            {
                if (Rail != null & Rail.IsFunctional)
                {
                    // state
                    // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
                    if (state == 0)
                    {
                        (Rail as IMyConveyorSorter).Enabled = false;
                    }
                    else
                    {
                        (Rail as IMyConveyorSorter).Enabled = true;

                        if (AUTO_CONFIG_WEAPs)
                        {
                            Rail.SetValue("WC_Grids", true);
                            Rail.SetValue("WC_LargeGrid", true);
                            Rail.SetValue("WC_SmallGrid", true);

                            Rail.SetValue("WC_SubSystems", true);
                            setBlockRepelOff(Rail);

                            if (state < 2) // hold fire if less than 2
                            {
                                setBlockFireModeManual(Rail);
                            }
                            else // weapons free
                            {
                                setBlockFireModeAuto(Rail);
                            }
                        }
                    }
                }
            }
        }
    }
}
