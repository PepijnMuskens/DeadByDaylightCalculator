using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IAddonContainer
    {
        public List<AddonDTO> GetAllAddons();
    }
}
