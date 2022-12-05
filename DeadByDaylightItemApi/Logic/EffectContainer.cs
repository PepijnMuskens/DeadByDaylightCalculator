using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class EffectContainer
    {
        public List<Effect> Effects { get; set; }
        public Interface.IEffectContainer IEffectContainer { get; private set; }

        public EffectContainer()
        {
            IEffectContainer = Factory.IEffectFactory.CreateEffectContainer();
            Effects = new List<Effect>();
            GetAllEffects();
        }
        private void GetAllEffects()
        {
            foreach (Interface.EffectDTO effectDTO in IEffectContainer.GetAllEffects())
            {
                Effects.Add(new Effect(effectDTO));
            }
        }
    }
}
