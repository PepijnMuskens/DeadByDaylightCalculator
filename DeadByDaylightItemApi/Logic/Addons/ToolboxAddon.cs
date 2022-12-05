using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Addons
{
    public class ToolboxAddon : Addon
    {
        public double RepairSpeed { get; set; }
        public double SaboSpeed { get; set; }

        public ToolboxAddon(Interface.AddonDTO addonDTO) : base(addonDTO)
        {
            RepairSpeed = addonDTO.RepairSpeed;
            SaboSpeed = addonDTO.SaboSpeed;
        }
    }
}
    