using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class GetHeroHandler : IRequestHandler<GetHeroByIdRequest, IResult>
{
    private readonly IResponseService<HeroDto> _heroResponseService;

    public GetHeroHandler(IResponseService<HeroDto> heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(GetHeroByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.GetOne(request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}