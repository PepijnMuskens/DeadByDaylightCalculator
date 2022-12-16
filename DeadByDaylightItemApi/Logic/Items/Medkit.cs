using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Medkit : Item
    {
        public double selfHealSpeed { get; set; }
        public double healSpeed { get; set; }

        public Medkit(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            selfHealSpeed = itemDTO.SelfHealSpeed;
            healSpeed = itemDTO.HealSpeed;
        }
    }
}
