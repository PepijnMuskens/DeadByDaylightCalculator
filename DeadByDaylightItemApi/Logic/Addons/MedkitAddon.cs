using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class MedkitAddon : Addon
    {
        public double healSpeed { get; set; }
        public double selfHealSpeed { get; set; }

        public MedkitAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            healSpeed = addonDTO.HealSpeed;
            selfHealSpeed = addonDTO.SelfHealSpeed;
        }
    }
}
    