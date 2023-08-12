using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL
{
    public class ReadOnlyApplicationDbContext : DbContext, IReadOnlyApplicationDbContext
    {
        public DbSet<ChatCompletion> ChatCompletions { get; set; }

        public DbSet<ChatCompletionMessage> ChatCompletionMessages { get; set; }

        public DbSet<ChatCompletionUsage> ChatCompletionUsages { get; set; }

        public ReadOnlyApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
