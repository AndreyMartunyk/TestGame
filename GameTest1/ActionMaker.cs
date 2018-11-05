using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class ActionMaker
    {
        public void MakeAction(ref GameRoom level, ref Brain brain, int frameTime)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                if (frameTime % level.gameObj[i].Slowness == 0)
                {
                    MakeAction(ref level, ref level.gameObj[i], brain);
                }
                
            }

            brain.SetPlayerAction(UnitActions.None); // для того что бы действие не дублировалось снова и снова
            
        }

        public void MakeAction(ref GameRoom level, ref GameObject gameObject, Brain brain)
        {
            UnitActions action = brain.MakeDecision(level, gameObject);

            switch (action)
            {
                case UnitActions.MoveRight:
                    PositionCl.Move(ref level, ref gameObject, Direction.Right);
                    break;
                case UnitActions.MoveLeft:
                    PositionCl.Move(ref level, ref gameObject, Direction.Left);
                    break;
                case UnitActions.MoveDown:
                    PositionCl.Move(ref level, ref gameObject, Direction.Down);
                    break;
                case UnitActions.MoveTop:
                    PositionCl.Move(ref level, ref gameObject, Direction.Top);
                    break;
                case UnitActions.Stop:
                    break;
                case UnitActions.Shoot:
                    break;
                case UnitActions.Die:
                    break;
                case UnitActions.GetDamage:
                    break;
                case UnitActions.Attack:
                    break;
                default:
                case UnitActions.None:

                    break;
            }

        }
    }
}
