using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Medkit : Item
    {
        public double SelfHealSpeed { get; set; }
        public double HealSpeed { get; set; }

        public Medkit(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            SelfHealSpeed = itemDTO.SelfHealSpeed;
            HealSpeed = itemDTO.HealSpeed;
        }
    }
}
