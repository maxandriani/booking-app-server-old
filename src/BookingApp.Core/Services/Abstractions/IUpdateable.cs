namespace BookingApp.Services.Abstractions;

public interface IUpdateable<TKey, TInput, TOutput>
{
  Task<TOutput> UpdateAsync(TKey keys, TInput input);
}

public interface IUpdateable<Tkey, TInput> : IUpdateable<Tkey, TInput, TInput> {}