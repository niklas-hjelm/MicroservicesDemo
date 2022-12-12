using DomainCommons.DTOs;

namespace HeroApi.Requests;

public class PutHeroRequest : IHttpRequest
{
    public int Id { get; set; }

    public HeroDto Hero { get; set; }
}