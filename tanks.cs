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

        private double _totalH2 = 0;

        private double _initH2 = 0;
        private double _actualH2 = 0;
        private double _integrityH2 = 0;
        private void refreshH2Tanks()
        {
            _actualH2 = 0;
            _totalH2 = 0;

            foreach (IMyGasTank Tank in _h2Tanks)
            {
                if (Tank.IsFunctional)
                {
                    // switch on
                    Tank.Enabled = true;

                    _totalH2 += Tank.Capacity;
                    _actualH2 += (Tank.Capacity * Tank.FilledRatio);
                }
            }

            _integrityH2 = Math.Round(100 * (_totalH2 / _initH2));
        }

        private void initH2Tanks()
        {
            _initH2 = 0;
            foreach (IMyGasTank Tank in _h2Tanks)
            {
                if (Tank != null)
                    _initH2 += Tank.Capacity;
            }
        }

        private void setH2Tanks(TankAndBatteryModes mode)
        {
            if (mode == TankAndBatteryModes.NoChange) return;

            foreach (IMyGasTank Tank in _h2Tanks)
            {
                if (Tank == null) continue;

                // why would this ever be off
                Tank.Enabled = true;

                if (mode == TankAndBatteryModes.StockpileRecharge)
                    Tank.Stockpile = true;
                else
                    Tank.Stockpile = false;
            }
        }

        // O2 Tanks -----------------------------------------------------------------

        private double TOTAL_O2 = 0;
        private double ACTUAL_O2 = 0;
        private double _initO2 = 0;
        private double _integrityO2 = 0;
        private void refreshO2Tanks()
        {
            ACTUAL_O2 = 0;
            TOTAL_O2 = 0;

            foreach (IMyGasTank Tank in _o2Tanks)
            {
                if (Tank.IsFunctional)
                {
                    // switch on
                    Tank.Enabled = true;

                    TOTAL_O2 += Tank.Capacity;
                    ACTUAL_O2 += (Tank.Capacity * Tank.FilledRatio);
                }
            }
            _integrityO2 = Math.Round(100 * (TOTAL_O2 / _initO2));
        }

        private void initO2Tanks()
        {
            _initO2 = 0;
            foreach (IMyGasTank Tank in _o2Tanks)
            {
                if (Tank != null)
                    _initO2 += Tank.Capacity;
            }
        }

        private void setO2Tanks(TankAndBatteryModes mode)
        {
            if (mode == TankAndBatteryModes.NoChange) return;

            foreach (IMyGasTank Tank in _o2Tanks)
            {
                if (Tank == null) continue;

                // why would this ever be off
                Tank.Enabled = true;

                if (mode == TankAndBatteryModes.StockpileRecharge)
                    Tank.Stockpile = true;
                else
                    Tank.Stockpile = false;
            }
        }
    }
}
