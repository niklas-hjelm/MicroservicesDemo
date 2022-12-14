using DomainCommons.DTOs;

namespace VillainApi.Endpoints.Requests;

public class PutVillainRequest : IHttpRequest
{
    public int Id { get; set; }

    public VillainDto Villain { get; set; }
}