using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct Brain
    {
        private UnitActions playerAction;


        

        public void SetPlayerAction(UnitActions action)
        {
            playerAction = action;
        }

        public UnitActions MakeDecision(GameRoom level,GameObject thinkingObject)
        {
            UnitActions action = UnitActions.None;

            switch (thinkingObject.teg)
            {

                case Tags.Player:
                    action = playerAction;
                    break;
                case Tags.DamageToucher:
                case Tags.Stone:
                    action = UnitActions.None;                
                    break;
                case Tags.BlindBeagle:
                    action = BlindBeagle(level, thinkingObject);
                    break;
                case Tags.Zone:
                    break;
                default:
                case Tags.None:
                    //TODO: Add log about error
                    break;
            }



            return action;
        }

        private UnitActions BlindBeagle (GameRoom level, GameObject beagle)
        {
            UnitActions beagleAction = UnitActions.None;
            int playerIndex = FindPlayerIndex(level);
            Coordinate playerCenter = level.gameObj[playerIndex].area.GetCenter();
            Coordinate beagleCenter = beagle.area.GetCenter();

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

        private int FindPlayerIndex (GameRoom level)
        {
            // войвращает номер индекса игрока, если его нет то возвр. -1
            int playerIndex = -1;
            for (int i = 0; i < level.countOfObjects; i++)
            {              
                if (level.gameObj[i].teg == Tags.Player)
                {
                    playerIndex = i;
                    break;
                }
            }

            return playerIndex;
        }

    }
}
