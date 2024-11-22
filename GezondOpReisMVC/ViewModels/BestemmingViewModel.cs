using System.ComponentModel;

namespace GezondOpReis.ViewModels
{
    public class BestemmingViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }

        [DisplayName("Minimum leeftijd")]
        public int MinLeeftijd { get; set; }

        [DisplayName("Maximum leeftijd")]
        public int MaxLeeftijd { get; set; }
    }
}
