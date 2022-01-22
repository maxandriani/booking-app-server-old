using BookingApp.Services.Abstractions;
using BookingApp.Services.Requests;

namespace BookingApp.Payments;

public interface IPaymentService : ICrudService<PaymentDto, GetByIdRequest, SearchPaymentRequest, CreateUpdatePaymentDto>
{
  Task<PaymentDto> ConfirmAsync(GetByIdRequest payment, ConfirmPaymentDto confirmation);
  Task<PaymentDto> UnConfirmAsync(GetByIdRequest payment);
}
