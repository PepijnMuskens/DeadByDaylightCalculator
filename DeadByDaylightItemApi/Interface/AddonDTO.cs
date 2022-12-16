using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public struct AddonDTO
    {
        public int Id;
        public string Name;
        public Type Type;
        public int Charges;
        public double ConsumptionRate;
        public double SelfHealSpeed;
        public double HealSpeed;
        public double RepairSpeed;
        public double SaboSpeed;
        public double BlindDuration;
        public double BlindSpeed;
        public double BeamRange;
        public double BeamAngle;
        public double Aurarange;
        public byte[] Icon;
        
        public AddonDTO(Type type)
        {
            Id = 0;
            Name = "";
            Type = type;
            Charges = 0;
            ConsumptionRate = 0;
            SelfHealSpeed = 0;
            HealSpeed = 0;
            RepairSpeed = 0;
            SaboSpeed = 0;
            BlindDuration = 0;
            BlindSpeed = 0;
            BeamRange = 0;
            BeamAngle = 0;
            Aurarange = 0;
            Icon = null;
        }
    }

}
