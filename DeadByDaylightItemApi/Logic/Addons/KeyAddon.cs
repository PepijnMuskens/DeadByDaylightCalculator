using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class KeyAddon : Addon
    {
        public double auraRange { get; set; }

        public KeyAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            auraRange = addonDTO.Aurarange;
        }
    }
}
    