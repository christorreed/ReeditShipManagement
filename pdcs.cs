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
        private int INIT_PDCs = 0;
        private double INTEGRITY_PDCs = 0;

        private void refreshPDCs()
        {
            ACTUAL_PDCs = 0;

            foreach (IMyTerminalBlock Pdc in PDCs)
            {
                // turn pdcs on for 2+ on [1]
                processPdc(Pdc, STANCES[S][1] > 1);
            }

            foreach (IMyTerminalBlock Pdc in PDCs_DEF)
            {
                // turn defensive pdcs on for 1+ on [1]
                processPdc(Pdc, STANCES[S][1] > 0);
            }

            INTEGRITY_PDCs = Math.Round(100 * (ACTUAL_PDCs / INIT_PDCs));
        }

        private void processPdc(IMyTerminalBlock pdc, bool power_state)
        {
            if (pdc != null && pdc.IsFunctional)
            {
                ACTUAL_PDCs++;

                // IsFull doesn't work because volume of a full inner PDC is...
                // 1000000 / 1000002
                // so instead now I just confirm that it's > 95% full.

                (pdc as IMyConveyorSorter).Enabled = power_state;

            }
        }

        private void setPdcs(int state)
        {
            foreach (IMyTerminalBlock Pdc in PDCs)


            {
                if (Pdc != null & Pdc.IsFunctional)
                {
                    // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                    switch (state)
                    {
                        case 0:
                        case 1:
                            // off
                            (Pdc as IMyConveyorSorter).Enabled = false;
                            break;
                        case 2:
                            // defence
                            (Pdc as IMyConveyorSorter).Enabled = true;

                            if (AUTO_CONFIG_WEAPs)
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
                        case 3:
                            // offence
                            (Pdc as IMyConveyorSorter).Enabled = true;

                            if (AUTO_CONFIG_WEAPs)
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

                        case 4:
                            // switch on only...
                            (Pdc as IMyConveyorSorter).Enabled = true;
                            break;
                    }
                }
            }

            foreach (IMyTerminalBlock Pdc in PDCs_DEF)
            {
                if (Pdc != null & Pdc.IsFunctional)
                {
                    // 1: pdcs; 0: all off, 1: minimum defence, 2: all defence, 3: offence
                    switch (state)
                    {
                        case 0:
                            // off
                            (Pdc as IMyConveyorSorter).Enabled = false;
                            break;
                        case 1:
                        case 2:
                        case 3:
                            // defence
                            (Pdc as IMyConveyorSorter).Enabled = true;

                            if (AUTO_CONFIG_WEAPs)
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

                        case 4:
                            // switch on only...
                            (Pdc as IMyConveyorSorter).Enabled = true;
                            break;
                    }
                }
            }
        }
    }
}
