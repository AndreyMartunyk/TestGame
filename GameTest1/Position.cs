using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Position
    {
        public int oldPosX;
        public int oldPosY;
        public int newPosX;
        public int newPosY;
        //сделать одну на основе другой
    }

    public struct Coordinate
        //rename coordinate
    {
        public int x;
        public int y;
    }

    public class PositionCl
    {
        public static void Move(ref GameRoom level, ref GameObject gameObject, int indexGameObj, Direction dir, int countMove = 1)
        {
            switch (dir)
            {
                case Direction.Top:
                    gameObject.area.From.newPosY -= countMove;
                    gameObject.area.To.newPosY -= countMove;
                    break;
                case Direction.Down:
                    gameObject.area.From.newPosY += countMove;
                    gameObject.area.To.newPosY += countMove;
                    break;
                case Direction.Left:
                    gameObject.area.From.newPosX -= countMove * 2;
                    gameObject.area.To.newPosX -= countMove * 2;
                    break;
                case Direction.Right:
                    gameObject.area.From.newPosX += countMove * 2;
                    gameObject.area.To.newPosX += countMove * 2;
                    break;
                default:
                    break;     
            }

            CollisionChecker collChecker = new CollisionChecker();
            if (collChecker.CheckCollision(ref level, gameObject, indexGameObj) != GameEvents.NoneEvent)
            {
                PositionCl.GetBackPos(ref gameObject);
            }

        }

        public static void MovePos(ref Position pos, Direction dir)
        {
            switch (dir)
            {
                case Direction.Top:
                    pos.newPosY -= 1; 
                    break;
                case Direction.Down:
                    pos.newPosY += 1;
                    break;
                case Direction.Left:
                    pos.newPosX -= 2;
                    break;
                case Direction.Right:
                    pos.newPosX += 2;
                    break;
                default:
                    break;
            }
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
            NewToOld(ref gameObject.area.From);
            NewToOld(ref gameObject.area.To);
   
        }

        public static void NewToOld (ref Position pos)
        {
            pos.oldPosX = pos.newPosX;
            pos.oldPosY = pos.newPosY;
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
            if (gameObject.area.From.newPosX <= overflowArea.From.newPosX 
                || gameObject.area.To.newPosX >= overflowArea.To.newPosX)
            {
                GetBackPos(ref gameObject);
            }
            if (gameObject.area.From.newPosY <= overflowArea.From.newPosY
                || gameObject.area.To.newPosY >= overflowArea.To.newPosY -1)
            {
                GetBackPos(ref gameObject);
            }

        }

        // методы выше и ниже не связаны - это может потянуть на себя ошибки в будующем
        // в идеале перегруженный метод более высокого уровня должен исспользовать тот что меньшего уровня

        public static void CheckOverflow (ref Position pos, Area overflowArea)
        {
            if (pos.newPosX >= overflowArea.To.newPosX || pos.newPosX <= overflowArea.From.newPosX)
            {
                pos.newPosX = pos.oldPosX;
            }

            if (pos.newPosY <= overflowArea.From.newPosY || pos.newPosY >= overflowArea.To.newPosY - 1)
            {
                pos.newPosY = pos.oldPosY;
            }
        }

        public static void GetBackPos (ref GameObject gameObject)
        {
            gameObject.area.From.newPosX = gameObject.area.From.oldPosX;
            gameObject.area.To.newPosX = gameObject.area.To.oldPosX;
            gameObject.area.From.newPosY = gameObject.area.From.oldPosY;
            gameObject.area.To.newPosY = gameObject.area.To.oldPosY;
        }
    }
}
