using System.Threading.Tasks;
using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly IPokemonRepo _pokemonRepo;
        public PokemonService(IPokemonRepo pokemonRepo)
        {
            _pokemonRepo = pokemonRepo;
        }

        public async Task<Pokemon> Get(string name)
        {
            var pokemon = await _pokemonRepo.Get(name);

            return pokemon;
        }

    }
}
