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
        // Ship Cores -----------------------------------------------------------------
        // the SDX2 ship core lists the punishments it is currently applying
        // in its detailed info. the section sits between the grid header and
        // the grid statistics, and looks like this:
        //
        //   Punishments:
        //     Speed: Yes
        //       - Main core is offline
        //     Modifiers: Yes
        //       - Main core is offline
        //     Limited Blocks: No
        //   Grid Statistics:
        //
        // anything reading Yes is something the pilot wants to know about,
        // so we lift those onto the warnings LCD along with their reasons.
        //
        // note the detailed info also contains "Punishment: ShutOff" lines
        // further down under Block Limits. those are the punishment a limit
        // *would* apply, not one that is active, so we only read the
        // "Punishments:" section and stop at the next unindented line.

        class CorePunishment
        {
            public string Name = "";
            public string Reason = "";
        }

        // the punishments the core is currently applying.
        private List<CorePunishment> _corePunishments = new List<CorePunishment>();

        private void refreshShipCores()
        {
            _corePunishments.Clear();

            foreach (IMyTerminalBlock Core in _shipCores)
            {
                // note we don't require IsFunctional here. a damaged or
                // switched off core still reports the grid's punishments,
                // and "main core is offline" is exactly when we want to know.
                if (Core == null) continue;

                // read the punishments off the first core that reports any.
                // backup cores mirror the active one.
                if (readCorePunishments(Core)) break;
            }
        }

        // returns true if this block had a punishments section to read.
        private bool readCorePunishments(IMyTerminalBlock Core)
        {
            string info;


            try
            {
                info = Core.CustomInfo;
            }
            catch (Exception ex)
            {
                if (_d) Echo("Failed to read core info!\n" + ex.Message);
                return false;
            }



            if (string.IsNullOrEmpty(info)) return false;


            int start = info.IndexOf("Punishments:");
            if (start < 0) return false;



            string[] lines = info.Substring(start).Split('\n');

            // the punishment we're currently underneath,
            // so we can pick up its reason lines.
            CorePunishment current = null;

            // skip lines[0], that's the "Punishments:" header itself.
            for (int i = 1; i < lines.Length; i++)
            {

                // TrimEnd sheds any \r, but keep the leading spaces;
                // the indent is how we know where the section ends.
                string raw = lines[i].TrimEnd();
                string line = raw.Trim();

                // blank lines don't mean anything, keep going.
                if (line.Length == 0) continue;

                // back at the left margin means we've reached the next
                // section, eg "Grid Statistics:". we're done.
                if (raw.Length == line.Length) break;

                // a reason for the punishment we're already inside.
                if (line[0] == '-')
                {
                    if (current == null) continue;

                    string reason = line.Substring(1).Trim();
                    if (reason.Length == 0) continue;

                    if (current.Reason.Length > 0) current.Reason += "\n";
                    current.Reason += reason;

                    continue;
                }

                current = null;

                int split = line.IndexOf(':');

                // not a "Name: Value" pair, so nothing we can use.
                if (split < 1) continue;

                string name = line.Substring(0, split).Trim();
                string value = line.Substring(split + 1).Trim();

                if (name.Length == 0) continue;
                if (value.ToUpper() != "YES") continue;

                current = new CorePunishment();
                current.Name = name;

                _corePunishments.Add(current);
            }

            return true;
        }
    }
}
