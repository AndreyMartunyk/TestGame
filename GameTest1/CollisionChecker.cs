using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class CollisionChecker
    {
        public GameEvents CheckCollision(ref GameRoom level, GameObject moovingObj, int indexGameObj)
        {
            GameEvents collisionEvent = GameEvents.NoneEvent;

            for (int i = 0; i < level.countOfObjects; i++)
            {
                if (i == indexGameObj) // проверка на то, не проверяем ли мы игровой обьект с самим собой
                {
                    continue;
                }

                if (IsFaceOnBack(moovingObj, level.gameObj[i]))
                {
                    collisionEvent = GameEvents.CollisionObject;
                        
                    if (moovingObj.teg == Tegs.Player && level.gameObj[i].teg == Tegs.DamageToucher)
                    {
                        moovingObj.HP -= level.gameObj[i].damage;
                        collisionEvent = GameEvents.CollisionEnemy;
#if DEBUG
                        GameLogger.AddLog(ref Program.log,
                            string.Format("Player damaged from enemy on {0}", level.gameObj[i].damage));
#endif
                    }
                    else if (moovingObj.teg == Tegs.DamageToucher && level.gameObj[i].teg == Tegs.Player)
                    {
                        moovingObj.HP -= level.gameObj[i].damage;
                        collisionEvent = GameEvents.CollisionEnemy;

#if DEBUG
                        GameLogger.AddLog(ref Program.log,
                            string.Format("Enemy attack player on {0}", level.gameObj[i].damage));
#endif
                    }



                    //PositionCl.GetBackPos(ref moovingObj);
                    break;
                }
            }


            return collisionEvent;
        }

        private bool IsChangedPos(GameObject gameObj)
        {
            //bool isChange = true;

            //if (gameObj.area.From.newPosX == gameObj.area.From.oldPosX
            //    && gameObj.area.From.newPosY == gameObj.area.From.oldPosY)
            //{
            //    isChange = false;
            //}

            //return isChange;

            return !((gameObj.area.From.newPosX == gameObj.area.From.oldPosX
                && gameObj.area.From.newPosY == gameObj.area.From.oldPosY));
        }

        private bool IsFaceOnBack(GameObject objFace, GameObject objBack)
        {
            //возвращает true если "передняя" часть обьекта находится на той же что и "спина" другого обьекта 
            bool isFaced = false;

            Direction faceDir;
            Direction backDir;
            FindFaceAndBack(objFace, out faceDir, out backDir);

            SimplePos[] facePos = GetSide(objFace, faceDir);
            SimplePos[] backPos = GetSide(objBack, backDir);

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
                    GameLogger.AddLog(ref Program.log, "В методе поиска направления обьекта ничего не нашло");
#endif
                    break;
            }
        }

        private Direction FindMoveDirection(GameObject gameObj)
        {
            Direction dir = Direction.None;

            if (gameObj.area.From.newPosX > gameObj.area.From.oldPosX)
            {
                dir = Direction.Right;
            }
            else if (gameObj.area.From.newPosX < gameObj.area.From.oldPosX)
            {
                dir = Direction.Left;
            }
            else if (gameObj.area.From.newPosY > gameObj.area.From.oldPosY)
            {
                dir = Direction.Down;
            }
            else if (gameObj.area.From.newPosY < gameObj.area.From.oldPosY)
            {
                dir = Direction.Top;
            }

            return dir;
        }

        private SimplePos[] GetSide(GameObject gameObj, Direction dir)
        {
            SimplePos[] side;

            switch (dir)
            {
                case Direction.Top:
                    side = new SimplePos[gameObj.area.To.newPosX - gameObj.area.From.newPosX + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new SimplePos { y = gameObj.area.From.newPosY, x = gameObj.area.From.newPosX + i };
                    }
                break;
                case Direction.Down:
                    side = new SimplePos[gameObj.area.To.newPosX - gameObj.area.From.newPosX + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new SimplePos { y = gameObj.area.To.newPosY, x = gameObj.area.From.newPosX + i };
                    }
                    break;
                case Direction.Left:
                    side = new SimplePos[gameObj.area.To.newPosY - gameObj.area.From.newPosY + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new SimplePos { y = gameObj.area.From.newPosY + i, x = gameObj.area.From.newPosX};
                    }
                    break;
                case Direction.Right:
                    side = new SimplePos[gameObj.area.To.newPosY - gameObj.area.From.newPosY + 1];
                    for (int i = 0; i < side.Length; i++)
                    {
                        side[i] = new SimplePos { y = gameObj.area.From.newPosY + i, x = gameObj.area.To.newPosX };
                    }
                    break;
                default:
                case Direction.None:
                    side = new SimplePos[0];
#if DEBUG
                    GameLogger.AddLog(ref Program.log, "In Function CollisionChecker.GetSide switch get none or default");
#endif
                break;

            }

            return side;
        }

    }
}
