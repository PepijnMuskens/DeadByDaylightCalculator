using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ItemContainer
    {
        public List<Item> Items;
        private Interface.IItemContainer IItemContainer;

        public ItemContainer()
        {
            Items = new List<Item>();
            IItemContainer = Factory.IItemFactory.CreateIItemContainer();
            GetAllItems();
        }

        public Items.Medkit GetMedkitByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == name && Items[i].Type.ToString() == "Medkit")
                {
                    return (Logic.Items.Medkit)Items[i];
                }
            }
            return null;
        }
        public Items.Toolbox GetToolboxByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == name && Items[i].Type.ToString() == "Toolbox")
                {
                    return (Items.Toolbox)Items[i];
                }
            }
            return null;
        }
        public Items.Flashlight GetFlashlightByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == name && Items[i].Type.ToString() == "Flashlight")
                {
                    return (Logic.Items.Flashlight)Items[i];
                }
            }
            return null;
        }
        public Items.Key GetKeyByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == name && Items[i].Type.ToString() == "Key")
                {
                    return (Logic.Items.Key)Items[i];
                }
            }
            return null;
        }
        public Items.Map GetMapByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == name && Items[i].Type.ToString() == "Map")
                {
                    return (Logic.Items.Map)Items[i];
                }
            }
            return null;
        }
        public List<Item> GetAllItems()
        {
            Items.Clear();
            foreach (Interface.ItemDTO itemDTO in IItemContainer.GetAllItems())
            {
                switch (itemDTO.Type.ToString())
                {
                    case "Medkit":
                        Items.Add(new Items.Medkit(itemDTO));
                        break;
                    case "Toolbox":
                        Items.Add(new Items.Toolbox(itemDTO));
                        break;
                    case "Flashlight":
                        Items.Add(new Items.Flashlight(itemDTO));
                        break;
                    case "Key":
                        Items.Add(new Items.Key(itemDTO));
                        break;
                    case "Map":
                        Items.Add(new Items.Map(itemDTO));
                        break;
                }
            }
            return Items;
        }
    }
}
