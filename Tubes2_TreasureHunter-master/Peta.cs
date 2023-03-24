using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MazeHunter
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
            numTreasure = 0;
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

            string[] lines = File.ReadAllLines(file);
            int numx;
            int size = 0;
            int numy = 0;
            bool first = true;
            foreach (string line in lines)
            {
                List<Cell> row = new List<Cell>();
                numx = 0;
                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == 'K' || line[i] == 'T' || line[i] == 'R' || line[i] == 'X')
                    {

                        Cell item = new Cell(line[i], numx, numy);
                        row.Add(item);
                        numx++;
                        if (line[i] == 'T')
                        {
                            numTreasure++;
                        }
                        if (line[i] == 'K')
                        {
                            start = item;
                        }
                    }
                    else if (line[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        throw (new InvalidCharacterException());
                    }


                }
                map.Add(row);
                numy++;
                if (first)
                {
                    size = numx;
                    first = false;
                }
                else
                {
                    if(size!=numx)
                    {
                        throw new RowInconsistentException();
                    }
                }
            }
        }

        public Cell GetValue(int x, int y)
        {
            return map[y][x];
        }
        public void SetValue(int x, int y, Cell other)
        {
            map[y][x] = other;
        }
        public Cell this[int x, int y]
        {
            get => GetValue(x, y);
            set => SetValue(x, y, value);

        }

        public int GetNumRow()
        {
            return map.Count;
        }

        public int GetNumCol()
        {
            return map[0].Count;
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

        public void PrintPetaCoor()
        {
            foreach (List<Cell> line in map)
            {
                foreach (Cell cell in line)
                    Console.Write($" <{cell.X},{cell.Y}> ");
                Console.WriteLine();
            }
        }

        public void Copy(Peta other)
        {
            map.Clear();
            Start = other.Start;
            numTreasure = other.numTreasure;
            foreach( List<Cell> row in other.map)
            {
                List<Cell> temp = new List<Cell>();

                foreach(Cell cell in row)
                {
                    Cell tempCell = new Cell(cell);
                    temp.Add(tempCell);
                }
                map.Add(temp);
            }
        }

        
    }
}
