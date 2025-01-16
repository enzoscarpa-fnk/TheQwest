namespace JDR.Models
{

    public enum MaterialArmor {cloth, leather, wooden, metal, golden}

    public class Armor : Item
    {
        public MaterialArmor MaterialType {get; set; }
        public int Weight {get; private set; }
        public MaterialArmor MaterialRandom {get; set; }
        
        private static Random random = new Random();

        public Armor (Hero hero,
                    string name,
                    int staminaBonus,
                    int strengthBonus,
                    int intellectBonus,
                    int agilityBonus,
                    int spiritBonus,
                    int armorBonus,
                    int damageBonus,
                    int criticalChanceBonus,
                    int hasteBonus,
                    int dodgeBonus)
                    : base(name)
        {
            Name = name;
            StaminaBonus = staminaBonus;
            StrengthBonus = strengthBonus;
            IntellectBonus = intellectBonus;
            AgilityBonus = agilityBonus;
            SpiritBonus = spiritBonus;
            base.ArmorBonus = armorBonus;
            DamageBonus = damageBonus;
            CriticalChanceBonus = criticalChanceBonus;
            HasteBonus = hasteBonus;
            DodgeBonus = dodgeBonus;
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            SetAttributes(MaterialType);
        }

        // Random material type selection
        public MaterialArmor MaterialChance(int level)
        {
            int roll = random.Next(1, 100);

            switch(level)
            {
                case 1: // Niveau 1
                    if (roll <= 70) return MaterialArmor.cloth;    // 70% cloth
                    if (roll <= 87) return MaterialArmor.leather;     // 17% leather
                    if (roll <= 95) return MaterialArmor.wooden;     // 8% wooden
                    if (roll <= 99) return MaterialArmor.metal;    // 4% metal
                    return MaterialArmor.golden;                      // 1% golden

                case 2: // Niveau 2
                    if (roll <= 50) return MaterialArmor.cloth;    // 50% tissu
                    if (roll <= 75) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 90) return MaterialArmor.wooden;     // 15% wooden
                    if (roll <= 98) return MaterialArmor.metal;    // 8% metal
                    return MaterialArmor.golden;                      // 2% golden

                case 3: // Niveau 3
                    if (roll <= 40) return MaterialArmor.cloth;    // 40% cloth
                    if (roll <= 65) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 85) return MaterialArmor.wooden;     // 20% wooden
                    if (roll <= 95) return MaterialArmor.metal;    // 10% metal
                    return MaterialArmor.golden;                      // 5% golden

                case 4: // Niveau 4
                    if (roll <= 30) return MaterialArmor.cloth;    // 30% cloth
                    if (roll <= 55) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 75) return MaterialArmor.wooden;     // 20% wooden
                    if (roll <= 90) return MaterialArmor.metal;    // 15% metal
                    return MaterialArmor.golden;                      // 10% golden

                case 5: // Niveau 5
                    if (roll <= 20) return MaterialArmor.cloth;    // 20% cloth
                    if (roll <= 45) return MaterialArmor.leather;     // 25% leather
                    if (roll <= 65) return MaterialArmor.wooden;     // 20% wooden
                    if (roll <= 85) return MaterialArmor.metal;    // 20% metal
                    return MaterialArmor.golden;                      // 15% golden

                case 6: // Niveau 6
                    if (roll <= 10) return MaterialArmor.cloth;    // 10% cloth
                    if (roll <= 30) return MaterialArmor.leather;     // 20% leather
                    if (roll <= 55) return MaterialArmor.wooden;     // 25% wooden
                    if (roll <= 80) return MaterialArmor.metal;    // 25% metal
                    return MaterialArmor.golden;                      // 20% golden

                case >= 7: // Niveau 7 et plus
                    if (roll <= 5) return MaterialArmor.cloth;     // 5% cloth
                    if (roll <= 20) return MaterialArmor.leather;     // 15% leather
                    if (roll <= 45) return MaterialArmor.wooden;     // 25% wooden
                    if (roll <= 75) return MaterialArmor.metal;    // 30% metal
                    return MaterialArmor.golden;                      // 25% golden

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Error: Invalid level.");
            }
        }
        private void SetAttributes(MaterialArmor MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialArmor.cloth:
                    ArmorBonus = random.Next(4, 10);
                    Weight = 2;
                    break;
                
                case MaterialArmor.leather:
                    ArmorBonus = random.Next(10, 16);
                    Weight = 4;
                    break;

                case MaterialArmor.wooden:
                    ArmorBonus = random.Next(16, 21);
                    Weight = 6;
                    break;
                
                case MaterialArmor.metal:
                    ArmorBonus = random.Next(21, 27);
                    Weight = 8;
                    break;
                
                case MaterialArmor.golden:
                    ArmorBonus = random.Next(27, 32);
                    Weight = 10;
                    break;
                
                default:
                    ArmorBonus = 1;
                    Weight = 0;
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Name}, made out of {MaterialType} ! \n" +
            $"Defense : {ArmorBonus} | Weight : {Weight}";
        }
    }
}
