using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using HeroApi.DataAccess.Models;

namespace HeroApi.Services;

public interface IHeroResponseService
{
    Task<ServiceResponse<HeroDto?>> AddHero(HeroDto newHero);
    Task<ServiceResponse<HeroDto?>> GetHeroWithId(int id);
    Task<ServiceResponse<IEnumerable<HeroDto>>> GetAllHeroes();
    Task<ServiceResponse<HeroDto?>> UpdateHeroWithId(HeroDto newHero, int id);
    Task<ServiceResponse<HeroDto?>> DeleteHeroWithId(int id);
}