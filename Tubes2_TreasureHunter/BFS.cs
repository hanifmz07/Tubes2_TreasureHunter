using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    internal class BFS : RouteFinder
    { 
        private Queue<Cell> queue;


        //BFS prioritize desc right down left up

        public override void Solve()
        {
            queue = new Queue<Cell>();
            queue.Enqueue(peta.Start);
            int count = peta.NumTreasure;
            while (count > 0 && queue.Count>0) 
            {
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
            }
        }
    }
}
