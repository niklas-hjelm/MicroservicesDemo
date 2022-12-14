using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class DeleteHeroHandler : IRequestHandler<DeleteHeroByIdRequest, IResult>
{
    private readonly IResponseService<HeroDto> _heroResponseService;

    public DeleteHeroHandler(IResponseService<HeroDto> heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(DeleteHeroByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.Delete(request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}