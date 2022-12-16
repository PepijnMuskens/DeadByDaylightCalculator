using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class MapAddon : Addon
    {
        //test
        public double auraRange { get; set; }

        public MapAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            auraRange = addonDTO.Aurarange;
        }
    }
}
    