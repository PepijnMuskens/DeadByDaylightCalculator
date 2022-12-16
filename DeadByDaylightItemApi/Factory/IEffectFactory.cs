using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public static class IEffectFactory
    {
       public static Interface.IEffectContainer CreateEffectContainer()
        {
            return new Data.EffectDAL();
        } 
    }
}
