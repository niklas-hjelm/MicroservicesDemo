using HeroApi.Endpoints.Requests;
using HeroApi.Extensions;

namespace HeroApi.Endpoints;

public static class HeroEndpoints
{
    public static void MapHeroEndpoints(this WebApplication app)
    {
        //Create
        app.MediatePost<PostHeroRequest>("/heroes");

        //Read
        app.MediateGet<GetAllHeroesRequest>("/heroes");
        app.MediateGet<GetHeroByIdRequest>("/heroes/{id}");

        //Update
        app.MediatePut<PutHeroRequest>("/heroes/{id}");

        //Delete
        app.MediateDelete<DeleteHeroByIdRequest>("/heroes/{id}");
    }
}