using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Addon
    {
        public int id { get; private set; }
        public string name { get; set; }
        public Interface.Type type { get; set; }
        public int charges { get; set; }
        public double consumptionRate { get; set; }
        public byte[] icon { get; set; }

        public Addon(Interface.AddonDTO addonDTO)
        {
            id = addonDTO.Id;
            name = addonDTO.Name;
            type = addonDTO.Type;
            charges = addonDTO.Charges;
            consumptionRate = addonDTO.ConsumptionRate;
            icon = addonDTO.Icon;
        }
    }
}
