using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions.Interfaces
{
    public interface IReadOnlyApplicationDbContext
    {
        DbSet<Chat> Chats { get; set; }

        DbSet<ChatMessage> ChatMessages { get; set; }

    }
}
