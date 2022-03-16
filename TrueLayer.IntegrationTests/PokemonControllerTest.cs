using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TrueLayer.IntegrationTests
{
    [TestClass]
    public class PokemonControllerTest
    {
        private HttpClient _client;
        public PokemonControllerTest()
        {
            _client = new HttpClient()
            {
                BaseAddress = new System.Uri("https://localhost:44368/")
            };
            this._client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        [TestMethod]
        public async Task GetPokemonDescription()
        {
            //Arrange
            //Act
            var response = await _client.GetAsync("Pokemon/charizard");

            //Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
            var content = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(content);
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }
    }
}
