namespace JDR.Models
{
    public class Player
    {
        public string? Name { get; set; }
        public int MaxLife { get; set; }
        public int CurrentLife { get; set; }

        // Constructeur
        public Player(string name, int maxLife)
        {
            Name = name;
            MaxLife = maxLife;
            CurrentLife = maxLife;
        }

        // Méthode pour guérir le joueur
        public void Heal(int healAmount)
        {
            // Augmenter la vie du joueur en s'assurant qu'il ne dépasse pas la vie maximale
            CurrentLife = Math.Min(MaxLife, CurrentLife + healAmount);
        }
    }
}
