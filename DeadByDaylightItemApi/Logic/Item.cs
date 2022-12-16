using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public Interface.Type type { get; set; }
        public int charges { get; set; }
        public double consumptionRate { get; set; }
        public byte[] icon { get; private set; }
        public Item(Interface.ItemDTO itemDTO)
        {
            id = itemDTO.Id;
            icon = itemDTO.Icon;
            name = itemDTO.Name;
            type = itemDTO.Type;
            charges = itemDTO.Charges;
            consumptionRate = itemDTO.ConsumptionRate;
        }
    }
}
