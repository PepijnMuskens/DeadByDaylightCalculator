using Interface;
using Logic.Addons;
using Logic.Items;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Type = Interface.Type;

namespace Logic
{
    public static class Calculator
    {
        private static ItemContainer ItemContainer = new ItemContainer();
        public static List<Item> Items = ItemContainer.GetAllItems();

        private static AddonContainer AddonContainer = new AddonContainer();
        public static List<Addon> Addons = AddonContainer.GetAllAddons();


        public static Loadout GetLongestDuration(Type type)
        {
            List<Item> items = Items.FindAll(i => i.type == type);
            List<Addon> addons = Addons.FindAll(a => a.type == type);
            return GetLongestDuration(items, addons);
        }

        public static Loadout GetLongestDuration(int itemid)
        {
            Item item = Items.Find(i => i.id == itemid);
            List<Item> items = Items.FindAll(i => i.id == item.id);
            List<Addon> addons = Addons.FindAll(a => a.type == item.type);
            return GetLongestDuration(items, addons);
        }

        private static Loadout GetLongestDuration(List<Item> items, List<Addon> addons)
        {
            Loadout loadout = new Loadout();
            double charges = 0;

            foreach (Item item in items)
            {
                foreach (Addon addon1 in addons)
                {
                    foreach (Addon addon2 in addons)
                    {
                        if (addon1 != addon2)
                        {
                            double temp = (item.charges + addon1.charges + addon2.charges) * (item.consumptionRate + addon1.consumptionRate + addon2.consumptionRate);
                            if (temp > charges)
                            {
                                charges = temp;
                                loadout.Item = item;
                                loadout.Addons[0] = addon1;
                                loadout.Addons[1] = addon2;
                            }
                        }
                    }
                }
            }
            return loadout;
        }

        public static Loadout GetMostTimeSaved(Type type)
        {
            List<Item> items = Items.FindAll(i => i.type == type);
            List<Addon> addons = Addons.FindAll(a => a.type == type);
            return GetMostTimeSaved(items, addons);
        }

        public static Loadout GetMostTimeSaved(int itemid)
        {
            Item item = Items.Find(i => i.id == itemid);
            List<Item> items = Items.FindAll(i => i.id == item.id);
            List<Addon> addons = Addons.FindAll(a => a.type == item.type);
            return GetMostTimeSaved(items, addons);
        }

        private static Loadout GetMostTimeSaved(List<Item> items, List<Addon> addons)
        {
            Loadout loadout = new Loadout();
            double most = 0;
            foreach (Item item in items)
            {
                Toolbox toolbox = (Toolbox)item;
                foreach (Addon addon1 in addons)
                {
                    ToolboxAddon taddon1 = addon1.id == 0 ? new ToolboxAddon(new Interface.AddonDTO()) : (ToolboxAddon)addon1;
                    foreach (Addon addon2 in addons)
                    {
                        ToolboxAddon taddon2 = addon2.id == 0 ? new ToolboxAddon(new Interface.AddonDTO()) : (ToolboxAddon)addon2;
                        if (addon1 != addon2)
                        {
                            double Charges = (item.charges + addon1.charges + addon2.charges) * (item.consumptionRate + addon1.consumptionRate + addon2.consumptionRate);
                            double RepairSpeed = toolbox.repairSpeed + taddon1.repairSpeed + taddon2.repairSpeed;
                            double RepairDuration = Charges / RepairSpeed;
                            double TimeSaveRepair = Charges - RepairDuration;
                            if (TimeSaveRepair > most)
                            {
                                most = TimeSaveRepair;
                                loadout.Item = item;
                                loadout.Addons[0] = addon1;
                                loadout.Addons[1] = addon2;
                            }
                        }
                    }
                }
            }
            return loadout;
        }
    }
}
