namespace HeroApi.Endpoints.Requests;

public class DeleteHeroByIdRequest : IHttpRequest
{
    public int Id { get; set; }
}