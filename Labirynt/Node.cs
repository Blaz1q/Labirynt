using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt
{
    public class Node
    {
        public int Row;
        public int Col;

        public Node Parent;
        public int Distance = int.MaxValue;
        public bool Visited = false;
    }
}
