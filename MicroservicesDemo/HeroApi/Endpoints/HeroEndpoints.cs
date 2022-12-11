using DomainCommons.DTOs;
using HeroApi.DataAccess.Repositories;
using HeroApi.Services;

namespace HeroApi.Endpoints;

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

    private static async Task<IResult> DeleteHero(IHeroResponseService heroService, int id)
    {
        var response = await heroService.DeleteHeroWithId(id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }

    private static async Task<IResult> PostHero(IHeroResponseService heroService, HeroDto hero)
    {
        var response = await heroService.AddHero(hero);

        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }

    private static async Task<IResult> GetHero(IHeroResponseService heroService, int id)
    {
        var response = await heroService.GetHeroWithId(id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }

    private static async Task<IResult> GetAllHeroes(IHeroResponseService heroService)
    {
        var response = await heroService.GetAllHeroes();
        return Results.Ok(response);
    }


    private static async Task<IResult> PutHero(IHeroResponseService heroService, HeroDto hero, int id)
    {
        var response = await heroService.UpdateHeroWithId(hero, id);
        return response.Success
            ? Results.Ok(response) 
            : Results.NotFound(response);
    }
}