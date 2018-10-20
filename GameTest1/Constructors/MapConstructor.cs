using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class MapConstructor
    {
        LandscapeConstructor lc = new LandscapeConstructor();

        public GameMap Tutorial_1()
        {
            GameMap tutorial_1 = new GameMap();
            tutorial_1.Name = "Tutorial_1";

            tutorial_1.Doors = new GameObject[2];
            tutorial_1.Doors[0] = tutorial_1.GetDoorZone(Direction.Left);
            tutorial_1.Doors[0] = tutorial_1.GetDoorZone(Direction.Right);

            tutorial_1.LandScape = lc.Labyrinth();

            return tutorial_1;
        }
    }
}
