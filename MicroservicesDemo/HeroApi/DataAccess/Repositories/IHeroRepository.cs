using DomainCommons.DTOs;

namespace HeroApi.DataAccess.Repositories;

public interface IHeroRepository
{
    Task<HeroDto?> AddHero(HeroDto hero);
    Task<HeroDto?> GetHeroById(int id);
    Task<IEnumerable<HeroDto>> GetAllHeroes();
    Task<HeroDto?> UpdateHero(HeroDto hero, int id);
    Task<HeroDto?> DeleteHero(int id);
}