using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class Peta
    {

        /*
         * Attribute:
         * map: List<List<Cell>>
         * numTreasure: int
         */
        private List<List<Cell>> map;
        private Cell start;
        public Cell Start
        {
            get { return start; } 
            set {  start = value; }
        }


        private int numTreasure;
        public int NumTreasure
        {
            get { return numTreasure; }
            set { numTreasure = value; }
        }
        public void readFrom(string file)
        {

        }

        public Cell GetValue(int x, int y)
        {
            return map[x][y];
        }
        public void SetValue(int x, int y, Cell other)
        {
            map[x][y] = other;
        }
        public Cell this[int x, int y]
        {
            get => GetValue(x, y);
            set => SetValue(x, y, value);

        }



        
    }
}
