using System;
using System.Collections.Generic;
using System.Text;
using PokeApiNet;

namespace ApplicationLayer
{
    public interface IPokemonService
    {
        public string GetPokemonDesctiption(string name);
    }
}
