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

        string _ammoCritical = "";

        void runAutoLoad()
        {

            if (!_autoLoad) return;

            if (_d) Echo("Running autoload...");

            _ammoCritical = "";

            foreach (var Item in _items)
            {
                // if this item isn't ammo, we don't need to do anything.
                if (!Item.IsTorp && !Item.IsAmmo) continue;

                if (_d) Echo("Checking " + Item.LcdName);

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

                bool ammoCritical = false;

                foreach (INVENTORY Inv in CombinedInventories)
                {
                    if (Inv == null) continue;

                    if (Inv.AutoLoad)
                    {
                        // this block needs loading
                        //if (_d) Echo(Inv.Block.CustomName + " VFF = " + Inv.FillFactor);

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
                        else if(!ammoCritical && Item.SpareQty == 0)
                        {
                            // we have no spare ammo
                            // and this gun is empty.
                            ammoCritical = true;
                        }
                    }
                    else
                    {
                        // this block is a container
                        if (Inv.Qty > 0)
                        {
                            // if (_d) Echo("Adding " + Inv.Block.CustomName + " as a source.");
                            LoadFrom.Add(Inv);
                        }
                    }
                }

                if (ammoCritical)
                {
                    if (_ammoCritical != "") _ammoCritical += "\n";
                    _ammoCritical += Item.Type.SubtypeId;
                }

                if (LoadTo.Count > 0)
                {
                    // calculate average qty
                    int IntQty = (int)(AverageQty / AutoloadCount);

                    /*if (_d) Echo("Average qty = " + IntQty +
                        "\nNeed loading count = " + LoadTo.Count +
                        "\nSpare qty = " + Item.SpareQty);*/

                    // at least some blocks require autoloading.

                    // this should order the list
                    // emptest first, fullest last.
                    LoadTo = LoadTo.OrderBy(a => a.Qty).ToList();

                    if (Item.SpareQty > 0)
                    {
                        if (_d) Echo("Loading " + Item.Type.SubtypeId + "...");

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

                        if (_d) Echo("Balancing " + Item.Type.SubtypeId + "...");

                        // this should order the list
                        // fullest first, emptiest last.
                        BalanceFrom = BalanceFrom.OrderByDescending(a => a.Qty).ToList();

                        loadInventories(BalanceFrom, LoadTo, Item.Type, IntQty);

                    }
                }
                else
                {
                    if (_d) Echo("No loading required " + Item.Type.SubtypeId + "...");
                }
            }
        }
    }
}
