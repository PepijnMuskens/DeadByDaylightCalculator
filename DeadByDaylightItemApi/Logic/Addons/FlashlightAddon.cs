using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class FlashlightAddon : Addon
    {
        public double blindDuration { get; set; }
        public double blindSpeed { get; set; }
        public double beamRange { get; set; }
        public double beamAngle { get; set; }

        public FlashlightAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            blindDuration = addonDTO.BlindDuration;
            blindSpeed = addonDTO.BlindSpeed;
            beamRange = addonDTO.BeamRange;
            beamAngle = addonDTO.BeamAngle;
        }
    }
}
    