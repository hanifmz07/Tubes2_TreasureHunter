using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class BFS : RouteFinder
    {

        private Peta dynamic_peta;
        public BFS(){
            peta = new Peta();
            solusi = new Route();
            dynamic_peta = new Peta();
        }
        private Queue<(Cell, Route)> queue;


        //BFS prioritize desc right down left up

        public override void Solve(bool TSP)
        {
            bool repeat = TSP;
            dynamic_peta.Copy(peta);
            queue = new Queue<(Cell,Route)>();
            queue.Enqueue((dynamic_peta.Start, new Route()));
            int count = peta.NumTreasure;
            while (count > 0 && queue.Count > 0) 
            {

                
                
                
                (Cell,Route) accessing = queue.Dequeue();
                Route temp = new Route(accessing.Item2);
                temp.AddCell(accessing.Item1);
                if(accessing.Item1.Type == 3) {
                    count--;
                        
                    dynamic_peta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                    dynamic_peta[dynamic_peta.Start.X, dynamic_peta.Start.Y].Type = 2;
                    dynamic_peta.Start = dynamic_peta[accessing.Item1.X, accessing.Item1.Y];
                    //empty queue
                    dynamic_peta.Inaccess();
                    if(count <= 0) {
                        
                        if (repeat)
                        {
                            count++;
                            dynamic_peta[peta.Start.X, peta.Start.Y].Type = 3;
                            dynamic_peta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                            dynamic_peta[dynamic_peta.Start.X, dynamic_peta.Start.Y].Type = 2;
                            dynamic_peta.Start = dynamic_peta[accessing.Item1.X, accessing.Item1.Y];
                            repeat = false;
                            Console.WriteLine("Masuk");
                            queue.Clear();
                            queue.Enqueue((dynamic_peta.Start, accessing.Item2));
                        }
                        else
                        {
                            solusi.Copy(temp);
                            queue.Clear();
                        }
                    }
                    else
                    {
                        queue.Clear();
                        queue.Enqueue((dynamic_peta.Start, accessing.Item2));
                    }

                }
                else//type ==2
                {
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !dynamic_peta[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((dynamic_peta[accessing.Item1.X + 1, accessing.Item1.Y], temp));
                        }
                    }catch (Exception e) { }//ignore
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !dynamic_peta[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((dynamic_peta[accessing.Item1.X - 1, accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !dynamic_peta[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {
                            queue.Enqueue((dynamic_peta[accessing.Item1.X, accessing.Item1.Y + 1], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                    try
                    {
                        if (dynamic_peta[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !dynamic_peta[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            queue.Enqueue((dynamic_peta[accessing.Item1.X, accessing.Item1.Y - 1], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                }

                dynamic_peta[accessing.Item1.X, accessing.Item1.Y].Accessed = true;
            }
        }
    }
}
