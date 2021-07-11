using System;
using System.Text.Json.Serialization;

namespace Pokedex.Models
{
    public class Language
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
