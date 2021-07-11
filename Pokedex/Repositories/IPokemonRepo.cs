using System;
using System.Threading.Tasks;
using Pokedex.Models;
using Refit;

namespace Pokedex.Repositories
{
    public interface IPokemonRepo
    {
        [Get("/pokemon-species/{name}")]
        Task<Pokemon> Get(string name);
    }
}
