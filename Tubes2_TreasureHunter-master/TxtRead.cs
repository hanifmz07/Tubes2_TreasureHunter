using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tubes2_TreasureHunter
{
    public class TxtRead
    {
        private List<List<char>> map;
        private int size;
        public TxtRead(string file)
        {
            
            size = 0;
            List<List<char>> map = new List<List<char>>();
                Console.WriteLine("Hello");
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    List<char> row = new List<char>();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == 'K' || line[i] == 'T' || line[i] == 'R' || line[i] == 'X')
                        {

                            row.Add(line[i]);
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
                foreach (List<char> line in map)
                {
                    foreach (char character in line)
                        Console.WriteLine(character);
                }
            }
        }

        //Array copy
}
