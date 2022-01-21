namespace BookingApp.Services.Abstractions;

public interface IReadable<TKey, TOutput>
{
  Task<TOutput> GetByIdAsync(TKey keys);
}