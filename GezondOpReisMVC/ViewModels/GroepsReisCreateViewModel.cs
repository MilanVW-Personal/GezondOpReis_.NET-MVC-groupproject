using System.ComponentModel.DataAnnotations;

namespace GezondOpReis.ViewModels
{
    public class GroepsReisCreateViewModel
    {
        [Required(ErrorMessage = "Selecteer een bestemming")]
        [Display(Name = "Bestemming")]
        public int BestemmingId { get; set; }

        [Required(ErrorMessage = "Begin datum is verplicht")]
        [Display(Name = "Begin Datum")]
        [DataType(DataType.Date)]
        public DateTime BeginDatum { get; set; }

        [Required(ErrorMessage = "Eind datum is verplicht")]
        [Display(Name = "Eind Datum")]
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht")]
        [Display(Name = "Prijs")]
        [Range(0, float.MaxValue, ErrorMessage = "Prijs moet groter zijn dan 0")]
        public float Prijs { get; set; }

        // For dropdown
        public IEnumerable<BestemmingViewModel>? Bestemmingen { get; set; }
    }
}
