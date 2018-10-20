using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class LandscapeConstructor
    {
        public GameObject[] Labyrinth()
        {
            GameObject[] myLabyrinth = new GameObject[1];
            myLabyrinth[0] = new GameObject();
            myLabyrinth[0].area = new Area().SetArea(1, 8, 2, 20);
            myLabyrinth[0].teg = Tegs.NonToucher;
            myLabyrinth[0].viev = "#########################################################################################";

            return myLabyrinth;
        }
    }
}
