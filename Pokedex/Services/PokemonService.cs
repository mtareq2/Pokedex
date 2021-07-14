using System.Threading.Tasks;
using AutoMapper;
using Pokedex.Dtos;
using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly IPokemonRepo _pokemonRepo;
        private readonly ITranslateRepo _translateRepo;
        private readonly IMapper _mapper;

        public PokemonService(IPokemonRepo pokemonRepo, ITranslateRepo translateRepo, IMapper mapper)
        {
            _pokemonRepo = pokemonRepo;
            _translateRepo = translateRepo;
            _mapper = mapper;
        }

        public async Task<Pokemon> Get(string name)
        {
            var pokemonDto = await _pokemonRepo.Get(name);
            var pokemon = _mapper.Map<Pokemon>(pokemonDto);

            return pokemon;
        }

        public async Task<Pokemon> GetTranslated(string name)
        {
            var pokemon = await this.Get(name);
            pokemon.Description = await getTranslatedPokemonDescription(pokemon);

            return pokemon;
        }

        private async Task<string> getTranslatedPokemonDescription(Pokemon pokemon)
        {
            var pokemonDescription = pokemon?.Description;
            if (string.IsNullOrEmpty(pokemonDescription))
            {
                // log error/warning
                return string.Empty;
            }

            // In Mac response has extra /n which makes FunTranslate function fail 
            pokemonDescription = pokemonDescription.Replace(System.Environment.NewLine, " ");

            const string CaveHabitat = "cave";
            FunTranslationDto translatedDescription;
            try
            {
                if (pokemon.IsLegendary || pokemon.Habitat.ToLower() == CaveHabitat)
                {
                    translatedDescription = await _translateRepo.GetYoda(pokemonDescription);
                }
                else
                {
                    translatedDescription = await _translateRepo.GetShakespear(pokemonDescription);
                }

                if (translatedDescription?.Success?.Total > 0 &&
                    !string.IsNullOrEmpty(translatedDescription.Contents?.Translated))
                {
                    return translatedDescription.Contents.Translated;
                }
                else
                {
                    // log failed, returning original description
                    return pokemon.Description;
                }
            }
            catch (System.Exception ex)
            {
                // log ex, returning original description
                return pokemon.Description;
            }
        }
    }
}
