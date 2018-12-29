using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Coordinate
    {
        public int x;
        public int y;

        public bool MyEquals (Coordinate coord)
        {
            return ((x == coord.x) && (y == coord.y));
        }
    }
}
