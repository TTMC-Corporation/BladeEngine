using System.Numerics;

namespace BladeEngine
{
    public class GameObject
    {
        public string name = "GameObject";
        public char skin = '♦';
        public Vector2 position = new Vector2(10, 10);
        public bool solid = true;
        public ConsoleColor color = ConsoleColor.White;
    }
    public class Game
    {
        public static Vector2 size = new Vector2(100, 50);
        public static char wall = '█';
        public static char ground = '.';
        public static ConsoleColor wallColor = ConsoleColor.Gray;
        public static ConsoleColor groundColor = ConsoleColor.DarkGray;
        public static void Flush(GameObject gameObject)
        {
            Console.SetCursorPosition((int)gameObject.position.X, (int)gameObject.position.Y);
            Console.ForegroundColor = gameObject.color;
            Console.Write(gameObject.skin);
            Console.ForegroundColor =groundColor;
            Console.SetCursorPosition(0, (int)size.Y);
        }
        public static void Start()
        {
            Console.CursorVisible = false;
            Console.Clear();
            string[] loader = {"" , ""};
            for (int i = 0; i < (int)size.X; i++)
            {
                loader[0] += wall;
            }
            for (int i = 2; i < (int)size.X; i++)
            {
                loader[1] += ground;
            }
            Console.ForegroundColor = wallColor;
            Console.WriteLine(loader[0]);
            for (int i = 2; i < (int)size.Y; i++)
            {
                Console.ForegroundColor = wallColor;
                Console.Write(wall);
                Console.ForegroundColor = groundColor;
                Console.Write(loader[1]);
                Console.ForegroundColor = wallColor;
                Console.WriteLine(wall);
            }
            Console.ForegroundColor = wallColor;
            Console.WriteLine(loader[0]);
        }
        public static void MoveUp(GameObject gameObject)
        {
            if (SafeMove(0, gameObject))
            {
                Console.SetCursorPosition((int)gameObject.position.X, (int)gameObject.position.Y);
                Console.Write(ground);
                Console.SetCursorPosition((int)gameObject.position.X, (int)--gameObject.position.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.skin);
                Console.ForegroundColor = groundColor;
                Console.SetCursorPosition(0, (int)size.Y);
            }
        }
        public static void MoveDown(GameObject gameObject)
        {
            if (SafeMove(1, gameObject))
            {
                Console.SetCursorPosition((int)gameObject.position.X, (int)gameObject.position.Y);
                Console.Write(ground);
                Console.SetCursorPosition((int)gameObject.position.X, (int)++gameObject.position.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.skin);
                Console.ForegroundColor = groundColor;
                Console.SetCursorPosition(0, (int)size.Y);
            }
        }
        public static void MoveRight(GameObject gameObject)
        {
            if (SafeMove(2, gameObject))
            {
                Console.SetCursorPosition((int)gameObject.position.X, (int)gameObject.position.Y);
                Console.Write(ground);
                Console.SetCursorPosition((int)++gameObject.position.X, (int)gameObject.position.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.skin);
                Console.ForegroundColor = groundColor;
                Console.SetCursorPosition(0, (int)size.Y);
            }
        }
        public static void MoveLeft(GameObject gameObject)
        {
            if (SafeMove(3, gameObject))
            {
                Console.SetCursorPosition((int)gameObject.position.X, (int)gameObject.position.Y);
                Console.Write(ground);
                Console.SetCursorPosition((int)--gameObject.position.X, (int)gameObject.position.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.skin);
                Console.ForegroundColor = groundColor;
                Console.SetCursorPosition(0, (int)size.Y);
            }
        }
        private static bool SafeMove(int dir, GameObject gameObject)
        {
            bool safe = true;
            if (dir == 0)
            {
                if (gameObject.position.Y <= 1)
                {
                    safe = false;
                }
            }
            if (dir == 1)
            {
                if (gameObject.position.Y >= (int)size.Y - 2)
                {
                    safe = false;
                }
            }
            if (dir == 2)
            {
                if (gameObject.position.X >= (int)size.X - 2)
                {
                    safe = false;
                }
            }
            if (dir == 3)
            {
                if (gameObject.position.X <= 1)
                {
                    safe = false;
                }
            }
            return safe;
        }
    }
}