using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{ 

    public struct GameMap
    {
        public string Name;
        public GameObject[] Doors;
        public GameObject[] ClearZones;
        public GameObject[] LandScape;

//        public GameObject GetClearZone(Direction dir)
//        {
//            GameObject clearZone = new GameObject();
//            clearZone.teg = Tegs.Zone;

//            switch (dir)
//            {
//                case Direction.Top:
//                    clearZone.area = new Area().SetArea(40, 0, 5, 10);
//                    break;
//                case Direction.Down:
//                    clearZone.area = new Area().SetArea(50, 35, 5, 10);
//                    break;
//                case Direction.Left:
//                    clearZone.area = new Area().SetArea(0, 15, 5, 10);
//                    break;
//                case Direction.Right:
//                    clearZone.area = new Area().SetArea(70, 20, 5, 10);
//                    break;
//                default:
//                case Direction.None:

//#if DEBUG
//                    GameLogger.AddLog(ref Program.log, "В методе GameMap.GetDoor свич попал в default иил None");

//#endif
//                    break;
//            }

//            return clearZone;
//        }

        public GameObject GetDoorZone(Direction dir)
        {
            GameObject doorZone = new GameObject();
            doorZone.teg = Tags.Zone;

            switch (dir)
            {
                case Direction.Top:
                    doorZone.area = new Area().SetArea(40, 0, 2, 10);
                    break;
                case Direction.Down:
                    doorZone.area = new Area().SetArea(50, 38, 2, 10);
                    break;
                case Direction.Left:
                    doorZone.area = new Area().SetArea(0, 15, 5, 2);
                    break;
                case Direction.Right:
                    doorZone.area = new Area().SetArea(78, 20, 5, 2);
                    break;
                default:
                case Direction.None:

#if DEBUG
                    GameLogger.AddLog(ref Program.log, "В методе GameMap.GetDoor свич попал в default иил None");

#endif
                    break;
            }

            return doorZone;
        }
    }
}
