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

            GameRoom level_1 = new GameRoom();
            level_1.CreateLevelStorage();

            CharacterConstructor characterConstructor = new CharacterConstructor();
            GameObject player = characterConstructor.CreatePlayer(10, 10);
            level_1.AddGameObject(player);

            
            level_1.AddMap(new MapConstructor().Tutorial_1());

            ConsoleKey key = ConsoleKey.F14;
            CollisionChecker collChecker = new CollisionChecker();
            bool actionDone = true;

            UI.Show(level_1);

            int frameTime = 0;
            FpsCalculator fps = new FpsCalculator();
            fps.CreateFpsCalculator();
            do
            {
                //   ---=== INPUT ===---

                if (Console.KeyAvailable && actionDone) // проверка на то, была ли нажата кнопка
                {
                    key = Console.ReadKey(true).Key;
                    actionDone = false;
                }

                // Обработка вводных данных
                //controller от водимого знака возвращает енам с Юзер екшн
                switch (key)
                {
                    case ConsoleKey.A:
                        PositionCl.Move(ref level_1, ref level_1.gameObj[0], 0, Direction.Left);
                        break;
                    case ConsoleKey.D:
                        PositionCl.Move(ref level_1, ref level_1.gameObj[0], 0, Direction.Right);
                        break;
                    case ConsoleKey.W:
                        PositionCl.Move(ref level_1, ref level_1.gameObj[0], 0, Direction.Top);
                        break;
                    case ConsoleKey.S:
                        PositionCl.Move(ref level_1, ref level_1.gameObj[0], 0, Direction.Down);
                        break;
                    case ConsoleKey.Escape:
                        Console.Write("Good by! Press any key to continue... ");
                        Console.ReadKey();
                        break;
                    default:
                        //никак не реагируем при нажатиии незадекларируемой клавиши
                        break;
                }
                actionDone = true;

                key = ConsoleKey.F14;

                // проверка на выход за рамки консоли
                PositionCl.CheckOverflow(ref level_1, Settings.GetGameArea());

                // затирание старой позиции и рисование новой, если позиция поменялась
                UI.Refresh(level_1);

                // помещение новых координат в старые
                PositionCl.NewToOld(ref level_1);

                Thread.Sleep(10);
#if DEBUG
                if (frameTime % 5 == 0)
                {
                    UI.PrintLog(Program.log);
                }
#endif
                UI.ShowFPS(fps.EndOfFrame(out int countOfFrames), countOfFrames);

                ++frameTime;
            } while (true);  
        }
    }
}
