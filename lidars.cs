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
        private bool LIDAR_WORKING;
        
        private void iterateLidars(bool power_state, bool set_power_state)
        {
            LIDAR_WORKING = false;

            foreach (IMyConveyorSorter Lidar in LIDARs)
            {
                if (Lidar != null && Lidar.IsFunctional)
                {
                    LIDAR_WORKING = true;

                    if (set_power_state)
                        Lidar.Enabled = power_state;

                }
            }
        }
    }
}
