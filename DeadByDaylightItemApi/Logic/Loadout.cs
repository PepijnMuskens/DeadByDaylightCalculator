using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Loadout
    {
        public Item Item;
        public Addon[] Addons;
        public Perk[] Perks;
        public Effect[] KillerEffects;
        public List<Effect> SurvivorEffects;

        public double TimeSave { get; private set;}
        public double Charges { get; private set;}
        public double Heals { get; private set; }
        public double TimeToHeal { get; private set; }
        public double TimeToSelfHeal { get; private set; }
        public string Info { get; set; }
        private double streetwise;

        public Loadout()
        {
            Item = new Item(new Interface.ItemDTO());
            Addons = new Addon[2];
            Perks = new Perk[4];
            KillerEffects = new Effect[4];
            SurvivorEffects = new List<Effect>();
        }

        public void Update()
        {
            if (Item != null)
            {
                int itemCharges = Item.Charges;
                foreach (Addon addon in Addons)
                {
                    itemCharges += addon.Charges;
                }
                double perkCharges = 1;
                foreach(Perk perk in Perks)
                {
                    perkCharges += perk.ChargesMultiplier;
                    streetwise += perk.ItemEffMultiplier;
                }
                foreach(Effect effect in KillerEffects)
                {
                    
                }
                switch (Item.Type.ToString())
                {
                    case "Medkit":
                        Heals = Charges / 16;
                        double perkHealspeed = 0;
                        double perkSelfHealspeed = 0;
                        foreach (Perk perk in Perks)
                        {
                            perkHealspeed += perk.HealSpeedMultiplier;
                            perkSelfHealspeed += perk.SelfHealSpeedMultiplier;
                        }
                        foreach (Addon addon in Addons)
                        {
                            if(addon.Type.ToString() == "Medkit")
                            {
                                Addon addon1 = (Logic.Addons.MedkitAddon)addon;
                                
                            }
                        }
                        
                        break;
                    case "Toolbox":
                        break;
                    case "Flashlight":
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
