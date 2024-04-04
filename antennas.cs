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
    partial class Program : MyGridProgram
    {
        bool _commsActive = false;
        string _commsMessage = "";
        double _commsRange = 0; 
       

        void refreshAntennas()
        {
            _commsActive = false;

            _commsRange = 0;
            
            foreach (IMyRadioAntenna Antenna in _antennas)
            {
                if (Antenna != null)
                {
                    if (Antenna.IsFunctional)
                    {
                        float range = Antenna.Radius;
                        if (range > _commsRange) _commsRange = range;
                        if (Antenna.IsBroadcasting && Antenna.Enabled) _commsActive = true;
                    }
                }
            }
        }

        void setAntennaComms(string Comms)
        {
            _commsMessage = Comms;

            foreach (IMyTerminalBlock Block in _antennas)
            {
                IMyRadioAntenna Antenna = Block as IMyRadioAntenna;
                if (Antenna != null) Antenna.HudText = Comms;
            }
        }


    }
}
