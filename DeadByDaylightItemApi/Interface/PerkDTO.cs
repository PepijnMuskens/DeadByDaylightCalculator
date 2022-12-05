using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public struct PerkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SelfHealSpeedMultiplier { get; set; }
        public double HealSpeedMultiplier { get; set; }
        public double MedkitEffMultiplier { get; set; }
        public double ItemEffMultiplier { get; set; }
        public double ChargesMultiplier { get; set; }
        public double SaboSpeedMultiplier { get; set; }
        public double RepairSpeedMultiplier { get; set; }
        public int AuraRange { get; set; }
        public int TimeWasted { get; set; }
        public int Stacks { get; set; }
        public string Condition { get; set; }
    }
}
