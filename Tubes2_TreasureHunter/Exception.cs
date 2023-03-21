using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_TreasureHunter
{
    public class RowInconsistentException : Exception
    {
        public RowInconsistentException() : base() { }
    }
    public class InvalidCharacterException : Exception 
    {
        public InvalidCharacterException() : base() { }
    }
}
