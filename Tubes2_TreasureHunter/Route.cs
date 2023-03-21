using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Tubes2_TreasureHunter
{
    internal class Route
    {
        private List<Cell> jalur;
        public Route() { 
            jalur = new List<Cell>();
        
        
        }
        public Cell this[int x]
        {
            get { return jalur[x]; }
            set { jalur[x] = value; }

        }
        public void AddCell(Cell cell)
        {
            jalur.Add(cell);
        }

        public void PrintRoute()
        {
            foreach(Cell cell in jalur)
            {
                Console.Write($" <{cell.X}, {cell.Y}> ");
            }
        }
    }
}
