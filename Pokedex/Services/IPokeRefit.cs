using System;
using System.Threading.Tasks;
using Pokedex.Models;
using Refit;

namespace Pokedex.Services
{
    public interface IPokeRefit
    {
        [Get("/pokemon-species/{name}")]
        Task<Pokemon> Get(string name);
    }
}
