using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeHunter
{
    internal class Cell
    {
        public Cell(char c, int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
            switch (c)
            {
                case 'K':
                    type = 0;
                    break;
                case 'X':
                    type = 1;
                    break;
                case 'R':
                    type = 2;
                    break;
                case 'T':
                    type = 3;
                    break;
            }
        }
        public Cell(Cell other)
        {
            this.x = other.x;
            this.y = other.y;
            this.type = other.type;
            this.NumAccessed = 0;
        }
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        //May be breakdown into sub classes for these attributes
        private bool accessed;
        public bool Accessed
        {
            get { return accessed; }
            set { accessed = value; }
        }

        private int numAccessed;
        public int NumAccessed
        {
            get { return numAccessed; }
            set { numAccessed = value; }
        }

        private int type;
        /*
         Type 0: start tile
         Type 1: empty tile
         Type 2: Alive tile
         Type 3: Treasure tile
         */
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private List<Tuple<int, int>> precedence;
        public List<Tuple<int, int>> Precedence
        {
            get { return precedence; } 
            set { precedence = value; }
        }
        public void PrintCell()
        {
            Console.Write($" <{x},{y}> ");
        }
    }


    
}
