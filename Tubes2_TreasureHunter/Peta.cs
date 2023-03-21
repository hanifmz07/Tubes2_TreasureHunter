using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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

        public Peta() {
            map = new List<List<Cell>>();
        }   

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
            

            Console.WriteLine("Hello");
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                List<Cell> row = new List<Cell>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'K' || line[i] == 'T' || line[i] == 'R' || line[i] == 'X')
                    {
                        Cell item = new Cell(line[i]);
                        row.Add(item);
                        
                    }
                    else if (line[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        //invalid, throw exception
                    }


                }
                map.Add(row);
            }
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

        public void Inaccess()
        {
            foreach(List<Cell> row in map)
            {
                foreach(Cell cell in row)
                {
                    cell.Accessed = false;
                }
            }
        }
        public void PrintPeta()
        {
            foreach (List<Cell> line in map)
            {
                foreach (Cell cell in line)
                    Console.Write($" {cell.Type} ");
                Console.WriteLine();
            }
        }



        
    }
}
