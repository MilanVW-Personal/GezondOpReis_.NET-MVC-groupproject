using GezondOpReis.Models;
using GezondOpReis.ViewModels;


namespace GezondOpReis.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Activiteit, ActiviteitViewModel>();
            CreateMap<Programma, ActiviteitViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Activiteit.Naam))
                .ForMember(dest => dest.Beschrijving, opt => opt.MapFrom(src => src.Activiteit.Beschrijving));
            CreateMap<Activiteit, ActiviteitDeleteViewModel>();
            CreateMap<Activiteit, ActiviteitEditViewModel>();
            CreateMap<Bestemming, BestemmingViewModel>();
            CreateMap<Bestemming, BestemmingEditViewModel>();
            CreateMap<Bestemming, BestemmingDeleteViewModel>();
            CreateMap<Groepsreis, GroepsReisDetailsViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Bestemming.Naam))
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Bestemming.Fotos.FirstOrDefault().Naam))
                .ForMember(dest => dest.Beschrijving, opt => opt.MapFrom(src => src.Bestemming.Beschrijving))
                .ForMember(dest => dest.MinLeeftijd, opt =>opt.MapFrom(src => src.Bestemming.MinLeeftijd))
                .ForMember(dest => dest.MaxLeeftijd, opt => opt.MapFrom(src => src.Bestemming.MaxLeeftijd));
            CreateMap<Groepsreis, GroepsReisInfoViewModel>()
            .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Bestemming.Naam))
            .ForMember(dest => dest.Fotos, opt => opt.MapFrom(src => src.Bestemming.Fotos.Select(f => f.Naam).ToList()))
            .ForMember(dest => dest.Beschrijving, opt => opt.MapFrom(src => src.Bestemming.Beschrijving))
            .ForMember(dest => dest.MinLeeftijd, opt => opt.MapFrom(src => src.Bestemming.MinLeeftijd))
            .ForMember(dest => dest.MaxLeeftijd, opt => opt.MapFrom(src => src.Bestemming.MaxLeeftijd));
            CreateMap<Kind, KindViewModel>();
            CreateMap<Kind, KindEditViewModel>();
            CreateMap<Kind, KindDeleteViewModel>();
        }
    }
}
