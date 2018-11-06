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
            GameObject[] myLabyrinth = new GameObject[9];

            for (int i = 0; i < myLabyrinth.Length; i++)
            {
                myLabyrinth[i] = new GameObject();
                myLabyrinth[i].ObjTag = Tags.Stone;
                myLabyrinth[i].Viev = SViews.SHARP;
                myLabyrinth[i].Color = GameColors.Grey;
                myLabyrinth[i].BackColor = GameColors.DarkGrey;
            }
            myLabyrinth[0].ObjArea = new Area().SetArea(1, 8, 1, 21);
            myLabyrinth[1].ObjArea = new Area().SetArea(22, 8, 20, 3);
            myLabyrinth[2].ObjArea = new Area().SetArea(22, 30, 1, 17);
            myLabyrinth[3].ObjArea = new Area().SetArea(22, 31, 8, 3);
            myLabyrinth[4].ObjArea = new Area().SetArea(36, 5, 26, 3);
            myLabyrinth[5].ObjArea = new Area().SetArea(14, 5, 1, 22);
            myLabyrinth[6].ObjArea = new Area().SetArea(56, 6, 30, 3);
            myLabyrinth[7].ObjArea = new Area().SetArea(38, 36, 1, 21);
            myLabyrinth[5].ObjArea = new Area().SetArea(56, 5, 1, 22);

            return myLabyrinth;
        }
    }
}
