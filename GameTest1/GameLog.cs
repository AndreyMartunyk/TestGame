using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    public struct LogItem
    {
        public string Message; // запись в логе игры
        public int Color; // цвет подсказывающий насколько важна транслируемая запись
        public int CountIdenticalLogs; // переменная показывающая сколько одинаковых записей было подряд
    }

    public struct GameLogger
    {
        public const int DAFAULT_LOG_SIZE = 150;
        public LogItem[] Messages;
        public int MessageCount; // кол-во записей уже вписаных в лог игры
        public bool isChanged;
        

        public static GameLogger CreateGameLog(int size = DAFAULT_LOG_SIZE)
        {
            GameLogger log;
            log.isChanged = false;
            log.MessageCount = 0;
            log.Messages = new LogItem[DAFAULT_LOG_SIZE];

            for (int i = 0; i < log.Messages.Length; i++)
            {
                log.Messages[i].Message = string.Empty;
            }

            return log;
        }

        public static void AddLog(ref GameLogger log, LogItem newMessage)
        {
            log.isChanged = true;
            if (log.MessageCount < log.Messages.Length)
            {
                log.Messages[log.MessageCount] = newMessage;
                ++log.MessageCount;
            }
        }

        public static void AddLog(ref GameLogger log, string message)
        {
            log.isChanged = true;
            if (log.MessageCount < log.Messages.Length)  // проверка на переполненость массива
            {

                //проверка на то, являестся ли новая запись идентичной прошлой
                if (log.MessageCount > 0 && message == log.Messages[log.MessageCount - 1].Message) 
                {
                    log.Messages[log.MessageCount - 1].CountIdenticalLogs++;
                }
                else
                {
                    log.Messages[log.MessageCount] = new LogItem() { Message = message, Color = 0 };
                    ++log.MessageCount;
                }
            }
        }
        
    }

    
}
