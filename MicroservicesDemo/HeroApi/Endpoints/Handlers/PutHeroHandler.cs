using HeroApi.Endpoints.Requests;
using HeroApi.Services;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class PutHeroHandler : IRequestHandler<PutHeroRequest, IResult>
{
    private readonly IHeroResponseService _heroResponseService;

    public PutHeroHandler(IHeroResponseService heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(PutHeroRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.UpdateHeroWithId(request.Hero, request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}