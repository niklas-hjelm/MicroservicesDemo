using DomainCommons.ResponseTypes;
using FakeItEasy;
using HeroApi.DataAccess.Models;
using HeroApi.DataAccess.Repositories;

namespace HeroApi.Tests
{
    public class HeroRepositoryTests
    {
        [Fact]
        public async Task GetAllHeroes_Returns_CorrectResponse()
        {
            //Arrange
            var count = 5;
            var dummies = A.CollectionOfDummy<Hero>(count);
            var dummyResponse = 
                A.Fake<ServiceResponse<IEnumerable<Hero>>>(
                    d=>d.ConfigureFake(
                        a =>
                        {
                            a.Data = dummies;
                            a.Message = "Here you go!";
                        })
                    );
            var fakeRepo = A.Fake<IHeroRepository>();
            A.CallTo(() => fakeRepo.GetAllHeroes()).Returns(dummyResponse);

            //Act
            var response = await fakeRepo.GetAllHeroes();
            
            //Assert
            Assert.NotNull(response.Data);
            Assert.Equal(response.Data.Count(), count);
        }
    }
}