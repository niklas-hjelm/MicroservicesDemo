using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.DataAccess.Repositories;

public class Repository : IRepository<HeroDto>, IDisposable
{
    private readonly HeroContext _heroContext;

    public Repository(HeroContext heroContext)
    {
        _heroContext = heroContext;
    }

    public async Task<HeroDto?> Add(HeroDto hero)
    {
        await _heroContext.AddAsync(new Hero()
        {
            Name = hero.Name,
            Description = hero.Description
        });

        await _heroContext.SaveChangesAsync();
        return hero;
    }

    public async Task<HeroDto?> GetById(object id)
    {
        var hero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == (int)id);
        return hero is not null
            ? new HeroDto(hero.Name, hero.Description)
            : null;
    }

    public async Task<IEnumerable<HeroDto>> GetAll()
    {
        return await _heroContext.Heroes
            .Select(h=> new HeroDto(h.Name,h.Description))
            .ToListAsync();
    }

    public async Task<HeroDto?> Update(HeroDto hero, object id)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == (int)id);
        if (existingHero is not null)
        {
            existingHero.Name = hero.Name;
            existingHero.Description = hero.Description;
            await _heroContext.SaveChangesAsync();
            return hero;
        }

        return null;
    }

    public async Task<HeroDto?> Delete(object id)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == (int)id);
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