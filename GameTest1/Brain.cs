using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Brain
    {

        public void SetPlayerDecision(GameRoom level, UnitActions action)
        {
            level.gameObj[level.FindPlayerIndex()].Action = action;
        }

        public void MakeDecision(ref GameRoom level, Direction dir = Direction.None)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                MakeDecision(level, ref level.gameObj[i], dir);
            }
        }


        public void MakeDecision(GameRoom level, ref GameObject thinkingObject, Direction dir = Direction.None)
        {
            UnitActions action = UnitActions.None;

            switch (thinkingObject.ObjTag)
            {

                case Tags.Player:
                    action = thinkingObject.Action;
                    break;
                case Tags.DamageToucher:
                case Tags.Stone:
                    action = UnitActions.None;                
                    break;
                case Tags.BlindBeagle:
                    action = BlindBeagle(level, thinkingObject);
                    break;
                case Tags.Bullet:
                    action = Bullet(thinkingObject, dir);
                    break;
                case Tags.Zone:
                    break;
                default:
                case Tags.None:
                    //TODO: Add log about error
                    break;
            }

            thinkingObject.Action = action;
        }

        private UnitActions Bullet (GameObject bullet, Direction dir)
        {
            UnitActions bulletAction = UnitActions.None;

            switch (dir)
            {
                case Direction.None:
                    break;
                case Direction.Top:
                    bulletAction = UnitActions.MoveTop;
                    break;
                case Direction.Down:
                    bulletAction = UnitActions.MoveDown;
                    break;
                case Direction.Left:
                    bulletAction = UnitActions.MoveLeft;
                    break;
                case Direction.Right:
                    bulletAction = UnitActions.MoveRight;
                    break;
                default:
                    break;
            }

            return bulletAction;

        }

        private UnitActions BlindBeagle (GameRoom level, GameObject beagle)
        {
            UnitActions beagleAction = UnitActions.None;
            int playerIndex = level.FindPlayerIndex();
            Coordinate playerCenter = level.gameObj[playerIndex].ObjArea.GetCenter();
            Coordinate beagleCenter = beagle.ObjArea.GetCenter();

            int absX = Math.Abs(playerCenter.x - beagleCenter.x);
            int absY = Math.Abs(playerCenter.y - beagleCenter.y);

            if (absX > absY)
            {
                if (playerCenter.x >= beagleCenter.x)
                {
                    beagleAction = UnitActions.MoveRight;
                }
                else
                {
                    beagleAction = UnitActions.MoveLeft;
                }
            }
            else
            {
                if (playerCenter.y >= beagleCenter.y)
                {
                    beagleAction = UnitActions.MoveDown;
                }
                else
                {
                    beagleAction = UnitActions.MoveTop;
                }
            }

            return beagleAction;
        }

        

    }
}
