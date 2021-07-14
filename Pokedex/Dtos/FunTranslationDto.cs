using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pokedex.Dtos
{
    public class FunTranslationDto
    {
        public FunTranslationDto()
        {
        }

        [JsonPropertyName("success")]
        public TranslationSuccess Success { get; set; }

        [JsonPropertyName("contents")]
        public TranslationContent Contents { get; set; }
    }

    public class TranslationContent
    {
        public TranslationContent()
        {
        }

        [JsonPropertyName("translated")]
        public string Translated { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("translation")]
        public string TranslationMethod { get; set; }
    }

    public class TranslationSuccess
    {
        public TranslationSuccess()
        {
        }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
