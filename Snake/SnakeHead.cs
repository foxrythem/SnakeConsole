using System.Numerics;

namespace SnakeGame
{
    public class SnakeHead : SnakePiece
    {
        public SnakeHead(Vector2 posistion, Direction direction) : base(SNAKE_HEAD_NAME, posistion, SNAKE_HEAD_ICON)
        {
            currentDirection = direction;
        }

        public void OnKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    changeDirection(Direction.UP);
                    break;
                case ConsoleKey.DownArrow:
                    changeDirection(Direction.DOWN);
                    break;
                case ConsoleKey.LeftArrow:
                    changeDirection(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    changeDirection(Direction.RIGHT);
                    break;
            }
        }

        protected override void moveSnake()
        {
            switch (currentDirection)
            {
                case Direction.UP:
                    nextPosistion = this.posistion + Vector2Helper.Up;
                    break;
                case Direction.DOWN:
                    nextPosistion = this.posistion + Vector2Helper.Down;
                    break;
                case Direction.LEFT:
                    nextPosistion = this.posistion + Vector2Helper.Left;
                    break;
                case Direction.RIGHT:
                    nextPosistion = this.posistion + Vector2Helper.Right;
                    break;
                case Direction.NONE:
                    break;
            }

            //Console.WriteLine($"{GetType().Name}: Current Direction is : {currentDirection}");

            base.moveSnake();
        }

        public void changeDirection(Direction direction)
        {
            // Can't move on to your tail
            if (isOppositeDirection(direction)) return;
            // Don't need to double your direction
            if (direction == currentDirection) return;

            currentDirection = direction;
        }

        private bool isOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    return currentDirection == Direction.DOWN;
                case Direction.DOWN:
                    return currentDirection == Direction.UP;
                case Direction.LEFT:
                    return currentDirection == Direction.RIGHT;
                case Direction.RIGHT:
                    return currentDirection == Direction.LEFT;
            }
            return false;
        }

        public Direction getDirection() => currentDirection;
        protected Direction currentDirection = Direction.NONE;

        private const string SNAKE_HEAD_NAME = "Snake Head";
        private const string SNAKE_HEAD_ICON = "S";
    }
}
