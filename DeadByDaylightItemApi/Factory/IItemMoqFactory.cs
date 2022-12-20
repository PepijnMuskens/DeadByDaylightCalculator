using System;

namespace Factory
{
    public static class IItemMoqFactory
    {
        public static Interface.IItemContainer CreateIItemContainer()
        {
            return new Data.ItemDALMoq();
        }
    }
}
