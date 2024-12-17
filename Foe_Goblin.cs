namespace JDR;

public class FoeGoblin : Foe
{
    private static Random rand = new();
    public int RollResult { get; private set; }
    public FoeGoblin(
        string characterName = "Goblin",
        bool isDead = false,
        int armorValue = 4,
        int criticalChance = 2,
        int hasteRating = 5,
        int dodgeRating = 5
        ) : base(characterName, isDead)
    {
        ArmorValue = armorValue;
        CriticalChance = criticalChance;
        HasteRating = hasteRating;
        DodgeRating = dodgeRating;
    }
    
    // Initializes stats
    private void InitializeStats()
    {
        Stamina = StatsCalculator.CalculateStat(5, 1.2, Level);
        Power = StatsCalculator.CalculateStat(3, 1.25, Level);
        HealthValue = Stamina * 10;
        AttackValue = (int)Math.Round(Power * 1.6);
    }
    
    // Calculates the foe level if the hero level is at least 2
    public void CalculateLevel(int heroLevel)
    {
        RollResult = rand.Next(1, 101);

        if (heroLevel > 1)
        {
            if (RollResult <= 15)
            {
                Level = heroLevel - 1;
            }
            else if (RollResult <= 65)
            {
                Level = heroLevel;
            }
            else if (RollResult <= 92)
            {
                Level = heroLevel + 1;
            }
            else
            {
                Level = heroLevel + 2;
            }
        }
        else
        {
            Level = heroLevel;
        }
        
        InitializeStats();
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
        if (target.IsDead)
            return;
        
        int baseDamage = AttackValue - target.ArmorValue;
        int damage = baseDamage <= 0 ? 0 : baseDamage;

        bool isCritical;
        int calculatedDamage = CriticalHit(damage, out isCritical);
        
        string message = isCritical ? "Critical hit! " : "";
        message += $"Base attack from {CharacterName} dealt {calculatedDamage} damage to {target.CharacterName}.";

        Console.WriteLine(message);
        
        target.TakeDamage(calculatedDamage, this);
    }
}