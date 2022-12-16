using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Toolbox : Item
    {
        public double repairSpeed { get; set; }
        public double saboSpeed { get; set; }

        public Toolbox(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            repairSpeed = itemDTO.RepairSpeed;
            saboSpeed = itemDTO.SaboSpeed;
        }
    }
}
