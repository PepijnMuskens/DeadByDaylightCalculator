using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Key : Item
    {
        public double Aurarange { get; set; }

        public Key(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            Aurarange = itemDTO.Aurarange;
        }
    }
}
