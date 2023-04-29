using System.Numerics;


namespace SnakeGame
{
    public class SnakeBody : SnakePiece
    {
        public SnakeBody(Vector2 posistion, SnakePiece snakePieceToFolow) : base(SNAKE_BODY_NAME, posistion, SNAKE_BODY_ICON) 
        {
            this.snakePieceToFolow = snakePieceToFolow;
        }

        public void followPiece(SnakePiece snakePiece)
        {
            nextPosistion = snakePiece.prevousPosistion;
        }

        protected override void moveSnake()
        {
            followPiece(snakePieceToFolow);
            base.moveSnake();
        }

        private SnakePiece snakePieceToFolow;
        private const string SNAKE_BODY_NAME = "Snake Body";
        private const string SNAKE_BODY_ICON = "B";
    }
}
