namespace JDR.Models
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player()
        {
            X = 0;
            Y = 0;
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
                    break;
                case "Right":
                    if (X < gridSize - 1) X++;
                    break;
            }
        }
    }
}
