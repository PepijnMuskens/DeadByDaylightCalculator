using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Interface.Type Type { get; set; }
        public int Charges { get; set; }
        public double ConsumptionRate { get; set; }
        public byte[] Icon { get; private set; }
        public Item(Interface.ItemDTO itemDTO)
        {
            Id = itemDTO.Id;
            Icon = itemDTO.Icon;
            Name = itemDTO.Name;
            Type = itemDTO.Type;
            Charges = itemDTO.Charges;
            ConsumptionRate = itemDTO.ConsumptionRate;
        }
    }
}
