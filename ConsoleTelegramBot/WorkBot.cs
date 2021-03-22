using NLog;
using Telegram.Bot;
using Telegram.Bot.Args;
using WorkTelegramBot;

namespace ConsoleTelegramBot
{
    class WorkBot
    {
        ITelegramBotClient botClient;
        readonly Logger log = LogManager.GetCurrentClassLogger();

        public WorkBot(ITelegramBotClient _botClient)
        {
            botClient = _botClient;
        }

        public void Start()
        {
            var me = botClient.GetMeAsync().Result;

            log.Info("First message: \n{0}", $"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        private async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            log.Info("Get message from user: \n{0}", e.Message.Text);

            MainLogic logic = new MainLogic();
            string textOut = logic.MessageProcess(e.Message.Text);
            await botClient.SendTextMessageAsync(
                          chatId: e.Message.Chat,
                          text: textOut
                        );

            log.Info("Answer from bot: \n{0}", textOut);
        }
    }
}
