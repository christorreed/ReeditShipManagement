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
        // Torpedo Launchers -----------------------------------------------------------------

        private double ACTUAL_TORPs = 0;
        private int INIT_TORPs = 0;
        private double INTEGRITY_TORPs = 0;

        private void iterateTorpedoes()
        {
            ACTUAL_TORPs = 0;

            foreach (IMyTerminalBlock Torp in TORPs)
            {
                if (Torp != null && Torp.IsFunctional)
                {
                    ACTUAL_TORPs++;

                    // turn torps on for 1+ on [0]
                    (Torp as IMyConveyorSorter).Enabled = STANCES[S][0] > 0;

                    // autoloading is complex for torpedoes.
                    if (AUTOLOAD)
                    {
                        // basic are we full check.
                        if (!inventorySomewhatFull(Torp))
                            TO_LOAD.Add(Torp);

                        // get active ammo.
                        string AmmoType = WC_PB_API.GetActiveAmmo(Torp, 0);
                        string OutputAmmoType = getOutputAmmoType(AmmoType);
                        IMyInventory WeapInv = Torp.GetInventory();

                        if (D) Echo("Launcher " + Torp.CustomName + " needs " + OutputAmmoType);

                        // iterate all ITEMS
                        foreach (ITEM Item in ITEMS)
                        {
                            if (Item.IS_TORP)
                            {
                                //if (D) Echo("Checking for " + Item.NAME);

                                // this counts torps in launchers.
                                int Count = WeapInv.GetItemAmount(Item.TYPE).ToIntSafe();
                                // this adds torp inventory to our torp inventory counts
                                Item.COUNT += Count;

                                // this is the right ammo type for this torp
                                if (Item.TYPE.SubtypeId == OutputAmmoType)
                                {
                                    Item.ARMED_IN.Add(WeapInv);
                                }

                                // this torp shouldn't be there
                                // so we unload it.
                                else if (Count > 0)
                                {
                                    if (D) Echo("Attempting to unload " + Count + "x " + Item.TYPE.SubtypeId + " from " + Torp.CustomName + "...");

                                    List<MyInventoryItem> Items = new List<MyInventoryItem>();
                                    WeapInv.GetItems(Items);

                                    foreach (MyInventoryItem InvItem in Items)
                                    {
                                        if (InvItem.ToString().Contains(Item.TYPE.SubtypeId))
                                        {
                                            foreach (IMyInventory CargoInv in INVENTORIEs)
                                            {
                                                bool Success = CargoInv.TransferItemFrom(WeapInv, InvItem, Count);
                                                if (Success)
                                                {
                                                    if (WeapInv.GetItemAmount(Item.TYPE).ToIntSafe() < 1)
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            INTEGRITY_TORPs = Math.Round(100 * (ACTUAL_TORPs / INIT_TORPs));
        }

        private void setTorpedoes(int state)
        {
            foreach (IMyTerminalBlock Torp in TORPs)
            {
                if (Torp != null & Torp.IsFunctional)
                {
                    // state
                    // 0: torpedoes; 0: off, 1: on;
                    if (state == 0)
                    {
                        (Torp as IMyConveyorSorter).Enabled = false;
                    }
                    else
                    {
                        (Torp as IMyConveyorSorter).Enabled = true;

                        if (AUTO_CONFIG_WEAPs)
                        {
                            Torp.SetValue("WC_FocusFire", true);
                            Torp.SetValue("WC_Grids", true);
                            Torp.SetValue("WC_LargeGrid", true);
                            Torp.SetValue("WC_SmallGrid", false);
                            Torp.SetValue("WC_FocusFire", true);
                            Torp.SetValue("WC_SubSystems", true);
                            setBlockRepelOff(Torp);
                        }
                    }
                }
            }
        }
    }
}
