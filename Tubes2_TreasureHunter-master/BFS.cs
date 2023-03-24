using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MazeHunter
{
    internal class BFS : RouteFinder
    {

        private Peta DynamicPeta { get; set; }
        public BFS(){
            peta = new Peta();
            solusi = new Route();
            DynamicPeta = new Peta();
        }
        private Queue<(Cell, Route)> queue { get; set; }


        //BFS prioritize desc right down left up

        public override void Solve(bool TSP)
        {
            bool repeat = TSP;
            DynamicPeta.Copy(peta);
            queue = new Queue<(Cell,Route)>();
            queue.Enqueue((DynamicPeta.Start, new Route()));
            int count = DynamicPeta.NumTreasure;
            while (count > 0 && queue.Count > 0) 
            {
                
                (Cell,Route) accessing = queue.Dequeue();
                Route temp = new Route(accessing.Item2);
                temp.AddCell(accessing.Item1);
                if(accessing.Item1.Type == 3) {
                    count--;
                    accessing.Item1.NumAccessed++;
                    DynamicPeta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                    DynamicPeta[DynamicPeta.Start.X, DynamicPeta.Start.Y].Type = 2;
                    DynamicPeta.Start = DynamicPeta[accessing.Item1.X, accessing.Item1.Y];
                    //empty queue
                    DynamicPeta.Inaccess();
                    if(count <= 0) {
                        
                        if (repeat)
                        {
                            count++;
                            DynamicPeta[peta.Start.X, peta.Start.Y].Type = 3;
                            DynamicPeta[accessing.Item1.X, accessing.Item1.Y].Type = 0;
                            DynamicPeta[DynamicPeta.Start.X, DynamicPeta.Start.Y].Type = 2;
                            DynamicPeta.Start = DynamicPeta[accessing.Item1.X, accessing.Item1.Y];
                            repeat = false;
                            Console.WriteLine("Masuk");
                            queue.Clear();
                            queue.Enqueue((DynamicPeta.Start, accessing.Item2));
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
                        queue.Enqueue((DynamicPeta.Start, accessing.Item2));
                    }

                }
                else//type ==2
                {
                    try
                    { // 
                        if (DynamicPeta[accessing.Item1.X + 1, accessing.Item1.Y].Type > 1 && !DynamicPeta[accessing.Item1.X + 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((DynamicPeta[accessing.Item1.X + 1, accessing.Item1.Y], temp));
                        }
                    }catch (Exception e) { }//ignore
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X, accessing.Item1.Y - 1].Type > 1 && !DynamicPeta[accessing.Item1.X, accessing.Item1.Y - 1].Accessed)
                        {
                            queue.Enqueue((DynamicPeta[accessing.Item1.X, accessing.Item1.Y - 1], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X - 1, accessing.Item1.Y].Type > 1 && !DynamicPeta[accessing.Item1.X - 1, accessing.Item1.Y].Accessed)
                        {
                            queue.Enqueue((DynamicPeta[accessing.Item1.X - 1 , accessing.Item1.Y], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
                    try
                    {
                        if (DynamicPeta[accessing.Item1.X, accessing.Item1.Y + 1].Type > 1 && !DynamicPeta[accessing.Item1.X, accessing.Item1.Y + 1].Accessed)
                        {

                            queue.Enqueue((DynamicPeta[accessing.Item1.X, accessing.Item1.Y + 1], temp));
                        }
                    }
                    catch (Exception e) { }//ignore
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
