using System.Text.RegularExpressions;
using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.DataAccess.Repositories;

public class HeroRepository : IHeroRepository, IDisposable
{
    private readonly HeroContext _heroContext;

    public HeroRepository(HeroContext heroContext)
    {
        _heroContext = heroContext;
    }

    public async Task<HeroDto?> AddHero(HeroDto hero)
    {
        await _heroContext.AddAsync(new Hero()
        {
            Name = hero.Name,
            Description = hero.Description
        });

        await _heroContext.SaveChangesAsync();
        return hero;
    }

    public async Task<HeroDto?> GetHeroById(int id)
    {
        var hero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        return hero is not null
            ? new HeroDto(hero.Name, hero.Description)
            : null;
    }

    public async Task<IEnumerable<HeroDto>> GetAllHeroes()
    {
        return _heroContext.Heroes
            .Select(h=> new HeroDto(h.Name,h.Description))
            .ToList();
    }

    public async Task<HeroDto?> UpdateHero(HeroDto hero, int id)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        if (existingHero is not null)
        {
            existingHero.Name = hero.Name;
            existingHero.Description = hero.Description;
            await _heroContext.SaveChangesAsync();
            return hero;
        }

        return null;
    }

    public async Task<HeroDto?> DeleteHero(int id)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        if (existingHero is not null)
        {
            _heroContext.Heroes.Remove(existingHero);
            await _heroContext.SaveChangesAsync();
            return new HeroDto(existingHero.Name, existingHero.Description);
        }

        return null;
    }

    public void Dispose()
    {
        _heroContext.Dispose();
    }
}