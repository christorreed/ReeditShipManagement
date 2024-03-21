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
        // Gyroscopes -----------------------------------------------------------------

        private double INIT_GYROs = 0;
        private int ACTUAL_GYROs = 0;
        private double INTEGRITY_GYROs = 0;

        private void refreshGyros(bool power_state, bool set_power_state)
        {
            ACTUAL_GYROs = 0;

            foreach (IMyGyro Gyro in GYROs)
            {
                if (Gyro != null && Gyro.IsFunctional)
                {
                    ACTUAL_GYROs++;

                    if (set_power_state)
                        Gyro.Enabled = power_state;

                }
            }

            INTEGRITY_GYROs = Math.Round(100 * (ACTUAL_GYROs / INIT_GYROs));
        }
    }
}
