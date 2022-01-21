using System.Text.Json;
using AutoMapper;
using BookingApp.Services.Requests;
using BookingApp.Services.Results;
using BookingApp.Services.Abstractions;
using BookingApp.Data;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace BookingApp.Places;

public class PlaceService :
  IReadable<GetByIdRequest, PlaceDto>,
  ICollectionable<SearchPlaceRequest, PlaceDto>,
  ICreateable<CreateUpdatePlaceDto, PlaceDto>,
  IUpdateable<GetByIdRequest, CreateUpdatePlaceDto, PlaceDto>,
  IDeleteable<GetByIdRequest>, IPlaceService
{
  private ILogger<PlaceService> Logger;
  private IMapper Mapper;
  private IBookingAppDbContext DbContext;

  public PlaceService(ILogger<PlaceService> logger, IMapper mapper, IBookingAppDbContext dbContext)
  {
    Logger = logger;
    Mapper = mapper;
    DbContext = dbContext;
  }

  public async Task<PlaceDto> CreateAsync(CreateUpdatePlaceDto input)
  {
    var place = Mapper.Map<CreateUpdatePlaceDto, Place>(input);
    // @todo check business validations
    await DbContext.Places.AddAsync(place);
    await DbContext.SaveChangesAsync();

    Logger.LogTrace($"Place {input.Name} salvo com sucesso!");

    return Mapper.Map<Place, PlaceDto>(place);
  }

  public async Task DeleteAsync(GetByIdRequest input)
  {
    var place = DbContext.Places.First(p => p.Id == input.Id);
    // @todo Check business validations.
    DbContext.Places.Remove(place);
    await DbContext.SaveChangesAsync();

    Logger.LogTrace($"Place {input.Id} removido com sucesso!");
  }

  public Task<PlaceDto> GetByIdAsync(GetByIdRequest keys)
  {
    var place = DbContext.Places.First(p => p.Id == keys.Id);
    Logger.LogTrace($"Place {place.Id} foi consultado");
    return Task.FromResult(Mapper.Map<Place, PlaceDto>(place));
  }

  public Task<CollectionResult<PlaceDto>> GetCollectionAsync(SearchPlaceRequest input)
  {
    IQueryable<Place> query = DbContext.Places;

    if (!string.IsNullOrEmpty(input.Search))
    {
      query = query.Where(p => p.Name.ToLower().Contains(input.Search.ToLower()));
    }

    if (input is ISortedRequest)
      query = ApplyPagination(query, input);

    if (input is IPagedRequest)
      query = ApplySorting(query, input);

    var totalCount = query.Count();
    var result = new CollectionResult<PlaceDto>(query.Select(p => Mapper.Map<Place, PlaceDto>(p)).ToList(), totalCount);

    Logger.LogTrace($"Consulta de Places realizada com os seguintes argumentos: {JsonSerializer.Serialize(input)}");

    return Task.FromResult(result);
  }

  private IQueryable<Place> ApplySorting(IQueryable<Place> query, ISortedRequest input)
  {
    if (string.IsNullOrEmpty(input.Sorting)) return query.OrderBy(p => p.Name);
    return query.OrderBy(input.Sorting);
  }

  private IQueryable<Place> ApplyPagination(IQueryable<Place> query, IPagedRequest input)
  {
    if (input?.Take < 1 || input?.Page < 0) return query;

    var take = input?.Take ?? 0;
    var skip = (input?.Page ?? 0) * take;

    return query.Take(take).Skip(skip);
  }

  public async Task<PlaceDto> UpdateAsync(GetByIdRequest keys, CreateUpdatePlaceDto input)
  {
    var place = DbContext.Places.First(p => p.Id == keys.Id);
    Mapper.Map<CreateUpdatePlaceDto, Place>(input, place);
    // check business rules..
    DbContext.Places.Update(place);
    await DbContext.SaveChangesAsync();
    Logger.LogTrace($"Place {keys.Id} atualizado");
    return Mapper.Map<Place, PlaceDto>(place);
  }
}