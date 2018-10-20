using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct GameRoom
    {
        public GameObject[] gameObj;
        public int countOfObjects;
        private GameMap map;
        //current obj?????

        public void CreateLevelStorage(int arrayLength = 100) // arrayLength - размер массива GameObject[]
        {

            gameObj = new GameObject[arrayLength];
            countOfObjects = 0;
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObj[countOfObjects] = gameObject;
            ++countOfObjects;
        }

        public void AddMap(GameMap gameMap)
        {
            map = gameMap;
            for (int i = 0; i < map.LandScape.Length ; i++)
            {
                AddGameObject(map.LandScape[i]);
            }       
        }
    }


}
