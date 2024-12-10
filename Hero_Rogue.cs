namespace JDR;

public class HeroRogue : Hero
{
    public HeroRogue(
        string characterName,
        bool isDead,
        int energyValue,
        int armorValue,
        LevelProgression progression,
        int level,
        int experienceValue,
        int armor = 3,
        int bonusDamage = 0,
        int criticalChance = 3,
        int hasteRating = 6,
        int dodgeRating = 6
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
        Stamina = HeroStatsCalculator.CalculateStat(3, 1.25, Level);
        Strength = HeroStatsCalculator.CalculateStat(1, 1.05, Level);
        Intellect = HeroStatsCalculator.CalculateStat(1, 1.05, Level);
        Agility = HeroStatsCalculator.CalculateStat(4, 1.25, Level);
        Spirit = HeroStatsCalculator.CalculateStat(4, 1.2, Level);
        HealthValue = Stamina * 10;
        AttackValue = (int)Math.Round(Agility * 1.8);
    }
    
    protected override void LevelUp()
    {
        base.LevelUp();
        InitializeStats(); // Updates stats after level up
    }
}