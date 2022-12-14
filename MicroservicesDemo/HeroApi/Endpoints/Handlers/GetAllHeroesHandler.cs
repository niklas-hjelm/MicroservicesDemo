using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class GetAllHeroesHandler : IRequestHandler<GetAllHeroesRequest, IResult>
{
    private readonly IResponseService<HeroDto> _heroResponseService;

    public GetAllHeroesHandler(IResponseService<HeroDto> heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(GetAllHeroesRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.GetAll();
        return Results.Ok(response);
    }
}