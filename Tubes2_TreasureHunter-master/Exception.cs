using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeHunter
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
