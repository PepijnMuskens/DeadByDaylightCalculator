using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IItemContainer
    {
        public List<ItemDTO> GetAllItems();
        public List<ItemDTO> GetAllItems(string type);

    }
}
