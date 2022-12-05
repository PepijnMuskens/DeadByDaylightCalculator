using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AddonContainer
    {
        public List<Addon> Addons;
        private Interface.IAddonContainer IAddonContainer;
        public AddonContainer()
        {
            Addons = new List<Addon>();
            IAddonContainer = Factory.IAddonFacory.CreateIAddonContainer();
            GetAllAddons();
        }

        public Addons.MedkitAddon GetMedkitByName(string name)
        {
            for (int i = 0; i < Addons.Count; i++)
            {
                if (Addons[i].Name == name && Addons[i].Type.ToString() == "Medkit")
                {
                    return (Logic.Addons.MedkitAddon)Addons[i];
                }
            }
            return null;
        }


        private void GetAllAddons()
        {
            foreach (Interface.AddonDTO addonDTO in IAddonContainer.GetAllAddons())
            {
                switch (addonDTO.Type.ToString())
                {
                    case "Medkit":
                        Addons.Add(new Addons.MedkitAddon(addonDTO));
                        break;
                    case "Toolbox":
                        Addons.Add(new Addons.ToolboxAddon(addonDTO));
                        break;
                    case "Flashlight":
                        Addons.Add(new Addons.MedkitAddon(addonDTO));
                        break;
                    case "Key":
                        Addons.Add(new Addons.KeyAddon(addonDTO));
                        break;
                    case "Map":
                        Addons.Add(new Addons.MapAddon(addonDTO));
                        break;

                }

            }
        }
    }
}
