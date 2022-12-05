using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Items
{
    public class Flashlight : Item
    {
        public double BlindDuration { get; set; }
        public double BlindSpeed { get; set; }
        public double BeamRange { get; set; }
        public double BeamAngle { get; set; }

        public Flashlight(Interface.ItemDTO itemDTO) : base(itemDTO)
        {
            BlindDuration = itemDTO.BlindDuration;
            BlindSpeed = itemDTO.BlindSpeed;
            BeamRange = itemDTO.BeamRange;
            BeamAngle = itemDTO.BeamAngle;
        } 
    }
}
