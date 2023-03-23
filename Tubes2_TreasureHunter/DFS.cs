using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class DFS : RouteFinder
    {
        public DFS()
        {
            peta = new Peta();
            solusi = new Route();
        }
        private Stack<(Cell, Route)> stack;

        //DFS prioritize desc right down left up

        public override void Solve(bool TSP)
        {
            Peta a = new Peta();
            bool repeat = TSP;
            a.Copy(peta);
            stack = new Stack<(Cell, Route)>();
            stack.Push((a.Start, new Route()));
            int count = peta.NumTreasure;

            while (count > 0 && stack.Count > 0)
            {
                (Cell, Route) accessing = stack.Pop();
                Route temp = new Route(accessing.Item2);
                temp.AddCell(accessing.Item1);
                if (accessing.Item1.Type == 3)
                {
                    count--;
                    a[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                    a[a.Start.X, a.Start.Y].Type = 2;
                    a.Start = a[accessing.Item1.X, accessing.Item1.Y];

                    a.Inaccess();
                    if (count <= 0)
                    {
                        if (repeat)
                        {
                            count++;
                            a[peta.Start.X, peta.Start.Y].Type = 3;
                            a[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                            a[a.Start.X, a.Start.Y].Type = 2;
                            a.Start = a[accessing.Item1.X, accessing.Item1.Y];
                            repeat = false;
                            Console.WriteLine("Masuk");
                            stack.Clear();
                            stack.Push((a.Start, accessing.Item2));
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
                        stack.Push((a.Start, accessing.Item2));
                    }
                }
                else //type ==2
                {
                    try
                    {
                        if (a[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X, accessing.Item1.Y - 1], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (a[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X, accessing.Item1.Y + 1], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (a[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X - 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }
                    try
                    {
                        if (a[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X + 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }
                }
                a[accessing.Item1.X, accessing.Item1.Y].Accessed = true;
            }
        }
    }
}
