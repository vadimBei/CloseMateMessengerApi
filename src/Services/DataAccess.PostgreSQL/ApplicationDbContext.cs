using DataAccess.PostgreSQL.Interceptors;
using Entities.Models;
using Infrastructure.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.PostgreSQL
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Chat> Chats { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            ChangeTracker.AutoDetectChangesEnabled = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
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
