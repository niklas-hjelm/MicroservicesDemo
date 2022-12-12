using DomainCommons.DTOs;

namespace HeroApi.Requests;

public class PostHeroRequest : IHttpRequest
{
    public HeroDto Hero { get; set; }
}