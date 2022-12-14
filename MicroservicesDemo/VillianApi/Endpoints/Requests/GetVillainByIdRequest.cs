namespace VillainApi.Endpoints.Requests;

public class GetVillainByIdRequest : IHttpRequest
{
    public int Id { get; set; }
}