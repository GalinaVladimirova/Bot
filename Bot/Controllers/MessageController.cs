using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Bot.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ITelegramBotClient botClient;

        [HttpPost]
        public async void Post(MessageModel messageModel)
        {
            botClient = Models.Bot.Get();

            await botClient.SendTextMessageAsync(
                chatId: messageModel.chat_id,
                text: messageModel.message).ConfigureAwait(false);        
        }
        
    }
}
