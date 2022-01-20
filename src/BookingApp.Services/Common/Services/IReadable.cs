namespace BookingApp.Services;

public interface IReadable<TKey, TOutput>
{
  Task<TOutput> GetByIdAsync(TKey keys);
}