using DomainCommons.DTOs;
using DomainCommons.Services;
using MediatR;
using VillainApi.Endpoints.Requests;

namespace VillainApi.Endpoints.Handlers;

public class PutVillainHandler : IRequestHandler<PutVillainRequest, IResult>
{
    private readonly IResponseService<VillainDto> _villainResponseService;

    public PutVillainHandler(IResponseService<VillainDto> villainResponseService)
    {
        _villainResponseService = villainResponseService;
    }

    public async Task<IResult> Handle(PutVillainRequest request, CancellationToken cancellationToken)
    {
        var response = await _villainResponseService.UpdateOne(request.Villain, request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}