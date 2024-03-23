﻿using Sandbox.Game.EntityComponents;
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
        // Torpedo Launchers -----------------------------------------------------------------

        private double ACTUAL_TORPs = 0;
        private int INIT_TORPs = 0;
        private double INTEGRITY_TORPs = 0;

        private void refreshTorpedoes()
        {
            ACTUAL_TORPs = 0;

            foreach (IMyTerminalBlock Torp in TORPs)
            {
                if (Torp != null && Torp.IsFunctional)
                {
                    ACTUAL_TORPs++;

                    // turn torps on for 1+ on [0]
                    (Torp as IMyConveyorSorter).Enabled = STANCES[S][0] > 0;

                    // autoloading is complex for torpedoes.
                    if (AUTOLOAD)
                    {

                        // get active ammo.
                        string AmmoType = WC_PB_API.GetActiveAmmo(Torp, 0);
                        //string OutputAmmoType = getOutputAmmoType(AmmoType);
                        int Ammo = sortAmmoType(AmmoType);
                        //IMyInventory WeapInv = Torp.GetInventory();

                        if (_d) Echo("Launcher " + Torp.CustomName + " needs " + AmmoType + "(" + Ammo + ")");

                        addTempInventory(Torp, Ammo);

                    }
                }
            }

            INTEGRITY_TORPs = Math.Round(100 * (ACTUAL_TORPs / INIT_TORPs));
        }

        private void setTorpedoes(int state)
        {
            foreach (IMyTerminalBlock Torp in TORPs)
            {
                if (Torp != null & Torp.IsFunctional)
                {
                    // state
                    // 0: torpedoes; 0: off, 1: on;
                    if (state == 0)
                    {
                        (Torp as IMyConveyorSorter).Enabled = false;
                    }
                    else
                    {
                        (Torp as IMyConveyorSorter).Enabled = true;

                        if (AUTO_CONFIG_WEAPs)
                        {
                            Torp.SetValue("WC_FocusFire", true);
                            Torp.SetValue("WC_Grids", true);
                            Torp.SetValue("WC_LargeGrid", true);
                            Torp.SetValue("WC_SmallGrid", false);
                            Torp.SetValue("WC_FocusFire", true);
                            Torp.SetValue("WC_SubSystems", true);
                            setBlockRepelOff(Torp);
                        }
                    }
                }
            }
        }
    }
}
