using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class CollisionChecker
    {


        public bool CheckCollision(GameRoom level, GameObject moovingObj, out int collisionIndex)
        {
            // возвращает булевое значение которое указывает было ли столкновение
            // и Out-ит индекс обьекта с которым и было непосредственное столкновение 

            bool isFaced = false;
            collisionIndex = 0;

            for (int i = 0; i <= level.lastObjectIndex; i++)
            {
                if (moovingObj.IsActive && level.gameObj[i].IsActive)
                {
                    if (i == moovingObj.Index) // проверка на то, не проверяем ли мы игровой обьект с самим собой
                    {
                        continue;
                    }

                    if (IsFaced(moovingObj, level.gameObj[i]))
                    {

                        collisionIndex = i;
                        isFaced = true;
                        break;
                    }
                }
            }


            return isFaced;
        }

        //private bool IsFaced (GameObject moovingObg, GameObject checkingObg)
        //{
        //    //возвращает булевую переменную указывающую произошло ли столкновение двух игровых обьектов
        //    bool isFaced = false;

        //    if (IsFaceOnBack(moovingObg, checkingObg))
        //    {
        //        isFaced = true;
        //    }

        //    isFaced = false;

        //    return isFaced;
        //}

        private bool IsChangedPos(GameObject gameObj)
        {
            //bool isChange = true;

            //if (gameObj.area.From.newPosX == gameObj.area.From.oldPosX
            //    && gameObj.area.From.newPosY == gameObj.area.From.oldPosY)
            //{
            //    isChange = false;
            //}

            //return isChange;

            return !((gameObj.ObjArea.From.newPos.x == gameObj.ObjArea.From.oldPos.x
                && gameObj.ObjArea.From.newPos.y == gameObj.ObjArea.From.oldPos.y));
        }

        #region BlackMagicRegion

        private bool IsFaced(GameObject objFace, GameObject objBack)
        {
            //возвращает true если "передняя" часть обьекта находится на той же что и "спина" другого обьекта 
            bool isFaced = false;

            Direction faceDir;
            Direction backDir;

            Coordinate[] facePos;
            Coordinate[] backPos;

            FindFaceAndBack(objFace, out faceDir, out backDir);
            facePos = GetSide(objFace, faceDir);
            backPos = GetSide(objBack, backDir);

            for (int i = 0; i < facePos.Length; i++)
            {
                for (int y = 0; y < backPos.Length; y++)
                {
                    if (facePos[i].Equals(backPos[y]))
                    {
                        isFaced = true;
                        break;
                    }
                }
            }

            return isFaced;
        }

        private void FindFaceAndBack(GameObject objFace, out Direction face, out Direction back)
        {

            face = FindMoveDirection(objFace);
            back = Direction.None;

            switch (face)
            {
                case Direction.Top:
                    back = Direction.Down;
                    break;
                case Direction.Down:
                    back = Direction.Top;
                    break;
                case Direction.Left:
                    back = Direction.Right;
                    break;
                case Direction.Right:
                    back = Direction.Left;
                    break;
                default:
                case Direction.None:
#if DEBUG
                   // GameLogger.AddLog(ref Program.log, "В методе поиска на");
#endif
                    break;
            }
        }

        private Direction FindMoveDirection(GameObject gameObj)
        {
            Direction dir = Direction.None;

            if (gameObj.ObjArea.From.newPos.x > gameObj.ObjArea.From.oldPos.x)
            {
                dir = Direction.Right;
            }
            else if (gameObj.ObjArea.From.newPos.x < gameObj.ObjArea.From.oldPos.x)
            {
                dir = Direction.Left;
            }
            else if (gameObj.ObjArea.From.newPos.y > gameObj.ObjArea.From.oldPos.y)
            {
                dir = Direction.Down;
            }
            else if (gameObj.ObjArea.From.newPos.y < gameObj.ObjArea.From.oldPos.y)
            {
                dir = Direction.Top;
            }

            return dir;
        }

        private Coordinate[] GetSide(GameObject gameObj, Direction dir)
        {
            Coordinate[] side;

            switch (dir)
            {
                case Direction.Top:
                    side = new Coordinate[gameObj.ObjArea.To.newPos.x - gameObj.ObjArea.From.newPos.x + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new Coordinate { y = gameObj.ObjArea.From.newPos.y, x = gameObj.ObjArea.From.newPos.x + i };
                    }
                break;
                case Direction.Down:
                    side = new Coordinate[gameObj.ObjArea.To.newPos.x - gameObj.ObjArea.From.newPos.x + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new Coordinate { y = gameObj.ObjArea.To.newPos.y, x = gameObj.ObjArea.From.newPos.x + i };
                    }
                    break;
                case Direction.Left:
                    side = new Coordinate[gameObj.ObjArea.To.newPos.y - gameObj.ObjArea.From.newPos.y + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new Coordinate { y = gameObj.ObjArea.From.newPos.y + i, x = gameObj.ObjArea.From.newPos.x};
                    }
                    break;
                case Direction.Right:
                    side = new Coordinate[gameObj.ObjArea.To.newPos.y - gameObj.ObjArea.From.newPos.y + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new Coordinate { y = gameObj.ObjArea.From.newPos.y + i, x = gameObj.ObjArea.To.newPos.x };
                    }
                    break;
                default:
                case Direction.None:
                    side = new Coordinate[0];
                    //side[0] = new Coordinate { x = gameObj.ObjArea.From.newPos.x, y = gameObj.ObjArea.From.newPos.y };
#if DEBUG
                   //GameLogger.AddLog(ref Program.log, "In Function CollisionCh");
#endif
                break;

            }

            return side;
        }

        #endregion

    }
}
