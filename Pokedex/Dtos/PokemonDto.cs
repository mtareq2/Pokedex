using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pokedex.Models;

namespace Pokedex.Dtos
{
    public class PokemonDto
    {
        public PokemonDto()
        {
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("flavor_text_entries")]
        public IEnumerable<FlavorTextEntry> FlavorTextEntries { get; set; }

        [JsonPropertyName("habitat")]
        public Habitat Habitat { get; set; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; set; }
    }
}
