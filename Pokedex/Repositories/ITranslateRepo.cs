using System.Threading.Tasks;
using Pokedex.Dtos;
using Refit;

namespace Pokedex.Repositories
{
    public interface ITranslateRepo
    {
        [Get("/shakespeare.json")]
        Task<FunTranslationDto> GetShakespear(string text);

        [Get("/yoda.json")]
        Task<FunTranslationDto> GetYoda(string text);
    }
}
