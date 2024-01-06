using pacman;
using System;
using System.Threading;

namespace pacman
{
    class Pacman : Object
    {
        public Pacman(int x, int y)
        {
            this.X = x;
            this.Y = y;
            currentStatePlace = _.map.EmptySpace;
            objectDirection = direction.left;
            _.map.RenderChar(x, y, GetSymbol());
        }

        static ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();

        public void Control(Thread background)
        {
            while (background.IsAlive)
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    objectDirection = direction.left;
                }
                else if (KeyInfo.Key == ConsoleKey.RightArrow)
                {
                    objectDirection = direction.right;
                }
                else if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    objectDirection = direction.up;
                }
                else if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    objectDirection = direction.down;
                }
            }
        }

        public override char GetSymbol()
        {
            return 'P';
        }

        public override void ChangePositionByDirection(direction Direction)
        {
            if (x > 27) x = 0;
            else if (x < 0) x = 27;
            _.map.RenderChar(x, y, currentStatePlace);
            if (Direction == direction.left) x--;
            if (Direction == direction.right) x++;
            if (Direction == direction.up) y--;
            if (Direction == direction.down) y++;
            CalcScore();
            _.map.RenderChar(x, y, GetSymbol());
        }
        public void CalcScore()
        {
            if (_.map[x, y] == Map.jewel)
            {
                _.score += 10;
            }
        }

        public override void Step()
        {
            Char newPosition = GetSymbolByDirection(objectDirection);

            if (newPosition != Map.wall)
            {
                ChangePositionByDirection(objectDirection);
                previousObjectDirection = objectDirection;
            }
            else
            {
                newPosition = GetSymbolByDirection(previousObjectDirection);
                if (newPosition != Map.wall)
                {
                    ChangePositionByDirection(previousObjectDirection);
                }
            }

        }
    }
}