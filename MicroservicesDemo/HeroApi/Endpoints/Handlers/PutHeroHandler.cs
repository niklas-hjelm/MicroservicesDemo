using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class PutHeroHandler : IRequestHandler<PutHeroRequest, IResult>
{
    private readonly IResponseService<HeroDto> _heroResponseService;

    public PutHeroHandler(IResponseService<HeroDto> heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(PutHeroRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.UpdateOne(request.Hero, request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}