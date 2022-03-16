using System;
using System.Collections.Generic;
using System.Text;
using PokeApiNet;

namespace TrueLayer.Application
{
    public interface IPokemonService
    {
        public string GetPokemonDesctiption(string name);
    }
}
