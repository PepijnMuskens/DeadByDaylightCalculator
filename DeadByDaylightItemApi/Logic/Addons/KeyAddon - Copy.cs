using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class MapAddon : Addon
    {
        public double AuraRange { get; set; }

        public MapAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            AuraRange = addonDTO.Aurarange;
        }
    }
}
    