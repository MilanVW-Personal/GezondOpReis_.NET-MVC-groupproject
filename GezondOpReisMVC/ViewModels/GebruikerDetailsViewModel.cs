namespace GezondOpReis.ViewModels
{
    public class GebruikerDetailsViewModel
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Gemeente { get; set; }
        public string Postcode { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Huisdokter { get; set; }
        public string ContactNummer { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string RekeningNummer { get; set; }
        public bool IsActief { get; set; }
    }
}