using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public enum Type
    {
        Medkit,
        Toolbox,
        Flashlight,
        Key,
        Map
    }
    public struct ItemDTO
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
    }
}
