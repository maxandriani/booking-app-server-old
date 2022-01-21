namespace Microsoft.EntityFrameworkCore;

public interface IDbContext : IDisposable
{
  DbSet<TEntity> Set<TEntity>() where TEntity : class;
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  int SaveChanges();
}