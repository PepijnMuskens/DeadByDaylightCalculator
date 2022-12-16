using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public struct EffectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double HealSpeedMultiplier { get; set; }
        public double ItemEffMultiplier { get; set; }
        public double ChargesMultiplier { get; set; }
        public double SaboSpeedMultiplier { get; set; }
        public double RepairSpeedMultiplier { get; set; }
        public int Stacks { get; set; }
        public bool KillerEffect { get; set; }
        public string Condition { get; set; }
    }
}
