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
        // Vents -----------------------------------------------------------------

        private int _ventsSealedCount = 0;
        private void refreshVents(bool power_state, bool set_power_state)
        {
            _ventsSealedCount = 0;

            foreach (IMyAirVent Vent in _vents)
            {
                if (Vent != null)
                {
                    if (set_power_state)
                        Vent.Enabled = power_state;

                    if (Vent.CanPressurize)
                        _ventsSealedCount++;
                }
            }
        }

        // Connectors -----------------------------------------------------------------
        private void refreshConnectors(bool power_state)
        {
            foreach (IMyShipConnector Conenctor in _connectors)
            {
                if (Conenctor != null)
                    Conenctor.Enabled = power_state;
            }
        }

        // Cameras -----------------------------------------------------------------
        private void refreshCameras(bool power_state)
        {
            foreach (IMyCameraBlock Camera in _cameras)
            {
                if (Camera != null)
                    Camera.Enabled = power_state;
            }
        }

        // Sensors -----------------------------------------------------------------
        private void refreshSensors(bool power_state)
        {
            foreach (IMySensorBlock Sensor in _sensors)
            {
                if (Sensor != null)
                    Sensor.Enabled = power_state;
            }
        }
    }
}
