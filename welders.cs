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

        // todo
        // add toolcore support!

        double ACTUAL_WELDERS = 0;
        int _initWelders = 0;
        double INTEGRITY_WELDERs = 0;

        void iterateWelders()
        {
            ACTUAL_WELDERS = 0;

            foreach (IMyTerminalBlock Welder in WELDERs)
            {
                if (Welder != null && Welder.IsFunctional)
                    ACTUAL_WELDERS++;
            }

            INTEGRITY_WELDERs = Math.Round(100 * (ACTUAL_WELDERS / _initWelders));
        }
    }
}
