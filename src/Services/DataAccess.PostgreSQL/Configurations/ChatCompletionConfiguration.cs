using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.PostgreSQL.Configurations
{
    public class ChatCompletionConfiguration : IEntityTypeConfiguration<ChatCompletion>
    {
        public void Configure(EntityTypeBuilder<ChatCompletion> builder)
        {
            builder.ToTable("ChatCompletions");
        }
    }
}
