using System;
using static System.Console;

namespace pacman
{
    public class Map
    {
        int x, y;
        public static char wall = '█';
        public static char emptySpace = ' ';
        public static char jewel = '·';
        public static char smartGhostSymbol = 'E';
        public static char stupidGhostSymbol = 'Y';
        public char[,] area = new char[31, 28];

        public char Wall { get; set; }
        public char EmptySpace { get; set; }
        public char Jewel { get; set; }

        public char this[int x, int y]
        {
            get
            {
                if (x < 0) return area[y, 27];
                else if (x > 27) return area[y, 0];
                else return area[y, x];
            }
            set
            {
                area[y, x] = value;
                ForegroundColor = ConsoleColor.Green;
                SetCursorPosition(x + 1, y + 1);
                Write(value);
                ForegroundColor = ConsoleColor.Red;
            }
        }
        public void RenderChar(int x, int y, char symbol)
        {
            if (x < 0) x = 27;
            else if (x > 27) x = 0;
            if (symbol == 'P') ForegroundColor = ConsoleColor.White;
            else if (symbol == 'X') ForegroundColor = ConsoleColor.Red;
            else if (symbol == 'Y') ForegroundColor = ConsoleColor.Blue;
            SetCursorPosition(x + 1, y + 1);
            Write(symbol);
            ForegroundColor = ConsoleColor.White;
            area[y, x] = symbol;
        }
        private void RenderWall(int x, int y)
        {
            ForegroundColor = ConsoleColor.Cyan;
            SetCursorPosition(x + 1, y + 1);
            Write(wall);
            ForegroundColor = ConsoleColor.White;
            area[y, x] = wall;
        }
        public void RenderEmptySpace(int x, int y)
        {
            SetCursorPosition(x + 1, y + 1);
            Write(emptySpace);
            area[y, x] = emptySpace;
        }
        public void RenderJewel(int x, int y)
        {
            ForegroundColor = ConsoleColor.Yellow;
            SetCursorPosition(x + 1, y + 1);
            Write(jewel);
            ForegroundColor = ConsoleColor.White;
            area[y, x] = jewel;
        }
        public void RenderMap()
        {
            ForegroundColor = ConsoleColor.Green;
            SetCursorPosition(1, 1);
            for (int i = 0; i < 28; i++)
            {
                Write(wall);
                area[0, i] = wall;
            }
            SetCursorPosition(5, 20);
            for (int i = 0; i < 28; i++)
            {
                Write(wall);
                area[30, i] = wall;
            }
            for (int i = 2; i < 15; i++)
            {
                SetCursorPosition(1, i);
                Write(wall);
                area[i - 1, 0] = wall;
                SetCursorPosition(28, i);
                Write(wall);
                area[i - 1, 27] = wall;
            }
            for (int i = 16; i < 31; i++)
            {
                SetCursorPosition(1,4);
                Write(wall);
                area[i - 1, 0] = wall;
                SetCursorPosition(28, 4);
                Write(wall);
                area[i - 1, 27] = wall;
            }
            for (int i = 3; i < 6; i++)
            {
                SetCursorPosition(3, 4);
                for (int j = 3; j < 7; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                SetCursorPosition(3, i);
                for (int j = 3; j < 7; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 15; i++)
            {
                SetCursorPosition(2, i);
                for (int j = 2; j < 7; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                SetCursorPosition(2, i);
                for (int j = 2; j < 7; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(2, i);
                for (int j = 2; j < 4; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(3, i);
                for (int j = 3; j < 7; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 24; i < 27; i++)
            {
                SetCursorPosition(5, i);
                for (int j = 5; j < 7; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 3; i < 6; i++)
            {
                SetCursorPosition(8, i);
                for (int j = 8; j < 13; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 15; i++)
            {
                SetCursorPosition(8, i);
                for (int j = 8; j < 10; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 12; i++)
            {
                SetCursorPosition(10, i);
                for (int j = 10; j < 13; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                SetCursorPosition(8, i);
                for (int j = 8; j < 10; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(8, i);
                for (int j = 8; j < 13; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 28; i++)
            {
                SetCursorPosition(8, i);
                for (int j = 8; j < 10; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 28; i < 30; i++)
            {
                SetCursorPosition(3, i);
                for (int j = 3; j < 13; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 2; i < 6; i++)
            {
                SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 12; i++)
            {
                SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 13; i < 14; i++)
            {
                SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 14; i < 17; i++)
            {
                SetCursorPosition(11, i);
                for (int j = 11; j < 12; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 17; i < 18; i++)
            {
                SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 19; i < 21; i++)
            {
                SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 21; i < 24; i++)
            {
                SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 27; i < 30; i++)
            {
                SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 3; i < 6; i++)
            {
                SetCursorPosition(23, i);
                for (int j = 23; j < 27; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                SetCursorPosition(23, i);
                for (int j = 23; j < 27; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 15; i++)
            {
                SetCursorPosition(23, i);
                for (int j = 23; j < 28; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                SetCursorPosition(23, i);
                for (int j = 23; j < 28; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(26, i);
                for (int j = 26; j < 28; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(23, i);
                for (int j = 23; j < 27; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 24; i < 27; i++)
            {
                SetCursorPosition(23, i);
                for (int j = 23; j < 25; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 3; i < 6; i++)
            {
                SetCursorPosition(17, i);
                for (int j = 17; j < 22; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 15; i++)
            {
                SetCursorPosition(20, i);
                for (int j = 20; j < 22; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 12; i++)
            {
                SetCursorPosition(17, i);
                for (int j = 17; j < 20; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                SetCursorPosition(20, i);
                for (int j = 20; j < 22; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(17, i);
                for (int j = 17; j < 22; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 28; i++)
            {
                SetCursorPosition(20, i);
                for (int j = 20; j < 22; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 28; i < 30; i++)
            {
                SetCursorPosition(17, i);
                for (int j = 17; j < 27; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 2; i < 6; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 12; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 13; i < 14; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 14; i < 17; i++)
            {
                SetCursorPosition(18, i);
                for (int j = 18; j < 19; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 17; i < 18; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 19; i < 21; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 21; i < 24; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 27; i < 30; i++)
            {
                SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            ForegroundColor = ConsoleColor.White;
        }
        public void RenderJewels()
        {
            SetCursorPosition(2, 2);
            for (int i = 1; i < 13; i++)
            {
                Write(jewel);
                area[1, i] = jewel;
            }
            SetCursorPosition(16, 2);
            for (int i = 15; i < 27; i++)
            {
                Write(jewel);
                area[1, i] = jewel;
            }
            SetCursorPosition(2, 6);
            for (int i = 1; i < 27; i++)
            {
                Write(jewel);
                area[5, i] = jewel;
            }
            for (int i = 3; i < 10; i++)
            {
                SetCursorPosition(2, i);
                Write(jewel);
                area[i - 1, 1] = jewel;
            }
            for (int i = 3; i < 28; i++)
            {
                SetCursorPosition(7, i);
                Write(jewel);
                area[i - 1, 6] = jewel;
            }
            for (int i = 3; i < 6; i++)
            {
                SetCursorPosition(13, i);
                Write(jewel);
                area[i - 1, 12] = jewel;
            }
            for (int i = 3; i < 6; i++)
            {
                SetCursorPosition(16, i);
                Write(jewel);
                area[i - 1, 15] = jewel;
            }
            for (int i = 3; i < 28; i++)
            {
                SetCursorPosition(22, i);
                Write(jewel);
                area[i - 1, 21] = jewel;
            }
            for (int i = 3; i < 10; i++)
            {
                SetCursorPosition(27, i);
                Write(jewel);
                area[i - 1, 26] = jewel;
            }
            for (int i = 7; i < 9; i++)
            {
                SetCursorPosition(10, i);
                Write(jewel);
                area[i - 1, 9] = jewel;
            }
            for (int i = 7; i < 9; i++)
            {
                SetCursorPosition(19, i);
                Write(jewel);
                area[i - 1, 18] = jewel;
            }
            SetCursorPosition(3, 9);
            for (int i = 2; i < 6; i++)
            {
                Write(jewel);
                area[8, i] = jewel;
            }
            SetCursorPosition(23, 9);
            for (int i = 22; i < 26; i++)
            {
                Write(jewel);
                area[8, i] = jewel;
            }
            SetCursorPosition(10, 9);
            for (int i = 9; i < 13; i++)
            {
                Write(jewel);
                area[8, i] = jewel;
            }
            SetCursorPosition(16, 9);
            for (int i = 15; i < 19; i++)
            {
                Write(jewel);
                area[8, i] = jewel;
            }
            SetCursorPosition(2, 4);
            for (int i = 1; i < 27; i++)
            {
                Write(jewel);
                area[29, i] = jewel;
            }
            SetCursorPosition(2, 27);
            for (int i = 1; i < 7; i++)
            {
                Write(jewel);
                area[26, i] = jewel;
            }
            SetCursorPosition(22, 27);
            for (int i = 21; i < 27; i++)
            {
                Write(jewel);
                area[26, i] = jewel;
            }
            SetCursorPosition(10, 27);
            for (int i = 9; i < 13; i++)
            {
                Write(jewel);
                area[26, i] = jewel;
            }
            SetCursorPosition(16, 27);
            for (int i = 15; i < 19; i++)
            {
                Write(jewel);
                area[26, i] = jewel;
            }

            for (int i = 28; i < 30; i++)
            {
                SetCursorPosition(2, i);
                Write(jewel);
                area[i - 1, 1] = jewel;
            }
            for (int i = 28; i < 30; i++)
            {
                SetCursorPosition(13, i);
                Write(jewel);
                area[i - 1, 12] = jewel;
            }
            for (int i = 28; i < 30; i++)
            {
                SetCursorPosition(16, i);
                Write(jewel);
                area[i - 1, 15] = jewel;
            }
            for (int i = 28; i < 30; i++)
            {
                SetCursorPosition(27, i);
                Write(jewel);
                area[i - 1, 26] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(4, i);
                Write(jewel);
                area[i - 1, 3] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(10, i);
                Write(jewel);
                area[i - 1, 9] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(19, i);
                Write(jewel);
                area[i - 1, 18] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                SetCursorPosition(25, i);
                Write(jewel);
                area[i - 1, 24] = jewel;
            }
            SetCursorPosition(2, 24);
            for (int i = 1; i < 4; i++)
            {
                Write(jewel);
                area[23, i] = jewel;
            }
            SetCursorPosition(25, 24);
            for (int i = 24; i < 27; i++)
            {
                Write(jewel);
                area[23, i] = jewel;
            }
            SetCursorPosition(8, 24);
            for (int i = 7; i < 13; i++)
            {
                Write(jewel);
                area[23, i] = jewel;
            }
            SetCursorPosition(16, 24);
            for (int i = 15; i < 21; i++)
            {
                Write(jewel);
                area[23, i] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(2, i);
                Write(jewel);
                area[i - 1, 1] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(13, i);
                Write(jewel);
                area[i - 1, 12] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(16, i);
                Write(jewel);
                area[i - 1, 15] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                SetCursorPosition(27, i);
                Write(jewel);
                area[i - 1, 26] = jewel;
            }
            SetCursorPosition(2, 21);
            for (int i = 1; i < 13; i++)
            {
                Write(jewel);
                area[20, i] = jewel;
            }
            SetCursorPosition(16, 21);
            for (int i = 15; i < 27; i++)
            {
                Write(jewel);
                area[20, i] = jewel;
            }
            ForegroundColor = ConsoleColor.White;
        }
    }
}