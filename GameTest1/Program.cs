using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTest1
{
    class Program
    {
#if DEBUG
        public static GameLogger log = GameLogger.CreateGameLog();
#endif        

        static void Main(string[] args)
        {
            Settings.ConsoleSetings();

            ModelViev.PrintBracket();

             GameRoom level_1 = new GameRoomConstructor().Init();
            Controller controller = new Controller();

            UI.Show(level_1);

            int frameTime = 0;
            FpsCalculator fps = new FpsCalculator();
            fps.CreateFpsCalculator();
            do
            {
                if (Console.KeyAvailable) // проверка на то, была ли нажата кнопка
                { 
                    // берем нажатую клавишу и передаем ее "Мозгу", который даст Player-у задачу, идти, стрелять и тд.
                    new Brain().SetPlayerDecision(level_1, controller.GetActionFromKey(Console.ReadKey(true).Key)); 
                }

                // берем все обьекты и выполняем все их действия
                new ActionMaker().MakeВeliberateAction(ref level_1, frameTime); // передаем frameTime для учета скорости

                // проверка на выход за рамки консоли
                PositionCl.CheckOverflow(ref level_1, Settings.GetGameArea());

                new CollisionPolice().Review(ref level_1);

                // затирание старой позиции и рисование новой, если позиция поменялась
                UI.Refresh(level_1);

                // помещение новых координат в старые
                PositionCl.NewToOld(ref level_1);

                Thread.Sleep(15);
#if DEBUG
                if (frameTime % 5 == 0)
                {
                    UI.PrintLog(Program.log);
                }
#endif
                int countOfFrames;
                UI.ShowFPS(fps.EndOfFrame(out countOfFrames), countOfFrames);

                Console.SetCursorPosition(Settings.GetGameArea().To.newPos.x + 5, 6);
                Console.Write("HP = {0}   ", level_1.gameObj[0].HP);

                ++frameTime;
            } while (true);  
        }
    }
}

