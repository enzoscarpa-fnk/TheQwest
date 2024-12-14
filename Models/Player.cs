namespace JDR.Models
{
    public class Player
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;
        public Direction FacingDirection { get; private set; } = Direction.Right;
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

        public void Move(string direction, int gridSize)
        {
            switch (direction)
            {
                case "Up":
                    if (Y > 0) Y--;
                    break;
                case "Down":
                    if (Y < gridSize - 1) Y++;
                    break;
                case "Left":
                    if (X > 0) X--;
                    FacingDirection = Direction.Left;
                    break;
                case "Right":
                    if (X < gridSize - 1) X++;
                    FacingDirection = Direction.Right;
                    break;
            }
        }

        // Méthode pour guérir le joueur
        public void Heal(int healAmount)
        {
            // Augmenter la vie du joueur en s'assurant qu'il ne dépasse pas la vie maximale
            CurrentLife = Math.Min(MaxLife, CurrentLife + healAmount);
        }
    }

    public enum Direction { Left, Right}
}
