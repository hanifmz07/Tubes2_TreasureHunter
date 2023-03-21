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
        public Route(Route other)
        {
            jalur = new List<Cell>();
            for(int i = 0; i < other.jalur.Count; i++)
            {
                jalur.Add(other.jalur[i]);
            }
        }
        public void Copy(Route other)
        {
            jalur.Clear();
            for (int i = 0; i < other.jalur.Count; i++)
            {
                jalur.Add(other.jalur[i]);
            }
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
            
            foreach (Cell cell in jalur)
            {
                cell.PrintCell();
                
            }
            Console.WriteLine(" ");
        }
    }
}
