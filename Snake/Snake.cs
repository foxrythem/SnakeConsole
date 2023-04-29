using SnakeGame;
using System.Numerics;

namespace SnakeGame
{
    public class Snake : GameObject
    {
        public Snake(Vector2 startingPosistion, int length, Direction direction) : base (SNAKE_NAME, startingPosistion, SNAKE_ICON)
        {
            snakeHead = new SnakeHead(startingPosistion, direction);
            pieces.Add(snakeHead);

            for (int i = 0; i < length; i++)
            {
                addSnakeBody();
            }
        }

        public void moveSnake(ConsoleKey consoleKey)
        {
            snakeHead.OnKeyPress(consoleKey);
        }

        public override void Update()
        {
            foreach (var snakepiece in pieces)
            {
                snakepiece.Update();
            }
            base.Update();
        }

        public void addSnakeBody()
        {
            var CurrentSnakeTail = GetCurrentSnakeTail();
            // Console.WriteLine($"Current SnakeTail is {CurrentSnakeTail.ToString()}");
            var NewSnakeTail = new SnakeBody(CurrentSnakeTail.prevousPosistion, CurrentSnakeTail);
            pieces.Add(NewSnakeTail);
        }

        private SnakePiece GetCurrentSnakeTail() => pieces.LastOrDefault<SnakePiece>(snakeHead);
        public SnakeHead getCurrenctSnakeHead() => snakeHead;
        public List<SnakePiece> getSnakePieces => pieces;

        private SnakeHead snakeHead;
        List<SnakePiece> pieces = new List<SnakePiece>();
        private const string SNAKE_NAME = "";
        private const string SNAKE_ICON = "";
    }
}
