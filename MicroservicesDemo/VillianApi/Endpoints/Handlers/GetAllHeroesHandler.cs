using DomainCommons.DTOs;
using DomainCommons.Services;
using MediatR;
using VillainApi.Endpoints.Requests;

namespace VillainApi.Endpoints.Handlers;

public class GetAllHeroesHandler : IRequestHandler<GetAllVillainsRequest, IResult>
{
    private readonly IResponseService<VillainDto> _villainResponseService;

    public GetAllHeroesHandler(IResponseService<VillainDto> villainResponseService)
    {
        _villainResponseService = villainResponseService;
    }

    public async Task<IResult> Handle(GetAllVillainsRequest request, CancellationToken cancellationToken)
    {
        var response = await _villainResponseService.GetAll();
        return Results.Ok(response);
    }
}