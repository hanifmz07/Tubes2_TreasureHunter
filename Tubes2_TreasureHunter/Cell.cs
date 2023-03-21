using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class Cell
    {
        public Cell(char c)
        {
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
        public int NumAccesed
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
    }


    
}
