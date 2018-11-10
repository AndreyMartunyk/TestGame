using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Position
    {
        public Coordinate oldPos;
        public Coordinate newPos;


        public Position SetPosition(int x, int y)
        {
            Position pos = new Position();
            pos.oldPos.x = x;
            pos.oldPos.y = y;
            pos.newPos.x = x;
            pos.newPos.y = y;
            return pos;
        }
    }

 

    public class PositionCl
    {
        public static void Move(ref GameRoom level, ref GameObject moovingObject, Direction dir, int countMove = 1)
        {
            switch (dir)
            {
                case Direction.Top:
                    moovingObject.ObjArea.MoveNew(0, -countMove);
                    break;
                case Direction.Down:
                    moovingObject.ObjArea.MoveNew(0, countMove);
                    break;
                case Direction.Left:
                    moovingObject.ObjArea.MoveNew(-countMove , 0);;
                    break;
                case Direction.Right:
                    moovingObject.ObjArea.MoveNew(countMove, 0);
                    break;
                default:
                    break;     
            }

            new CollisionChecker().RespondToCollision(ref level, ref moovingObject);

            //CollisionChecker collChecker = new CollisionChecker();

            //if (collChecker.CheckCollision(ref level, moovingObject) != GameEvents.NoneEvent)
            //{
            //    PositionCl.GetBackPos(ref moovingObject);
            //}

        }

        public static void NewToOld(ref GameRoom level)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                NewToOld(ref level.gameObj[i]);     
            }
        }

        public static void NewToOld(ref GameObject gameObject)
        {
            NewToOld(ref gameObject.ObjArea.From);
            NewToOld(ref gameObject.ObjArea.To);
   
        }

        public static void NewToOld (ref Position pos)
        {
            pos.oldPos.x = pos.newPos.x;
            pos.oldPos.y = pos.newPos.y;
        }

        public static void CheckOverflow(ref GameRoom level, Area overflowArea)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                CheckOverflow(ref level.gameObj[i], overflowArea);
            }
        }

        public static void CheckOverflow(ref GameObject gameObject, Area overflowArea)
        {
            //overflowArea переменная определяющая поле в котором МОЖЕТ находится gameObject
            if (gameObject.ObjArea.From.newPos.x <= overflowArea.From.newPos.x 
                || gameObject.ObjArea.To.newPos.x >= overflowArea.To.newPos.x)
            {
                GetBackPos(ref gameObject);
            }
            if (gameObject.ObjArea.From.newPos.y <= overflowArea.From.newPos.y
                || gameObject.ObjArea.To.newPos.y >= overflowArea.To.newPos.y -1)
            {
                GetBackPos(ref gameObject);
            }

        }

        // методы выше и ниже не связаны - это может потянуть на себя ошибки в будующем
        // в идеале перегруженный метод более высокого уровня должен исспользовать тот что меньшего уровня

        public static void CheckOverflow (ref Position pos, Area overflowArea)
        {
            if (pos.newPos.x >= overflowArea.To.newPos.x || pos.newPos.x <= overflowArea.From.newPos.x)
            {
                pos.newPos.x = pos.oldPos.x;
            }

            if (pos.newPos.y <= overflowArea.From.newPos.y || pos.newPos.y >= overflowArea.To.newPos.y - 1)
            {
                pos.newPos.y = pos.oldPos.y;
            }
        }

        public static void GetBackPos (ref GameObject gameObject)
        {
            gameObject.ObjArea.From.newPos.x = gameObject.ObjArea.From.oldPos.x;
            gameObject.ObjArea.To.newPos.x = gameObject.ObjArea.To.oldPos.x;
            gameObject.ObjArea.From.newPos.y = gameObject.ObjArea.From.oldPos.y;
            gameObject.ObjArea.To.newPos.y = gameObject.ObjArea.To.oldPos.y;
        }
    }
}
