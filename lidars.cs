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
        // LiDARs -----------------------------------------------------------------
        private bool _lidarWorking;
        private bool _lidarHasTarget;


        private void refreshLidars(bool power_state, bool set_power_state)
        {
            _lidarWorking = false;

            foreach (IMyConveyorSorter Lidar in _lidars)
            {
                if (Lidar != null && Lidar.IsFunctional)
                {
                    _lidarWorking = true;

                    if (set_power_state)
                        Lidar.Enabled = power_state;

                    // check to see if the lidar has a target
                    // if it does, torpedoes will be switched on (if so configured)
                    // if it doesn't, torpedoes will be switched off (if so configured)
                    if (!_lidarHasTarget)
                    {
                        MyDetectedEntityInfo? LidarTarget = _wcPbApi.GetWeaponTarget(Lidar);
                        if (LidarTarget.HasValue)
                        {
                            string Name = LidarTarget.Value.Name;
                            if (Name != null && Name != "")
                            {
                                if (_d) Echo("At least one lidar  has a target!");
                                _lidarHasTarget = true;
                            }
                        }
                    }

                }
            }

            // no lidar working, so pretend like we have a target and to turn on torps.
            if (!_lidarWorking)
            {
                _lidarHasTarget = true;
            }
        }
    }
}
