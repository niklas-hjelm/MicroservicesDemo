using DomainCommons.DTOs;
using DomainCommons.Services;
using MediatR;
using VillainApi.Endpoints.Requests;

namespace VillainApi.Endpoints.Handlers;

public class DeleteHeroHandler : IRequestHandler<DeleteVillainByIdRequest, IResult>
{
    private readonly IResponseService<VillainDto> _villainResponseService;

    public DeleteHeroHandler(IResponseService<VillainDto> villainResponseService)
    {
        _villainResponseService = villainResponseService;
    }

    public async Task<IResult> Handle(DeleteVillainByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _villainResponseService.Delete(request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}