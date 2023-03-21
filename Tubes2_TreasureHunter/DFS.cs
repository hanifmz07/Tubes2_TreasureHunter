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

        public override void Solve()
        {
            Peta a = peta;
            stack = new stack<(Cell, Route)>();
            stack.Push((a.Start, solusi));
            int count = peta.NumTreasure;

            while (count > 0 && stack.Count > 0)
            {
                (Cell, Route) accessing = stack.Pop();
                accessing.Item2.AddCell(accessing.Item1);
                if (!(stack.Peek().Item1.Accessed))
                {
                    if (accessing.Item1.Type == 3)
                    {
                        count--;
                        a[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                        a[a.Start.X, a.Start.Y].Type = 2;
                        a.Start = a[accessing.Item1.X, accessing.Item1.Y];
                        //empty stack
                        a.Inaccess();
                        if (count <= 0)
                        {
                            solusi = accessing.Item2;
                        }
                        else
                        {
                            stack.Clear();
                            stack.Push((a.Start, accessing.Item2));
                        }

                    }
                    else //type ==2
                    {
                        if (a[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X, accessing.Item1.Y - 1], accessing.Item2));
                        }
                        if (a[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X, accessing.Item1.Y + 1], accessing.Item2));
                        }
                        if (a[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X - 1, accessing.Item1.Y], accessing.Item2));
                        }
                        if (a[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            stack.Push((a[accessing.Item1.X + 1, accessing.Item1.Y], accessing.Item2));
                        }
                    }
                }
            }
        }
    }
}
