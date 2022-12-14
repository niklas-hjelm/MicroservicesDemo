using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class PostHeroHandler : IRequestHandler<PostHeroRequest, IResult>
{

    private readonly IResponseService<HeroDto> _heroResponseService;

    public PostHeroHandler(IResponseService<HeroDto> heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(PostHeroRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.Add(request.Hero);

        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}