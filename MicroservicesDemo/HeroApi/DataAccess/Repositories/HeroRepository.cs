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

    public async Task<ServiceResponse<bool>> AddHero(HeroDto hero)
    {
        if (!Regex.IsMatch(hero.Name, "\\w+", RegexOptions.NonBacktracking))
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "Name can´t be empty"
            };
        }

        await _heroContext.AddAsync(new Hero()
        {
            Name = hero.Name,
            Description = hero.Description
        });

        await _heroContext.SaveChangesAsync();
        return new ServiceResponse<bool>
        {
            Success = true,
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
                Success = true,
                Data = hero,
                Message = "Here you go!"
            }
            : new ServiceResponse<Hero?>()
            {
                Success = false,
                Message = $"No hero with the id:{id} was found in the database."
            };
    }

    public async Task<ServiceResponse<IEnumerable<Hero>>> GetAllHeroes()
    {
        return new ServiceResponse<IEnumerable<Hero>>()
        {
            Success = true,
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
                Success = true,
                Data = true,
                Message = $"Hero with id:{id} was updated."
            };
        }

        return new ServiceResponse<bool>()
        {
            Success = false,
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
                Success = true,
                Data = true,
                Message = $"Hero with id:{id} was successfully deleted."
            };
        }

        return new ServiceResponse<bool>()
        {
            Success = true,
            Message = $"No Hero with id: {id} was found to delete."
        };
    }

    public void Dispose()
    {
        _heroContext.Dispose();
    }
}