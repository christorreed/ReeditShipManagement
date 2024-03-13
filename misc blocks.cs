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

        private int ACTUAL_VENTS_SEALED = 0;
        private void iterateVents(bool power_state, bool set_power_state)
        {
            ACTUAL_VENTS_SEALED = 0;

            foreach (IMyAirVent Vent in VENTs)
            {
                if (Vent != null)
                {
                    if (set_power_state)
                        Vent.Enabled = power_state;

                    if (Vent.CanPressurize)
                        ACTUAL_VENTS_SEALED++;
                }
            }
        }

        // Connectors -----------------------------------------------------------------
        private void iterateConnectors(bool power_state)
        {
            foreach (IMyShipConnector Conenctor in CONNECTORs)
            {
                if (Conenctor != null)
                    Conenctor.Enabled = power_state;
            }
        }

        // Cameras -----------------------------------------------------------------
        private void iterateCameras(bool power_state)
        {
            foreach (IMyCameraBlock Camera in CAMERAs)
            {
                if (Camera != null)
                    Camera.Enabled = power_state;
            }
        }

        // Sensors -----------------------------------------------------------------
        private void iterateSensors(bool power_state)
        {
            foreach (IMySensorBlock Sensor in SENSORs)
            {
                if (Sensor != null)
                    Sensor.Enabled = power_state;
            }
        }
    }
}
