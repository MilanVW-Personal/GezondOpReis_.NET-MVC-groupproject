using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class KindViewModel
    {
        public int Id { get; set; }
        public string PersoonId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

        public DateTime GeboorteDatum { get; set; }
        public string Allergieen { get; set; }
        public string Medicatie { get; set; }
        public CustomUser? CustomUser { get; set; }
    }
}
