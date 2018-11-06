using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameTest1
{
    class ActionMaker
    {

        //Thread thread = new Thread(Console.Beep);

        public void MakeAction(ref GameRoom level, int frameTime)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                if (frameTime % level.gameObj[i].Slowness == 0)
                {
                    MakeAction(ref level, ref level.gameObj[i]);
                }               
            }

            level.gameObj[level.FindPlayerIndex()].Action = UnitActions.None;      
        }

        public void MakeAction(ref GameRoom level, ref GameObject gameObject)
        {
           new Brain().MakeDecision(level, ref gameObject);

            switch (gameObject.Action)
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
                case UnitActions.ShootLeft:
                    Console.Beep(800, 100);
                    break;
                case UnitActions.ShootRight:
                    Console.Beep(800, 50);
                    break;
                case UnitActions.ShootDown:
                    Console.Beep(800, 50);
                    break;
                case UnitActions.ShootUp:
                    Console.Beep();
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
