using Sandbox.Game.EntityComponents;
using Sandbox.Game.GameSystems.Electricity;
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
        private double _maxPower;

        private void refreshPowerBlocks(TankAndBatteryModes mode)
        {
            _maxPower = 0;

            refreshBatteries(mode);
            refreshReactors();
        }

        // Batteries -----------------------------------------------------------------

        private double TOTAL__batteries = 0;
        private double _initBatteries = 0;
        private double ACTUAL__batteries = 0;
        private double INTEGRITY__batteries = 0;

        private void refreshBatteries(TankAndBatteryModes mode)
        {
            TOTAL__batteries = 0;
            ACTUAL__batteries = 0;

            foreach (IMyBatteryBlock Battery in _batteries)
            {
                if (Battery != null && Battery.IsFunctional)
                {
                    ACTUAL__batteries += Battery.CurrentStoredPower;
                    TOTAL__batteries += Battery.MaxStoredPower;
                    _maxPower += Battery.MaxOutput;

                    // always turn batteries on
                    Battery.Enabled = true;

                    bool Discharging = mode == TankAndBatteryModes.Discharge;
                    // if we're discharging in this stance
                    // and we're using discharge management
                    // choose if to discharge or auto based on
                    // railgun target status.
                    if (Discharging && _manageBatteryDischarge)
                    {
                        if (_kineticsHaveTarget)
                            Battery.ChargeMode = ChargeMode.Discharge;
                        else
                            Battery.ChargeMode = ChargeMode.Auto;
                    }
                }
            }

            INTEGRITY__batteries = Math.Round(100 * (_maxPower / _initBatteries));
        }
        private void initBatteries()
        {
            _initBatteries = 0;
            foreach (IMyBatteryBlock Battery in _batteries)
            {
                _initBatteries += Battery.MaxOutput;
            }
        }

        private void setBatteries(TankAndBatteryModes mode)
        {
            if (mode == TankAndBatteryModes.NoChange) return;

            foreach (IMyBatteryBlock Battery in _batteries)
            {
                if (Battery != null & Battery.IsFunctional)
                {
                    // always phucking on
                    Battery.Enabled = true;

                    // state
                    // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                    if (mode == TankAndBatteryModes.Auto)
                        Battery.ChargeMode = ChargeMode.Auto;
                    
                    else if (mode == TankAndBatteryModes.StockpileRecharge)
                        Battery.ChargeMode = ChargeMode.Recharge;

                    // if _manageBatteryDischarge is active, we will do this dynamically
                    // but if its not, just fulltime recharge it.
                    else if (!_manageBatteryDischarge)
                        Battery.ChargeMode = ChargeMode.Recharge;
                    
                }
            }
        }

        // Reactors -----------------------------------------------------------------
        
        private double _initReactors = 0;
        private double ACTUAL__reactors = 0;
        private double INTEGRITY__reactors = 0;

        private int EMPTY__reactors = 0;

        private void refreshReactors()
        {
            ACTUAL__reactors = 0;
            EMPTY__reactors = 0;

            foreach (IMyReactor Reactor in _reactors)
            {
                if (Reactor != null && Reactor.IsFunctional)
                {
                    // always turn reactors on
                    Reactor.Enabled = true;

                    if (inventoryEmpty(Reactor))
                        EMPTY__reactors++;
                    
                    else
                        ACTUAL__reactors += Reactor.MaxOutput;
                    
                }
            }
            INTEGRITY__reactors = Math.Round(100 * (ACTUAL__reactors / _initReactors));

            _maxPower += ACTUAL__reactors;
        }

        private void initReactors()
        {
            _initReactors = 0;
            foreach (IMyReactor Reactor in _reactors)
            {
                _initReactors += Reactor.MaxOutput;
            }
        }
    }
}
