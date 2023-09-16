namespace Infrastructure.Abstractions.Interfaces
{
    public interface IApplicationDbContext : IReadOnlyApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
