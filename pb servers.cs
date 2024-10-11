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
using VRage.Scripting;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        bool _pbCommandRanEfc = false;
        List<string> _pbCommandsBufferEfc = new List<string>();
        bool _pbCommandRanNavOs = false;
        List<string> _pbCommandsBufferNavOs = new List<string>();

        void runPbServerCommand(string argument, string script)
        {
            bool Success = false;
            List<IMyProgrammableBlock> Pbs = new List<IMyProgrammableBlock>();

            try
            {
                if (script == "EFC") Pbs = _pbsEfc;
                else if (script == "NavOS") Pbs = _pbsNavOs;

                foreach (IMyProgrammableBlock pb in Pbs)
                {
                    // if PB gone or turned off, try the next one...
                    if (pb == null || !pb.Enabled) continue;

                    // run the command
                    Success = (pb as IMyProgrammableBlock).TryRun(argument);

                    if (Success && _d)
                        Echo("Ran " + argument + " on " + pb.CustomName + " successfully.");
                    else
                        _alerts.Add(new Alert(
                            script + " command failed!",
                            script + " command " + argument + " failed!"
                            , 1
                            ));

                    if (script == "EFC") _pbCommandRanEfc = true;
                    else if (script == "NavOS") _pbCommandRanNavOs = true;

                    break;
                }
            }
            catch (Exception ex)
            {
                _alerts.Add(new Alert(
                    script + " command errored!",
                    script + " command " + argument + " errored!\n" + ex.Message
                    , 3
                    ));
            }


        }

        void addPbServerCommand(string argument, string script)
        {
            // EFC
            // if we have already run this tick
            // buffer this command
            if (script == "EFC")
            {
                if (_pbsEfc.Count < 1) return;

                if (_pbCommandRanEfc)
                {
                    _pbCommandsBufferEfc.Add(argument);
                    return;
                }
            }

            // NavOS
            // if we have already run this tick
            // buffer this command
            if (script == "NavOS")
            {
                // if we don't even have such a Pb, bail
                if (_pbsNavOs.Count < 1) return;

                if (_pbCommandRanNavOs)
                {
                    _pbCommandsBufferNavOs.Add(argument);
                    return;
                }
            }

            // otherwise, run right away
            runPbServerCommand(argument, script);
        }

        void refreshPbServers()
        {
            if (
                // there is at least one efc ommand
                _pbCommandsBufferEfc.Count > 0
                &&
                // and we haven't run an efc command this tick
                !_pbCommandRanEfc
                )
            {
                // run one.
                runPbServerCommand(_pbCommandsBufferEfc[0], "EFC");

                // and delete it from the buffer.
                _pbCommandsBufferEfc.RemoveAt(0);
            }

            if (
                // there is at least one navos ommand
                _pbCommandsBufferNavOs.Count > 0
                &&
                // and we haven't run an navos command this tick
                !_pbCommandRanNavOs
                )
            {
                // run one.
                runPbServerCommand(_pbCommandsBufferNavOs[0], "NavOS");

                // and delete it from the buffer.
                _pbCommandsBufferNavOs.RemoveAt(0);
            }

            // reset pb ran bools
            _pbCommandRanEfc = false;
            _pbCommandRanNavOs = false;
        }

    }
}
