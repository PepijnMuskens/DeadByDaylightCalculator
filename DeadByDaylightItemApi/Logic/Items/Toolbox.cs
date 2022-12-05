using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Toolbox : Item
    {
        public double RepairSpeed { get; set; }
        public double SaboSpeed { get; set; }

        public Toolbox(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            RepairSpeed = itemDTO.RepairSpeed;
            SaboSpeed = itemDTO.SaboSpeed;
        }
    }
}
