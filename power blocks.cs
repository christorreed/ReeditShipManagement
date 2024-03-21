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

        private void refreshPowerBlocks(int state)
        {
            MAX_POWER = 0;

            refreshBatteries(state);
            refreshReactors();
        }

        // Batteries -----------------------------------------------------------------

        private double TOTAL_BATTERIEs = 0;
        private double INIT_BATTERIEs = 0;
        private double ACTUAL_BATTERIEs = 0;
        private double INTEGRITY_BATTERIEs = 0;

        private void refreshBatteries(int state)
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

                    bool Discharging = state == 2;
                    // if we're discharging in this stance
                    // and we're using discharge management
                    // choose if to discharge or auto based on
                    // railgun target status.
                    if (Discharging && DISCHARGE_MGMT)
                    {
                        if (RAILs_HAVE_TARGET)
                            Battery.ChargeMode = ChargeMode.Discharge;
                        else
                            Battery.ChargeMode = ChargeMode.Auto;
                    }
                }
            }

            INTEGRITY_BATTERIEs = Math.Round(100 * (MAX_POWER / INIT_BATTERIEs));
        }
        private void initBatteries()
        {
            INIT_BATTERIEs = 0;
            foreach (IMyBatteryBlock Battery in BATTERIEs)
            {
                INIT_BATTERIEs += Battery.MaxOutput;
            }
        }

        private void setBatteries(int state)
        {

            foreach (IMyBatteryBlock Battery in BATTERIEs)
            {
                if (Battery != null & Battery.IsFunctional)
                {
                    // always phucking on
                    Battery.Enabled = true;

                    // state
                    // 16: stockpile tanks, recharge batts; 0: off, 1: on, 2: discharge batts
                    if (state == 0)
                        Battery.ChargeMode = ChargeMode.Auto;
                    
                    else if (state == 1)
                        Battery.ChargeMode = ChargeMode.Recharge;

                    // if DISCHARGE_MGMT is active, we will do this dynamically
                    // but if its not, just fulltime recharge it.
                    else if (!DISCHARGE_MGMT)
                        Battery.ChargeMode = ChargeMode.Recharge;
                    
                }
            }
        }

        // Reactors -----------------------------------------------------------------
        
        private double INIT_REACTORs = 0;
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
            INTEGRITY_REACTORs = Math.Round(100 * (ACTUAL_REACTORs / INIT_REACTORs));

            MAX_POWER += ACTUAL_REACTORs;
        }

        private void initReactors()
        {
            INIT_REACTORs = 0;
            foreach (IMyReactor Reactor in REACTORs)
            {
                INIT_REACTORs += Reactor.MaxOutput;
            }
        }
    }
}
