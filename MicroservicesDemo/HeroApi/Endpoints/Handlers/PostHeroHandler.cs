using HeroApi.Endpoints.Requests;
using HeroApi.Services;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class PostHeroHandler : IRequestHandler<PostHeroRequest, IResult>
{

    private readonly IHeroResponseService _heroResponseService;

    public PostHeroHandler(IHeroResponseService heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(PostHeroRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.AddHero(request.Hero);

        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}