namespace JDR.Models
{
    public class Monster
    {
        public string Name { get; set; }

        // Constructeur
        public Monster(string name)
        {
            Name = name;
        }

        // Méthode pour attaquer le joueur, le monstre inflige entre 10% et 50% des PV du joueur
        public void Attack(Player player)
        {
            Random random = new Random();
            int damagePercentage = random.Next(10, 51); // Aléatoire entre 10% et 50%
            int damageAmount = player.MaxLife * damagePercentage / 100;

            player.CurrentLife -= damageAmount;
            player.CurrentLife = Math.Max(0, player.CurrentLife); // La vie ne peut pas être inférieure à 0

            Console.WriteLine($"Le monstre attaque ! Vous perdez {damageAmount} HP.");
        }
    }
}
