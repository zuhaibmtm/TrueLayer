using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PokeApiNet;

namespace TrueLayer.Application
{
    public class PokemonService : IPokemonService
    {
        private PokeApiClient _pokeClient;
        public List<NamedApiResource<Pokemon>> pokemonList = null;
        NamedApiResource<Pokemon> pokemonRes = null;


        public PokemonService()
        {
            _pokeClient = new PokeApiClient();
        }
        public PokemonService(PokeApiClient pokeApiClient)
        {
            _pokeClient = pokeApiClient;
        }
        public string GetPokemonDesctiption(string name)
        {
            Pokemon pokemon = null;
            PokemonSpecies species = null;
            PokemonSpeciesFlavorTexts flavorText = null;
            var clientResult = Task.Run(() => _pokeClient.GetNamedResourcePageAsync<Pokemon>(-1, 0, default)).Result;
            pokemonList = clientResult.Results;
            string description = string.Empty;

            if (pokemonList.Count() > 0)
            {
                pokemonRes = pokemonList.FirstOrDefault(c => c.Name == name);
            }

            if (pokemonRes != null)
            {
                pokemon = Task.Run(() => _pokeClient.GetResourceAsync<Pokemon>(pokemonRes)).Result;
            }

            if (pokemon != null)
            {
                species = Task.Run(() => _pokeClient.GetResourceAsync<PokemonSpecies>(pokemon.Species)).Result; 
            }

            if (species != null)
            {
                flavorText = species.FlavorTextEntries.FirstOrDefault(c => c.Language.Name == "en");
            }

            if (flavorText != null)
            {
                description = ShakespearText(flavorText?.FlavorText);
            }

            return description;

        }


        private string ShakespearText (string text)
        {
            string finalText = string.Empty;
            HttpClient httpClient = new HttpClient();
            var cleanText = text.Replace("\n", " ").Replace("\r", " ");

            httpClient = new HttpClient()
            {
                BaseAddress = new System.Uri(
                    "https://api.funtranslations.com/")
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string data = HttpUtility.UrlEncode(cleanText);
            var httpResponse = Task.Run(() => httpClient.GetAsync($"translate/" +$"shakespeare?text=" + $"{data}")).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                dynamic contentResult = JsonConvert.DeserializeObject(
                     Task.Run(() => httpResponse.Content.ReadAsStringAsync()).Result);
                finalText = contentResult["contents"]["translated"];
            }
            return finalText;
        }
    }
}
