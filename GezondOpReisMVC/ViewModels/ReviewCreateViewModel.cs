using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class ReviewCreateViewModel
    {
        public string? Tekst { get; set; }
        public int Score { get; set; }
        public Bestemming? Bestemming { get; set; }
        public CustomUser? Persoon { get; set; }
    }
}
