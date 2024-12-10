namespace JDR;

public class HeroMage : Hero
{
    private static Random rand = new();
    public int RollResult { get; private set; }
    public HeroMage(
        string characterName,
        bool isDead,
        int energyValue,
        int armorValue,
        LevelProgression progression,
        int level,
        int experienceValue,
        int armor = 2,
        int bonusDamage = 0,
        int criticalChance = 2,
        int hasteRating = 5,
        int dodgeRating = 5
    ) : base(characterName, isDead, energyValue, armorValue, progression, level, experienceValue)
    {
        Armor = armor;
        BonusDamage = bonusDamage;
        CriticalChance = criticalChance;
        HasteRating = hasteRating;
        DodgeRating = dodgeRating;
        InitializeStats();
    }

    // Initializes stats
    private void InitializeStats()
    {
        Stamina = HeroStatsCalculator.CalculateStat(2, 1.2, Level);
        Strength = HeroStatsCalculator.CalculateStat(1, 1.05, Level);
        Intellect = HeroStatsCalculator.CalculateStat(4, 1.25, Level);
        Agility = HeroStatsCalculator.CalculateStat(1, 1.05, Level);
        Spirit = HeroStatsCalculator.CalculateStat(3, 1.15, Level);
        HealthValue = Stamina * 10;
        AttackValue = (int)Math.Round(Intellect * 1.8);
    }
    
    // Overrides the base LevelUp method to update the stats
    protected override void LevelUp()
    {
        base.LevelUp();
        InitializeStats(); // Updates stats after level up
    }

    // Decides if the attack is a critical hit
    public int CriticalHit(int baseDamage)
    {
        RollResult = rand.Next(1, 101);
        bool result = RollResult <= CriticalChance; // Return true if the roll result is in the range of the CriticalChance value
        int damage = result ? (int)Math.Round(baseDamage * CriticalHitFactor) : baseDamage; // if result is true then crit damage, else base damage

        return damage;
    }
    
    // The base attack
    public int Cast_BaseAttack()
    {
        EnergyValue -= 2;
        int baseDamage = AttackValue;
        int calculatedDamage = CriticalHit(baseDamage);
        
        return calculatedDamage;
    }

    // Low tier spell
    public int Cast_FireBall()
    {
        EnergyValue -= 6;
        int baseDamage = (int)Math.Round(AttackValue * 2.4);
        int calculatedDamage = CriticalHit(baseDamage);
        
        return calculatedDamage;
    }

    // Mid tier spell
    public int Cast_EarthShield()
    {
        EnergyValue -= 4;
        // Add timer here
        return Armor * 4;
    }

    // Ultimate spell
    public int Cast_FireBlast()
    {
        EnergyValue -= 18;
        int baseDamage = (int)Math.Round(AttackValue * 6.9);
        int calculatedDamage = CriticalHit(baseDamage);
        
        return calculatedDamage;
    }
}