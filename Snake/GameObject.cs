using System.Numerics;

namespace SnakeGame
{
    public abstract class GameObject
    {
        public GameObject (string name, Vector2 posistion, string icon)
        {
            this.name = name;
            this.posistion = posistion;
            this.icon = icon;
        }

        public virtual void Update()
        {

        }

        public string name { get; protected set; }
        public Vector2 posistion { get; protected set; }
        public string icon { get; protected set; }
    }
}
