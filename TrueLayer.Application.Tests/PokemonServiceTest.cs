using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokeApiNet;

namespace TrueLayer.Application.Tests
{
    [TestClass]
    public class PokemonTranslatorServiceTest
    {
        private Mock<PokeApiClient> mokPokeClient;
        private Mock<IPokemonService> mokPokemonService;
        private PokemonService PokemonService;
        [TestInitialize]
        public virtual void Setup()
        {
            mokPokeClient = new Mock<PokeApiClient>();
            mokPokemonService = new Mock<IPokemonService>();
        }

        [TestMethod]
        public void GetPokemon_description()
        {
            //Arrange
            string shakespearText = "Hi this is charizard";
            string name = "charizard";
            PokemonService = new PokemonService(mokPokeClient.Object);
            mokPokemonService.Setup(x => x.ShakespearText(shakespearText)).Returns("Hi this is charizard shakespear description");

            //Act
            var result = PokemonService.GetPokemonDesctiption(name);

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }
    }
}
