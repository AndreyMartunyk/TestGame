﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class Settings
    {
        public const int Width = 100;
        public const int Height = 40;
        private static Area gameArea;
        public static int LogWidthStartPos = 82;      

        public static void ConsoleSetings()
        {

            Console.Title = "The best Game!!!!";
            Console.CursorVisible = false;

            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);
#if DEBUG
            Console.SetWindowSize(Width + 50, Console.LargestWindowHeight);
            Console.SetBufferSize(Width + 50, Console.LargestWindowHeight);
#endif
            
#if DEBUG
            GameLogger.AddLog(ref Program.log, "Настройки консоли установлены");

#endif
        }

        public static Area GetGameArea()
        {
            gameArea = new Area
            {
                From = new Position
                {
                    newPosX = 0,
                    newPosY = 0,
                    oldPosX = 0,
                    oldPosY = 0
                },
                To  = new Position
                {
                    newPosX = 80,
                    newPosY = 40,
                    oldPosX = 80,
                    oldPosY = 40
                }
            };

            return gameArea;
        }
    }
}
