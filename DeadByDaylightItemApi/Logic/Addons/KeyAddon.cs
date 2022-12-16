using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class KeyAddon : Addon
    {
        public double AuraRange { get; set; }

        public KeyAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            AuraRange = addonDTO.Aurarange;
        }
    }
}
    