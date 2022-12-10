using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using HeroApi.DataAccess.Models;

namespace HeroApi.DataAccess.Repositories;

public interface IHeroRepository
{
    Task<ServiceResponse<bool>> AddHero(HeroDto hero);
    Task<ServiceResponse<Hero?>> GetHeroById(int id);
    Task<ServiceResponse<IEnumerable<Hero>>> GetAllHeroes();
    Task<ServiceResponse<bool>> UpdateHero(HeroDto hero, int id);
    Task<ServiceResponse<bool>> DeleteHero(int id);
}