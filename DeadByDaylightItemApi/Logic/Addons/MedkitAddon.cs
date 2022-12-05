using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class MedkitAddon : Addon
    {
        public double HealSpeed { get; set; }
        public double SelfHealSpeed { get; set; }

        public MedkitAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            HealSpeed = addonDTO.HealSpeed;
            SelfHealSpeed = addonDTO.SelfHealSpeed;
        }
    }
}
    