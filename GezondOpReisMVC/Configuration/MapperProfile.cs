using GezondOpReis.Models;
using GezondOpReis.ViewModels;

namespace GezondOpReis.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Activiteit, ActiviteitViewModel>();
            CreateMap<Activiteit, ActiviteitDeleteViewModel>();
            CreateMap<Activiteit, ActiviteitEditViewModel>();
            CreateMap<Bestemming, BestemmingViewModel>();
            CreateMap<Bestemming, BestemmingEditViewModel>();
            CreateMap<Bestemming, BestemmingDeleteViewModel>();
        }
    }
}
