﻿using Sandbox.Game.EntityComponents;
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

        double _totalBatteries = 0;
        double _initBatteries = 0;
        double _actualBatteries = 0;
        double _integrityBatteries = 0;

        void refreshBatteries(TankAndBatteryModes mode)
        {
            _totalBatteries = 0;
            _actualBatteries = 0;

            foreach (IMyBatteryBlock Battery in _batteries)
            {
                if (Battery != null && Battery.IsFunctional)
                {
                    _actualBatteries += Battery.CurrentStoredPower;
                    _totalBatteries += Battery.MaxStoredPower;
                    _maxPower += Battery.MaxOutput;

                    // always turn batteries on
                    Battery.Enabled = true;

                    // if we're using discharge management
                    // choose if to discharge or auto based on
                    // railgun target status.
                    if (mode == TankAndBatteryModes.ManagedDischarge)
                    {
                        if (_kineticsHaveTarget)
                            Battery.ChargeMode = ChargeMode.Discharge;
                        else
                            Battery.ChargeMode = ChargeMode.Recharge;
                    }
                }
            }

            _integrityBatteries = Math.Round(100 * (_maxPower / _initBatteries));
        }
        void initBatteries()
        {
            _initBatteries = 0;
            foreach (IMyBatteryBlock Battery in _batteries)
            {
                _initBatteries += Battery.MaxOutput;
            }
        }

        void setBatteries(TankAndBatteryModes mode)
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
                    else if (mode == TankAndBatteryModes.Discharge)
                        Battery.ChargeMode = ChargeMode.Recharge;
                    
                }
            }
        }

        // Reactors -----------------------------------------------------------------
        
        double _initReactors = 0;
        double _actualReactors = 0;
        double _integrityReactors = 0;

        int _emptyReactors = 0;

        void refreshReactors()
        {
            _actualReactors = 0;
            _emptyReactors = 0;

            foreach (IMyReactor Reactor in _reactors)
            {
                if (Reactor != null && Reactor.IsFunctional)
                {
                    // always turn reactors on
                    Reactor.Enabled = true;

                    if (inventoryEmpty(Reactor))
                        _emptyReactors++;
                    
                    else
                        _actualReactors += Reactor.MaxOutput;
                    
                }
            }
            _integrityReactors = Math.Round(100 * (_actualReactors / _initReactors));

            _maxPower += _actualReactors;
        }

        void initReactors()
        {
            _initReactors = 0;
            foreach (IMyReactor Reactor in _reactors)
            {
                _initReactors += Reactor.MaxOutput;
            }
        }
    }
}
