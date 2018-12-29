using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class CollisionPolice
    {
        public void Review(ref GameRoom room)
        {
            for (int i = 0; i <= room.lastObjectIndex; i++)
            {

                int collisionObgIndex;
                if (new CollisionChecker().CheckCollision(room, room.gameObj[i], out collisionObgIndex))
                {
                    //PositionCl.GetBackPos(ref room.gameObj[i]); // если столкнулись, то движущияся обьект должен упереться в него
                    new CollisionJudge().MakeDecision(ref room, ref room.gameObj[i], ref room.gameObj[collisionObgIndex]);
                    new ActionMaker().MakeAction(ref room, ref room.gameObj[i]);
                    new ActionMaker().MakeAction(ref room, ref room.gameObj[collisionObgIndex]);
                    PositionCl.GetBackPos(ref room.gameObj[i]); // если столкнулись, то движущияся обьект должен упереться в него
                }
                else
                {
                    //room.gameObj[i].Action = UnitActions.None;
                }
            }

        }
    }
}
