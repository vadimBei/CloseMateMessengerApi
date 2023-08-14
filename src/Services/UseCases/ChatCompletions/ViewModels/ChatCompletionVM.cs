using AutoMapper;
using Entities.Models;

namespace UseCases.ChatCompletions.ViewModels
{
    [AutoMap(typeof(ChatCompletion))]
    public class ChatCompletionVM
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public List<ChatCompletionMessageVM> Messages { get; set; }
    }
}
