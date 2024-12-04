using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class GroepsReisInfoViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<string> Fotos { get; set; }
        public string Beschrijving { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int MinLeeftijd { get; set; }
        public int MaxLeeftijd { get; set; }
        public float Prijs { get; set; }
        public List<ActiviteitViewModel> Activiteiten { get; set; }
        public List<Models.Monitor>? Monitoren { get; set; } 
        public List<Deelnemer>? Deelnemers { get; set; }
    }
}
