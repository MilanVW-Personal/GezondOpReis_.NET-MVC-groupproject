using GezondOpReis.Models;

namespace GezondOpReis.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Groepsreis, GroepsReisDetailsViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Bestemming.Naam))
                .ForMember(dest => dest.Beschrijving, opt => opt.MapFrom(src => src.Bestemming.Beschrijving));
        }
    }
}
