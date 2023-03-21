using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Tubes2_TreasureHunter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RouteFinder routeFinder = new BFS();
            Peta test = new Peta();
            test.readFrom("test.txt");
            
            //routeFinder.readFrom("test.txt");
            //routeFinder.Solve();
            //routeFinder.Solusi.PrintRoute();
        }

        
    }

    
}
