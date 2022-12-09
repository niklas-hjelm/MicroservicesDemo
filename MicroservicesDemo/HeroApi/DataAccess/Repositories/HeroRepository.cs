using System.Text.RegularExpressions;
using DomainCommons.DTOs;
using DomainCommons.Models;
using DomainCommons.ResponseTypes;
using HeroApi.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.DataAccess.Repositories;

public class HeroRepository : IHeroRepository, IDisposable
{
    private readonly HeroContext _heroContext;

    public HeroRepository(HeroContext heroContext)
    {
        _heroContext = heroContext;
    }

    public async Task<ServiceResponse<bool>> AddHero(HeroDto hero)
    {
        if (!Regex.IsMatch(hero.Name, "\\w+", RegexOptions.NonBacktracking))
        {
            return new ServiceResponse<bool>
            {
                Data = false,
                Message = "Name can´t be empty"
            };
        }

        await _heroContext.AddAsync(new Hero()
        {
            Name = hero.Name,
            Description = hero.Description
        });

        return new ServiceResponse<bool>
        {
            Data = true,
            Message = $"Hero: {hero} created"
        };
    }

    public async Task<ServiceResponse<Hero?>> GetHeroById(int id)
    {
        var hero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        return hero is not null
            ? new ServiceResponse<Hero?>()
            {
                Data = hero,
                Message = "Here yu go"
            }
            : new ServiceResponse<Hero?>()
            {
                Data = null,
                Message = $"No hero with the id:{id} was found in the database."
            };
    }

    public async Task<ServiceResponse<IEnumerable<Hero>>> GetAllHeroes()
    {
        return new ServiceResponse<IEnumerable<Hero>>()
        {
            Data = _heroContext.Heroes.ToList(),
            Message = "Here you go!"
        };
    }

    public async Task<ServiceResponse<bool>> UpdateHero(HeroDto hero, int id)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        if (existingHero is not null)
        {
            existingHero.Name = hero.Name;
            existingHero.Description = hero.Description;
            await _heroContext.SaveChangesAsync(); 
            return new ServiceResponse<bool>()
            {
                Data = true,
                Message = $"Hero with id:{id} was updated."
            };
        }

        return new ServiceResponse<bool>()
        {
            Data = false,
            Message = $"No Hero with id: {id} was found to update."
        };
    }

    public async Task<ServiceResponse<bool>> DeleteHero(int id)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        if (existingHero is not null)
        {
            _heroContext.Heroes.Remove(existingHero);
            await _heroContext.SaveChangesAsync();
            return new ServiceResponse<bool>()
            {
                Data = true,
                Message = $"Hero with id:{id} was successfully deleted."
            };
        }

        return new ServiceResponse<bool>()
        {
            Data = false,
            Message = $"No Hero with id: {id} was found to delete."
        };
    }

    public void Dispose()
    {
        _heroContext.Dispose();
    }
}