using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeHunter
{
    internal class DFS : RouteFinder
    {
        public DFS()
        {
            peta = new Peta();
            solusi = new Route();
            DynamicPeta = new Peta();
        }
        private Peta DynamicPeta { get; set; }
        private Stack<(Cell, Route)> stack { get; set; }

        //DFS prioritize desc right down left up

        public override void Solve(bool TSP)
        {
            bool repeat = TSP;
            DynamicPeta.Copy(peta);
            stack = new Stack<(Cell, Route)>();
            stack.Push((DynamicPeta.Start, new Route()));
            int count = DynamicPeta.NumTreasure;

            while (count > 0 && stack.Count > 0)
            {
                (Cell, Route) accessing = stack.Pop();
                Route temp = new Route(accessing.Item2);
                temp.AddCell(accessing.Item1);
                if (accessing.Item1.Type == 3)
                {
                    count--;
                    accessing.Item1.NumAccessed++;
                    DynamicPeta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                    DynamicPeta[DynamicPeta.Start.X, DynamicPeta.Start.Y].Type = 2;
                    DynamicPeta.Start = DynamicPeta[accessing.Item1.X, accessing.Item1.Y];

                    DynamicPeta.Inaccess();
                    if (count <= 0)
                    {
                        if (repeat)
                        {
                            count++;
                            DynamicPeta[peta.Start.X, peta.Start.Y].Type = 3;
                            DynamicPeta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                            DynamicPeta[DynamicPeta.Start.X, DynamicPeta.Start.Y].Type = 2;
                            DynamicPeta.Start = DynamicPeta[accessing.Item1.X, accessing.Item1.Y];
                            repeat = false;
                            Console.WriteLine("Masuk");
                            stack.Clear();
                            stack.Push((DynamicPeta.Start, accessing.Item2));
                        }
                        else
                        {
                            solusi.Copy(temp);
                            stack.Clear();
                        }
                    }
                    else
                    {
                        stack.Clear();
                        stack.Push((DynamicPeta.Start, accessing.Item2));
                    }
                }
                else //type ==2
                {
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !DynamicPeta[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            stack.Push((DynamicPeta[accessing.Item1.X, accessing.Item1.Y - 1], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !DynamicPeta[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            stack.Push((DynamicPeta[accessing.Item1.X, accessing.Item1.Y + 1], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !DynamicPeta[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((DynamicPeta[accessing.Item1.X - 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !DynamicPeta[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((DynamicPeta[accessing.Item1.X + 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }
                    accessing.Item1.NumAccessed++;
                }
                DynamicPeta[accessing.Item1.X, accessing.Item1.Y].Accessed = true;
            }
        }
        public int SumNodesChecked()
        {
            int sumNodes = 0;
            for (int i = 0; i < DynamicPeta.GetNumRow(); i++)
            {
                for (int j = 0; j < DynamicPeta.GetNumCol(); j++)
                {
                    sumNodes += DynamicPeta.GetValue(j, i).NumAccessed;
                }
            }
            return sumNodes;
        }
    }
}
