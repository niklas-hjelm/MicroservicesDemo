using DomainCommons.DTOs;

namespace HeroApi.Endpoints.Requests;

public class PutHeroRequest : IHttpRequest
{
    public int Id { get; set; }

    public HeroDto Hero { get; set; }
}