using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using DomainCommons.Services;
using FakeItEasy;
namespace HeroApi.Tests
{
    public class HeroEndpointTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public async Task GetAllHeroes_Returns_CorrectResponse(int count)
        {
            var request = A.Dummy<GetAllHeroesRequest>();
            var cancellationToken = A.Dummy<CancellationToken>();

            var dummies = A.CollectionOfDummy<HeroDto>(count);
            var dummyResponse = 
                A.Fake<ServiceResponse<IEnumerable<HeroDto>>>(
                    d=>d.ConfigureFake(
                        a =>
                        {
                            a.Data = dummies;
                            a.Message = "Here you go!";
                        })
                    );
            var responseService = A.Fake<IResponseService<HeroDto>>();
            A.CallTo(() => responseService.GetAll()).Returns(dummyResponse);

            var handler = new GetAllHeroesHandler(responseService);

            //Act
            var response = await handler.Handle(request, cancellationToken);
            var result = (response as Ok<ServiceResponse<IEnumerable<HeroDto>>>);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotNull(result.Value.Data);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(count, result.Value.Data.Count());
        }
    }
}