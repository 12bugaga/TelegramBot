using NLog;
using System;
using Telegram.Bot;

namespace ConsoleTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
           
            StartBot();
        }

        static private void StartBot()
        {
            Logger log = LogManager.GetCurrentClassLogger();

            Console.WriteLine("Press any key to exit");
            TelegramBotClient botClient = new TelegramBotClient("YOUR_BOT_TOKEN");
            log.Debug("Start bot");

            var workBot = new WorkBot(botClient);


            workBot.Start();
            
            Console.ReadKey();
            log.Debug("Close bot");
            botClient.StopReceiving();
        }
    }
}
