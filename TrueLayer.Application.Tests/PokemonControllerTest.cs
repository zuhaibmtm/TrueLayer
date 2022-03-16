using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrueLayer.Controllers;

namespace TrueLayer.Application.Tests
{
    [TestClass]
    public class PokemonControllerTest
    {
        private readonly Mock<IPokemonService> mockPokemonService;
        private PokemonController pokemonController;

        public PokemonControllerTest()
        {
            mockPokemonService = new Mock<IPokemonService>();
        }

        [TestMethod]
        public void GetPokemonDescription()
        {
            // Arrange
            string name = "charizard";
            this.pokemonController = new PokemonController(mockPokemonService.Object);
            mockPokemonService.Setup(x => x.GetPokemonDesctiption(name)).Returns("description");

            // Act
            var result = this.pokemonController.Get(name);

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result.description));
            Assert.IsTrue(!string.IsNullOrEmpty(result.name));
        }
    }
}
