using DomainCommons.DTOs;
using DomainCommons.Models;
using DomainCommons.ResponseTypes;

namespace HeroApi.DataAccess.Repositories;

public interface IHeroRepository
{
    Task<ServiceResponse<bool>> AddHero(HeroDto hero);
    Task<ServiceResponse<Hero?>> GetHeroById(int id);
    Task<ServiceResponse<IEnumerable<Hero>>> GetAllHeroes();
    Task<ServiceResponse<bool>> UpdateHero(HeroDto hero, int id);
    Task<ServiceResponse<bool>> DeleteHero(int id);
}