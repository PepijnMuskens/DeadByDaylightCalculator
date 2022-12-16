using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Map : Item
    {
        public double Aurarange { get; set; }

        public Map(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            Aurarange = itemDTO.Aurarange;
        }
    }
}
