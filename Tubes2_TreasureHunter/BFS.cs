using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class BFS : RouteFinder
    { 
        public BFS(){
            peta = new Peta();
            solusi = new Route();
        }
        private Queue<(Cell, Route)> queue;


        //BFS prioritize desc right down left up

        public override void Solve(bool TSP)
        {
            Peta a = new Peta();
            a.Copy(peta);
            queue = new Queue<(Cell,Route)>();
            queue.Enqueue((a.Start, new Route()));
            int count = peta.NumTreasure;
            while (count > 0 && queue.Count > 0) 
            {

                
                
                
                (Cell,Route) accessing = queue.Dequeue();
                Route temp = new Route(accessing.Item2);
                temp.AddCell(accessing.Item1);
                if(accessing.Item1.Type == 3) {
                    count--;
                        
                    a[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                    a[a.Start.X, a.Start.Y].Type = 2;
                    a.Start = a[accessing.Item1.X, accessing.Item1.Y];
                    //empty queue
                    a.Inaccess();
                    if(count <= 0) {
                        solusi.Copy(temp);
                        //accessing.Item2.PrintRoute();
                        //solusi.PrintRoute();
                        queue.Clear();
                    }
                    else
                    {
                        queue.Clear();
                        queue.Enqueue((a.Start, accessing.Item2));
                    }

                }
                else//type ==2
                {
                    try
                    {
                        if (a[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X + 1, accessing.Item1.Y], temp));
                        }
                    }catch (Exception e) { }//ignore
                    try
                    {
                        if (a[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X - 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                    try
                    {
                        if (a[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X, accessing.Item1.Y + 1], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                    try
                    {
                        if (a[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X, accessing.Item1.Y - 1], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                }

                a[accessing.Item1.X, accessing.Item1.Y].Accessed = true;
            }
        }
    }
}
