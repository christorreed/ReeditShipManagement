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
        // _allLcds -----------------------------------------------------------------

        private void iterateLcds()
        {
            foreach (IMyTextPanel Lcd in _allLcds)
            {
                Lcd.Enabled = true;
            }
        }

        private void initLcds()
        {
            // RSM _allLcds -----------------------------------------------------------------

            foreach (IMyTextPanel Lcd in _rsmLcds)
            {
                Lcd.Font = "Monospace";
                Lcd.ContentType = ContentType.TEXT_AND_IMAGE;

                if (Lcd.CustomName.Contains("HUD1"))
                {
                    setLcdCustomData(Lcd,
                        new bool[] {
                            true, // show_header
                            false, // show_header_overlay
                            false, // show_warnings
                            false, // show_tanks_and_batts
                            false, // show_inventory
                            false, // show_thrust
                            false, // show_integrity
                            false, // show_thrust_advanced
                        }, "hudlcd:-0.55:0.99:0.7"); // hudlcd
                    continue;
                }

                if (Lcd.CustomName.Contains("HUD2"))
                {
                    setLcdCustomData(Lcd,
                        new bool[] {
                                false, // show_header
                                false, // show_header_overlay
                                true, // show_warnings
                                false, // show_tanks_and_batts
                                false, // show_inventory
                                false, // show_thrust
                                false, // show_integrity
                                false, // show_thrust_advanced
                            }, "hudlcd:0.22:0.99:0.55"); // hudlcd
                    continue;
                }

                if (Lcd.CustomName.Contains("HUD3"))
                {
                    setLcdCustomData(Lcd,
                        new bool[] {
                                false, // show_header
                                false, // show_header_overlay
                                false, // show_warnings
                                true, // show_tanks_and_batts
                                false, // show_inventory
                                true, // show_thrust
                                false, // show_integrity
                                false, // show_thrust_advanced
                        }, "hudlcd:0.48:0.99:0.55"); // hudlcd
                    continue;
                }

                if (Lcd.CustomName.Contains("HUD4"))
                {
                    setLcdCustomData(Lcd,
                        new bool[] {
                                false, // show_header
                                false, // show_header_overlay
                                false, // show_warnings
                                false, // show_tanks_and_batts
                                false, // show_inventory
                                false, // show_thrust
                                true, // show_integrity
                                false, // show_thrust_advanced
                        }, "hudlcd:0.74:0.99:0.55"); // hudlcd
                    continue;
                }

                if (Lcd.CustomName.Contains("HUD5"))
                {
                    setLcdCustomData(Lcd,
                        new bool[] {
                                false, // show_header
                                false, // show_header_overlay
                                false, // show_warnings
                                false, // show_tanks_and_batts
                                true, // show_inventory
                                false, // show_thrust
                                false, // show_integrity
                                true, // show_thrust_advanced
                        }, "hudlcd:0.75:0:.54"); // hudlcd
                    continue;
                }

                if (Lcd.CustomName.Contains("HUD6"))
                {
                    setLcdCustomData(Lcd,
                        new bool[] {
                                false, // show_header
                                true, // show_header_overlay
                                false, // show_warnings
                                false, // show_tanks_and_batts
                                false, // show_inventory
                                false, // show_thrust
                                false, // show_integrity
                                false, // show_thrust_advanced
                        }, "hudlcd:-0.55:0.99:0.7"); // hudlcd
                    continue;
                }
            }


            // All other _allLcds -----------------------------------------------------------------
            bool NavigationLCDFound = false;
            bool REEDAV1LCDFound = false;
            bool REEDAV2LCDFound = false;

            foreach (IMyTextPanel Lcd in _allLcds)
            {
                if (Lcd == null) continue;

                // REEDAV _allLcds -----------------------------------------------------------------

                // todo
                // improve? maybe just remove?
                // numbering cleaned up?!
                // also for RCM.

                if (!REEDAV1LCDFound && Lcd.CustomName.Contains("[REEDAV].1"))
                {
                    REEDAV1LCDFound = true;
                    Lcd.CustomData =
                        "Show Targeting Info=True\nFirst Missile=0\nLast Missile=0\nExtra Missile Info=False\nhudlcd:0.56:0:.48";
                    continue;
                }

                if (!REEDAV2LCDFound && Lcd.CustomName.Contains("[REEDAV].2"))
                {
                    REEDAV2LCDFound = true;
                    Lcd.CustomData =
                        "Show Targeting Info=False\nFirst Missile=1\nLast Missile=24\nExtra Missile Info=False\nhudlcd:0.56:-.26:.48";
                    continue;
                }

                // EFC/NavOS Navigation _allLcds -----------------------------------------------------------------

                if (
                    !NavigationLCDFound
                    &&
                    (Lcd.CustomName.Contains(KEYWORD_PB_EFC)
                    ||
                    Lcd.CustomName.ToUpper().Contains(KEYWORD_PB_NAVOS))
                    )
                {
                    NavigationLCDFound = true;
                    Lcd.CustomData = "hudlcd:-0.52:-0.7:0.52";
                    continue;
                }
            }
        }

        void setLcdCustomData(IMyTerminalBlock Lcd, bool[] Settings, string Append)
        {
            Lcd.CustomData =
                "Show Header=" + Settings[0] +
                "\nShow Header Overlay=" + Settings[1] +
                "\nShow Warnings=" + Settings[2] +
                "\nShow Tanks & Batteries=" + Settings[3] +
                "\nShow Inventory=" + Settings[4] +
                "\nShow Thrust=" + Settings[5] +
                "\nShow Subsystem Integrity=" + Settings[6] +
                "\nShow Advanced Thrust=" + Settings[7]
                + "\n" + Append;
        }

    }
}
