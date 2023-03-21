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

        public override void Solve()
        {
            Peta a = peta;
            queue = new Queue<(Cell,Route)>();
            queue.Enqueue((a.Start, solusi));
            int count = peta.NumTreasure;

            while (count > 0 && queue.Count>0) 
            {
                if (queue.Peek().Item1.Accessed)
                { 
                    queue.Dequeue();
                }
                else
                {
                    (Cell,Route) accessing = queue.Dequeue();
                    accessing.Item2.AddCell(accessing.Item1);
                    if(accessing.Item1.Type == 3) {
                        count--;
                        a[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                        a[a.Start.X, a.Start.Y].Type = 2;
                        a.Start = a[accessing.Item1.X, accessing.Item1.Y];
                        //empty queue
                        queue.Clear();
                        queue.Enqueue((a.Start, accessing.Item2));
                        a.Inaccess();
                        if(count <= 0) {
                            solusi = accessing.Item2;
                        }
                        else
                        {
                            queue.Clear();
                            queue.Enqueue((a.Start, accessing.Item2));
                        }

                    }
                    else//type ==2
                    {
                        if (a[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X + 1, accessing.Item1.Y], accessing.Item2));

                        }
                        if (a[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !a[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X - 1, accessing.Item1.Y], accessing.Item2));
                        }
                        if (a[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X, accessing.Item1.Y + 1], accessing.Item2));
                        }
                        if (a[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !a[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            queue.Enqueue((a[accessing.Item1.X, accessing.Item1.Y - 1], accessing.Item2));
                        }
                    }

                }






                    /*
                if (queue.Peek().Accessed)
                {
                    queue.Dequeue();
                }
                else
                {
                    Cell accessing = queue.Dequeue();
                    
                    

                    
                    if (peta[accessing.X + 1, accessing.Y].Type > 1  && !peta[accessing.X + 1, accessing.Y].Accessed)
                    {
                        queue.Enqueue(peta[accessing.X + 1, accessing.Y]);

                    }
                    if (peta[accessing.X - 1, accessing.Y].Type > 1 && !peta[accessing.X - 1, accessing.Y].Accessed)
                    {
                        queue.Enqueue(peta[accessing.X - 1, accessing.Y]);
                    }
                    if (peta[accessing.X, accessing.Y + 1].Type > 1 && !peta[accessing.X, accessing.Y + 1].Accessed)
                    {
                        queue.Enqueue(peta[accessing.X, accessing.Y + 1]);
                    }
                    if (peta[accessing.X, accessing.Y - 1].Type > 1 && !peta[accessing.X, accessing.Y - 1].Accessed)
                    {
                        queue.Enqueue(peta[accessing.X, accessing.Y - 1]);
                    }



                    if(accessing.Type == 3 && !accessing.Accessed)
                    {
                        count--;
                    }

                    accessing.Accessed = true;

                }
            */}
        }
    }
}
