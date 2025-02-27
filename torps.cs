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

        private int _initTorpLaunchers = 0;
        private double _actualTorpLaunchers = 0;
        private double _integrityTorpedoLaunchers = 0;

        private void refreshTorpedoes()
        {
            _actualTorpLaunchers = 0;

            foreach (IMyTerminalBlock Torp in _torpedoLaunchers)
            {
                if (Torp != null && Torp.IsFunctional)
                {
                    _actualTorpLaunchers++;

                    // turn torps on for 1+ on [0]
                    (Torp as IMyConveyorSorter).Enabled = 
                        (_currentStance.TorpedoMode == TorpedoModes.On || (_currentStance.TorpedoMode == TorpedoModes.OnWhenLidarTarget && _lidarHasTarget));

                    // autoloading is complex for torpedoes.
                    if (_autoLoad)
                    {

                        // get active ammo.
                        string AmmoType = _wcPbApi.GetActiveAmmo(Torp, 0);
                        //string OutputAmmoType = getOutputAmmoType(AmmoType);
                        int Ammo = sortAmmoType(AmmoType);
                        //IMyInventory WeapInv = Torp.GetInventory();

                        if (_d) Echo("Launcher " + Torp.CustomName + " needs " + AmmoType + "(" + Ammo + ")");

                        addTempInventory(Torp, Ammo);

                    }
                }
            }

            _integrityTorpedoLaunchers = Math.Round(100 * (_actualTorpLaunchers / _initTorpLaunchers));
        }

        private void setTorpedoes(TorpedoModes mode)
        {
            if (mode == TorpedoModes.NoChange) return;

            foreach (IMyTerminalBlock Torp in _torpedoLaunchers)
            {
                if (Torp != null & Torp.IsFunctional)
                {
                    if (mode == TorpedoModes.OnWhenLidarTarget)
                    { 
                        // only turn the torps on if lidar has a target

                    }

                    bool TurnOn = (mode == TorpedoModes.On || (mode == TorpedoModes.OnWhenLidarTarget && _lidarHasTarget));

                    if (!TurnOn)
                    {
                        (Torp as IMyConveyorSorter).Enabled = false;
                    }
                    else
                    {
                        (Torp as IMyConveyorSorter).Enabled = true;

                        if (_autoConfigWeapons)
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
