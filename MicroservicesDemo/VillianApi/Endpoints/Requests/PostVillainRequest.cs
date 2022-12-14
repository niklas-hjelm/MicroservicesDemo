using DomainCommons.DTOs;

namespace VillainApi.Endpoints.Requests;

public class PostVillainRequest : IHttpRequest
{
    public VillainDto Villain { get; set; }
}