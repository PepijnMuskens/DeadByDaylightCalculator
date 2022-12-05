using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public static class IPicFacory
    {
        public static Interface.IPic CreateIPic()
        {
            return new Data.PicDAL();
        }
    }
}
