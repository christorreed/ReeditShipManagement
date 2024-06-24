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
        // Railguns -----------------------------------------------------------------

        private int _initKinetics = 0;
        private double _actualKinetics = 0;
        private double _integrityKinetics = 0;

        private bool _kineticsHaveTarget = false;

        private void refreshRailguns()
        {
            // will be used to control battery mode.
            _kineticsHaveTarget = false;

            _actualKinetics = 0;

            foreach (IMyTerminalBlock Rail in _kineticWeapons)
            {
                if (Rail != null && Rail.IsFunctional)
                {
                    _actualKinetics++;

                    // turn railguns on for 1+ on [2]
                    (Rail as IMyConveyorSorter).Enabled = _currentStance.RailgunMode != RailgunModes.Off;

                    if (!_kineticsHaveTarget)
                    {
                        MyDetectedEntityInfo? RailTarget = _wcPbApi.GetWeaponTarget(Rail);
                        if (RailTarget.HasValue)
                        {
                            string Name = RailTarget.Value.Name;
                            if (Name != null && Name != "")
                            {
                                if (_d) Echo("At least one rail has a target!");
                                _kineticsHaveTarget = true;
                            }
                        }
                    }
                }
            }

            foreach (IMyTerminalBlock Rail in _kineticFixedWeapons)
            {
                if (Rail != null && Rail.IsFunctional)
                {
                    _actualKinetics++;

                    // turn railguns on for 1+ on [2]
                    (Rail as IMyConveyorSorter).Enabled = _currentStance.RailgunMode != RailgunModes.Off;
                }
            }

            _integrityKinetics = Math.Round(100 * (_actualKinetics / _initKinetics));
        }

        private void setRails(RailgunModes mode)
        {
            if (mode == RailgunModes.NoChange) return;

            foreach (IMyTerminalBlock rail in _kineticWeapons)
            {
                setRail(rail, mode, false);
            }

            foreach (IMyTerminalBlock rail in _kineticFixedWeapons)
            {
                setRail(rail, mode, true);
            }
        }

        private void setRail(IMyTerminalBlock rail, RailgunModes mode, bool fixedWeap)
        {
            if (rail != null & rail.IsFunctional)
            {
                if (mode == RailgunModes.Off)
                {
                    (rail as IMyConveyorSorter).Enabled = false;
                }
                else
                {
                    (rail as IMyConveyorSorter).Enabled = true;
                    
                    if (!fixedWeap)
                    {
                        if (_autoConfigWeapons)
                        {
                            rail.SetValue("WC_Grids", true);
                            rail.SetValue("WC_LargeGrid", true);
                            rail.SetValue("WC_SmallGrid", true);
                            rail.SetValue("WC_SubSystems", true);
                            setBlockRepelOff(rail);
                        }

                        if (_setTurretFireMode)
                        {
                            if (mode == RailgunModes.OpenFire)
                            {
                                // weapons free
                                setBlockFireModeAuto(rail);
                            }
                            else
                            {
                                // hold fire
                                setBlockFireModeManual(rail);
                            }
                        }
                    }
                }
            }
        }
    }
}
