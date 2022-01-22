using AutoMapper;

namespace BookingApp.Services.Abstractions;

public interface ICreateable<TCreate, TOutput>
{
  Task<TOutput> CreateAsync(TCreate input);
}

public interface ICreateable<TCreate> : ICreateable<TCreate, TCreate> {}