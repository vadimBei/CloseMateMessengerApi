using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.PostgreSQL.Configurations
{
    public class ChatCompletionMessageConfiguration : IEntityTypeConfiguration<ChatCompletionMessage>
    {
        public void Configure(EntityTypeBuilder<ChatCompletionMessage> builder)
        {
            builder.ToTable("ChatCompletionMessages");
        }
    }
}
