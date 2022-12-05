using System;

namespace Factory
{
    public static class IItemFactory
    {
        public static Interface.IItemContainer CreateIItemContainer()
        {
            return new Data.ItemDAL();
        }
    }
}
