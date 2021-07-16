using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Pokedex.Controllers;
using Pokedex.Repositories;
using Pokedex.Services;

namespace Pokedex.Test
{
    public class PokemonControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_ReturnsCorrectPokemon()
        {
            // Arrange
            const string pokemonName = "mewtwo";
            var loggerMock = new Mock<ILogger<PokemonController>>();
            var pokemonService = new Mock<IPokemonService>();
            pokemonService.Setup(p => p.Get(pokemonName)).Returns(new Task<Models.Pokemon>(()=> {
                return new Models.Pokemon() { Id = 1, Description = "test", Habitat = "rare", IsLegendary = true };
            }));


            // Act
            var pokemonController = new PokemonController(loggerMock.Object, pokemonService.Object);
            var result = await pokemonController.Get(pokemonName);

            // Assert
            Assert.AreEqual(1,result.Id);
            Assert.AreEqual("test", result.Description);
            pokemonService.Verify(mock => mock.Get(pokemonName), Times.Once());
        }

        public async Task GetTranslated_ReturnsCorrectPokemonWithTranslatedDescription()
        {
            // Arrange
            const string pokemonName = "mewtwo";
            var loggerMock = new Mock<ILogger<PokemonController>>();
            var pokemonService = new Mock<IPokemonService>();
            var translateService = new Mock<ITranslateRepo>();
            pokemonService.Setup(p => p.GetTranslated(pokemonName)).Returns(new Task<Models.Pokemon>(() => {
                return new Models.Pokemon() { Id = 1, Description = "test", Habitat = "cave", IsLegendary = true };
            }));


            // Act
            var pokemonController = new PokemonController(loggerMock.Object, pokemonService.Object);
            var result = await pokemonController.Get(pokemonName);

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("test", result.Description);
            pokemonService.Verify(mock => mock.GetTranslated(pokemonName), Times.Once());
            translateService.Verify(mock => mock.GetYoda(pokemonName), Times.Once());
        }
    }
}
