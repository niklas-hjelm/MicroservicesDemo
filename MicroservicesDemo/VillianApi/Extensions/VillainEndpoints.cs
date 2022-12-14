using VillainApi.Endpoints.Requests;

namespace VillainApi.Extensions;

public static class VillainEndpoints
{
    public static void MapVillainEndpoints(this WebApplication app)
    {
        //Create
        app.MediatePost<PostVillainRequest>("/villains");

        //Read
        app.MediateGet<GetAllVillainsRequest>("/villains");
        app.MediateGet<GetVillainByIdRequest>("/villains/{id}");

        //Update
        app.MediatePut<PutVillainRequest>("/villains/{id}");

        //Delete
        app.MediateDelete<DeleteVillainByIdRequest>("/villains/{id}");
    }
}