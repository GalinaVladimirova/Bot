using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Models.Commands
{
    public class GetChatIdCommand : Command
    {
        public override string Name => @"/id";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var text = message?.Text;
            if (text == null)
                return;
            
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Ваш chat ID: '{message.Chat.Id}'").ConfigureAwait(false);
        }
    }
}
