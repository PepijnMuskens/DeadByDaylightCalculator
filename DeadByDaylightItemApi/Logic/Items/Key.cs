using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Key : Item
    {
        public double aurarange { get; set; }

        public Key(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            aurarange = itemDTO.Aurarange;
        }
    }
}
