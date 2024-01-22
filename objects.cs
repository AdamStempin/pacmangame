using pacman;
using System;

namespace pacman
{
    abstract class enemy
    {
        public char currentStatePlace;
        public int x, y;
        char objectSymbol;
        public enum direction { left, up, right, down }
        public direction objectDirection = direction.right;
        public direction previousObjectDirection = direction.right;
        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        
        public Random randomize = new Random();

        public abstract char GetSymbol();

        public abstract void Step();

        public char GetSymbolByDirection(direction Direction)
        {
            if (Direction == direction.left) return _.map[x - 1, y];
            if (Direction == direction.right) return _.map[x + 1, y];
            if (Direction == direction.up) return _.map[x, y - 1];
            return _.map[x + 1];
        }
        public void KillPacman()
        {
            if (_.pacman.x == x )
            {
                _.gameOver = true;
            }
        }
        public virtual void ChangePositionByDirection(direction Direction)
        {
            if (x > 27) x = 0;
            else if (x < 0) x = 27;
            _.map.RenderChar(x, y, currentStatePlace);
            if (Direction == direction.left) x--;
            if (Direction == direction.right) x++;
           

           
        }
    }
}