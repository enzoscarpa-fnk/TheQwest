using System;

namespace JDR.Models
{
    public class LifeFountain(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        // Méthode pour régénérer la vie du joueur lorsqu'il s'en approche
        public static void HealPlayer(Player player)
        {
            // Le pourcentage entre 25% et 75% de la vie maximale du joueur
            Random random = new();
            int healPercentage = random.Next(25, 76); // Aléatoire entre 25 et 75
            int healAmount = player.MaxLife * healPercentage / 100;

            player.Heal(healAmount);
            Console.WriteLine($"La fontaine vous heal ! Vous gagnez {healAmount} HP.");
        }
    }
}
