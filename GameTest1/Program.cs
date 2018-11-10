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
            GameObject player = characterConstructor.CreatePlayer(10, 30);
            GameObject bBeagle = characterConstructor.CreateBlindBeagle(12, 16);
            level_1.AddGameObject(player);
            level_1.AddGameObject(bBeagle);
            level_1.AddGameObject(characterConstructor.CreateBlindBeagle(30, 16));
            level_1.AddGameObject(characterConstructor.CreateBlindBeagle(50, 16));
            
            level_1.AddMap(new MapConstructor().Tutorial_1());

 
            CollisionChecker collChecker = new CollisionChecker();
            Controller controller = new Controller();

            UI.Show(level_1);

            int frameTime = 0;
            FpsCalculator fps = new FpsCalculator();
            fps.CreateFpsCalculator();
            do
            {
                //   ---=== INPUT ===---

                if (Console.KeyAvailable) // проверка на то, была ли нажата кнопка
                {
                    //key = Console.ReadKey(true).Key;
                    new Brain().SetPlayerDecision(level_1, controller.GetActionFromKey(Console.ReadKey(true).Key));
                }
                // Обработка вводных данных
                //controller от водимого знака возвращает енам с Юзер екшн


                new ActionMaker().MakeAction(ref level_1, frameTime);



                //brain.SetPlayerAction(UnitActions.None);

                // проверка на выход за рамки консоли
                PositionCl.CheckOverflow(ref level_1, Settings.GetGameArea());

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
                UI.ShowFPS(fps.EndOfFrame(out int countOfFrames), countOfFrames);

                Console.SetCursorPosition(Settings.GetGameArea().To.newPos.x + 5, 6);
                Console.Write("HP = {0}   ", level_1.gameObj[0].HP);

                ++frameTime;
            } while (true);  
        }
    }
}
