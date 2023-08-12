namespace Infrastructure.Interfaces
{
    public interface IApplicationDbContext : IReadOnlyApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
