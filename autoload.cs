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
        void manageAutoload()
        {

            if (!AUTOLOAD) return;

            if (debug) Echo("Managing Autoload, " + TO_LOAD.Count + " weapons to be loaded...");

            bool Ammo_Low = false;

            if (WC_PB_API == null)
            {
                try
                {
                    WC_PB_API = new WcPbApi();
                    WC_PB_API.Activate(Me);
                }
                catch
                {
                    WC_PB_API = null;
                }
            }

            missing_ammo = "";

            foreach (IMyTerminalBlock Weapon in TO_LOAD)
            {
                string AmmoType = WC_PB_API.GetActiveAmmo(Weapon, 0);

                string OutputAmmoType = "";

                // lol these ammo types are crappy and have to be manually processed.
                switch (AmmoType)
                {
                    case "220mm Explosive Torpedo":
                        OutputAmmoType = "220mmExplosiveTorpedoMagazine";
                        break;

                    case "MCRN Torpedo High Spread":
                    case "MCRN Torpedo Low Spread":
                        OutputAmmoType = "220mmMCRNTorpedoMagazine";
                        break;

                    case "UNN Torpedo High Spread":
                    case "UNN Torpedo Low Spread":
                        OutputAmmoType = "220mmUNNTorpedoMagazine";
                        break;

                    case "40mm Tungsten-Teflon Ammo":
                        OutputAmmoType = "40mmTungstenTeflonPDCBoxMagazine";
                        break;

                    case "40mm Lead-Steel PDC Box Ammo":
                        OutputAmmoType = "40mmLeadSteelPDCBoxMagazine";
                        break;

                    case "Ramshackle Torpedo Magazine":
                        OutputAmmoType = "RamshackleTorpedoMagazine";
                        break;

                    case "120mm Lead-Steel Slug Ammo":
                        OutputAmmoType = "120mmLeadSteelSlugMagazine";
                        break;

                    case "100mm Tungsten-Uranium Slug UNN Ammo":
                        OutputAmmoType = "100mmTungstenUraniumSlugUNNMagazine";
                        break;

                    case "100mm Tungsten-Uranium Slug MCRN Ammo":
                        OutputAmmoType = "100mmTungstenUraniumSlugMCRNMagazine";
                        break;

                    case "80mm Tungsten-Uranium Sabot Ammo":
                        OutputAmmoType = "80mmTungstenUraniumSabotMagazine";
                        break;

                    default:
                        if (debug) Echo("Unknown AmmoType = " + AmmoType);
                        break;

                }

                foreach (ITEM Item in ITEMS)
                {
                    //if (debug) Echo("Checking " + Item.TYPE.SubtypeId);

                    if (Item.TYPE.SubtypeId == OutputAmmoType) // this is the correct item for this ammo type.
                    {
                        if (Item.STORED_IN.Count > 0) // there are inventories where this item is stored.
                            loadInventory(Weapon, Item.STORED_IN, OutputAmmoType, 99);
                        else // there arne't any inventories where this item is stored.
                        {
                            Ammo_Low = true;

                            // this will prevent overflowing ammo names from causing double ups here
                            // by truncating to 32 chars
                            if (AmmoType.Length > 32)
                                AmmoType = AmmoType.Substring(0, 32);

                            if (!missing_ammo.Contains(AmmoType))
                            {
                                if (missing_ammo != "") missing_ammo += "\n";
                                missing_ammo += centreText(AmmoType, 32);
                            }
                        }
                    }
                }
            }

            if (Ammo_Low)
            {
                if (ammo_low_count < ammo_low_threshold)
                {
                    ammo_low_count++;
                }
                else
                {
                    ammo_low_count = 0;
                    debugEcho("Ammo Low!", "Ammo Low! Some weapons cannot autoload because there is no spare ammo!");
                }
            }

            TO_LOAD.Clear();
        }


    }
}
