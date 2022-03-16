using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TrueLayer.Application.Tests
{
    [TestClass]
    public class PokemonServiceTest
    {
        //[TestInitialize]

        //private Mock<PokemonService> mockPokemonService;


        //public virtual void Setup()
        //{
        //    mockPokemonService = new Mock<PokemonService>();
        //}


        //[TestMethod]
        //public async Task GetPokemonTranslation_Should_ReturnPokemon()
        //{
        //    //Arrange
        //    string name = "pikachu";
        //    mockPokeApiService.Setup(c => c.GetPokemonDescription(
        //        name)).Returns(Task.FromResult("description"));

        //    mockShakeService.Setup(c => c.TranslateText(
        //        It.IsAny<string>())).Returns(
        //        Task.FromResult("shake description"));

        //    //Act
        //    var result = await ptService.GetPokemonTranslation(name);

        //    //Assert
        //    Assert.IsTrue(!string.IsNullOrEmpty(result.description));
        //    Assert.IsTrue(!string.IsNullOrEmpty(result.name));
        //}
    }
}
