using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using DomainCommons.Services;

namespace VillainApi.Services;

public class VillainResponseService : IResponseService<VillainDto>
{
    private readonly IRepository<VillainDto> _repository;

    public VillainResponseService(IRepository<VillainDto> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<VillainDto?>> Add(VillainDto newVillain)
    {
        var response = await _repository.Add(newVillain);
        return response is not null
            ? new ServiceResponse<VillainDto?>
            {
                Success = true,
                Data = response,
                Message = "Great Success!"
            }
            : new ServiceResponse<VillainDto?>
            {
                Success = false,
                Data = response,
                Message = "NO Success!"
            };
    }

    public async Task<ServiceResponse<VillainDto?>> GetOne(object id)
    {
        var response = await _repository.GetById(id);
        return response is not null
            ? new ServiceResponse<VillainDto?>()
            {
                Success = true,
                Data = response,
                Message = "Great Success!"
            }
            : new ServiceResponse<VillainDto?>
            {
                Success = false,
                Data = response,
                Message = "NO Success!"
            };
    }

    public async Task<ServiceResponse<IEnumerable<VillainDto>>> GetAll()
    {
        var response = await _repository.GetAll();
        return new ServiceResponse<IEnumerable<VillainDto>>()
        {
            Success = true,
            Data = response,
            Message = "Great Success!"
        };
    }

    public Task<ServiceResponse<VillainDto?>> UpdateOne(VillainDto newHero, object id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<VillainDto?>> Delete(object id)
    {
        throw new NotImplementedException();
    }
}