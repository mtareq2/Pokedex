using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        [Route("~/[controller]/{name}")]
        public async Task<Pokemon> Get([Required]string name)
        {
            return await _pokemonService.Get(name);
        }

        [HttpGet]
        [Route("~/[controller]/translated/{name}")]
        public async Task<Pokemon> Translated([Required] string name)
        {
            return await _pokemonService.GetTranslated(name);

        }
    }
}
