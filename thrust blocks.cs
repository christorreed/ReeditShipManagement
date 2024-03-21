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

        private float THRUST_MAX;
        private float THRUST_ACTUAL;

        private float INIT_THRUSTERs_MAIN;
        private double INTEGRITY_THRUSTERs_MAIN;

        private void refreshMainThrusters()
        {
            float MaxTotal = 0;
            float MaxOn = 0;
            float ActualTotal = 0;
            float ActualOn = 0;

            foreach (IMyThrust Thruster in THRUSTERs_EPSTEIN)
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

            INTEGRITY_THRUSTERs_MAIN = Math.Round(100 * (MaxTotal / INIT_THRUSTERs_MAIN));

            // calculate current thrust.
            // if nothing is on, we want to show numbers for all drives
            if (MaxOn == 0)
            {
                THRUST_MAX = MaxTotal;
                THRUST_ACTUAL = ActualTotal;
            }
            // but if some drives are on, show numbers for those drives only.
            else
            {
                THRUST_MAX = MaxOn;
                THRUST_ACTUAL = ActualOn;
            }
        }

        private void initMainThrusters()
        {
            INIT_THRUSTERs_MAIN = 0;
            foreach (IMyThrust Thruster in THRUSTERs_EPSTEIN)
            {
                if (Thruster != null)
                    INIT_THRUSTERs_MAIN += Thruster.MaxThrust;
            }
        }

        private void setMainThrusters(int state, int state_rcs)
        {
            foreach (IMyThrust Thruster in THRUSTERs_EPSTEIN)
            {
                setMainThruster(Thruster, state, state_rcs);
            }

            foreach (IMyThrust Thruster in THRUSTERs_CHEM)
            {
                setMainThruster(Thruster, state, state_rcs, true);
            }
        }

        private void setMainThruster(IMyThrust Thruster, int state, int state_rcs, bool chem = false)
        {
            bool DockingThruster = Thruster.CustomName.Contains(KEYWORD_THRUST_DOCKING);

            // docking thrusters follow state_rcs.
            // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
            if (DockingThruster)
            {
                if (state_rcs == 9) // no change.
                    return; // so do nothing
                else if (state_rcs > 0)
                    Thruster.Enabled = true;
                else
                    Thruster.Enabled = false;
            }

            // Guess it's a main thruster...

            // 3: main drives; 0: off, 1: on, 2: minimum only, 3: epstein only, 4: chems only, 9: no change
            else if (state == 9) // no change
            {
                return; // so do nothing
            }
            else // ...and we def doing something to it...
            {
                bool MinThruster = Thruster.CustomName.Contains(KEYWORD_THRUST_MIN);

                // lets decide what that is...
                if (
                    (state == 1) // On
                    ||
                    (state == 2 && MinThruster) // Min Only
                    ||
                    (state == 3 && !chem) // Eps only
                    ||
                    (state == 4 && chem) // Chems only
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

        private float ACTUAL_THRUSTERs_RCS;
        private float INIT_THRUSTERs_RCS;
        private double INTEGRITY_THRUSTERs_RCS;

        private void refreshRcsThrusters()
        {
            ACTUAL_THRUSTERs_RCS = 0;

            foreach (IMyThrust Thruster in THRUSTERs_RCS)
            {
                if (Thruster!= null && Thruster.IsFunctional)
                {
                    ACTUAL_THRUSTERs_RCS += Thruster.MaxThrust;
                }
            }

            INTEGRITY_THRUSTERs_RCS = Math.Round(100 * (ACTUAL_THRUSTERs_RCS / INIT_THRUSTERs_RCS));
        }
        private void initRcsThrusters()
        {
            INIT_THRUSTERs_RCS = 0;
            foreach (IMyThrust Thruster in THRUSTERs_RCS)
            {
                if (Thruster != null)
                    INIT_THRUSTERs_RCS += Thruster.MaxThrust;
            }
        }

        private void setRcsThrusters(int state)
        {
            foreach (IMyThrust Thruster in THRUSTERs_RCS)
            {
                if (Thruster != null)
                    setRcsThruster(Thruster, state);
            }

            foreach (IMyThrust Thruster in THRUSTERs_ATMO)
            {
                if (Thruster != null)
                    setRcsThruster(Thruster, state, true);
            }
        }

        private void setRcsThruster(IMyThrust Thruster, int state, bool atmo = false)
        {
            // Guess it's a main thruster...

            // 4: maneuvering thrusters; 0: off, 1: on, 2: forward off, 3: reverse off, 4: rcs only, 5: atmo only, 9: no change
            if (state == 9) // no change
            {
                return; // so do nothing
            }
            else // ...and we def doing something to it...
            {
                // this seems like it's around the wrong way.
                // but its not...
                bool Forward = Thruster.GridThrustDirection == Vector3I.Backward;
                bool Reverse = Thruster.GridThrustDirection == Vector3I.Forward;

                // ...lets decide what that is...
                if (
                    (state == 1) // On
                    ||
                    (state == 2 && !Forward) // all on, fwd off.
                    ||
                    (state == 3 && !Reverse) // all on, rev off.
                    ||
                    (state == 4 && !atmo) // all rcs on, atmo off
                    ||
                    (state == 5 && atmo) // all rcs off, atmo on
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
}
