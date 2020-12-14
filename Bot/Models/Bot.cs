using Bot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Bot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }
        public static TelegramBotClient Get()
        {
            if (client != null)
                return client;
            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new GetChatIdCommand());

            client = new TelegramBotClient(AppSettings.Key);
            client.StartReceiving();
            client.OnMessage += Bot_OnMessage;

            return  client;
        }
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var commands = Commands;
            var message = e.Message;
            var client = Get();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    command.Execute(message, client);
                    break;
                }
            }
        }

       
    }
}
