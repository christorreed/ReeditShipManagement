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

        void runAutoLoad()
        {

            if (!AUTOLOAD) return;

            if (D) Echo("Running autoload...");

            foreach (var Item in ITEMS)
            {
                // if this item isn't ammo, we don't need to do anything.
                if (!Item.IsTorp && !Item.IsAmmo) continue;

                if (D) Echo("Checking " + Item.LcdName);

                // include temp inventories as well
                // like torps which change ammo type
                List<INVENTORY> CombinedInventories = Item.Inventories.Concat(Item.TempInventories).ToList();

                // to and from inv lists
                List<INVENTORY> LoadFrom = new List<INVENTORY>();
                List<INVENTORY> BalanceFrom = new List<INVENTORY>();
                List<INVENTORY> LoadTo = new List<INVENTORY>();

                // we need average for balancing.
                int AverageQty = 0;
                int AutoloadCount = 0;

                foreach (INVENTORY Inv in CombinedInventories)
                {
                    if (Inv == null) continue;

                    if (Inv.AutoLoad)
                    {
                        // this block needs loading
                        //if (D) Echo(Inv.Block.CustomName + " VFF = " + Inv.FillFactor);

                        AutoloadCount++;
                        AverageQty += Inv.Qty;


                        // if ammo isn't full
                        if (Inv.FillFactor < 0.95)
                        {
                            // we could use auto loading
                            LoadTo.Add(Inv);
                        }

                        // if we're anything other than totally empty
                        if (Inv.FillFactor != 0)
                        {
                            // we're eligable as a balance source
                            BalanceFrom.Add(Inv);
                        }
                    }
                    else
                    {
                        // this block is a container
                        if (Inv.Qty > 0)
                        {
                            // if (D) Echo("Adding " + Inv.Block.CustomName + " as a source.");
                            LoadFrom.Add(Inv);
                        }
                    }
                }

                if (LoadTo.Count > 0)
                {
                    // calculate average qty
                    int IntQty = (int)(AverageQty / AutoloadCount);

                    /*if (D) Echo("Average qty = " + IntQty +
                        "\nNeed loading count = " + LoadTo.Count +
                        "\nSpare qty = " + Item.SpareQty);*/

                    // at least some blocks require autoloading.

                    // this should order the list
                    // emptest first, fullest last.
                    LoadTo = LoadTo.OrderBy(a => a.Qty).ToList();

                    if (Item.SpareQty > 0)
                    {
                        if (D) Echo("Loading " + Item.Type.SubtypeId + "...");

                        // we have some ammo in storage at least,
                        // so lets load from cargo.

                        // this should order the list backwards
                        // fullest first, emptest last, 
                        LoadFrom = LoadFrom.OrderByDescending(a => a.Qty).ToList();

                        loadBlocks(LoadFrom, LoadTo, Item.Type);

                    }
                    else
                    {
                        // we have no spare ammo at all,
                        // so we need to balance what we have between weapons

                        if (D) Echo("Balancing " + Item.Type.SubtypeId + "...");

                        // this should order the list
                        // fullest first, emptiest last.
                        BalanceFrom = BalanceFrom.OrderByDescending(a => a.Qty).ToList();

                        loadBlocks(BalanceFrom, LoadTo, Item.Type, IntQty);

                    }
                }
                else
                {
                    if (D) Echo("No loading required " + Item.Type.SubtypeId + "...");
                }

            }

            /*MISSING_AMMO = "";

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
                    LoadFromMe = LoadFromMe.OrderBy(a => a.VolumeFillFactor).ToList();
                    LoadFromMe.Reverse();
                    //Item.ARMED_IN = Item.ARMED_IN.OrderBy(a => a.VolumeFillFactor).ToList();

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

            TO_LOAD.Clear();*/
        }

        void loadBlocks(List<INVENTORY> LoadFrom, List<INVENTORY> LoadTo, MyItemType Type, int Average = -1)
        {
            if (D) Echo("Loading " + LoadTo.Count + " inventories from " + LoadFrom.Count + " sources.");

            foreach (INVENTORY ToInv in LoadTo)
            {
                // how many from inventories to try for this to.
                int Retries = 3;

                //if (D) Echo("Loading " + ToInv.Block.CustomName);

                foreach (INVENTORY FromInv in LoadFrom)
                {
                    //if (D) Echo("Checking  " + FromInv.Block.CustomName + "\nRetries = " + Retries);

                    // we're done with this 
                    if (Retries < 0) break;

                    // if an average value is provided
                    // and this inventory already has at least that much
                    // skip this 
                    // note the .95 modifier, which adds 5% wiggle room
                    // so we don't loop forever.
                    if (Average != -1 && ToInv.Qty >= (Average * .95)) break;

                    // if there is no terminal connection, move onto the next source.
                    if (!ToInv.Inv.IsConnectedTo(FromInv.Inv)) continue;

                    // get the items
                    List<MyInventoryItem> InvItems = new List<MyInventoryItem>();
                    FromInv.Inv.GetItems(InvItems);

                    // iterate the items
                    foreach (MyInventoryItem InvItem in InvItems)
                    {
                        //if (D) Echo("This is " + InvItem.Type.SubtypeId);

                        // make sure it's the right item, and there's some in there.
                        if (InvItem.Type == Type)
                        {
                            //if (D) Echo("Found ammo type " + Type.SubtypeId);
                            // if there's no average provided,
                            // try sending them all, let limits figure it out
                            int Qty = InvItem.Amount.ToIntSafe();

                            // bail if we're to is empty.
                            if (Qty == 0) break;

                            // throttle this a little so we don't go nuts trying everything.
                            Retries--;

                            // if we have an average value provided
                            // it means we want to balance Tos and Froms to target the average value.
                            if (Average != -1)
                            {
                                // if our from has less than the average, bail.
                                if (Qty <= Average)
                                {
                                    break;
                                }

                                // set the transfer amount to the average
                                // less whatever we already have in to.
                                Qty = Average - ToInv.Qty;
                            }

                            // load the item.
                            bool Success = ToInv.Inv.TransferItemFrom
                                (FromInv.Inv, InvItem, Qty);

                            // if this worked, don't attempt to load this block again.
                            if (Success) Retries = -1;

                            if (D) Echo("Loading success = " + Success);

                            break;
                        }
                    }
                }
            }
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
