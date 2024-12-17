namespace JDR;

public class Foe : Character
{
    public int Stamina { get; set; }
    public int Power { get; set; }
    public int CriticalChance { get; set; }
    public int HasteRating { get; set; }
    public int DodgeRating { get; set; }
    public Foe(
        string characterName,
        bool isDead = false
        ) : base(characterName, isDead)
    {
    }
}