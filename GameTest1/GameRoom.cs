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
        public int lastObjectIndex;
        private GameMap map;
        const int DEFAULT_ARRAY_LENGTH = 500;


        public void CreateLevelStorage() // arrayLength - размер массива GameObject[]
        {

            gameObj = new GameObject[DEFAULT_ARRAY_LENGTH];
            lastObjectIndex = -1;
        }

        public void AddGameObject(GameObject addingObject)
        {
            int index;
            if (FindFreePlace(out index))
            {
                gameObj[index] = addingObject;
                gameObj[index].Index = index;
                gameObj[index].IsActive = true;
                ++lastObjectIndex;
            }
            
        }

        public void DeleteGameObject(GameObject deletingObj)
        {
            gameObj[deletingObj.Index].IsActive = false;
            if (deletingObj.Index == lastObjectIndex)
            {
                --lastObjectIndex;
            }
            
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
            for (int i = 0; i <= lastObjectIndex; i++)
            {
                if (gameObj[i].ObjTag == Tags.Player)
                {
                    playerIndex = i;
                    break;
                }
            }

            return playerIndex;
        }

        private bool FindFreePlace(out int index)
        {
            bool success = false;
            index = 0;
            for (int i = 0; i < gameObj.Length; i++)
            {
                if (i > lastObjectIndex || !gameObj[i].IsActive)
                {
                    index = i;
                    success = true;
                    break;
                }
            }
            return success;
        }
    }


}
