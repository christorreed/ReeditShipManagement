using ParallelTasks;
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
                    bool isToolCore = Block.BlockDefinition.ToString().Contains("ToolCore");

                    if (mode == ToggleModes.On || isToolCore) // don't turn toolcore stuff off!
                        Block.ApplyAction("OnOff_On");
                    
                    else if (!isToolCore) // don't turn toolcore stuff off!
                        Block.ApplyAction("OnOff_Off");

                    if (isToolCore)
                    {
                        ITerminalAction action = Block.GetActionWithName("ToolCore_Shoot_Action");
                        if (action != null)
                        {
                            StringBuilder actionStringBuilder = new StringBuilder();
                            action.WriteValue(Block, actionStringBuilder);
                            string actionString = actionStringBuilder.ToString();
                            if (_d) Echo(actionString);
                            if (actionString == "Active" && mode == ToggleModes.Off)
                                action.Apply(Block);
                            else if (actionString == "Inactive" && mode == ToggleModes.On)
                                action.Apply(Block);
                        }
                    }
                }
                catch
                {
                    if (_d) Echo("Failed to set aux block " + Block.CustomName);
                }
            }
        }
    }
}
