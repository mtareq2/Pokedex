using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PokemonController> _logger;
        private readonly IPokeService _pokeService;

        public PokemonController(ILogger<PokemonController> logger, IPokeService pokeService)
        {
            _logger = logger;
            _pokeService = pokeService;
        }

        [HttpGet]
        [Route("~/[controller]/{name}")]
        public async Task<Pokemon> Get([Required]string name)
        {
            // validate/sanitize name
            return await _pokeService.Get(name);
        }
    }
}
