using HeroApi.Requests;
using HeroApi.Services;
using MediatR;

namespace HeroApi.Handlers;

public class GetAllHeroesHandler:IRequestHandler<GetAllHeroesRequest, IResult>
{
    private readonly IHeroResponseService _heroResponseService;

    public GetAllHeroesHandler(IHeroResponseService heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(GetAllHeroesRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.GetAllHeroes();
        return Results.Ok(response);
    }
}