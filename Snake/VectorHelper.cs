using System.Numerics;

namespace SnakeGame
{
    /// <summary>
    /// These are set up because the board 0,0 is the top left
    /// This is usually not true and 0,0 would be center of the board
    /// </summary>
    public static class Vector2Helper
    {
        public static Vector2 Up => new Vector2(-1, 0);
        public static Vector2 Down => new Vector2(1, 0);
        public static Vector2 Left => new Vector2(0, -1);
        public static Vector2 Right => new Vector2(0, 1);
    }
}
