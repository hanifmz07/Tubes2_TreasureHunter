using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class Cell
    {
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
