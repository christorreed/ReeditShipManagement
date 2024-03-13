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
        // H2 Tanks -----------------------------------------------------------------

        private double TOTAL_H2 = 0;
        private double ACTUAL_H2 = 0;
        private double INIT_H2 = 0;
        private double INTEGRITY_H2 = 0;
        private void iterateH2Tanks()
        {
            ACTUAL_H2 = 0;

            foreach (IMyGasTank Tank in TANKs_H2)
            {
                if (Tank.IsFunctional)
                {
                    // switch on
                    Tank.Enabled = true;

                    TOTAL_H2 += Tank.Capacity;
                    ACTUAL_H2 += (Tank.Capacity * Tank.FilledRatio);
                }
            }

            INTEGRITY_H2 = Math.Round(100 * (TOTAL_H2 / INIT_H2));
        }

        private void initH2Tanks()
        {
            INIT_H2 = 0;
            foreach (IMyGasTank Tank in TANKs_H2)
            {
                if (Tank != null)
                    INIT_H2 += Tank.Capacity;
            }
        }

        private void setH2Tanks(int state)
        {
            foreach (IMyGasTank Tank in TANKs_H2)
            {
                if (Tank == null) continue;

                // why would this ever be off
                Tank.Enabled = true;

                // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                if (state == 0)
                    Tank.Stockpile = false;
                else
                    Tank.Stockpile = true;
            }
        }

        // O2 Tanks -----------------------------------------------------------------

        private double TOTAL_O2 = 0;
        private double ACTUAL_O2 = 0;
        private double INIT_O2 = 0;
        private double INTEGRITY_O2 = 0;
        private void iterateO2Tanks()
        {
            ACTUAL_H2 = 0;
            foreach (IMyGasTank Tank in TANKs_O2)
            {
                if (Tank.IsFunctional)
                {
                    // switch on
                    Tank.Enabled = true;

                    TOTAL_O2 += Tank.Capacity;
                    ACTUAL_O2 += (Tank.Capacity * Tank.FilledRatio);
                }
            }
            INTEGRITY_O2 = Math.Round(100 * (TOTAL_O2 / INIT_O2));
        }

        private void initO2Tanks()
        {
            INIT_O2 = 0;
            foreach (IMyGasTank Tank in TANKs_O2)
            {
                if (Tank != null)
                    INIT_O2 += Tank.Capacity;
            }
        }

        private void setO2Tanks(int state)
        {
            foreach (IMyGasTank Tank in TANKs_O2)
            {
                if (Tank == null) continue;

                // why would this ever be off
                Tank.Enabled = true;

                // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                if (state == 0)
                    Tank.Stockpile = false;
                else
                    Tank.Stockpile = true;
            }
        }
    }
}
