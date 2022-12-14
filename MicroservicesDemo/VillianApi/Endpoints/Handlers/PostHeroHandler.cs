using DomainCommons.DTOs;
using DomainCommons.Services;
using MediatR;
using VillainApi.Endpoints.Requests;

namespace VillainApi.Endpoints.Handlers;

public class PostHeroHandler : IRequestHandler<PostVillainRequest, IResult>
{

    private readonly IResponseService<VillainDto> _villainResponseService;

    public PostHeroHandler(IResponseService<VillainDto> villainResponseService)
    {
        _villainResponseService = villainResponseService;
    }

    public async Task<IResult> Handle(PostVillainRequest request, CancellationToken cancellationToken)
    {
        var response = await _villainResponseService.Add(request.Villain);

        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}