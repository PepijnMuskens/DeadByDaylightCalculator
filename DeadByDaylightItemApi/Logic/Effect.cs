using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Effect
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double HealSpeedMultiplier { get; private set; }
        public double ItemEffMultiplier { get; private set; }
        public double ChargesMultiplier { get; private set; }
        public double SaboSpeedMultiplier { get; private set; }
        public double RepairSpeedMultiplier { get; private set; }
        public bool KillerEffect { get; private set; }
        public int Stacks { get; private set; }
        public string Condition { get; private set; }

        public Effect(Interface.EffectDTO effectDTO)
        {
            Id = effectDTO.Id;
            Name = effectDTO.Name;
            HealSpeedMultiplier = effectDTO.HealSpeedMultiplier;
            ItemEffMultiplier = effectDTO.ItemEffMultiplier;
            ChargesMultiplier = effectDTO.ChargesMultiplier;
            SaboSpeedMultiplier = effectDTO.SaboSpeedMultiplier;
            RepairSpeedMultiplier = effectDTO.RepairSpeedMultiplier;
            Stacks = effectDTO.Stacks;
            KillerEffect = effectDTO.KillerEffect;
            Condition = effectDTO.Condition;
        }
    }
}
