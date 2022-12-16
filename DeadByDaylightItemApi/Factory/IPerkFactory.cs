using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public static class IPerkFactory
    {
        public static Interface.IPerkContainer CreateIPerkContainer()
        {
            return new Data.PerkDAL();
        }
    }
}
