using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Area
    {
        public Position From;
        public Position To;

        public int GetHeight()
        {
            return To.newPos.y - From.newPos.y + 1;
        }

        public int GetWidth()
        {
            return To.newPos.x - From.newPos.x + 1;
        }

        public Area SetArea(int startX, int startY, int height, int width)
        {
            Area ar = new Area();
            ar.From.newPos.x = startX;
            ar.From.oldPos.x = startX;
            ar.From.newPos.y = startY;
            ar.From.oldPos.y = startY;

            ar.To.newPos.x = startX + width - 1;
            ar.To.oldPos.x = startX + width - 1;
            ar.To.newPos.y = startY + height - 1;
            ar.To.oldPos.y = startY + height - 1;

            return ar;
        }

        public void MoveNew (int x, int y)
        {
            From.newPos.x += x * 2;
            From.newPos.y += y;

            To.newPos.x += x * 2;
            To.newPos.y += y;
        }

    }
}
