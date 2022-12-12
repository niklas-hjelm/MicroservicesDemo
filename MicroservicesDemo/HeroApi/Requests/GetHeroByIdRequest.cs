namespace HeroApi.Requests;

public class GetHeroByIdRequest : IHttpRequest
{
    public int Id { get; set; }
}