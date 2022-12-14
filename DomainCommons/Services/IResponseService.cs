using DomainCommons.ResponseTypes;

namespace DomainCommons.Services;

public interface IResponseService<TDto>
{
    Task<ServiceResponse<TDto?>> Add(TDto newVillain);
    Task<ServiceResponse<TDto?>> GetOne(object id);
    Task<ServiceResponse<IEnumerable<TDto>>> GetAll();
    Task<ServiceResponse<TDto?>> UpdateOne(TDto newHero, object id);
    Task<ServiceResponse<TDto?>> Delete(object id);
}