namespace DomainCommons.Services;

public interface IRepository<TDto>
{
    Task<TDto?> Add(TDto dto);
    Task<TDto?> GetById(object id);
    Task<IEnumerable<TDto>> GetAll();
    Task<TDto?> Update(TDto dto, object id);
    Task<TDto?> Delete(object id);
}