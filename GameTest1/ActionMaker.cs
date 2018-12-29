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

        public void MakeВeliberateAction(ref GameRoom level, int frameTime)
        {
            for (int i = 0; i <= level.lastObjectIndex; i++)
            {
                if (level.gameObj[i].IsActive)
                {
                    if (frameTime % level.gameObj[i].Slowness == 0)
                    {
                        MakeВeliberateAction(ref level, ref level.gameObj[i]);
                    }
                }
            }

            level.gameObj[level.FindPlayerIndex()].Action = UnitActions.None;      
        }

        public void MakeВeliberateAction(ref GameRoom level, ref GameObject gameObject)
        {
           new Brain().MakeDecision(level, ref gameObject);

            MakeAction(ref level, ref gameObject);
        }

        public void MakeAction(ref GameRoom level, ref GameObject gameObject)
        {
            if (gameObject.IsActive)
            {
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
                        Console.Beep(800, 50);
                        gameObject.Shoot(ref level, Direction.Left);
                        break;
                    case UnitActions.ShootRight:
                        gameObject.Shoot(ref level, Direction.Right);
                        Console.Beep(800, 50);
                        break;
                    case UnitActions.ShootDown:
                        gameObject.Shoot(ref level, Direction.Down);
                        Console.Beep(800, 50);
                        break;
                    case UnitActions.ShootUp:
                        gameObject.Shoot(ref level, Direction.Top);
                        Console.Beep(800, 50);
                        break;
                    case UnitActions.Die:
                        Die(ref level, gameObject);
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


            public void Die (ref GameRoom room, GameObject dyingObj)
        {
            room.DeleteGameObject(dyingObj);
            UI.Hide(room.gameObj[dyingObj.Index]);
            

        }
    }
}
