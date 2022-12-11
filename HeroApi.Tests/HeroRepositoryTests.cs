using DomainCommons.DTOs;
using DomainCommons.ResponseTypes;
using FakeItEasy;
using HeroApi.DataAccess.Models;
using HeroApi.DataAccess.Repositories;
using HeroApi.Services;

namespace HeroApi.Tests
{
    public class HeroRepositoryTests
    {
        [Fact]
        public async Task GetAllHeroes_Returns_CorrectResponse()
        {
            //Arrange
            var count = 5;
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
            var responseService = A.Fake<IHeroResponseService>();
            A.CallTo(() => responseService.GetAllHeroes()).Returns(dummyResponse);

            //Act
            var response = await responseService.GetAllHeroes();
            
            //Assert
            Assert.NotNull(response.Data);
            Assert.Equal(response.Data.Count(), count);
        }
    }
}