using Logic.Addons;
using Logic.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Logic
{
    public class Loadout
    {
        public Item Item { get; set; }
        public Addon[] Addons { get; set; }

        public double TimeSave { get; private set;}
        public double Charges { get; private set;}

        //medkit
        public double Heals { get; private set; }
        public double TimeToHeal { get; private set; }
        public double TimeToSelfHeal { get; private set; }
        public double TimeSaveSelfHeal { get; private set; }

        //toolbox
        public double TimetoSabo { get; private set; }
        public double NrOfSabo { get; private set; }
        public double TimeSaveRepair { get; private set; }
        public double RepairDuration { get; private set; }
        public double RepairSpeed { get; private set; }


        //flashlight
        public double BeamRange { get; private set; }
        public double BeamWidth { get; private set; }
        public double Duration { get; private set; }
        public double NrOfBlinds { get; private set; }
        public double BlindDuration { get; private set; }


        public string Info { get; set; }

        public Loadout()
        {
            Item = new Item(new Interface.ItemDTO());
            Addons = new Addon[2];
        }

        public void Update()
        {
            if (Item != null)
            {
                if (Addons[0] == null) Addons[0] = new Addon(new Interface.AddonDTO());
                if (Addons[1] == null) Addons[1] = new Addon(new Interface.AddonDTO());
                Charges = Item.charges;
                foreach (Addon addon in Addons)
                {
                    Charges += addon.charges;
                }
                switch (Item.type.ToString())
                {
                    case "Medkit":
                        Medkit medkit = (Medkit)Item;
                        MedkitAddon addon1 = Addons[0].id == 0 ? new MedkitAddon(new Interface.AddonDTO()) : (MedkitAddon)Addons[0];
                        MedkitAddon addon2 = Addons[1].id == 0 ? new MedkitAddon(new Interface.AddonDTO()) : (MedkitAddon)Addons[1];

                        Heals = Charges / 16;
                        TimeToHeal = 16 / (medkit.healSpeed + addon1.healSpeed + addon2.healSpeed);
                        TimeToSelfHeal = 16 / (medkit.selfHealSpeed + addon1.selfHealSpeed + addon2.selfHealSpeed);
                        TimeSave = Heals * (16 - TimeToHeal);
                        TimeSaveSelfHeal = Heals * (32 - TimeToSelfHeal);
                        
                        break;
                    case "Toolbox":
                        Toolbox toolbox = (Toolbox)Item;
                        ToolboxAddon taddon1 = Addons[0].id == 0 ? new ToolboxAddon(new Interface.AddonDTO()) : (ToolboxAddon)Addons[0];
                        ToolboxAddon taddon2 = Addons[1].id == 0 ? new ToolboxAddon(new Interface.AddonDTO()) : (ToolboxAddon)Addons[1];

                        NrOfSabo = Charges / 6;
                        TimetoSabo = 6 / (toolbox.saboSpeed * (1+taddon1.saboSpeed + taddon2.saboSpeed));
                        RepairSpeed = toolbox.repairSpeed + taddon1.repairSpeed + taddon2.repairSpeed;
                        RepairDuration = Charges / RepairSpeed;
                        TimeSaveRepair = Charges - RepairDuration;

                        break;
                    case "Flashlight":
                        Flashlight flashlight = (Flashlight)Item;
                        FlashlightAddon faddon1 = Addons[0].id == 0 ? new FlashlightAddon(new Interface.AddonDTO()) : (FlashlightAddon)Addons[0];
                        FlashlightAddon faddon2 = Addons[1].id == 0 ? new FlashlightAddon(new Interface.AddonDTO()) : (FlashlightAddon)Addons[1];
                        
                        BeamRange = flashlight.beamRange * (faddon1.beamRange + faddon2.beamRange + 1);
                        BeamWidth = flashlight.beamAngle * (faddon1.beamAngle + faddon2.beamAngle + 1);
                        Duration = Charges / (flashlight.consumptionRate - faddon1.consumptionRate - faddon2.consumptionRate);
                        BlindDuration = flashlight.blindDuration * (faddon1.blindDuration + faddon2.blindDuration + 1);
                        NrOfBlinds = Duration / 1.2;

                        break;
                    case "Key":
                        break;
                    case "Map":
                        break;    
                }
            }
            
        }
    }
}
