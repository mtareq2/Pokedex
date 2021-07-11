using System;
using System.Text.Json.Serialization;

namespace Pokedex.Models
{
    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }
        [JsonPropertyName("language")]
        public Language Language { get; set; }
        [JsonPropertyName("version")]
        public Version Version { get; set; }
    }
}
