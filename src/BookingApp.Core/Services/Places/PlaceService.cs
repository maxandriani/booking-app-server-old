using System.Text.Json;
using AutoMapper;
using BookingApp.Services.Requests;
using BookingApp.Services.Results;
using BookingApp.Services.Abstractions;
using BookingApp.Data;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Places;

public class PlaceService :
  CrudService<Place, PlaceDto, GetByIdRequest, SearchPlaceRequest, CreateUpdatePlaceDto>,
  IPlaceService
{
  public PlaceService(ILogger<PlaceService> logger, IMapper mapper, IBookingAppDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  protected override IQueryable<Place> CreateCollectionQuery(IQueryable<Place> query, SearchPlaceRequest input)
  {
    if (!string.IsNullOrEmpty(input?.Search)) {
      query = query.Where(p => p.Name.ToLower().Contains(input.Search.ToLower()));
    }

    return query;
  }

  protected override IQueryable<Place> DefaultSorting(IQueryable<Place> query) => query.OrderBy(p => p.Name);

  protected override Place GetEntityById(GetByIdRequest keys) => DbSet.First(p => p.Id == keys.Id);
}