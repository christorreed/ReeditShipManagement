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

        void setSpotlights(SpotlightModes mode)
        {
            if (mode == SpotlightModes.NoChange) return;

            foreach (IMyReflectorLight Spot in LIGHTs_SPOT)
            {
                if (Spot == null) continue;

                // 5: spotlights; 0: off, 1: on, 2: on max radius
                if (mode == SpotlightModes.Off)
                    Spot.Enabled = false; // off
                else
                {
                    Spot.Enabled = false; // on
                    if (mode == SpotlightModes.OnMax) Spot.Radius = 9999;
                }
            }
        }

        // Exterior Lights -----------------------------------------------------------------

        void setExteriorLights(LightToggleModes mode, Color colour)
        {
            if (mode == LightToggleModes.NoChange) return;

            foreach (IMyLightingBlock Light in LIGHTs_EXTERIOR)
            {
                if (Light == null) continue;

                if (mode == LightToggleModes.Off)
                    Light.Enabled = false;
                else
                    Light.Enabled = true;

                if (mode != LightToggleModes.OnNoColourChange)
                    Light.SetValue("Color", colour);
            }
        }

        // Interior Lights -----------------------------------------------------------------

        void setInteriorLights(LightToggleModes mode, Color colour)
        {
            if (mode == LightToggleModes.NoChange) return;

            foreach (IMyLightingBlock Light in LIGHTs_EXTERIOR)
            {
                if (Light == null) continue;

                if (mode == LightToggleModes.Off)
                    Light.Enabled = false;
                else
                    Light.Enabled = true;

                if (mode != LightToggleModes.OnNoColourChange)
                    Light.SetValue("Color", colour);
            }
        }

        // Nav Lights -----------------------------------------------------------------

        Color COLOUR_BLACK = new Color(255, 0, 0, 255);
        Color COLOUR_PORT = new Color(255, 0, 0, 255);
        Color COLOUR_STARBOARD = new Color(255, 0, 0, 255);

        void setNavLights(LightToggleModes mode)
        {
            if(mode == LightToggleModes.NoChange) return;

            foreach (IMyLightingBlock Light in LIGHTs_NAV_PORT)
            {
                setNavLight(Light, mode, COLOUR_PORT);
            }

            foreach (IMyLightingBlock Light in LIGHTs_NAV_STARBOARD)
            {
                setNavLight(Light, mode, COLOUR_STARBOARD);
            }
        }

        void setNavLight(IMyLightingBlock Light, LightToggleModes mode, Color colour)
        {
            if (Light == null) return;
            if (mode == LightToggleModes.Off)
            {
                Light.Enabled = false;
                Light.SetValue("Color", COLOUR_BLACK);
            }
            else
            {
                Light.Enabled = true;
                if (mode != LightToggleModes.OnNoColourChange)
                    Light.SetValue("Color", colour);
            }              
        }
    }
}
