namespace BookingApp.Services;

public interface IDeleteable<TKeys>
{
  Task DeleteAsync(TKeys input);
}