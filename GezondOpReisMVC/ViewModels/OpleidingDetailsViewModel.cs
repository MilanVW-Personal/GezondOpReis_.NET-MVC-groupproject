namespace GezondOpReis.ViewModels
{
    public class OpleidingDetailsViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int AantalPlaatsen { get; set; }
        public string? ErrorMessage { get; set; }

        public List<string> InschrevenPersonen { get; set; }

    }
    
}