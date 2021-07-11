using System;
using System.Threading.Tasks;
using Pokedex.Models;
using Refit;

namespace Pokedex.Services
{
    public interface IPokeService
    {
        Task<Pokemon> Get(string name);
    }
}
