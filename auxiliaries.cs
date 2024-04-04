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
        // Auxiliaries -----------------------------------------------------------------
        
        

        void iterateAuxiliaries()
        {
            _activeAuxBlockCount = 0;

            foreach (IMyTerminalBlock Block in _auxiliaries)
            {
                if (Block == null)
                    continue;
                if (Block.IsWorking)
                    _activeAuxBlockCount++;
            }
        }

        void setAuxiliaries(ToggleModes mode)
        {
            if (mode == ToggleModes.NoChange) return;

            foreach (IMyTerminalBlock Block in _auxiliaries)
            {
                if (Block == null) continue;

                try
                {
                    if (mode == ToggleModes.Off)
                        Block.ApplyAction("OnOff_Off");
                    else
                        Block.ApplyAction("OnOff_On");
                }
                catch
                {
                    if (_d) Echo("Failed to set aux block " + Block.CustomName);
                }
            }
        }
    }
}
