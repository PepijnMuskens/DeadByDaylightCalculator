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
    }
}
