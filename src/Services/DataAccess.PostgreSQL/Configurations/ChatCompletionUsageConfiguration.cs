using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.PostgreSQL.Configurations
{
    public class ChatCompletionUsageConfiguration : IEntityTypeConfiguration<ChatCompletionUsage>
    {
        public void Configure(EntityTypeBuilder<ChatCompletionUsage> builder)
        {
            builder.ToTable("ChatCompletionUsages");
        }
    }
}
