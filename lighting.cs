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
        // Spotlights -----------------------------------------------------------------

        void setSpotlights(int state)
        {
            foreach (IMyReflectorLight Spot in LIGHTs_SPOT)
            {
                if (Spot == null) continue;

                // 5: spotlights; 0: off, 1: on, 2: on max radius
                if (state == 0)
                    Spot.Enabled = false; // off
                else
                {
                    Spot.Enabled = false; // on
                    if (state == 2) Spot.Radius = 9999;
                }
            }
        }

        // Exterior Lights -----------------------------------------------------------------

        void setExteriorLights(int state, Color colour)
        {
            foreach (IMyLightingBlock Light in LIGHTs_EXTERIOR)
            {
                if (Light == null) continue;

                if (state == 0)
                    Light.Enabled = false;
                else
                    Light.Enabled = true;

                Light.SetValue("Color", colour);
            }
        }

        // Interior Lights -----------------------------------------------------------------

        void setInteriorLights(int state, Color colour)
        {
            foreach (IMyLightingBlock Light in LIGHTs_EXTERIOR)
            {
                if (Light == null) continue;

                if (state == 0)
                    Light.Enabled = false;
                else
                    Light.Enabled = true;

                Light.SetValue("Color", colour);
            }
        }

        // Nav Lights -----------------------------------------------------------------

        Color COLOUR_BLACK = new Color(255, 0, 0, 255);
        Color COLOUR_PORT = new Color(255, 0, 0, 255);
        Color COLOUR_STARBOARD = new Color(255, 0, 0, 255);

        void setNavLights(int state)
        {
            foreach (IMyLightingBlock Light in LIGHTs_NAV_PORT)
            {
                setNavLight(Light, state, COLOUR_PORT);
            }

            foreach (IMyLightingBlock Light in LIGHTs_NAV_STARBOARD)
            {
                setNavLight(Light, state, COLOUR_STARBOARD);
            }
        }

        void setNavLight(IMyLightingBlock Light, int state, Color colour)
        {
            if (Light == null) return;
            if (state == 0)
            {
                Light.Enabled = false;
                Light.SetValue("Color", COLOUR_BLACK);
            }
            else
            {
                Light.Enabled = true;
                Light.SetValue("Color", colour);
            }              
        }
    }
}
