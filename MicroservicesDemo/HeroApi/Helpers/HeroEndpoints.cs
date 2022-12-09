using DomainCommons.DTOs;
using HeroApi.DataAccess.Repositories;

namespace HeroApi.Helpers;

public static class HeroEndpoints
{
    public static void MapHeroEndpoints(this WebApplication app)
    {
        //Create
        app.MapPost("/heroes", PostHero);

        //Read
        app.MapGet("/heroes", GetAllHeroes);
        app.MapGet("/heroes/{id:int}", GetHero);

        //Update
        app.MapPut("/heroes/{id:int}", PutHero);

        //Delete
        app.MapDelete("/heroes/{id:int}", DeleteHero);
    }

    private static async Task<IResult> DeleteHero(IHeroRepository repo, int id)
    {
        var response = await repo.DeleteHero(id);
        return response.Data
            ? Results.Ok(response.Message)
            : Results.NotFound(response.Message);
    }

    private static async Task<IResult> PostHero(IHeroRepository repo, HeroDto hero)
    {
        var response = await repo.AddHero(hero);

        return response.Data
            ? Results.Ok(response.Message)
            : Results.NotFound(response.Message);
    }

    private static async Task<IResult> GetHero(IHeroRepository repo, int id)
    {
        var response = await repo.GetHeroById(id);
        return response.Data is not null 
            ? Results.Ok(response.Data)
            : Results.NotFound(response.Message);
    }

    private static async Task<IResult> GetAllHeroes(IHeroRepository repo)
    {
        var response = await repo.GetAllHeroes();
        return Results.Ok(response.Data);
    }


    private static async Task<IResult> PutHero(IHeroRepository repo, HeroDto hero, int id)
    {
        var response = await repo.UpdateHero(hero, id);
        return response.Data 
            ? Results.Ok(response.Message) 
            : Results.NotFound(response.Message);
    }
}