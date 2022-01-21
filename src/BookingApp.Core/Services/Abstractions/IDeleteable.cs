namespace BookingApp.Services.Abstractions;

public interface IDeleteable<TKeys>
{
  Task DeleteAsync(TKeys input);
}