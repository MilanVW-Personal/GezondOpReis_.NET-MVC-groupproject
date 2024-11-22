using GezondOpReis.Models;

namespace GezondOpReis.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Groepsreis, GroepsReisDetailsViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Bestemming.Naam))
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Bestemming.Fotos.FirstOrDefault().Naam))
                .ForMember(dest => dest.Beschrijving, opt => opt.MapFrom(src => src.Bestemming.Beschrijving))
                .ForMember(dest => dest.MinLeeftijd, opt =>opt.MapFrom(src => src.Bestemming.MinLeeftijd))
                .ForMember(dest => dest.MaxLeeftijd, opt => opt.MapFrom(src => src.Bestemming.MaxLeeftijd));

        }
    }
}
