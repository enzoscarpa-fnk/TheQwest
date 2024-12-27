namespace JDR.Models
{
    public class Monster(
        int x,
        int y,
        string characterName
        ) : Character(x, y, characterName)
    {
        public int Stamina { get; set; }
        public int Power { get; set; }
        public int HasteRating { get; set; }
        public int DodgeRating { get; set; }
    }
}
