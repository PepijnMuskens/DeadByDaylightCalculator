using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class FlashlightAddon : Addon
    {
        public double BlindDuration { get; set; }
        public double BlindSpeed { get; set; }
        public double BeamRange { get; set; }
        public double BeamAngle { get; set; }

        public FlashlightAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            BlindDuration = addonDTO.BlindDuration;
            BlindSpeed = addonDTO.BlindSpeed;
            BeamRange = addonDTO.BeamRange;
            BeamAngle = addonDTO.BeamAngle;
        }
    }
}
    