namespace HeroApi.Requests;

public class DeleteHeroByIdRequest : IHttpRequest
{
    public int Id { get; set; }
}