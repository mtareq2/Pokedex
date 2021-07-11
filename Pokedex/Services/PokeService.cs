using System;
using System.Net.Http;
using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class PokeService : IPokeService
    {

        private readonly IPokeRefit _pokeRefit;
        public PokeService(IPokeRefit pokeRefit)
        {
            _pokeRefit = pokeRefit;
        }

        public async Task<Pokemon> Get(string name)
        {
            var pokemon = await _pokeRefit.Get(name);

            return pokemon;
        }

    }
}
