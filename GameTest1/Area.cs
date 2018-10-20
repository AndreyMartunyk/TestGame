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
            return To.newPosY - From.newPosY + 1;
        }

        public int GetWidth()
        {
            return To.newPosX - From.newPosX + 1;
        }

        public Area SetArea(int startX, int startY, int height, int width)
        {
            Area ar = new Area();
            ar.From.newPosX = startX;
            ar.From.oldPosX = startX;
            ar.From.newPosY = startY;
            ar.From.oldPosY = startY;

            ar.To.newPosX = startX + width - 1;
            ar.To.oldPosX = startX + width - 1;
            ar.To.newPosY = startY + height - 1;
            ar.To.oldPosY = startY + height - 1;

            return ar;
        }
    }
}
