using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public static class IAddonMoqFacory
    {
        public static Interface.IAddonContainer CreateIAddonContainer()
        {
            return new Data.AddonDALMoq();
        }
    }
}
