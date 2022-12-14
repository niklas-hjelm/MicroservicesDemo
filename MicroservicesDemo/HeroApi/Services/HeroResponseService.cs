using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using System.Text.RegularExpressions;
using DomainCommons.Services;

namespace HeroApi.Services;

public class HeroResponseService: IResponseService<HeroDto>
{
    private readonly IRepository<HeroDto> _repository;

    public HeroResponseService(IRepository<HeroDto> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<HeroDto?>> Add(HeroDto newVillain)
    {
        if (!Regex.IsMatch(newVillain.Name, "\\w+", RegexOptions.NonBacktracking))
        {
            return new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = "Name can not be empty and must contain letters."
            };
        }

        return new ServiceResponse<HeroDto?>()
        {
            Success = true,
            Data = await _repository.Add(newVillain),
            Message = $"Successfully added hero: {newVillain.Name}"
        };
    }

    public async Task<ServiceResponse<HeroDto?>> GetOne(object id)
    {
        var hero = await _repository.GetById(id);
        return hero is null
            ? new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = $"No hero with the id: {(int)id} was found."
            }
            : new ServiceResponse<HeroDto?>()
            {
                Success = true,
                Data = hero,
                Message = "Here you go!"
            };
    }

    public async Task<ServiceResponse<IEnumerable<HeroDto>>> GetAll()
    {
        return new ServiceResponse<IEnumerable<HeroDto>>()
        {
            Success = true,
            Data = await _repository.GetAll(),
            Message = "Here you go!"
        };
    }

    public async Task<ServiceResponse<HeroDto?>> UpdateOne(HeroDto newHero, object id)
    {
        var hero = await _repository.Update(newHero, id);
        return hero is null
            ? new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = $"No hero with the id: {(int)id} was found!"
            }
            : new ServiceResponse<HeroDto?>()
            {
                Success = true,
                Data = hero,
                Message = $"Hero with the id: {(int)id} was updated!"
            };
    }

    public async Task<ServiceResponse<HeroDto?>> Delete(object id)
    {
        var hero = await _repository.Delete((int)id);
        return hero is null
            ? new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = $"No hero with the id: {(int)id} was found!"
            }
            : new ServiceResponse<HeroDto?>()
            {
                Success = true,
                Data = hero,
                Message = $"Hero with the id: {(int)id} was deleted!"
            };
    }
}