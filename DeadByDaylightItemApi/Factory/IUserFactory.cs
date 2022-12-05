using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public static class IUserFactory
    {
        public static Interface.IUeser CreateIUser()
        {
            return new Data.UserDAL();
        }

        public static Interface.IUserContainer CreateIUserContainer()
        {
            return new Data.UserDAL();
        }
    }
}
