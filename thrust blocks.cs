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
using VRageRender.Messages;

namespace IngameScript
{
    partial class Program
    {
        // Epstein Drives -----------------------------------------------------------------

        private float _maxThrust;
        private float _actualThrust;

        private float _initThrustMain;
        private double _integrityThrustMain;

        private void refreshMainThrusters()
        {
            float MaxTotal = 0;
            float MaxOn = 0;
            float ActualTotal = 0;
            float ActualOn = 0;

            foreach (IMyThrust Thruster in _epsteinThrusters)
            {
                if (Thruster != null && Thruster.IsFunctional)
                {
                    MaxTotal += Thruster.MaxThrust;
                    ActualTotal += Thruster.CurrentThrust;

                    if (Thruster.Enabled)
                    {
                        MaxOn += Thruster.MaxThrust;
                        ActualOn += Thruster.CurrentThrust;
                    }
                }
            }

            _integrityThrustMain = Math.Round(100 * (MaxTotal / _initThrustMain));

            // calculate current thrust.
            // if nothing is on, we want to show numbers for all drives
            if (MaxOn == 0)
            {
                _maxThrust = MaxTotal;
                _actualThrust = ActualTotal;
            }
            // but if some drives are on, show numbers for those drives only.
            else
            {
                _maxThrust = MaxOn;
                _actualThrust = ActualOn;
            }
        }

        private void initMainThrusters()
        {
            _initThrustMain = 0;
            foreach (IMyThrust Thruster in _epsteinThrusters)
            {
                if (Thruster != null)
                    _initThrustMain += Thruster.MaxThrust;
            }
        }

        private void setMainThrusters(MainDriveModes mode, ManeuveringThrusterModes modeRcs)
        {
            if (mode == MainDriveModes.NoChange) return;

            foreach (IMyThrust Thruster in _epsteinThrusters)
            {
                setMainThruster(Thruster, mode, modeRcs);
            }

            foreach (IMyThrust Thruster in _chemicalThrusters)
            {
                setMainThruster(Thruster, mode, modeRcs, true);
            }
        }

        private void setMainThruster(IMyThrust Thruster, MainDriveModes mode, ManeuveringThrusterModes modeRcs, bool chem = false)
        {
            bool DockingThruster = Thruster.CustomName.Contains(_keywordThrustersDocking);

            // docking thrusters follow state_rcs.
            // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
            if (DockingThruster)
            {
                if (modeRcs != ManeuveringThrusterModes.Off && modeRcs != ManeuveringThrusterModes.AtmoOnly)
                    Thruster.Enabled = true;
                else
                    Thruster.Enabled = false;
            }

            // Guess it's a main thruster...

            // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change

            else
            {
                bool MinThruster = Thruster.CustomName.Contains(_keywordThrustersMinimum);

                // lets decide what that is...
                if (
                    (mode == MainDriveModes.On) // On
                    ||
                    (mode == MainDriveModes.Minimum && MinThruster) // Min Only
                    ||
                    (mode == MainDriveModes.EpsteinOnly && !chem) // Eps only
                    ||
                    (mode == MainDriveModes.ChemOnly && chem) // Chems only
                    )
                {
                    Thruster.Enabled = true;
                }
                else
                {
                    Thruster.Enabled = false;
                }
            }
        }


        // RCS Thrusters -----------------------------------------------------------------

        private float ACTUAL__rcsThrusters;
        private float _initThrustRCS;
        private double _integrityThrustRCS;

        private void refreshRcsThrusters()
        {
            ACTUAL__rcsThrusters = 0;

            foreach (IMyThrust Thruster in _rcsThrusters)
            {
                if (Thruster!= null && Thruster.IsFunctional)
                {
                    ACTUAL__rcsThrusters += Thruster.MaxThrust;
                }
            }

            _integrityThrustRCS = Math.Round(100 * (ACTUAL__rcsThrusters / _initThrustRCS));
        }
        private void initRcsThrusters()
        {
            _initThrustRCS = 0;
            foreach (IMyThrust Thruster in _rcsThrusters)
            {
                if (Thruster != null)
                    _initThrustRCS += Thruster.MaxThrust;
            }
        }

        private void setRcsThrusters(ManeuveringThrusterModes mode)
        {
            if (mode == ManeuveringThrusterModes.NoChange) return;

            foreach (IMyThrust Thruster in _rcsThrusters)
            {
                if (Thruster != null)
                    setRcsThruster(Thruster, mode);
            }

            foreach (IMyThrust Thruster in _atmoThrusters)
            {
                if (Thruster != null)
                    setRcsThruster(Thruster, mode, true);
            }
        }

        private void setRcsThruster(IMyThrust Thruster, ManeuveringThrusterModes mode, bool atmo = false)
        {
            // Guess it's a main thruster...

            // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change

            // this seems like it's around the wrong way.
            // but its not...
            bool Forward = Thruster.GridThrustDirection == Vector3I.Backward;
            bool Reverse = Thruster.GridThrustDirection == Vector3I.Forward;

                // ...lets decide what that is...
            if (
                (mode == ManeuveringThrusterModes.On) // On
                ||
                (mode == ManeuveringThrusterModes.ForwardOff && !Forward) // all on, fwd off.
                ||
                (mode == ManeuveringThrusterModes.ReverseOff && !Reverse) // all on, rev off.
                ||
                (mode == ManeuveringThrusterModes.RcsOnly && !atmo) // all rcs on, atmo off
                ||
                (mode == ManeuveringThrusterModes.AtmoOnly && atmo) // all rcs off, atmo on
                )
            {
                Thruster.Enabled = true;
            }
            else
            {
                Thruster.Enabled = false;
            }
            
        }
    }
}
