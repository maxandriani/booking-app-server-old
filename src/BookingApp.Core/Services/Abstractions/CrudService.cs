using System.Text.Json;
using AutoMapper;
using BookingApp.Services.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingApp.Services.Abstractions;


public abstract class CrudService<TEntity, TEntityDto, TKey, TSearchRequest, TCreateUpdateInput> : CrudService<TEntity, TEntityDto, TKey, TSearchRequest, TCreateUpdateInput, TCreateUpdateInput>
  where TEntity : class
{
  protected CrudService(ILogger logger, IMapper mapper, IDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }
}

public abstract class CrudService<TEntity, TEntityDto, TKey, TSearchRequest, TCreateInput, TUpdateInput> : ReadOnlyService<TEntity, TEntityDto, TKey, TSearchRequest>,
  ICrudService<TEntityDto, TKey, TSearchRequest, TCreateInput, TUpdateInput> where TEntity : class
{
  protected CrudService(ILogger logger, IMapper mapper, IDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  private TEntity MapFromInput(TCreateInput input) => Mapper.Map<TCreateInput, TEntity>(input);
  private TEntity MapFromInput(TUpdateInput input, TEntity update) => Mapper.Map<TUpdateInput, TEntity>(input, update);

  public async Task<TEntityDto> CreateAsync(TCreateInput input)
  {
    var entity = MapFromInput(input);
    // @todo check business validations
    await DbSet.AddAsync(entity);
    await SaveChangesAsync();

    Logger.LogTrace($"{nameof(TEntity)} {JsonSerializer.Serialize(input)} salvo com sucesso!");

    return MapToOutput(entity);
  }

  public async Task<TEntityDto> UpdateAsync(TKey keys, TUpdateInput input)
  {
    var entity = MapFromInput(input, GetEntityById(keys));
    // check business rules..
    DbSet.Update(entity);
    await SaveChangesAsync();
    Logger.LogTrace($"{nameof(TEntity)} {JsonSerializer.Serialize(keys)} atualizado");
    return MapToOutput(entity);
  }

  public async Task DeleteAsync(TKey input)
  {
    var place = GetEntityById(input);
    // @todo Check business validations.
    DbSet.Remove(place);
    await DbContext.SaveChangesAsync();

    Logger.LogTrace($"{nameof(TEntity)} {JsonSerializer.Serialize(input)} removido com sucesso!");
  }
}