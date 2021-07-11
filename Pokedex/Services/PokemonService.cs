using System.Threading.Tasks;
using AutoMapper;
using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly IPokemonRepo _pokemonRepo;
        private readonly IMapper _mapper;

        public PokemonService(IPokemonRepo pokemonRepo, IMapper mapper)
        {
            _pokemonRepo = pokemonRepo;
            _mapper = mapper;
        }

        public async Task<Pokemon> Get(string name)
        {
            var pokemonDto = await _pokemonRepo.Get(name);
            var pokemon = _mapper.Map<Pokemon>(pokemonDto);

            return pokemon;
        }

    }
}
