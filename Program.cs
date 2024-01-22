using pacman;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace pacman
{
    class program
    {
        public static bool gameOver = false;
        public static int score = 0;
        static int speed = 240;
        public enum direction { left, up, right, down }
        static Thread background = new Thread(BackgroundGame);
        public static Map map = new Map();
        public static Pacman pacman;
        public static List<Enemy> smartGhosts = new List<Enemy>();

        static void Main()
        {
            Title = "PacmanGame";
            CursorVisible = false;
            ForegroundColor = ConsoleColor.Cyan;
            SetCursorPosition(12, 15);
            WriteLine("PACMAN");
            Thread.Sleep(1500);

            map.RenderMap();
            map.RenderJewels();

            _.pacman = new Pacman(13, 23);

            _.Enemy.Add(new Enemy(15, 11, Object.direction.right));

            background.Start();
            background.IsBackground = true;
            pacman.Control(background);
            Clear();

            if (score < 2430)
            {
                SetCursorPosition(12, 6);
                ForegroundColor = ConsoleColor.Red;
                Write("JE MI ĽÚTO SKÚS TO ZNOVA!");
                SetCursorPosition(12, 8);
                ForegroundColor = ConsoleColor.Red;
                Write("Score: {0}", score);
                Thread.Sleep(500);
                SetCursorPosition(12, 10);
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                SetCursorPosition(12, 6);
                ForegroundColor = ConsoleColor.Red;
                Write("GRATULÁCIA!");
                SetCursorPosition(12, 8);
                ForegroundColor = ConsoleColor.Red;
                Write("Score: {0}", score);
                Thread.Sleep(500);
                SetCursorPosition(12, 10);
                ForegroundColor = ConsoleColor.Red;
            }
        }
        public static void BackgroundGame()
        {
            while (!_.gameOver)
            {
                if (score == 2430) gameOver = true;
                pacman.Step();
                foreach ( Enemy ghost in _.Enemy) ghost.Step();
                ForegroundColor = ConsoleColor.Yellow;
                SetCursorPosition(31, 1);
                Write("Score: {0}", score);
                Thread.Sleep(speed);
            }
        }
    }
}