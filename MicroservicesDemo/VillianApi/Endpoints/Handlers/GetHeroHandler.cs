using DomainCommons.DTOs;
using DomainCommons.Services;
using MediatR;
using VillainApi.Endpoints.Requests;

namespace VillainApi.Endpoints.Handlers;

public class GetHeroHandler : IRequestHandler<GetVillainByIdRequest, IResult>
{
    private readonly IResponseService<VillainDto> _villainResponseService;

    public GetHeroHandler(IResponseService<VillainDto> villainResponseService)
    {
        _villainResponseService = villainResponseService;
    }

    public async Task<IResult> Handle(GetVillainByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _villainResponseService.GetOne(request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}