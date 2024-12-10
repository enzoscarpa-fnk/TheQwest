namespace JDR;

public class Foe : Character
{
    private static Random rand = new();
    public int RollResult { get; private set; }
    public Foe(string characterName, bool isDead, int healthValue, int energyValue, int attackValue, int armorValue) : base(characterName, isDead, energyValue, armorValue, level: 1)
    {
        HealthValue = healthValue;
        AttackValue = attackValue;
    }
    
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
    }
}