using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public struct AddonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Charges { get; set; }
        public double ConsumptionRate { get; set; }
        public double SelfHealSpeed { get; set; }
        public double HealSpeed { get; set; }
        public double RepairSpeed { get; set; }
        public double SaboSpeed { get; set; }
        public double BlindDuration { get; set; }
        public double BlindSpeed { get; set; }
        public double BeamRange { get; set; }
        public double BeamAngle { get; set; }
        public double Aurarange { get; set; }
        public byte[] Icon { get; set; }

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
