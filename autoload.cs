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
        //List<IMyTerminalBlock> TO_LOAD = new List<IMyTerminalBlock>();
        //List<IMyTerminalBlock> TO_BALANCE_LOAD = new List<IMyTerminalBlock>();

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

                        loadInventories(LoadFrom, LoadTo, Item.Type);

                    }
                    else
                    {
                        // we have no spare ammo at all,
                        // so we need to balance what we have between weapons

                        if (D) Echo("Balancing " + Item.Type.SubtypeId + "...");

                        // this should order the list
                        // fullest first, emptiest last.
                        BalanceFrom = BalanceFrom.OrderByDescending(a => a.Qty).ToList();

                        loadInventories(BalanceFrom, LoadTo, Item.Type, IntQty);

                    }
                }
                else
                {
                    if (D) Echo("No loading required " + Item.Type.SubtypeId + "...");
                }
            }
        }

        void loadInventories(List<INVENTORY> LoadFrom, List<INVENTORY> LoadTo, MyItemType Type, int Average = -1)
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
    }
}
