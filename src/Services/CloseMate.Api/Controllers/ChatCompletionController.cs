using Microsoft.AspNetCore.Mvc;
using UseCases.ChatCompletions.Commands.CreateChatCompletion;
using UseCases.ChatCompletions.Commands.DeleteChatCompletion;
using UseCases.ChatCompletions.Commands.UpdateChatCompletion;
using UseCases.ChatCompletions.Queries.GetChatCompletionById;
using UseCases.ChatCompletions.Queries.GetChatCompletions;
using UseCases.ChatCompletions.ViewModels;

namespace CloseMate.Api.Controllers
{
    [Route("api/close-mate/chat-completions")]
    public class ChatCompletionController : ApiController
    {
        [HttpPost]
        public async Task<ChatCompletionVM> CreateChatCompletion(CreateChatCompletionCommand command)
            => await Mediator.Send(command);

        [HttpGet]
        public async Task<IEnumerable<ChatCompletionVM>> GetChatCompletions()
            => await Mediator.Send(new GetChatCompletionsQuery());

        [HttpGet("{id}")]
        public async Task<ChatCompletionVM> GetChatCompletionById(long id)
            => await Mediator.Send(new GetChatCompletionByIdQuery()
            {
                Id = id
            });

        [HttpPut]
        public async Task<ChatCompletionVM> UpdateChatCompletion(UpdateChatCompletionCommand command)
            => await Mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatCompletion(long id)
        {
            await Mediator.Send(new DeleteChatCompletionCommand()
            {
                Id = id
            });

            return Ok();
        }
    }
}
