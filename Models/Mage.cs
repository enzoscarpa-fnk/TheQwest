using System;
using System.Threading.Tasks;

namespace JDR.Models
{
    public class Mage : Hero
    {
        public Mage(
            string characterName,
            LevelProgression progression,
            int level = 1,
            int experienceValue = 0,
            int energyValue = 13,
            int armorValue = 2,
            int bonusDamage = 0,
            int criticalChance = 2,
            int hasteRating = 15,
            int dodgeRating = 15
            ) : base(characterName, progression)
        {
            Level = level;
            ExperienceValue = experienceValue;
            CurrentEnergyValue = energyValue;
            ArmorValue = armorValue;
            BonusDamage = bonusDamage;
            CriticalChance = criticalChance;
            HasteValue = hasteRating;
            DodgeRating = dodgeRating;
            InitializeStats();
        }

        // Initializes stats
        private void InitializeStats()
        {
            Stamina = StatsCalculator.CalculateStat(8, 1.27, Level);
            Strength = StatsCalculator.CalculateStat(1, 1.05, Level);
            Intellect = StatsCalculator.CalculateStat(4, 1.27, Level);
            Agility = StatsCalculator.CalculateStat(1, 1.05, Level);
            Spirit = StatsCalculator.CalculateStat(7, 1.27, Level);
            MaxHealthValue = Stamina * 4;
            MaxEnergyValue = (int)Math.Floor(13 * Spirit * 0.6);
            AttackValue = (int)Math.Floor(Intellect * 1.8);
            if (Level == 1) // First initialization
            {
                CurrentHealthValue = MaxHealthValue;
                CurrentEnergyValue = MaxEnergyValue;
            }
        }
    
        // Overrides the base LevelUp method to update the stats
        protected override void LevelUp()
        {
            base.LevelUp();
            int previousMaxHealthValue = MaxHealthValue;
            int previousMaxEnergyValue = MaxEnergyValue;
            InitializeStats(); // Updates stats after level up
            
            // Adjust CurrentXXXValue proportionally to the increase in MaxXXXValue
            CurrentHealthValue += MaxHealthValue - previousMaxHealthValue;
            CurrentEnergyValue += MaxEnergyValue - previousMaxEnergyValue;

            // Ensure CurrentXXXValue does not exceed MaxXXXValue
            if (CurrentHealthValue > MaxHealthValue)
                CurrentHealthValue = MaxHealthValue;
            
            if (CurrentEnergyValue > MaxEnergyValue)
                CurrentEnergyValue = MaxEnergyValue;
        }
    
        // The base attack
        public override void BaseAttack(Character target, Action restartGameAction)
        {
            if (target.CurrentHealthValue == 0) { return; }
            
            if (target.Dodge())
            {
                Console.WriteLine($"{target.Name} dodged {Name}'s attack !");
            }
            else
            {
                int baseDamage = AttackValue - target.ArmorValue;
                int damage = baseDamage <= 0 ? 0 : baseDamage;

                int calculatedDamage = CriticalHit(damage, out bool isCritical);

                string message = isCritical ? "Critical hit! " : "";
                message += $"Base attack from {Name} dealt {calculatedDamage} damage to {target.Name}.";

                Console.WriteLine(message);
        
                target.TakeDamage(calculatedDamage, this, restartGameAction);
            }
        }

        // Low tier spell
        public override bool LowTierAttack(Character target, Action restartGameAction)
        {
            if (target.CurrentHealthValue == 0 || CurrentEnergyValue < 6)
            {
                Console.WriteLine("Not enough Mana");
                return false;
            }
            
            if (target.Dodge())
            {
                Console.WriteLine($"{target.Name} dodged {Name}'s attack !");
                return true;
            }
       
            CurrentEnergyValue -= 6;
            int baseDamage = (int)Math.Round((AttackValue - target.ArmorValue) * 2.4);
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            int calculatedDamage = CriticalHit(damage, out bool isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Frost Spikes from {Name} dealt {calculatedDamage} damage to {target.Name}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
            return true;
        }

        // Mid tier spell
        public override bool MidTierAttack(Character target, Action refreshUI)
        {
            if (target.CurrentHealthValue == 0 || CurrentEnergyValue < 4)
            {
                Console.WriteLine("Not enough Mana");
                return false;
            }

            CurrentEnergyValue -= 14;
            int originalArmorValue = target.ArmorValue;
            target.ArmorValue *= 4;

            Console.WriteLine($"{target.Name} casts Arcane Shield! Armor value increased temporarily.");
            refreshUI?.Invoke();  // Forces the UI to refresh after casting the spell

            // Delay before stat returns to original value
            // await Task.Delay(4000);

            target.ArmorValue = originalArmorValue;
            Console.WriteLine($"{target.Name}'s Arcane Shield has worn off. Armor value returns to normal.");
            refreshUI?.Invoke();  // Forces the UI to refresh after the spell has no more effect
            return true;
        }

        // Ultimate spell
        public override bool UltimateAttack(Character target, Action restartGameAction)
        {
        
            if (target.CurrentHealthValue == 0 || CurrentEnergyValue < 18)
            {
                Console.WriteLine("Not enough Mana");
                return false;
            }
            
            if (target.Dodge())
            {
                Console.WriteLine($"{target.Name} dodged {Name}'s attack !");
                return true;
            }

            CurrentEnergyValue -= 26;
            int baseDamage = (int)Math.Round((AttackValue - target.ArmorValue) * 6.9);
            int damage = baseDamage <= 0 ? 0 : baseDamage;
        
            int calculatedDamage = CriticalHit(damage, out bool isCritical);
        
            string message = isCritical ? "Critical hit! " : "";
            message += $"Meteor Blast from {Name} dealt {calculatedDamage} damage to {target.Name}.";

            Console.WriteLine(message);
        
            target.TakeDamage(calculatedDamage, this, restartGameAction);
            return true;
        }
    }
}