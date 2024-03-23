using Entities.Models;
using Infrastructure.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder
                .Entity<ChatMessage>()
                .HasIndex(x => x.IsDeleted)
                .HasFilter("IsDeleted = 0");

            builder
                .Entity<Chat>()
                .HasIndex(x => x.IsDeleted)
                .HasFilter("IsDeleted = 0");

            base.OnModelCreating(builder);
        }
    }
}
