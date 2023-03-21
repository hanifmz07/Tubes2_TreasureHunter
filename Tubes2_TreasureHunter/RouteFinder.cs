using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tubes2_TreasureHunter
{

    
    internal abstract class RouteFinder
    {
        
        protected Peta peta;
        public Peta PetaAccessor { get { return peta; } }
        protected Route solusi;


        public RouteFinder()
        {
            peta = new Peta();
            solusi = new Route();
        }
        public Route Solusi { get { return solusi; } }
        public abstract void Solve(bool TSP);
        public void readFrom(string input)
        {
            peta.readFrom(input);
        }

    }
}
