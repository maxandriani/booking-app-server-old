using System.Text.Json;
using AutoMapper;
using BookingApp.Services.Requests;
using BookingApp.Services.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace BookingApp.Services.Abstractions;

public abstract class ReadOnlyService<TEntity, TEntityDto, TKey, TSearchRequest> : Service<TEntity>,
  IReadOnlyService<TEntityDto, TKey, TSearchRequest> where TEntity : class
{
  protected ReadOnlyService(ILogger logger, IMapper mapper, IDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  protected abstract TEntity GetEntityById(TKey keys);

  protected TEntityDto MapToOutput(TEntity entity) => Mapper.Map<TEntity, TEntityDto>(entity);

  public Task<TEntityDto> GetByIdAsync(TKey keys)
  {
    var place = GetEntityById(keys);
    Logger.LogTrace($"{nameof(TEntity)} {JsonSerializer.Serialize(keys)} foi consultado");
    return Task.FromResult(MapToOutput(place));
  }

  protected abstract IQueryable<TEntity> CreateCollectionQuery(IQueryable<TEntity> query, TSearchRequest input);

  protected abstract IQueryable<TEntity> DefaultSorting(IQueryable<TEntity> query);

  public async Task<CollectionResult<TEntityDto>> GetCollectionAsync(TSearchRequest input)
  {
    IQueryable<TEntity> query = CreateCollectionQuery(DbSet, input);

    var totalCount = await query.CountAsync();

    if (input is IPagedRequest pagedInput)
      query = ApplyPagination(query, pagedInput);

    if (input is ISortedRequest sortedInput)
      query = ApplySorting(query, sortedInput);

    var result = query.AsEnumerable<TEntity>().Select(p => MapToOutput(p));

    Logger.LogTrace($"Consulta de Places realizada com os seguintes argumentos: {JsonSerializer.Serialize(input)}");

    return new CollectionResult<TEntityDto>(result, totalCount);
  }

  private IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, ISortedRequest? input)
  {
    if (string.IsNullOrEmpty(input?.Sorting)) return DefaultSorting(query);
    return query.OrderBy(input.Sorting);
  }

  private IQueryable<TEntity> ApplyPagination(IQueryable<TEntity> query, IPagedRequest? input)
  {
    if (input?.Take < 1 || input?.Page < 0) return query;

    var take = input?.Take ?? 0;
    var skip = (input?.Page ?? 0) * take;

    return query.Skip(skip).Take(take);
  }
}