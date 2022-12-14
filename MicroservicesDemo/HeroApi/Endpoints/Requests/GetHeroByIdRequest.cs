namespace HeroApi.Endpoints.Requests;

public class GetHeroByIdRequest : IHttpRequest
{
    public int Id { get; set; }
}