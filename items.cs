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
        class ITEM
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
        }

        private List<ITEM> ITEMS = new List<ITEM>();

        private void buildItemsList()
        {
            try
            {
                // this order is important, don't change it.

                ITEMS.Add(buildItem("Fusion F ", "MyObjectBuilder_Ingot", "FusionFuel", true)); //0
                ITEMS.Add(buildItem("Fuel Tank", "MyObjectBuilder_Component", "Fuel_Tank")); //1
                ITEMS.Add(buildItem("Jerry Can", "MyObjectBuilder_Component", "SG_Fuel_Tank")); //2

                ITEMS.Add(buildItem("PDC      ", "MyObjectBuilder_AmmoMagazine", "40mmLeadSteelPDCBoxMagazine", true)); //3
                ITEMS.Add(buildItem("PDC Tefl ", "MyObjectBuilder_AmmoMagazine", "40mmTungstenTeflonPDCBoxMagazine", true)); //4

                ITEMS.Add(buildItem("220 Torp ", "MyObjectBuilder_AmmoMagazine", "220mmExplosiveTorpedoMagazine", true, true)); //5
                ITEMS.Add(buildItem("220 MCRN ", "MyObjectBuilder_AmmoMagazine", "220mmMCRNTorpedoMagazine", true, true)); //6
                ITEMS.Add(buildItem("220 MCRN ", "MyObjectBuilder_AmmoMagazine", "220mmUNNTorpedoMagazine", true, true)); //7
                ITEMS.Add(buildItem("RS Torp  ", "MyObjectBuilder_AmmoMagazine", "RamshackleTorpedoMagazine", true, true)); //8
                ITEMS.Add(buildItem("LRS Torp ", "MyObjectBuilder_AmmoMagazine", "LargeRamshackleTorpedoMagazine", true, true)); //9

                ITEMS.Add(buildItem("120mm RG ", "MyObjectBuilder_AmmoMagazine", "120mmLeadSteelSlugMagazine", true)); //10
                ITEMS.Add(buildItem("Dawson   ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugUNNMagazine", true)); //11
                ITEMS.Add(buildItem("Stiletto ", "MyObjectBuilder_AmmoMagazine", "100mmTungstenUraniumSlugMCRNMagazine", true)); //12
                ITEMS.Add(buildItem("80mm     ", "MyObjectBuilder_AmmoMagazine", "80mmTungstenUraniumSabotMagazine", true)); //13

                ITEMS.Add(buildItem("Foehammr ", "MyObjectBuilder_AmmoMagazine", "120mmTungstenUraniumSlugMCRNMagazine", true)); //14
                ITEMS.Add(buildItem("Farren   ", "MyObjectBuilder_AmmoMagazine", "120mmTungstenUraniumSlugUNNMagazine", true)); //15

                ITEMS.Add(buildItem("Kess     ", "MyObjectBuilder_AmmoMagazine", "180mmLeadSteelSabotMagazine", true)); //16

                ITEMS.Add(buildItem("Steel Pla", "MyObjectBuilder_Component", "SteelPlate")); //17
            }
            catch (Exception ex)
            {
                Echo("Failed to build item lists!");
                Echo(ex.Message);
                return;
            }
        }

        private void iterateItems()
        {
            // first we have to clear the old component counts
            foreach (ITEM Item in ITEMS)
            {
                Item.COUNT = 0;
                Item.STORED_IN.Clear();

                // torps are harder because they can change ammo type.
                if (Item.IS_TORP)
                    Item.ARMED_IN.Clear();

                // count PDCs, Railgun inventories for ammo.
                if (Item.AMMO && !Item.IS_TORP)
                {
                    foreach (IMyInventory WeapInv in Item.ARMED_IN)
                    {
                        Item.COUNT += WeapInv.GetItemAmount(Item.TYPE).ToIntSafe();
                    }
                }

                foreach (IMyInventory Inventory in INVENTORIEs)
                {
                    try
                    {
                        int Count = Inventory.GetItemAmount(Item.TYPE).ToIntSafe();
                        if (Count > 0)
                        {
                            Item.STORED_IN.Add(Inventory);
                            Item.COUNT += Count;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (D)
                        {
                            Echo("Failed to check an inventory!");
                            Echo(ex.Message);
                        }
                    }
                }
            }
        }

        private void initItems()
        {
            // set current item counts as the target.
            foreach (ITEM Item in ITEMS)
            {
                Item.TARGET = Item.COUNT;
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

        void loadInventory(IMyTerminalBlock ToLoad, List<IMyInventory> SourceInventories, string ItemType, int ItemCount)
        {

            if (D) Echo("Loading block " + ToLoad.CustomName + " with item type " + ItemType + " from " + SourceInventories.Count + " sources.");

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

            if (D) Echo("Loading failed.");
        }
    }
}
