using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class Controller
    {
        public UnitActions GetActionFromKey(ConsoleKey key)
        {
            UnitActions action = UnitActions.None;

            switch (key)
            {
                case ConsoleKey.A:
                    action = UnitActions.MoveLeft;
                    break;
                case ConsoleKey.D:
                    action = UnitActions.MoveRight;
                    break;
                case ConsoleKey.W:
                    action = UnitActions.MoveTop;
                    break;
                case ConsoleKey.S:
                    action = UnitActions.MoveDown;
                    break;
                default:
                    //никак не реагируем при нажатиии незадекларируемой клавиши
                    break;
            }

            return action;
        }
    }
}
