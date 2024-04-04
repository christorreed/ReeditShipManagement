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

        private double _initGyros = 0;
        private int _actualGyros = 0;
        private double _integrityGyros = 0;

        private void refreshGyros(bool power_state, bool set_power_state)
        {
            _actualGyros = 0;

            foreach (IMyGyro Gyro in _gyroscopes)
            {
                if (Gyro != null && Gyro.IsFunctional)
                {
                    _actualGyros++;

                    if (set_power_state)
                        Gyro.Enabled = power_state;

                }
            }

            _integrityGyros = Math.Round(100 * (_actualGyros / _initGyros));
        }
    }
}
