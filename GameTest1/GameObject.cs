using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct GameObject
    {

        // TODO all fields to Camel case
        public string name;
        public Area area;
        public GameColors color;
        public float speed;
        public int HP;
        public int damage;
        public string viev;
        public Tegs teg;
    }

    public class GameObjectInit
    {

        private static GameObject CreateEmptyGameObject()
        {

            GameObject gameObject = new GameObject
            {
                name = "name",
                color = 0,
                speed = 0,
                HP = 0,
                damage = 0,
                viev = "#####################################",
                teg = Tegs.None,
                area = new Area
                {
                    From = new Position
                    {
                        newPosX = 0,
                        newPosY = 0,
                        oldPosX = 0,
                        oldPosY = 0
                    },
                    To = new Position
                    {
                        newPosX = 0,
                        newPosY = 0,
                        oldPosX = 0,
                        oldPosY = 0
                    }
                }
            };
            return gameObject;
        }

        public static GameObject CreateGameObject(Position from, Position to)
        {
            GameObject gameObject = CreateEmptyGameObject();
            gameObject.area.From = from;
            gameObject.area.To = to;

            return gameObject;
        }

        public static GameObject CreateGameObject(Area ar)
        {
            GameObject gameObject = CreateEmptyGameObject();
            gameObject.area = ar;

            return gameObject;
        }

        public static GameObject CreateGameObject(Area ar, string viev)
        {
            GameObject gameObject = CreateEmptyGameObject();
            gameObject.area = ar;
            gameObject.viev = viev;
            return gameObject;
        }

        //public static GameObject CreateGameObject(Position from, Position to, string viev, Tegs nameOfTeg)
        //{
        //    GameObject gameObject = CreateGameObject(new Area, viev);
        //    gameObject.teg = nameOfTeg;
        //    return gameObject;
        //}

        public static GameObject CreateGameObject(Area ar, string viev, Tegs nameOfTeg)
        {
            GameObject gameObject = CreateGameObject(ar, viev);
            gameObject.teg = nameOfTeg;
            return gameObject;
        }

        //public static GameObject CreateGameObject(int X, int Y, int xSize, int ySize, string viev, Tegs nameOfTeg)
        //{
        //    GameObject gameObject = CreateEmptyGameObject();
        //    gameObject.area.From = new Position
        //    {
        //        newPosX = X,
        //        newPosY = Y,
        //        oldPosX = X,
        //        oldPosY = Y
        //    };
        //    gameObject.area.To = new Position
        //    {
        //        newPosX = X + xSize,
        //        newPosY = Y + ySize,
        //        oldPosX = X + xSize,
        //        oldPosY = Y + ySize
        //    };
        //    gameObject.viev = viev;
        //    gameObject.teg = nameOfTeg;
        //    return gameObject;
        //}


    }


}
