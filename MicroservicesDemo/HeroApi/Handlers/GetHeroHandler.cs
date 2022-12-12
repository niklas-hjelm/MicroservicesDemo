using HeroApi.Requests;
using HeroApi.Services;
using MediatR;

namespace HeroApi.Handlers;

public class GetHeroHandler : IRequestHandler<GetHeroByIdRequest, IResult>
{
    private readonly IHeroResponseService _heroResponseService;

    public GetHeroHandler(IHeroResponseService heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(GetHeroByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.GetHeroWithId(request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}