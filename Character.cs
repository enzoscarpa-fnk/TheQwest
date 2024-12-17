namespace JDR;

public abstract class Character
{
    public string CharacterName { get; set; }
    public int Level { get; set; }
    internal bool IsDead { get; set; }
    public int HealthValue { get; set; }
    public int EnergyValue { get; set; }
    public int AttackValue { get; set; }
    public int ArmorValue { get; set; }
    public double CriticalHitFactor { get; set; }
    
    public Character(
        string characterName,
        bool isDead,
        double criticalHitFactor = 1.72
        )
    {
        CharacterName = characterName;
        IsDead = isDead;
        CriticalHitFactor = criticalHitFactor;
    }
    
    // The base attack
    public virtual void Cast_BaseAttack(Character target)
    {
    }

    public void TakeDamage(int damage, Character attacker)
    {
        HealthValue -= damage;
        
        Console.WriteLine($"{CharacterName} took {damage} damage from {attacker.CharacterName}.");
        
        if (HealthValue <= 0)
        {
            Die(attacker);
        }
    }

    public void Heal(int heal)
    {
        HealthValue += heal;
    }

    public void Die(Character attacker)
    {
        HealthValue = 0;
        IsDead = true;
        Console.WriteLine($"{CharacterName} has died !");
        if (attacker is Hero heroAttacker)
        {
            heroAttacker.CalculateExperience(this);
        }
    }
}