using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class DFS : RouteFinder
    {
        private Peta dynamic_peta;
        public DFS()
        {
            peta = new Peta();
            solusi = new Route();
            dynamic_peta = new Peta();
        }
        private Stack<(Cell, Route)> stack;

        //DFS prioritize desc right down left up

        public override void Solve(bool TSP)
        {
            bool repeat = TSP;
            dynamic_peta.Copy(peta);
            stack = new Stack<(Cell, Route)>();
            stack.Push((dynamic_peta.Start, new Route()));
            int count = peta.NumTreasure;

            while (count > 0 && stack.Count > 0)
            {
                (Cell, Route) accessing = stack.Pop();
                Route temp = new Route(accessing.Item2);
                temp.AddCell(accessing.Item1);
                if (accessing.Item1.Type == 3)
                {
                    count--;
                    dynamic_peta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                    dynamic_peta[dynamic_peta.Start.X, dynamic_peta.Start.Y].Type = 2;
                    dynamic_peta.Start = dynamic_peta[accessing.Item1.X, accessing.Item1.Y];

                    dynamic_peta.Inaccess();
                    if (count <= 0)
                    {
                        if (repeat)
                        {
                            count++;
                            dynamic_peta[peta.Start.X, peta.Start.Y].Type = 3;
                            dynamic_peta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                            dynamic_peta[dynamic_peta.Start.X, dynamic_peta.Start.Y].Type = 2;
                            dynamic_peta.Start = dynamic_peta[accessing.Item1.X, accessing.Item1.Y];
                            repeat = false;
                            Console.WriteLine("Masuk");
                            stack.Clear();
                            stack.Push((dynamic_peta.Start, accessing.Item2));
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
                        stack.Push((dynamic_peta.Start, accessing.Item2));
                    }
                }
                else //type ==2
                {
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !dynamic_peta[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            stack.Push((dynamic_peta[accessing.Item1.X, accessing.Item1.Y - 1], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !dynamic_peta[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            stack.Push((dynamic_peta[accessing.Item1.X, accessing.Item1.Y + 1], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !dynamic_peta[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((dynamic_peta[accessing.Item1.X - 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !dynamic_peta[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((dynamic_peta[accessing.Item1.X + 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }
                }
                dynamic_peta[accessing.Item1.X, accessing.Item1.Y].Accessed = true;
            }
        }
    }
}
