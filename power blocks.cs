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
        private double MAX_POWER;

        private void refreshPowerBlocks(TankAndBatteryModes mode)
        {
            MAX_POWER = 0;

            refreshBatteries(mode);
            refreshReactors();
        }

        // Batteries -----------------------------------------------------------------

        private double TOTAL_BATTERIEs = 0;
        private double _initBatteries = 0;
        private double ACTUAL_BATTERIEs = 0;
        private double INTEGRITY_BATTERIEs = 0;

        private void refreshBatteries(TankAndBatteryModes mode)
        {
            TOTAL_BATTERIEs = 0;
            ACTUAL_BATTERIEs = 0;

            foreach (IMyBatteryBlock Battery in BATTERIEs)
            {
                if (Battery != null && Battery.IsFunctional)
                {
                    ACTUAL_BATTERIEs += Battery.CurrentStoredPower;
                    TOTAL_BATTERIEs += Battery.MaxStoredPower;
                    MAX_POWER += Battery.MaxOutput;

                    // always turn batteries on
                    Battery.Enabled = true;

                    bool Discharging = mode == TankAndBatteryModes.Discharge;
                    // if we're discharging in this stance
                    // and we're using discharge management
                    // choose if to discharge or auto based on
                    // railgun target status.
                    if (Discharging && _manageBatteryDischarge)
                    {
                        if (RAILs_HAVE_TARGET)
                            Battery.ChargeMode = ChargeMode.Discharge;
                        else
                            Battery.ChargeMode = ChargeMode.Auto;
                    }
                }
            }

            INTEGRITY_BATTERIEs = Math.Round(100 * (MAX_POWER / _initBatteries));
        }
        private void initBatteries()
        {
            _initBatteries = 0;
            foreach (IMyBatteryBlock Battery in BATTERIEs)
            {
                _initBatteries += Battery.MaxOutput;
            }
        }

        private void setBatteries(TankAndBatteryModes mode)
        {
            if (mode == TankAndBatteryModes.NoChange) return;

            foreach (IMyBatteryBlock Battery in BATTERIEs)
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
        private double ACTUAL_REACTORs = 0;
        private double INTEGRITY_REACTORs = 0;

        private int EMPTY_REACTORs = 0;

        private void refreshReactors()
        {
            ACTUAL_REACTORs = 0;
            EMPTY_REACTORs = 0;

            foreach (IMyReactor Reactor in REACTORs)
            {
                if (Reactor != null && Reactor.IsFunctional)
                {
                    // always turn reactors on
                    Reactor.Enabled = true;

                    if (inventoryEmpty(Reactor))
                        EMPTY_REACTORs++;
                    
                    else
                        ACTUAL_REACTORs += Reactor.MaxOutput;
                    
                }
            }
            INTEGRITY_REACTORs = Math.Round(100 * (ACTUAL_REACTORs / _initReactors));

            MAX_POWER += ACTUAL_REACTORs;
        }

        private void initReactors()
        {
            _initReactors = 0;
            foreach (IMyReactor Reactor in REACTORs)
            {
                _initReactors += Reactor.MaxOutput;
            }
        }
    }
}
