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
        // LCDs -----------------------------------------------------------------

        private void iterateLcds()
        {
            foreach (IMyTextPanel Lcd in _allLcds)
            {
                Lcd.Enabled = true;
            }
        }

        private void initLcds()
        {
            // RSM LCDs -----------------------------------------------------------------

            foreach (RsmLcd lcd in _rsmLcds)
            {


                lcd.Block.Font = "Monospace";
                lcd.Block.ContentType = ContentType.TEXT_AND_IMAGE;

                if (lcd.Block.CustomName.Contains("HUD1"))
                {
                    lcd.ShowHeader = true;
                    lcd.ShowHeaderOverlay = false;
                    lcd.ShowWarnings = false;
                    lcd.ShowPowerAndTanks = false;
                    lcd.ShowInventory = false;
                    lcd.ShowThrust = false;
                    lcd.ShowIntegrity = false;
                    lcd.ShowAdvancedThrust = false;

                    sortRsmLcd(lcd.Block, false, "hudlcd:-0.55:0.99:0.7") ;
                    continue;
                }

                if (lcd.Block.CustomName.Contains("HUD2"))
                {
                    lcd.ShowHeader = false;
                    lcd.ShowHeaderOverlay = false;
                    lcd.ShowWarnings = true;
                    lcd.ShowPowerAndTanks = false;
                    lcd.ShowInventory = false;
                    lcd.ShowThrust = false;
                    lcd.ShowIntegrity = false;
                    lcd.ShowAdvancedThrust = false;

                    sortRsmLcd(lcd.Block, false, "hudlcd:0.22:0.99:0.55");
                    continue;
                }

                if (lcd.Block.CustomName.Contains("HUD3"))
                {
                    lcd.ShowHeader = false;
                    lcd.ShowHeaderOverlay = false;
                    lcd.ShowWarnings = false;
                    lcd.ShowPowerAndTanks = true;
                    lcd.ShowInventory = false;
                    lcd.ShowThrust = true;
                    lcd.ShowIntegrity = false;
                    lcd.ShowAdvancedThrust = false;

                    sortRsmLcd(lcd.Block, false, "hudlcd:0.48:0.99:0.55");
                    continue;
                }

                if (lcd.Block.CustomName.Contains("HUD4"))
                {
                    lcd.ShowHeader = false;
                    lcd.ShowHeaderOverlay = false;
                    lcd.ShowWarnings = false;
                    lcd.ShowPowerAndTanks = false;
                    lcd.ShowInventory = false;
                    lcd.ShowThrust = false;
                    lcd.ShowIntegrity = true;
                    lcd.ShowAdvancedThrust = false;

                    sortRsmLcd(lcd.Block, false, "hudlcd:0.74:0.99:0.55");
                    continue;
                }

                if (lcd.Block.CustomName.Contains("HUD5"))
                {
                    lcd.ShowHeader = false;
                    lcd.ShowHeaderOverlay = false;
                    lcd.ShowWarnings = false;
                    lcd.ShowPowerAndTanks = false;
                    lcd.ShowInventory = true;
                    lcd.ShowThrust = false;
                    lcd.ShowIntegrity = false;
                    lcd.ShowAdvancedThrust = true;

                    sortRsmLcd(lcd.Block, false, "hudlcd:0.75:0:.54");
                    continue;
                }

                if (lcd.Block.CustomName.Contains("HUD6"))
                {
                    lcd.ShowHeader = false;
                    lcd.ShowHeaderOverlay = true;
                    lcd.ShowWarnings = false;
                    lcd.ShowPowerAndTanks = false;
                    lcd.ShowInventory = false;
                    lcd.ShowThrust = false;
                    lcd.ShowIntegrity = false;
                    lcd.ShowAdvancedThrust = false;

                    sortRsmLcd(lcd.Block, false, "hudlcd:-0.55:0.99:0.7");
                    continue;
                }
            }


            // All other LCDs -----------------------------------------------------------------
            bool NavigationLCDFound = false;
            bool REEDAV1LCDFound = false;
            bool REEDAV2LCDFound = false;

            foreach (IMyTextPanel Lcd in _allLcds)
            {
                if (Lcd == null) continue;

                // REEDAV LCDs -----------------------------------------------------------------

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

                // EFC/NavOS Navigation LCDs -----------------------------------------------------------------

                if (
                    !NavigationLCDFound
                    &&
                    (Lcd.CustomName.Contains(_keywordLcdEfc)
                    ||
                    Lcd.CustomName.ToUpper().Contains(_keywordLcdNavOs))
                    )
                {
                    NavigationLCDFound = true;
                    Lcd.CustomData = "hudlcd:-0.52:-0.7:0.52";
                    continue;
                }
            }
        }
    }
}
