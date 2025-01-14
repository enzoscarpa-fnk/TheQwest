namespace JDR.Models
{

    public enum MaterialArmor {cloth, leather, wooden, metal, golden}

    public class Armor
    {
        public string Name {get; set; }
        public MaterialArmor MaterialType {get; set; }
        public int BaseDefense {get; private set; }
        public int Weight {get; private set; }
        public MaterialArmor MaterialRandom {get; set; }
        
        private static Random random = new Random();

        public Armor (string name, Hero hero)
        {
            Name = name;
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
                    if (roll <= 70) return MaterialArmor.tissu;    // 70% cloth
                    if (roll <= 87) return MaterialArmor.cuir;     // 17% leather
                    if (roll <= 95) return MaterialArmor.bois;     // 8% wooden
                    if (roll <= 99) return MaterialArmor.métal;    // 4% metal
                    return MaterialArmor.or;                      // 1% golden

                case 2: // Niveau 2
                    if (roll <= 50) return MaterialArmor.tissu;    // 50% tissu
                    if (roll <= 75) return MaterialArmor.cuir;     // 25% leather
                    if (roll <= 90) return MaterialArmor.bois;     // 15% wooden
                    if (roll <= 98) return MaterialArmor.métal;    // 8% metal
                    return MaterialArmor.or;                      // 2% golden

                case 3: // Niveau 3
                    if (roll <= 40) return MaterialArmor.tissu;    // 40% cloth
                    if (roll <= 65) return MaterialArmor.cuir;     // 25% leather
                    if (roll <= 85) return MaterialArmor.bois;     // 20% wooden
                    if (roll <= 95) return MaterialArmor.métal;    // 10% metal
                    return MaterialArmor.or;                      // 5% golden

                case 4: // Niveau 4
                    if (roll <= 30) return MaterialArmor.tissu;    // 30% cloth
                    if (roll <= 55) return MaterialArmor.cuir;     // 25% leather
                    if (roll <= 75) return MaterialArmor.bois;     // 20% wooden
                    if (roll <= 90) return MaterialArmor.métal;    // 15% metal
                    return MaterialArmor.or;                      // 10% golden

                case 5: // Niveau 5
                    if (roll <= 20) return MaterialArmor.tissu;    // 20% cloth
                    if (roll <= 45) return MaterialArmor.cuir;     // 25% leather
                    if (roll <= 65) return MaterialArmor.bois;     // 20% wooden
                    if (roll <= 85) return MaterialArmor.métal;    // 20% metal
                    return MaterialArmor.or;                      // 15% golden

                case 6: // Niveau 6
                    if (roll <= 10) return MaterialArmor.tissu;    // 10% cloth
                    if (roll <= 30) return MaterialArmor.cuir;     // 20% leather
                    if (roll <= 55) return MaterialArmor.bois;     // 25% wooden
                    if (roll <= 80) return MaterialArmor.métal;    // 25% metal
                    return MaterialArmor.or;                      // 20% golden

                case >= 7: // Niveau 7 et plus
                    if (roll <= 5) return MaterialArmor.tissu;     // 5% cloth
                    if (roll <= 20) return MaterialArmor.cuir;     // 15% leather
                    if (roll <= 45) return MaterialArmor.bois;     // 25% wooden
                    if (roll <= 75) return MaterialArmor.métal;    // 30% metal
                    return MaterialArmor.or;                      // 25% golden

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Error: Invalid level !");
            }
        }
        private void SetAttributes(MaterialArmor MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialArmor.tissu:
                    BaseDefense = random.Next(4, 10);
                    Weight = 2;
                    break;
                
                case MaterialArmor.cuir:
                    BaseDefense = random.Next(10, 16);
                    Weight = 4;
                    break;

                case MaterialArmor.bois:
                    BaseDefense = random.Next(16, 21);
                    Weight = 6;
                    break;
                
                case MaterialArmor.métal:
                    BaseDefense = random.Next(21, 27);
                    Weight = 8;
                    break;
                
                case MaterialArmor.or:
                    BaseDefense = random.Next(27, 32);
                    Weight = 10;
                    break;
                
                default:
                    BaseDefense = 1;
                    Weight = 0;
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Name}, made out of {MaterialType} ! \n" +
            $"Defense : {BaseDefense} | Weight : {Weight}";
        }
    }
}
