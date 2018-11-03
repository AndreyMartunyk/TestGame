using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class ModelViev
    {

        public static void PrintBracket()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 0; i < Settings.Width - 1; i++)
            {
                Console.SetCursorPosition(i, 0); // верхняя линия
                Console.Write(" ");
                Console.SetCursorPosition(i, Settings.GetGameArea().To.newPos.y - 1); // нижняя линия
                Console.Write(" ");
            }
            for (int i = 0; i < Settings.Height - 1; i++)
            {
                Console.SetCursorPosition(0, i); // левая линия
                Console.Write(" ");
                Console.SetCursorPosition(Settings.Width - 1, i); // правая линия
                Console.Write(" ");
            }

            for (int i = 0; i <= Settings.GetGameArea().To.newPos.y - 1; i++)
            {
                Console.SetCursorPosition(Settings.GetGameArea().To.newPos.x - 1, i); // левая линия
                Console.Write(" ");

            }

            Console.ResetColor();

#if DEBUG
            GameLogger.AddLog(ref Program.log, "Статичная рамка игры нарисована");

#endif

        }
    }
}
