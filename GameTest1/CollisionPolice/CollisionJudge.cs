using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class CollisionJudge
    {
     
        public void MakeDecision(ref GameRoom room, ref GameObject moovingObj, ref GameObject victimObj)
        {
            if (moovingObj.IsActive)
            {
                switch (moovingObj.ObjTag)
                {
                    case Tags.None:
                        break;
                    case Tags.Player:
                        break;
                    case Tags.DamageToucher:
                        break;
                    case Tags.Stone:
                        break;
                    case Tags.BlindBeagle:
                        if (victimObj.ObjTag == Tags.Player)
                        {
                            victimObj.Action = UnitActions.Die;
                        }
                        break;
                    case Tags.Bullet:
                        if (victimObj.ObjTag == Tags.BlindBeagle)
                        {
                            victimObj.Action = UnitActions.Die;
                        }
                        room.gameObj[moovingObj.Index].Action = UnitActions.Die;
                        break;
                    case Tags.Zone:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
