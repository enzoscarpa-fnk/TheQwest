namespace JDR.Models
{
    
    public enum WeaponType {sword, axe, mace}
    public enum MaterialWeapon {wood, stone, bone, metal, gold}

    public class Weapon
    {
        public string Name {get; set; }
        public MaterialWeapon MaterialType {get; set; }
        public WeaponType WeaponType {get; set; }
        public MaterialWeapon MaterialRandom {get; set; }
        public int Damage {get; private set; }
        private double speed;
        public double Speed
        {
            get { return speed; }
            set { speed = Math.Round(value, 2); }
        }
        
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = Math.Round(value, 2); }
        }
        
        
        private static Random random = new Random();

        public Weapon (string name, Hero hero)
        {
            Name = name;
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
                    Speed *= 0.6;
                    Weight *= 0.1;
                    break;

                case 2:
                    weaponType = WeaponType.axe;
                    SetAttributes(MaterialType);
                    Speed *= 0.4;
                    Weight *= 0.3;
                    break;

                case 3:
                    weaponType = WeaponType.mace;
                    SetAttributes(MaterialType);
                    Speed *= 0.5;
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
                    if (roll <= 70) return MaterialWeapon.wood;    // 70% wood
                    if (roll <= 87) return MaterialWeapon.stone;  // 17% stone
                    if (roll <= 95) return MaterialWeapon.bone;      // 8% bone
                    if (roll <= 99) return MaterialWeapon.metal;   // 4% metal
                    return MaterialWeapon.gold;                     // 1% gold

                case 2: // Niveau 2
                    if (roll <= 50) return MaterialWeapon.wood;    // 50% wood
                    if (roll <= 75) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 90) return MaterialWeapon.bone;      // 15% bone
                    if (roll <= 98) return MaterialWeapon.metal;   // 8% metal
                    return MaterialWeapon.gold;                     // 2% gold

                case 3: // Niveau 3
                    if (roll <= 40) return MaterialWeapon.wood;    // 40% wood
                    if (roll <= 65) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 85) return MaterialWeapon.bone;      // 20% bone
                    if (roll <= 95) return MaterialWeapon.metal;   // 10% metal
                    return MaterialWeapon.gold;                     // 5% gold

                case 4: // Niveau 4
                    if (roll <= 30) return MaterialWeapon.wood;    // 30% wood
                    if (roll <= 55) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 75) return MaterialWeapon.bone;      // 20% bone
                    if (roll <= 90) return MaterialWeapon.metal;   // 15% metal
                    return MaterialWeapon.gold;                     // 10% gold

                case 5: // Niveau 5
                    if (roll <= 20) return MaterialWeapon.wood;    // 20% wood
                    if (roll <= 45) return MaterialWeapon.stone;  // 25% stone
                    if (roll <= 65) return MaterialWeapon.bone;      // 20% bone
                    if (roll <= 85) return MaterialWeapon.metal;   // 20% metal
                    return MaterialWeapon.gold;                     // 15% gold
                
                case 6: // Niveau 6
                    if (roll <= 10) return MaterialWeapon.wood;    // 10% wood
                    if (roll <= 30) return MaterialWeapon.stone;  // 20% stone
                    if (roll <= 55) return MaterialWeapon.bone;      // 25% bone
                    if (roll <= 80) return MaterialWeapon.metal;   // 25% metal
                    return MaterialWeapon.gold;                     // 20% gold

                case >= 7: // Niveau 7 et plus
                    if (roll <= 5) return MaterialWeapon.wood;     // 5% wood
                    if (roll <= 20) return MaterialWeapon.stone;  // 15% stone
                    if (roll <= 45) return MaterialWeapon.bone;      // 25% bone
                    if (roll <= 75) return MaterialWeapon.metal;   // 30% metal
                    return MaterialWeapon.gold;                     // 25% gold

                default:
                    throw new ArgumentOutOfRangeException(nameof(level), "Error: Invalid level.");
            }
        }
        
        // Implementation of weapons' stats from material type
        private void SetAttributes(MaterialWeapon MaterialType)
        {
            switch (MaterialType)
            {
                case MaterialWeapon.wood:
                    Damage = random.Next(4, 10);
                    Speed = 20;
                    Weight = 2;
                    break;
                
                case MaterialWeapon.stone:
                    Damage = random.Next(10, 16);
                    Speed = 15;
                    Weight = 4;
                    break;

                case MaterialWeapon.bone:
                    Damage = random.Next(16, 21);
                    Speed = 17;
                    Weight = 6;
                    break;
                
                case MaterialWeapon.metal:
                    Damage = random.Next(21, 27);
                    Speed = 13;
                    Weight = 8;
                    break;
                
                case MaterialWeapon.gold:
                    Damage = random.Next(27, 32);
                    Speed = 11;
                    Weight = 10;
                    break;
                
                default:
                    Damage = 1;
                    Speed = 20;
                    Weight = 0;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name}, a {WeaponType} made out of {MaterialType} ! \n" +
            $"Damage : {Damage} | Speed : {Speed} | Weight : {Weight}";
        }
    }
}
