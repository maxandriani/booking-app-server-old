using AutoMapper;
using BookingApp.Data;
using BookingApp.Services.Abstractions;
using BookingApp.Services.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingApp.Payments;

public interface IAccountService : ICrudService<AccountDto, GetByIdRequest, SearchAccountRequest, CreateUpdateAccountDto>
{}

public class AccountService :
  CrudService<Account, AccountDto, GetByIdRequest, SearchAccountRequest, CreateUpdateAccountDto>,
  IAccountService
{
  public AccountService(ILogger<AccountService> logger, IMapper mapper, IBookingAppDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  protected override IQueryable<Account> CreateCollectionQuery(IQueryable<Account> query, SearchAccountRequest input)
  {
    if (string.IsNullOrEmpty(input.Search) == false)
      query = query.Where(p => p.Name.ToLower().Contains(input.Search.ToLower()));
    
    return query;
  }

  protected override IQueryable<Account> DefaultSorting(IQueryable<Account> query) => query.OrderBy(p => p.Name);

  protected override Account GetEntityById(GetByIdRequest keys) => DbSet.Where(p => p.Id == keys.Id).First();
}