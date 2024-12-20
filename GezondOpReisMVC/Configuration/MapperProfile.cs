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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Bestemming.Naam))
                .ForMember(dest => dest.Fotos, opt => opt.MapFrom(src => src.Bestemming.Fotos.Select(f => f.Naam).ToList()))
                .ForMember(dest => dest.Beschrijving, opt => opt.MapFrom(src => src.Bestemming.Beschrijving))
                .ForMember(dest => dest.MinLeeftijd, opt => opt.MapFrom(src => src.Bestemming.MinLeeftijd))
                .ForMember(dest => dest.MaxLeeftijd, opt => opt.MapFrom(src => src.Bestemming.MaxLeeftijd));

            CreateMap<Opleiding, OpleidingViewModel>();
            CreateMap<OpleidingPersoon, OpleidingPersoonViewModel>();
            
              CreateMap<Kind, KindViewModel>();
            CreateMap<Kind, KindEditViewModel>();
            CreateMap<Kind, KindDeleteViewModel>();

            

            CreateMap<Deelnemer, DeelnemerDetailsViewModel>()
                .ForMember(dest => dest.Voornaam, opt => opt.MapFrom(src => src.Kind.Voornaam))
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Kind.Naam))
                .ForMember(dest => dest.OuderTelefoon, opt => opt.MapFrom(src => src.Kind.CustomUser.TelefoonNummer))
                .ForMember(dest => dest.Medicatie, opt => opt.MapFrom(src => src.Kind.Medicatie))
                .ForMember(dest => dest.Allergieen, opt => opt.MapFrom(src => src.Kind.Allergieen))
                .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => CalculateAge(src.Kind.GeboorteDatum)))
                .ForMember(dest => dest.Opmerkingen, opt => opt.MapFrom(src => src.Opmerkingen ?? "Geen"));
            

            CreateMap<Groepsreis, List<MonitorDeelneemerDetailsViewModel>>()
                .ConvertUsing((src, dest, context) => src.Monitoren
                    .Select(m => new MonitorDeelneemerDetailsViewModel
                    {
                        Voornaam = m.Persoon.Voornaam,
                        Naam = m.Persoon.Naam,
                        Leeftijd = CalculateAge(m.Persoon.GeboorteDatum),
                        Telefoon = m.Persoon.TelefoonNummer,
                        Email = m.Persoon.Email
                    }).ToList());

        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
