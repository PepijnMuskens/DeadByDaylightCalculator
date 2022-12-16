using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class ToolboxAddon : Addon
    {
        public double repairSpeed { get; set; }
        public double saboSpeed { get; set; }

        public ToolboxAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            repairSpeed = addonDTO.RepairSpeed;
            saboSpeed = addonDTO.SaboSpeed;
        }
    }
}
    