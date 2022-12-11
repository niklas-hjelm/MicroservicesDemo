using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using HeroApi.DataAccess.Models;
using HeroApi.DataAccess.Repositories;
using System.Text.RegularExpressions;

namespace HeroApi.Services;

public class HeroResponseService: IHeroResponseService
{
    private readonly IHeroRepository _repository;

    public HeroResponseService(IHeroRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<HeroDto?>> AddHero(HeroDto newHero)
    {
        if (!Regex.IsMatch(newHero.Name, "\\w+", RegexOptions.NonBacktracking))
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
            Data = await _repository.AddHero(newHero),
            Message = $"Successfully added hero: {newHero.Name}"
        };
    }

    public async Task<ServiceResponse<HeroDto?>> GetHeroWithId(int id)
    {
        var hero = await _repository.GetHeroById(id);
        return hero is null
            ? new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = $"No hero with the id: {id} was found."
            }
            : new ServiceResponse<HeroDto?>()
            {
                Success = true,
                Data = hero,
                Message = "Here you go!"
            };
    }

    public async Task<ServiceResponse<IEnumerable<HeroDto>>> GetAllHeroes()
    {
        return new ServiceResponse<IEnumerable<HeroDto>>()
        {
            Success = true,
            Data = await _repository.GetAllHeroes(),
            Message = "Here you go!"
        };
    }

    public async Task<ServiceResponse<HeroDto?>> UpdateHeroWithId(HeroDto newHero, int id)
    {
        var hero = await _repository.UpdateHero(newHero, id);
        return hero is null
            ? new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = $"No hero with the id: {id} was found!"
            }
            : new ServiceResponse<HeroDto?>()
            {
                Success = true,
                Data = hero,
                Message = $"Hero with the id: {id} was updated!"
            };
    }

    public async Task<ServiceResponse<HeroDto?>> DeleteHeroWithId(int id)
    {
        var hero = await _repository.DeleteHero(id);
        return hero is null
            ? new ServiceResponse<HeroDto?>()
            {
                Success = false,
                Data = null,
                Message = $"No hero with the id: {id} was found!"
            }
            : new ServiceResponse<HeroDto?>()
            {
                Success = true,
                Data = hero,
                Message = $"Hero with the id: {id} was deleted!"
            };
    }
}