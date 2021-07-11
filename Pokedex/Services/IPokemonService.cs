﻿using System;
using System.Threading.Tasks;
using Pokedex.Models;
using Refit;

namespace Pokedex.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> Get(string name);
    }
}
