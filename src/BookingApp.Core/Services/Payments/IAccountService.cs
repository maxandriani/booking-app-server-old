using BookingApp.Services.Abstractions;
using BookingApp.Services.Requests;

namespace BookingApp.Payments;

public interface IAccountService : ICrudService<AccountDto, GetByIdRequest, SearchAccountRequest, CreateUpdateAccountDto>
{}
