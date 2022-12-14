namespace VillainApi.Endpoints.Requests;

public class DeleteVillainByIdRequest : IHttpRequest
{
    public string Id { get; set; }
}