using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public interface IReadOnlyApplicationDbContext
    {
        DbSet<ChatCompletion> ChatCompletions { get; set; }

        DbSet<ChatCompletionMessage> ChatCompletionMessages { get; set; }

        DbSet<ChatCompletionUsage> ChatCompletionUsages { get; set; }
    }
}
