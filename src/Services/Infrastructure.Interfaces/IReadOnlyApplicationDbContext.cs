using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public interface IReadOnlyApplicationDbContext
    {
        DbSet<Chat> Chats { get; set; }

        DbSet<ChatMessage> ChatMessages { get; set; }

    }
}
