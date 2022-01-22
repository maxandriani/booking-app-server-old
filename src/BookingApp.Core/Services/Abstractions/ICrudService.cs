namespace BookingApp.Services.Abstractions;

public interface ICrudService<TEntityDto, TKey, TSearchRequest, TCreateUpdateInput> :
  IReadOnlyService<TEntityDto, TKey, TSearchRequest>,
  ICreateable<TCreateUpdateInput, TEntityDto>,
  IUpdateable<TKey, TCreateUpdateInput, TEntityDto>,
  IDeleteable<TKey>
{
}

public interface ICrudService<TEntityDto, TKey, TSearchRequest, TCreateInput, TUpdateInput> :
  IReadOnlyService<TEntityDto, TKey, TSearchRequest>,
  ICreateable<TCreateInput, TEntityDto>,
  IUpdateable<TKey, TUpdateInput, TEntityDto>,
  IDeleteable<TKey>
{
}
