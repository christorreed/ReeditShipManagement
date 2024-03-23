using Sandbox.Game;
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
using VRage.Network;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {

        class INVENTORY
        {
            // the block in question
            public IMyTerminalBlock Block { get; set; }

            // the block's inventory
            public IMyInventory Inv { get; set; }

            // the result of GetItems.
            List <MyInventoryItem> Items = new List<MyInventoryItem>();

            // how many of this item are in this block
            public int Qty = 0;

            // does this block require autoloading?
            public bool AutoLoad = false;

            // if so, does it require it, like... now?
            //public bool LowAmmo = false;

            // if it does, how full is it?
            public float FillFactor;

        }

        class ITEM
        {
            // the total number of this item we have on the ship
            public int ActualQty = 0;

            // the target value, set at init.
            public int InitQty = 0;

            // qty of items that are stored in cargo containers, not autoloaded blocks.
            public int SpareQty = 0;

            // The percentage of this item we have on board compared to init.
            public double Percentage;

            // list of inventories where this item might be found.
            public List<INVENTORY> Inventories = new List<INVENTORY>();

            // list of temp inventories where this item might be found.
            // for example, torp launchers
            // will be in different places depending on selected ammo type.
            // so need to be rebuilt more frequently.
            public List<INVENTORY> TempInventories = new List<INVENTORY>();

            // the type of item
            public MyItemType Type;

            // does this a torpedo?
            public bool IsTorp = false;

            // does this a ammo other than a torpedo
            public bool IsAmmo = false;

            // name as it appears on the LCD
            public string LcdName;

        }

        // the items list.
        private List<ITEM> ITEMS = new List<ITEM>();

        // key: LcdName
        // value: ITEM
        //Dictionary<string, ITEM> ITEMS = new Dictionary<string, ITEM>();

        /*class ITEM
        {
            public string NAME = "";
            public int TARGET = 0;
            public int COUNT = 0;
            public MyItemType TYPE;
            public double PERCENTAGE;
            public List<IMyInventory> STORED_IN = new List<IMyInventory>();
            public bool AMMO = false;
            public bool IS_TORP = false;
            public bool AMMO_LOW = false;
            public List<IMyInventory> ARMED_IN = new List<IMyInventory>();
        }

        ITEM buildItem(string LCDName, string SubTypeID, string TypeID, bool Ammo = false, bool Torp = false)
        {
            ITEM NewItem = new ITEM();
            NewItem.NAME = LCDName;
            NewItem.TYPE = new MyItemType(SubTypeID, TypeID);
            NewItem.IS_TORP = Torp;
            return NewItem;
        }*/

        //private List<ITEM> ITEMS = new List<ITEM>();



        void addInventory(IMyTerminalBlock b, int item = 99)
        {
            // item 99 is a container, could be storing anything...
            if (item == 99)
            {
                // so add it to aaallll the lists...
                foreach (var Item in ITEMS)
                {
                    INVENTORY Inv = new INVENTORY();

                    Inv.Block = b;
                    Inv.Inv = b.GetInventory();

                    Item.Inventories.Add(Inv);
                }
            }

            // otherwise it's storing this thing in particular...
            else
            {
                INVENTORY Inv = new INVENTORY();

                Inv.Block = b;
                Inv.Inv = b.GetInventory();

                // that means we want to autoload it
                // i mean, if we are autoloading in general.
                Inv.AutoLoad = AUTOLOAD;

                // and add it to that item's list only
                ITEMS[item].Inventories.Add(Inv);
            }
        }

        void addTempInventory(IMyTerminalBlock b, int item)
        {
            INVENTORY Inv = new INVENTORY();

            Inv.Block = b;
            Inv.Inv = b.GetInventory();

            // this is a torp
            // we want to autoload it
            // i mean, if we are autoloading in general.
            Inv.AutoLoad = AUTOLOAD;

            // and add it to that item's list only
            ITEMS[item].TempInventories.Add(Inv);
        }

        void buildItem(
        string LcdName,
        string SubTypeID,
        string TypeID,
        bool  IsAmmo = false,
        bool IsTorp = false
        )
        {
            ITEM Item = new ITEM();
            Item.Type = new MyItemType(SubTypeID, TypeID);
            Item.IsAmmo = IsAmmo;
            Item.IsTorp = IsTorp;
            Item.LcdName = LcdName;
            ITEMS.Add(Item);
        }

        private void buildItemsList()
        {
            try
            {
                // this order is important, don't change it.

                buildItem("Fusion F ", "MyObjectBuilder_Ingot", "FusionFuel", true); //0
                buildItem("Fuel Tank", "MyObjectBuilder_Component", "Fuel_Tank"); //1
                buildItem("Jerry Can", "MyObjectBuilder_Component", "SG_Fuel_Tank"); //2

                buildItem("PDC      ", "MyObjectBuilder_AmmoMagazine", "40mmLeadSteelPDCBoxMagazine", true); //3
                buildItem("PDC Tefl ", "MyObjectBuilder_AmmoMagazine", "40mmTungstenTeflonPDCBoxMagazine", true); //4

                buildItem("220 Torp ", "MyObjectBuilder_AmmoMagazine", "220mmExplosiveTorpedoMagazine", true, true); //5
                buildItem("220 MCRN ", "MyObjectBuilder_AmmoMagazine", "220mmMCRNTorpedoMagazine", true, true); //6
                buildItem("220 UNN  ", "MyObjectBuilder_AmmoMagazine", "220mmUNNTorpedoMagazine", true, true); //7
                buildItem("RS Torp  ", "MyObjectBuilder_AmmoMagazine", "RamshackleTorpedoMagazine", true, true); //8
                buildItem("LRS Torp ", "MyObjectBuilder_AmmoMagazine", "LargeRamshackleTorpedoMagazine", true, true); //9

                buildItem("120mm RG ", "MyObjectBuilder_AmmoMagazine", "120mmLeadSteelSlugMagazine", true); //10
                buildItem("Dawson   ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugUNNMagazine", true); //11
                buildItem("Stiletto ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugMCRNMagazine", true); //12
                buildItem("80mm     ", "MyObjectBuilder_AmmoMagazine", "80mmTungstenUraniumSabotMagazine", true); //13

                buildItem("Foehammr ", "MyObjectBuilder_AmmoMagazine", "120mmTungstenUraniumSlugMCRNMagazine", true); //14
                buildItem("Farren   ", "MyObjectBuilder_AmmoMagazine", "120mmTungstenUraniumSlugUNNMagazine", true); //15

                buildItem("Kess     ", "MyObjectBuilder_AmmoMagazine", "180mmLeadSteelSabotMagazine", true); //16

                buildItem("Steel Pla", "MyObjectBuilder_Component", "SteelPlate"); //17
            }
            catch (Exception ex)
            {
                Echo("Failed to build item lists!");
                Echo(ex.Message);
                return;
            }
        }

        void clearTempInventories()
        {
            foreach (var Item in ITEMS)
            {
                Item.TempInventories.Clear();
            }
        }

        private void refreshItems()
        {
          
            foreach (var Item in ITEMS)
            {
                // clear item qty values
                Item.ActualQty = 0;
                Item.SpareQty = 0;

                // include temp inventories as well
                // like torps which change ammo type
                List<INVENTORY> CombinedInventories = Item.Inventories.Concat(Item.TempInventories).ToList();

                //if (_d) Echo("Checking " + Item.LcdName);

                // check them all.
                foreach (INVENTORY Inv in CombinedInventories)
                {
                    Inv.Qty = Inv.Inv.GetItemAmount(Item.Type).ToIntSafe();
                    Item.ActualQty += Inv.Qty;

                    //if (D && Inv.Qty > 0) Echo(Inv.Block.CustomName + " contains " + Inv.Qty);

                    if (Inv.AutoLoad)
                    {
                        // this inventory needs to be loaded (ie is a weapon or a reactor)
                        // and autoload in general is also on.

                        Inv.FillFactor = Inv.Inv.VolumeFillFactor;
                        //if (_d) Echo(Inv.Block.CustomName + " VFF = " + Inv.FillFactor);
                    }
                    else
                    {
                        // this inventory is a cargo container
                        Item.SpareQty += Inv.Qty;
                    }
                }
            }
        }

        private void initItems()
        {
            // set current item counts as the target.
            foreach (ITEM Item in ITEMS)
            {
                Item.InitQty = Item.ActualQty;
            }
        }

        int sortAmmoType(string AmmoType)
        {
            switch (AmmoType)
            {
                case "220mm Explosive Torpedo":
                    return 5;

                case "MCRN Torpedo High Spread":
                case "MCRN Torpedo Low Spread":
                    return 6;

                case "UNN Torpedo High Spread":
                case "UNN Torpedo Low Spread":
                    return 7;

                case "40mm Tungsten-Teflon Ammo":
                    return 4;

                case "40mm Lead-Steel PDC Box Ammo":
                    return 4;

                case "Ramshackle Torpedo Magazine":
                    return 8;

                case "120mm Lead-Steel Slug Ammo":
                    return 10;

                case "100mm Tungsten-Uranium Slug UNN Ammo":
                    return 7;

                case "100mm Tungsten-Uranium Slug MCRN Ammo":
                    return 6;

                case "80mm Tungsten-Uranium Sabot Ammo":
                    return 13;

                case "120mm Tungsten-Uranium Slug MCRN Ammo":
                    return 14;

                case "120mm Tungsten-Uranium Slug UNN Ammo":
                    return 15;

                case "180mm Lead-Steel Sabot Ammo":
                    return 16;

                default:
                    if (_d) Echo("Unknown AmmoType = " + AmmoType);
                    return 99;

            }
        }

        bool inventorySomewhatFull(IMyTerminalBlock Block) // is a block's inventory > 95% full.
        {
            if (Block == null) return false;
            IMyInventory thisInventory = Block.GetInventory();
            return thisInventory.CurrentVolume.RawValue > (thisInventory.MaxVolume.RawValue * 0.95);
        }

        bool inventoryEmpty(IMyTerminalBlock Block) // is a block's inventory totally empty
        {
            IMyInventory thisInventory = Block.GetInventory();
            return thisInventory.VolumeFillFactor == 0;
        }

        void loadInventories(List<INVENTORY> LoadFrom, List<INVENTORY> LoadTo, MyItemType Type, int Average = -1)
        {
            if (_d) Echo("Loading " + LoadTo.Count + " inventories from " + LoadFrom.Count + " sources.");

            foreach (INVENTORY ToInv in LoadTo)
            {
                // how many from inventories to try for this to.
                int Retries = 3;

                //if (_d) Echo("Loading " + ToInv.Block.CustomName);

                foreach (INVENTORY FromInv in LoadFrom)
                {
                    //if (_d) Echo("Checking  " + FromInv.Block.CustomName + "\nRetries = " + Retries);

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
                        //if (_d) Echo("This is " + InvItem.Type.SubtypeId);

                        // make sure it's the right item, and there's some in there.
                        if (InvItem.Type == Type)
                        {
                            //if (_d) Echo("Found ammo type " + Type.SubtypeId);
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

                            if (_d) Echo("Loading success = " + Success);

                            break;
                        }
                    }
                }
            }
        }

        /*
        void loadInventory(IMyTerminalBlock ToLoad, List<IMyInventory> SourceInventories, string ItemType, int ItemCount)
        {

            if (_d) Echo("Loading block " + ToLoad.CustomName + " with item type " + ItemType + " from " + SourceInventories.Count + " sources.");

            IMyInventory ToLoadInventory = ToLoad.GetInventory();

            foreach (IMyInventory Source in SourceInventories)
            {
                try
                {
                    List<MyInventoryItem> Items = new List<MyInventoryItem>();
                    Source.GetItems(Items);

                    foreach (MyInventoryItem Item in Items)
                    {
                        if (Item.ToString().Contains(ItemType))
                        {
                            bool success = ToLoadInventory.TransferItemFrom(Source, Item, ItemCount);
                            if (success) return;
                        }
                    }
                }
                catch { }
            }

            if (_d) Echo("Loading failed.");
        }
        */
    }
}
