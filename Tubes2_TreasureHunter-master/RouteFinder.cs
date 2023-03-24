using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeHunter
{

    
    internal abstract class RouteFinder
    {
        protected Peta DynamicPeta;
        protected Peta peta;
        public Peta PetaAccessor { get { return peta; } }
        protected Route solusi;


        public RouteFinder()
        {
            peta = new Peta();
            DynamicPeta = new Peta();
            solusi = new Route();
        }
        public Route Solusi { get { return solusi; } }
        public abstract void Solve(bool TSP);
        public void readFrom(string input)
        {
            peta.readFrom(input);
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
