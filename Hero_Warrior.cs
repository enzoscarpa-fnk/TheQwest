namespace JDR;

public class HeroWarrior : Hero
{
    private static Random rand = new();
    public int RollResult { get; private set; }
    public HeroWarrior(
        string characterName,
        LevelProgression progression,
        bool isDead = false,
        int level = 1,
        int experienceValue = 0,
        int energyValue = 35,
        int armorValue = 5,
        int bonusDamage = 0,
        int criticalChance = 2,
        int hasteRating = 5,
        int dodgeRating = 5
        ) : base(characterName, progression)
    {
        Level = level;
        ExperienceValue = experienceValue;
        EnergyValue = energyValue;
        ArmorValue = armorValue;
        BonusDamage = bonusDamage;
        CriticalChance = criticalChance;
        HasteRating = hasteRating;
        DodgeRating = dodgeRating;
        InitializeStats();
    }

    // Initializes stats
    private void InitializeStats()
    {
        Stamina = StatsCalculator.CalculateStat(4, 1.3, Level);
        Strength = StatsCalculator.CalculateStat(4, 1.25, Level);
        Intellect = StatsCalculator.CalculateStat(1, 1.05, Level);
        Agility = StatsCalculator.CalculateStat(1, 1.05, Level);
        Spirit = StatsCalculator.CalculateStat(2, 1.15, Level);
        HealthValue = Stamina * 10;
        AttackValue = (int)Math.Round(Strength * 1.8);
    }
    
    protected override void LevelUp()
    {
        base.LevelUp();
        InitializeStats(); // Updates stats after level up
    }
    
    // Decides if the attack is a critical hit
    public int CriticalHit(int baseDamage, out bool isCritical)
    {
        RollResult = rand.Next(1, 101);
        isCritical = RollResult <= CriticalChance; // Return true if the roll result is in the range of the CriticalChance value
        int damage = isCritical ? (int)Math.Round(baseDamage * CriticalHitFactor) : baseDamage; // if result is true then crit damage, else base damage
        
        return damage;
    }
    
    // The base attack
    public override void Cast_BaseAttack(Character target)
    {
        if (target.IsDead || EnergyValue < 2)
            return;
        
        EnergyValue -= 2;
        int baseDamage = AttackValue;
        int damage = baseDamage <= 0 ? 0 : baseDamage;
        
        bool isCritical;
        int calculatedDamage = CriticalHit(damage, out isCritical);
        
        string message = isCritical ? "Critical hit! " : "";
        message += $"Base attack from {CharacterName} dealt {calculatedDamage} damage to {target.CharacterName}.";

        Console.WriteLine(message);
        
        target.TakeDamage(calculatedDamage, this);
    }
}