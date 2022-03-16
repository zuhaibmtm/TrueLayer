using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrueLayer.Application;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TrueLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public PokemonEntity Get(string pokemonName)
        {
            PokemonEntity pokemonEntity = new PokemonEntity();
            var result = _pokemonService.GetPokemonDesctiption(pokemonName);
            if (result != null)
            {
                pokemonEntity = new PokemonEntity()
                {
                    name = pokemonName,
                    description = result,
                }; 
            }
            return pokemonEntity;
        }
    }
}
