﻿using Sandbox.Game.EntityComponents;
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
        private int _initKinetics = 0;
        private double INTEGRITY_RAILs = 0;

        private bool RAILs_HAVE_TARGET = false;

        private void refreshRailguns()
        {
            // will be used to control battery mode.
            RAILs_HAVE_TARGET = false;

            ACTUAL_RAILs = 0;

            foreach (IMyTerminalBlock Rail in RAILs)
            {
                if (Rail != null && Rail.IsFunctional)
                {
                    ACTUAL_RAILs++;

                    // turn railguns on for 1+ on [2]
                    (Rail as IMyConveyorSorter).Enabled = _currentStance.RailgunMode != RailgunModes.Off;

                    if (!RAILs_HAVE_TARGET)
                    {
                        MyDetectedEntityInfo? RailTarget = WC_PB_API.GetWeaponTarget(Rail);
                        if (RailTarget.HasValue)
                        {
                            string Name = RailTarget.Value.Name;
                            if (Name != null && Name != "")
                            {
                                if (_d) Echo("At least one rail has a target!");
                                RAILs_HAVE_TARGET = true;
                            }
                        }
                    }
                }
            }

            INTEGRITY_RAILs = Math.Round(100 * (ACTUAL_RAILs / _initKinetics));
        }

        private void setRails(RailgunModes mode)
        {
            if (mode == RailgunModes.NoChange) return;

            foreach (IMyTerminalBlock Rail in RAILs)
            {
                if (Rail != null & Rail.IsFunctional)
                {
                    if (mode == RailgunModes.Off)
                    {
                        (Rail as IMyConveyorSorter).Enabled = false;
                    }
                    else
                    {
                        (Rail as IMyConveyorSorter).Enabled = true;

                        if (_autoConfigWeapons)
                        {
                            Rail.SetValue("WC_Grids", true);
                            Rail.SetValue("WC_LargeGrid", true);
                            Rail.SetValue("WC_SmallGrid", true);
                            Rail.SetValue("WC_SubSystems", true);
                            setBlockRepelOff(Rail);
                        }

                        if (_setTurretFireMode)
                        {
                            if (mode == RailgunModes.OpenFire) 
                            {
                                // weapons free
                                setBlockFireModeAuto(Rail);
                            }
                            else 
                            {
                                // hold fire
                                setBlockFireModeManual(Rail);
                            }
                        }
                    }
                }
            }
        }
    }
}
