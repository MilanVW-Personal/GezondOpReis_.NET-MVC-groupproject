namespace GezondOpReis.ViewModels
{
    public class OpleidingViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int AantalPlaatsen { get; set; }
        public bool IsIngeschreven { get; set; }
    }
}