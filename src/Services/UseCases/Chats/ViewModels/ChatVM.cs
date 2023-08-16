using AutoMapper;
using Entities.Models;
using UseCases.ChatMessages.ViewModels;

namespace UseCases.Chats.ViewModels
{
    [AutoMap(typeof(Chat))]
    public class ChatVM
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public List<ChatMessageVM> Messages { get; set; }
    }
}
