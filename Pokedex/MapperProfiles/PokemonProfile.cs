using System;
using AutoMapper;
using Pokedex.Dtos;
using Pokedex.Models;
using System.Linq;

namespace Pokedex.MapperProfiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<PokemonDto, Pokemon>()
                .ForMember(dst =>
                    dst.Description,
                    opt => opt.MapFrom(src => src.FlavorTextEntries.FirstOrDefault() == null ? string.Empty : src.FlavorTextEntries.FirstOrDefault().FlavorText))
                .ForMember(dst =>
                    dst.Habitat,
                    opt => opt.MapFrom(src => src.Habitat.Name));
               
        }
    }
}
