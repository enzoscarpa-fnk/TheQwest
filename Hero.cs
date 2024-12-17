namespace JDR;

public class Hero : Character
{
    public int ExperienceValue { get; protected set; }
    private LevelProgression levelProgression;
    public int ExperienceToNextLevel => levelProgression.ExperienceToLevelUp(Level);
    public event Action? OnLevelUp;
    public int Stamina { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Agility { get; set; }
    public int Spirit { get; set; }
    public int Armor { get; set; }
    public int BonusDamage { get; set; }
    public int CriticalChance { get; set; }
    public int HasteRating { get; set; }
    public int DodgeRating { get; set; }
    public Hero(
        string characterName,
        LevelProgression progression,
        bool isDead = false
        ) : base(characterName, isDead)
    {
        levelProgression = progression;
    }

    // Calculates the experience gained
    public void CalculateExperience(Character target)
    {
        int levelDifference = target.Level - Level;
        double experienceMath = 120 * Math.Pow(1.2, levelDifference);
        if (experienceMath < 5)
        {
            experienceMath = 5; // Minimum quantity of experience guaranteed
        }
        
        int experienceGained = (int)Math.Round(experienceMath);
        GainExperience(experienceGained, target);
    }

    // Adds the amount of experience gained and checks if it increases the level of the hero
    public void GainExperience(int amount, Character target)
    {
        ExperienceValue += amount;
        Console.WriteLine($"{CharacterName} received {amount} experience points from killing {target.CharacterName}.");

        while (levelProgression.CanLevelUp(Level, ExperienceValue))
        {
            LevelUp();
        }
    }
    
    // Adds a level to the character
    protected virtual void LevelUp()
    {
        ExperienceValue -= ExperienceToNextLevel;
        Level++;
        Console.WriteLine($"Yay ! {CharacterName} reached level {Level} !");
        OnLevelUp?.Invoke();
    }
    
    // Equip item and change stats
    public void EquipItem(Item item)
    {
        Stamina += item.StaminaBonus;
        Strength += item.StrengthBonus;
        Intellect += item.IntellectBonus;
        Agility += item.AgilityBonus;
        Spirit += item.SpiritBonus;
        Armor += item.ArmorBonus;
        BonusDamage += item.DamageBonus;
        CriticalChance += item.CriticalChanceBonus;
        HasteRating += item.HasteBonus;
        DodgeRating += item.DodgeBonus;

        Console.WriteLine($"{CharacterName} equipped {item.Name}.");
    }
}