using DomainCommons.DTOs;

namespace HeroApi.Endpoints.Requests;

public class PostHeroRequest : IHttpRequest
{
    public HeroDto Hero { get; set; }
}