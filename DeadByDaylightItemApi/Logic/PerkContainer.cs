using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PerkContainer
    {
        public List<Perk> Perks { get; private set; }
        private Interface.IPerkContainer IPerkContainer;

        public PerkContainer()
        {
            IPerkContainer = Factory.IPerkFactory.CreateIPerkContainer();
            Perks = new List<Perk>();
            GetAllPerks();
        }

        private void GetAllPerks()
        {
            foreach(Interface.PerkDTO perkdto in IPerkContainer.GetAllPerks())
            {
                Perks.Add(new Perk(perkdto));
            }
        }
    }
}
