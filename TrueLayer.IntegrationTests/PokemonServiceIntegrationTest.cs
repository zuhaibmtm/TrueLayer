using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrueLayer.Application;

namespace TrueLayer.IntegrationTests
{
    [TestClass]
    public class PokemonServiceIntegrationTest
    {
        private IPokemonService _pokemonService;

        public PokemonServiceIntegrationTest()
        {
            _pokemonService = new PokemonService();
        }


        [TestMethod]
        public void GetPokemon_description()
        {
            //Arrange
            string name = "charizard";

            //Act
            var result = _pokemonService.GetPokemonDesctiption(name);

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }


        [TestMethod]
        public void GetPokemon_shakespearText()
        {
            //Arrange
            string text = "Hi this is charizard";

            //Act
            var result = _pokemonService.ShakespearText(text);

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }
    }
}
