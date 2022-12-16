using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IUeser
    {
        public ItemDTO AddItem(int  itemId, int userId);
        public void RemoveItem(int userid, int itemid);
        public List<ItemDTO> GetAllItems(int userid);
        public AddonDTO AddAddon(int itemId, int userId);
        public void RemoveAddon(int userid, int addonod);
        public List<AddonDTO> GetAllAddons(int userid);
        public int Update(UserDTO userDTO);
    }
}
