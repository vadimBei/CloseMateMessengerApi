using Microsoft.AspNetCore.Mvc;
using UseCases.Chats.Commands.CreateChat;
using UseCases.Chats.Commands.DeleteChat;
using UseCases.Chats.Commands.UpdateChat;
using UseCases.Chats.Dtos;
using UseCases.Chats.Queries.GetChatById;
using UseCases.Chats.Queries.GetChats;
using UseCases.Chats.ViewModels;

namespace CloseMate.Api.Controllers
{
    [Route("api/close-mate/chats")]
    public class ChatsController : ApiController
    {
        [HttpPost]
        public async Task<ChatVM> CreateChat(CreateChatDto data)
            => await Mediator.Send(new CreateChatCommand()
            {
                Data = data
            });

        [HttpGet("{id}")]
        public async Task<ChatVM> GetChatById(long id)
            => await Mediator.Send(new GetChatByIdQuery()
            {
                Id = id
            });

        [HttpGet]
        public async Task<IEnumerable<ChatVM>> GetChats()
            => await Mediator.Send(new GetChatsQuery());

        [HttpPut]
        public async Task<ChatVM> UpdateChat(UpdateChatDto data)
            => await Mediator.Send(new UpdateChatCommand()
            {
                Data = data
            });

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(long id)
        {
            await Mediator.Send(new DeleteChatCommand()
            {
                Id = id
            });

            return Ok();
        }
    }
}
