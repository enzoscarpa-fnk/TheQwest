namespace JDR.Models
{
    
    public enum WeaponType {sword, axe, mace}
    public enum MaterialWeapon {wooden, stone, bone, metal, golden}

    public class Weapon : Item
    {
        public MaterialWeapon MaterialType {get; set; }
        public WeaponType WeaponType {get; set; }
        public MaterialWeapon MaterialRandom {get; set; }
        // public int damageBonus {get; private set; }
        private double haste;
        public double Haste
        {
            get { return haste; }
            set { haste = Math.Round(value, 2); }
        }
        
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = Math.Round(value, 2); }
        }
        
        
        private static Random random = new Random();

        public Weapon(Hero hero,
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
            ArmorBonus = armorBonus;
            DamageBonus = damageBonus;
            CriticalChanceBonus = criticalChanceBonus;
            HasteBonus = hasteBonus;
            DodgeBonus = dodgeBonus;
            MaterialRandom = MaterialChance(hero.Level);
            MaterialType = MaterialRandom;
            WeaponType = SetWeaponType();
        }

        // Random weapon type selection
        private WeaponType SetWeaponType()
        {
            int roll = random.Next(1, 4);
            WeaponType weaponType;

            switch (roll)
            {
                case 1:
                    weaponType = WeaponType.sword;
                    SetAttributes(MaterialType);
                    Haste *= 0.6;
                    Weight *= 0.1;
                    break;

                case 2:
                    weaponType = WeaponType.axe;
                    SetAttributes(MaterialType);
                    Haste *= 0.4;
                    Weight *= 0.3;
                    break;

                case 3:
                    weaponType = WeaponType.mace;
                    SetAttributes(MaterialType);
                    Haste *= 0.5;
                    Weight *= 0.2;
                    break;

                default:
                throw new ArgumentOutOfRangeException(nameof(weaponType), "Error: Invalid weapon type.");
            }
            return weaponType;
        }

        // Random material type selection
        public MaterialWeapon MaterialChance(int level)
        {
            int roll = random.Next(1, 100);

            switch(level)
            {
                case 1: // Niveau 1
                    if (roll <= 70) return MaterialWeapon.wooden;    // 70% wooden
                    if (roll <= 87) return MaterialWeapon.stone;  // 17% stone
                    if (roll <= 95) return MaterialWeapon.bone;      // 8% bone
                    if (roll <= 99) return MaterialWeapon.metal;   // 4% metal
                    return MaterialWeapon.golden;                     // 1% golden

                case 2: // Niveau 2
                    if (roll <= 50) return MaterialWeapon.wooden;    // 50% wooden
                    if (roll <= 75) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 90) return MaterialWeapon.bone;      // 15% bone
                    if (roll <= 98) return MaterialWeapon.metal;   // 8% metal
                    return MaterialWeapon.golden;                     // 2% golden

                case 3: // Niveau 3
                    if (roll <= 40) return MaterialWeapon.wooden;    // 40% wooden
                    if (roll <= 65) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 85) return MaterialWeapon.bone;      // 20% bone
                    if (roll <= 95) return MaterialWeapon.metal;   // 10% metal
                    return MaterialWeapon.golden;                     // 5% golden

                case 4: // Niveau 4
                    if (roll <= 30) return MaterialWeapon.wooden;    // 30% wooden
                    if (roll <= 55) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 75) return MaterialWeapon.bone;      // 20% bone
                    if (roll <= 90) return MaterialWeapon.metal;   // 15% metal
                    return MaterialWeapon.golden;                     // 10% golden

                case 5: // Niveau 5
                    if (roll <= 20) return MaterialWeapon.wooden;    // 20% wooden
                    if (roll <= 45) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 65) return MaterialWeapon.bone;      // 20% bone
                    if (roll <= 85) return MaterialWeapon.metal;   // 20% metal
                    return MaterialWeapon.golden;                     // 15% golden

                case 6: // Niveau 6
                    if (roll <= 10) return MaterialWeapon.wooden;    // 10% wooden
                    if (roll <= 30) return MaterialWeapon.stone;  // 20% stone
                    if (roll <= 55) return MaterialWeapon.bone;      // 25% bone
                    if (roll <= 80) return MaterialWeapon.metal;   // 25% metal
                    return MaterialWeapon.golden;                     // 20% golden

                case >= 7: // Niveau 7 et plus
                    if (roll <= 5) return MaterialWeapon.wooden;     // 5% wooden
                    if (roll <= 20) return MaterialWeapon.stone;  // 15% stone
                    if (roll <= 45) return MaterialWeapon.bone;      // 25% bone
                    if (roll <= 75) return MaterialWeapon.metal;   // 30% metal
                    return MaterialWeapon.golden;                     // 25% golden

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Error: Invalid level.");
            }
        }
        
        // Implementation of weapons' stats from material type
        private void SetAttributes(MaterialWeapon MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialWeapon.wooden: 
                    DamageBonus = random.Next(4,10);
                    Haste = 20;
                    Weight = 2;
                    break;
                
                case MaterialWeapon.stone:
                    DamageBonus = random.Next(10, 16);
                    Haste = 15;
                    Weight = 4;
                    break;

                case MaterialWeapon.bone:
                    DamageBonus = random.Next(16, 21);
                    Haste = 17;
                    Weight = 6;
                    break;
                
                case MaterialWeapon.metal:
                    DamageBonus = random.Next(21, 27);
                    Haste = 13;
                    Weight = 8;
                    break;
                
                case MaterialWeapon.golden:
                    DamageBonus = random.Next(27, 32);
                    Haste = 11;
                    Weight = 10;
                    break;
                
                default:
                    DamageBonus = 1;
                    Haste = 20;
                    Weight = 0;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name}, a {WeaponType} made out of {MaterialType} ! \n" +
            $"Damage : {DamageBonus} | Speed : {Haste} | Weight : {Weight}";
        }
    }
}
