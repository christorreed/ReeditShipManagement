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

        int _initWelders = 0;
        double _actualWelders = 0;
        double _integrityWelders = 0;

        void iterateWelders()
        {
            _actualWelders = 0;

            foreach (IMyTerminalBlock Welder in _welders)
            {
                if (Welder != null && Welder.IsFunctional)
                    _actualWelders++;
            }

            _integrityWelders = Math.Round(100 * (_actualWelders / _initWelders));
        }
    }
}
