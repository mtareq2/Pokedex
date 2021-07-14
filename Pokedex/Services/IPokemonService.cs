﻿using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> Get(string name);
        Task<Pokemon> GetTranslated(string name);
    }
}
