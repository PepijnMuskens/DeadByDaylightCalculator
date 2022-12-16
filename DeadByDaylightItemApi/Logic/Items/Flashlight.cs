using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Flashlight : Item
    {
        public double blindDuration { get; set; }
        public double blindSpeed { get; set; }
        public double beamRange { get; set; }
        public double beamAngle { get; set; }

        public Flashlight(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            blindDuration = itemDTO.BlindDuration;
            blindSpeed = itemDTO.BlindSpeed;
            beamRange = itemDTO.BeamRange;
            beamAngle = itemDTO.BeamAngle;
        } 
    }
}
