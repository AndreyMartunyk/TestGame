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
        const int DEFAULT_ARRAY_LENGTH = 500;
        //current obj?????

        public void CreateLevelStorage() // arrayLength - размер массива GameObject[]
        {

            gameObj = new GameObject[DEFAULT_ARRAY_LENGTH];
            countOfObjects = 0;
        }

        public void AddGameObject(GameObject addingObject)
        {
            gameObj[countOfObjects] = addingObject;
            gameObj[countOfObjects].Index = countOfObjects;
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

        public int FindPlayerIndex()
        {
            // войвращает номер индекса игрока, если его нет то возвр. -1
            int playerIndex = -1;
            for (int i = 0; i < countOfObjects; i++)
            {
                if (gameObj[i].ObjTag == Tags.Player)
                {
                    playerIndex = i;
                    break;
                }
            }

            return playerIndex;
        }
    }


}
