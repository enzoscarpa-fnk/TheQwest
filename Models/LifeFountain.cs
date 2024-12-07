using System;

namespace JDR.Models
{
    public class LifeFountain
    {
        public string Name { get; set; }
        public string Location { get; set; }

        // Constructeur
        public LifeFountain(string name, string location)
        {
            Name = name;
            Location = location;
        }

        // Méthode pour régénérer la vie du joueur lorsqu'il s'en approche
        public void HealPlayer(Player player)
        {
            // Le pourcentage entre 25% et 75% de la vie maximale du joueur
            Random random = new Random();
            int healPercentage = random.Next(25, 76); // Aléatoire entre 25 et 75
            int healAmount = player.MaxLife * healPercentage / 100;

            player.Heal(healAmount);
        }
    }
}
