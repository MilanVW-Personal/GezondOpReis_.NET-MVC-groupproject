using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class ReviewViewModel
    {
        public string PersoonId { get; set; }
        public int BestemmingId { get; set; }
        public string? Tekst { get; set; }
        public int Score { get; set; }
        public CustomUser? Persoon { get; set; }
    }
}
