using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MazeHunter
{
    internal class Route
    {
        private List<Cell> jalur { get; set; }
        public List<Cell> JalurAccessor { get { return jalur; } }
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

        public string GetRouteDisplay()
        {
            string route = "";
            for (int i = 0; i < jalur.Count - 1; i++)
            {
                if (jalur[i].X == jalur[i + 1].X + 1)
                {
                    route += "L";
                }
                else if (jalur[i].X == jalur[i + 1].X - 1)
                {
                    route += "R";
                }
                else if (jalur[i].Y == jalur[i + 1].Y + 1)
                {
                    route += "U";
                }
                else
                {
                    route += "D";
                }

                if (i != jalur.Count - 2)
                {
                    route += " - ";
                }
            }
            return route;

        }
    }
}
