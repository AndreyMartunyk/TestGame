using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public class UI
    {
        public static void Refresh (GameRoom level)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                Refresh(level.gameObj[i]);
            }
        }

        public static void Show(GameRoom level)
        {
            for (int i = 0; i < level.countOfObjects; i++)
            {
                Show(level.gameObj[i]);
            }
        }

        public static void Refresh (GameObject gameObject)
        {
            if (gameObject.ObjArea.From.newPos.x != gameObject.ObjArea.From.oldPos.x ||
                gameObject.ObjArea.From.newPos.y != gameObject.ObjArea.From.oldPos.y)
            {
                Hide(gameObject);
                Show(gameObject);
            }   
        }

        public static void Show (GameObject gameObject)
        {
            MakeTextColor(gameObject.Color);
            MakeBackgroundColor(gameObject.BackColor);
            int k = 0;
            for (int i = gameObject.ObjArea.From.newPos.y; i <= gameObject.ObjArea.To.newPos.y; i++)
            {
                for (int y = gameObject.ObjArea.From.newPos.x; y <= gameObject.ObjArea.To.newPos.x; y++)
                {
                    Console.SetCursorPosition(y, i);
                    Console.Write(gameObject.Viev[k]);
                    k++;
                }
            }
            ReturnDefaultColor();
            ReturnDefaultBackgroundColor();
        } 

        public static void Hide(GameObject gameObject)
        {
            for (int i = gameObject.ObjArea.From.oldPos.y; i <= gameObject.ObjArea.To.oldPos.y; i++)
            {
                for (int y = gameObject.ObjArea.From.oldPos.x; y <= gameObject.ObjArea.To.oldPos.x; y++)
                {
                    Console.SetCursorPosition(y, i);
                    Console.Write(" ");
                }
            }
        }

        public static void PrintLog(GameLogger l)
        {
            if (l.isChanged)
            {
                Hide(l);
                int yOffset = 3;

                for (int i = l.MessageCount - 1; i >= 0; i--)
                {
                    Console.SetCursorPosition(Settings.LogWidthStartPos + 20, yOffset);
                    // + Color
                    Console.Write("{0,30} ({1,3} раз)", l.Messages[i].Message, l.Messages[i].CountIdenticalLogs + 1);
                    ++yOffset;

                    if (yOffset >= Console.WindowHeight - 1)
                    {
                        break;
                    }
                }
                l.isChanged = false;
            }
        }

        public static void Hide(GameLogger gameLogger)
        {
            int yOffset = 3;
            for (int i = 0; i < gameLogger.MessageCount; i++)
            {
                // вылазит за буфер почини!
                
                Console.SetCursorPosition(Settings.LogWidthStartPos + 20, ++yOffset);
                // + Color
                Console.Write("{0,30}"," " );
                if (yOffset >= Console.WindowHeight - 1)
                {
                    break;
                }

            }
        }

        public static void MakeTextColor(GameColors color)
        {
            ConsoleColor consoleColor = ConsoleColor.Gray;
            switch (color)
            {
                case GameColors.None:
                    break;
                case GameColors.Red:
                    consoleColor = ConsoleColor.Red;
                    break;
                case GameColors.Cyan:
                    consoleColor = ConsoleColor.Cyan;
                    break;
                case GameColors.Grey:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case GameColors.Green:
                    consoleColor = ConsoleColor.Green;
                    break;
                case GameColors.White:
                    consoleColor = ConsoleColor.White;
                    break;
                case GameColors.Yellow:
                    consoleColor = ConsoleColor.Yellow;
                    break;
                case GameColors.DarkGrey:
                    consoleColor = ConsoleColor.DarkGray;
                    break;
                default:
                    break;
            }

            Console.ForegroundColor = consoleColor;
        } 

        public static void ReturnDefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void ShowFPS(bool show, int fps)
        {
            if (show)
            {
                Console.SetCursorPosition(85, 2);
                Console.WriteLine("fps " + fps);
            }
        }

        public static void MakeBackgroundColor(GameColors color)
        {
            ConsoleColor consoleColor = ConsoleColor.Black;
            switch (color)
            {
                case GameColors.None:
                    break;
                case GameColors.Red:
                    consoleColor = ConsoleColor.Red;
                    break;
                case GameColors.Cyan:
                    consoleColor = ConsoleColor.Cyan;
                    break;
                case GameColors.Grey:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case GameColors.Green:
                    consoleColor = ConsoleColor.Green;
                    break;
                case GameColors.White:
                    consoleColor = ConsoleColor.White;
                    break;
                case GameColors.Yellow:
                    consoleColor = ConsoleColor.Yellow;
                    break;
                case GameColors.DarkGrey:
                    consoleColor = ConsoleColor.DarkGray;
                    break;
                default:
                    break;
            }

            Console.BackgroundColor = consoleColor;
        }

        public static void ReturnDefaultBackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
