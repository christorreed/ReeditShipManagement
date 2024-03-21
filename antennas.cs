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
        bool COMMS_ON = false;
        string COMMS_MSG = "";
        double COMMS_RANGE = 0; 
       

        void refreshAntennas()
        {
            COMMS_ON = false;

            COMMS_RANGE = 0;
            
            foreach (IMyRadioAntenna Antenna in ANTENNAs)
            {
                if (Antenna != null)
                {
                    if (Antenna.IsFunctional)
                    {
                        float range = Antenna.Radius;
                        if (range > COMMS_RANGE) COMMS_RANGE = range;
                        if (Antenna.IsBroadcasting && Antenna.Enabled) COMMS_ON = true;
                    }
                }
            }
        }

        void setAntennaComms(string Comms)
        {
            COMMS_MSG = Comms;

            foreach (IMyTerminalBlock Block in ANTENNAs)
            {
                IMyRadioAntenna Antenna = Block as IMyRadioAntenna;
                if (Antenna != null) Antenna.HudText = Comms;
            }
        }


    }
}
