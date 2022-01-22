using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingApp.Services.Abstractions;

public abstract class Service<TEntity> where TEntity : class
{
  protected ILogger Logger;
  protected IMapper Mapper;
  protected IDbContext DbContext;

  protected Service(ILogger logger, IMapper mapper, IDbContext dbContext)
  {
    Logger = logger;
    Mapper = mapper;
    DbContext = dbContext;
  }

  protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

  protected Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => DbContext.SaveChangesAsync(cancellationToken);

  protected int SaveChanges() => DbContext.SaveChanges();

}