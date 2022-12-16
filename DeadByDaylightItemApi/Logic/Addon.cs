using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Addon
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public Interface.Type Type { get; set; }
        public int Charges { get; set; }
        public double ConsumptionRate { get; set; }
        public byte[] Icon { get; set; }

        public Addon(Interface.AddonDTO addonDTO)
        {
            Id = addonDTO.Id;
            Name = addonDTO.Name;
            Type = addonDTO.Type;
            Charges = addonDTO.Charges;
            ConsumptionRate = addonDTO.ConsumptionRate;
            Icon = addonDTO.Icon;
        }
    }
}
