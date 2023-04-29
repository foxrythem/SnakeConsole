using System.Numerics;

namespace SnakeGame
{
    public abstract class SnakePiece : GameObject
    {
        public SnakePiece(string name, Vector2 posistion, string icon) : base(name, posistion, icon)
        {
            this.name = name;
            this.posistion = posistion;
            this.icon = icon;
        }

        protected virtual void moveSnake()
        {
            prevousPosistion = posistion;
            posistion = nextPosistion;
            // Console.WriteLine($"{GetType().Name}: Cur pos is: {posistion}");
        }

        public override void Update()
        {
            moveSnake();
            base.Update();
        }

        public Vector2 nextPosistion { get; protected set; }
        public Vector2 prevousPosistion { get; protected set; }
    }
}
