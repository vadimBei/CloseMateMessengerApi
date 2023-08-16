using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL
{
    public class ReadOnlyApplicationDbContext : DbContext, IReadOnlyApplicationDbContext
    {
        public DbSet<Chat> Chats { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public ReadOnlyApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
