using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
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
        List<IMyTerminalBlock> TO_LOAD = new List<IMyTerminalBlock>();
        List<IMyTerminalBlock> TO_BALANCE_LOAD = new List<IMyTerminalBlock>();

        string MISSING_AMMO = "";

        void manageAutoload()
        {

            if (!AUTOLOAD) return;

            if (D) Echo("Managing Autoload, " + TO_LOAD.Count + " weapons to be loaded...");

            MISSING_AMMO = "";

            foreach (IMyTerminalBlock Weapon in TO_LOAD)
            {

                string AmmoType = "FusionFuel";
                string OutputAmmoType = "FusionFuel";

                if (Weapon.BlockDefinition.ToString().Split('/')[0] != "MyObjectBuilder_Reactor")
                {
                    AmmoType = WC_PB_API.GetActiveAmmo(Weapon, 0);
                    OutputAmmoType = getOutputAmmoType(AmmoType);
                }




                foreach (ITEM Item in ITEMS)
                {
                    //if (D) Echo("Checking " + Item.TYPE.SubtypeId);

                    if (Item.TYPE.SubtypeId == OutputAmmoType) // this is the correct item for this ammo type.
                    {
                        if (Item.STORED_IN.Count > 0) // there are inventories where this item is stored.
                        {
                            Item.AMMO_LOW = false;
                            loadInventory(Weapon, Item.STORED_IN, OutputAmmoType, 99);
                        }
                        else // there arne't any inventories where this item is stored.
                        {
                            // this will prevent overflowing ammo names from causing double ups here
                            // by truncating to 32 chars
                            if (AmmoType.Length > 32)
                                AmmoType = AmmoType.Substring(0, 32);

                            if (!MISSING_AMMO.Contains(AmmoType) && AmmoType != "FusionFuel")
                            {
                                if (MISSING_AMMO != "") MISSING_AMMO += "\n";
                                MISSING_AMMO += AmmoType;
                            }

                            if (Item.ARMED_IN.Count > 0)
                                Item.AMMO_LOW = true;

                        }
                        break;
                    }
                }
            }

            foreach (ITEM Item in ITEMS)
            {
                if (Item.AMMO_LOW)
                {

                    if (D) Echo(Item.NAME + " requires inventory balancing...");

                    // okay for this item, we have no ammo in cargo
                    // so it's time to start attempting to balance.

                    // 
                    //Item.ARMED_IN = Item.ARMED_IN.OrderBy(a => a.VolumeFillFactor).ToList();

                    int Count = 0;

                    List<IMyInventory> LoadMe = new List<IMyInventory>();
                    List<IMyInventory> LoadFromMe = new List<IMyInventory> ();

                    foreach (IMyInventory WeapInv in Item.ARMED_IN)
                    {
                        Count += WeapInv.GetItemAmount(Item.TYPE).ToIntSafe();
                    }

                    // this is the average ammo count
                    // so ideally we want all weapons to have this much ammo.
                    int Average = Count / Item.ARMED_IN.Count;

                    // now figure out which ones need what treatment...
                    foreach (IMyInventory WeapInv in Item.ARMED_IN)
                    {
                        int ThisInvCount = WeapInv.GetItemAmount(Item.TYPE).ToIntSafe();
                        if (ThisInvCount > Average)
                            LoadFromMe.Add(WeapInv);
                        else
                            // this bit adds a 10% wiggle room
                            // so it doesn't loop constantly
                            // and chills out once we're close to balanced.
                            if (ThisInvCount < (Average * .9))
                                LoadMe.Add(WeapInv);
                    }

                    // sort the LoadFromMe list
                    // so we pull from the full ones first.
                    Item.ARMED_IN = Item.ARMED_IN.OrderBy(a => a.VolumeFillFactor).ToList();

                    // load me like one of your french girls
                    foreach (IMyInventory Load in LoadMe)
                    {
                        foreach (IMyInventory LoadFrom in LoadFromMe)
                        {
                            int LoadCount = Load.GetItemAmount(Item.TYPE).ToIntSafe();

                            // this one is already loaded
                            if (LoadCount >= Average) break;

                            int LoadFromCount = LoadFrom.GetItemAmount(Item.TYPE).ToIntSafe();

                            int ToShare = LoadFromCount - Average;

                            // this LoadFrom has no more spares
                            if (LoadFromCount <= Average) break;

                            // don't load more than the average
                            int NumberToLoad = Average - LoadCount;

                            // don't load more than the LoadFrom has spare.
                            if (NumberToLoad > ToShare) NumberToLoad = ToShare;

                            if (D) Echo(
                                Item.NAME + 
                                "\n - LoadCount:" + LoadCount + 
                                "\n - LoadFromCount:" + LoadFromCount + 
                                "\n - ToLoad: " + NumberToLoad);

                            Load.TransferItemFrom(LoadFrom, 0, 0, true, NumberToLoad);

                        }
                    }
                }
            }

            TO_LOAD.Clear();
        }

        string getOutputAmmoType(string AmmoType)
        {
            switch (AmmoType)
            {
                case "220mm Explosive Torpedo":
                    return "220mmExplosiveTorpedoMagazine";
                    

                case "MCRN Torpedo High Spread":
                case "MCRN Torpedo Low Spread":
                    return "220mmMCRNTorpedoMagazine";

                case "UNN Torpedo High Spread":
                case "UNN Torpedo Low Spread":
                    return "220mmUNNTorpedoMagazine";

                case "40mm Tungsten-Teflon Ammo":
                    return "40mmTungstenTeflonPDCBoxMagazine";

                case "40mm Lead-Steel PDC Box Ammo":
                    return "40mmLeadSteelPDCBoxMagazine";

                case "Ramshackle Torpedo Magazine":
                    return "RamshackleTorpedoMagazine";

                case "120mm Lead-Steel Slug Ammo":
                    return "120mmLeadSteelSlugMagazine";

                case "100mm Tungsten-Uranium Slug UNN Ammo":
                    return "100mmTungstenUraniumSlugUNNMagazine";

                case "100mm Tungsten-Uranium Slug MCRN Ammo":
                    return "100mmTungstenUraniumSlugMCRNMagazine";

                case "80mm Tungsten-Uranium Sabot Ammo":
                    return "80mmTungstenUraniumSabotMagazine";

                case "120mm Tungsten-Uranium Slug MCRN Ammo":
                    return "120mmTungstenUraniumSlugMCRNMagazine";

                case "120mm Tungsten-Uranium Slug UNN Ammo":
                    return "120mmTungstenUraniumSlugUNNMagazine";

                case "180mm Lead-Steel Sabot Ammo":
                    return "180mmLeadSteelSabotMagazine";

                default:
                    if (D) Echo("Unknown AmmoType = " + AmmoType);
                    return "";

            }
        }


    }
}
