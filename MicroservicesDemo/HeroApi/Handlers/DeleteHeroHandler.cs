using HeroApi.Requests;
using HeroApi.Services;
using MediatR;

namespace HeroApi.Handlers;

public class DeleteHeroHandler : IRequestHandler<DeleteHeroByIdRequest, IResult>
{
    private readonly IHeroResponseService _heroResponseService;

    public DeleteHeroHandler(IHeroResponseService heroResponseService)
    {
        _heroResponseService = heroResponseService;
    }

    public async Task<IResult> Handle(DeleteHeroByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _heroResponseService.DeleteHeroWithId(request.Id);
        return response.Success
            ? Results.Ok(response)
            : Results.NotFound(response);
    }
}