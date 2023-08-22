using Microsoft.AspNetCore.Mvc;
using UseCases.ChatMessages.Commands.SendMessage;
using UseCases.ChatMessages.Dtos;
using UseCases.ChatMessages.ViewModels;

namespace CloseMate.Api.Controllers
{
    [Route("api/close-mate/chat-messages")]
    public class ChatMessagesController : ApiController
    {
        [HttpPost("send")]
        public async Task<ChatMessageVM> SendChatMessage(SendMessageDto data)
            => await Mediator.Send(new SendMessageCommand()
            {
                Data = data
            });
    }
}
