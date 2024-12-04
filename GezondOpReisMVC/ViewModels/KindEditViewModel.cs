using System.ComponentModel;

namespace GezondOpReis.ViewModels
{
    public class KindEditViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

        [DisplayName("Geboortedatum")]
        public DateTime GeboorteDatum { get; set; }
        public string Allergieen { get; set; }
        public string Medicatie { get; set; }
    }
}
