using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Perk
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double SelfHealSpeedMultiplier { get; private set; }
        public double HealSpeedMultiplier { get; private set; }
        public double MedkitEffMultiplier { get; private set; }
        public double ItemEffMultiplier { get; private set; }
        public double ChargesMultiplier { get; private set; }
        public double SaboSpeedMultiplier { get; private set; }
        public double RepairSpeedMultiplier { get; private set; }
        public int AuraRange { get; private set; }
        public int TimeWasted { get; private set; }
        public int Stacks { get; private set; }
        public string Condition { get; private set; }

        public Perk(Interface.PerkDTO perkDTO)
        {
            Id = perkDTO.Id;
            Name = perkDTO.Name;
            HealSpeedMultiplier = perkDTO.HealSpeedMultiplier;
            SelfHealSpeedMultiplier = perkDTO.SelfHealSpeedMultiplier;
            MedkitEffMultiplier = perkDTO.MedkitEffMultiplier;
            ItemEffMultiplier = perkDTO.ItemEffMultiplier;
            ChargesMultiplier = perkDTO.ChargesMultiplier;
            SaboSpeedMultiplier = perkDTO.SaboSpeedMultiplier;
            RepairSpeedMultiplier = perkDTO.RepairSpeedMultiplier;
            AuraRange = perkDTO.AuraRange;
            TimeWasted = perkDTO.TimeWasted;
            Stacks = perkDTO.Stacks;
            Condition = perkDTO.Condition;
        }
    }
}
