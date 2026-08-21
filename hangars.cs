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
        // Hangar Pads -----------------------------------------------------------------
        // the SDX2 hangar pad blocks. these draw power whether or not
        // anything is docked to them, so they are worth shutting down
        // when you are not using them.

        private int _actualHangars = 0;

        // applies the stance's hangar mode.
        // called on stance change.
        void setHangars(ToggleModes mode)
        {
            if (mode == ToggleModes.NoChange) return;

            foreach (IMyFunctionalBlock Hangar in _hangars)
            {
                if (Hangar == null) continue;

                Hangar.Enabled = (mode == ToggleModes.On);
            }
        }

        // keeps the pads where the stance put them,
        // in case something else has switched them.
        // also counts the working ones.
        void refreshHangars()
        {
            _actualHangars = 0;

            //bool set = _currentStance.HangarMode != ToggleModes.NoChange;
            //bool state = _currentStance.HangarMode == ToggleModes.On;

            foreach (IMyFunctionalBlock Hangar in _hangars)
            {
                if (Hangar == null || !Hangar.IsFunctional) continue;

                _actualHangars++;

                //if (set && Hangar.Enabled != state)
                    //Hangar.Enabled = state;
            }
        }
    }
}
