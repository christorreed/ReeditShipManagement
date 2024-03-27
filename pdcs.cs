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
        // PDCs -----------------------------------------------------------------

        private double ACTUAL_PDCs = 0;
        private int _initPdcs = 0;
        private double INTEGRITY_PDCs = 0;

        private void refreshPDCs()
        {
            ACTUAL_PDCs = 0;

            foreach (IMyTerminalBlock Pdc in PDCs)
            {
                // turn pdcs on
                processPdc(Pdc,
                    // except if off
                    _currentStance.PdcMode != PdcModes.Off
                    &&
                    // or min defence
                    _currentStance.PdcMode != PdcModes.MinDefence
                    );
            }

            foreach (IMyTerminalBlock Pdc in PDCs_DEF)
            {
                processPdc(Pdc,
                    // except if off
                    _currentStance.PdcMode != PdcModes.Off);
            }

            INTEGRITY_PDCs = Math.Round(100 * (ACTUAL_PDCs / _initPdcs));
        }

        private void processPdc(IMyTerminalBlock pdc, bool power_state)
        {
            if (pdc != null && pdc.IsFunctional)
            {
                ACTUAL_PDCs++;

                (pdc as IMyConveyorSorter).Enabled = power_state;
            }
        }

        private void setPdcs(PdcModes mode)
        {
            if (mode == PdcModes.NoChange) return;

            foreach (IMyTerminalBlock Pdc in PDCs)
            {
                if (Pdc != null & Pdc.IsFunctional)
                {
                    switch (mode)
                    {
                        case PdcModes.Off:
                        case PdcModes.MinDefence:
                            // off
                            (Pdc as IMyConveyorSorter).Enabled = false;
                            break;
                        case PdcModes.AllDefence:
                            // defence
                            (Pdc as IMyConveyorSorter).Enabled = true;

                            if (_autoConfigWeapons)
                            {
                                try
                                {
                                    Pdc.SetValue("WC_FocusFire", false);
                                    Pdc.SetValue("WC_Projectiles", true);
                                    Pdc.SetValue("WC_Grids", true);
                                    Pdc.SetValue("WC_LargeGrid", false);
                                    Pdc.SetValue("WC_SmallGrid", true);
                                    Pdc.SetValue("WC_SubSystems", true);
                                    Pdc.SetValue("WC_Biologicals", true);

                                    setBlockRepelOff(Pdc);
                                }
                                catch
                                {
                                    Echo("Strange PDC config error! Possible WC crash!");
                                }
                            }
                            break;
                        case PdcModes.Offence:
                            // offence
                            (Pdc as IMyConveyorSorter).Enabled = true;

                            if (_autoConfigWeapons)
                            {
                                try
                                {
                                    Pdc.SetValue("WC_FocusFire", false);
                                    Pdc.SetValue("WC_Projectiles", true);
                                    Pdc.SetValue("WC_Grids", true);
                                    Pdc.SetValue("WC_LargeGrid", true);
                                    Pdc.SetValue("WC_SmallGrid", true);
                                    Pdc.SetValue("WC_SubSystems", true);
                                    Pdc.SetValue("WC_Biologicals", true);


                                    setBlockRepelOff(Pdc);
                                }
                                catch
                                {
                                    Echo("Strange PDC config error! Possible WC crash!");
                                }
                            }
                            break;
                    }
                }
            }

            foreach (IMyTerminalBlock Pdc in PDCs_DEF)
            {
                if (Pdc != null & Pdc.IsFunctional)
                {
                    switch (mode)
                    {
                        case PdcModes.Off:
                            // off
                            (Pdc as IMyConveyorSorter).Enabled = false;
                            break;
                        case PdcModes.MinDefence:
                        case PdcModes.AllDefence:
                        case PdcModes.Offence:
                            // defence
                            (Pdc as IMyConveyorSorter).Enabled = true;

                            if (_autoConfigWeapons)
                            {
                                try
                                {
                                    Pdc.SetValue("WC_FocusFire", false);
                                    Pdc.SetValue("WC_Projectiles", true);
                                    Pdc.SetValue("WC_Grids", true);
                                    Pdc.SetValue("WC_LargeGrid", false);
                                    Pdc.SetValue("WC_SmallGrid", true);
                                    Pdc.SetValue("WC_SubSystems", true);
                                    Pdc.SetValue("WC_Biologicals", true);

                                    setBlockRepelOn(Pdc);
                                }
                                catch
                                {
                                    Echo("Strange PDC config error! Possible WC crash!");
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
