namespace GezondOpReis.Models
{
    public class CustomUser
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Straat {  get; set; }
        public string Huisnummer { get; set; }
        public string Gemeente { get; set; }
        public string Postcode { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Huisdokter { get; set; }
        public string? ContactNummer { get; set; }
        public string Email { get; set; }
        public bool? IsHoofdMonitor { get; set; }
        public string TelefoonNummer { get; set; }
        public string? RekeningNummer { get; set; }
        public bool IsActief {  get; set; }
        public ICollection<OpleidingPersoon> Opleidingen { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Monitor> Monitors { get; set; }
        public ICollection<Kind> Kinderen { get; set; }
    }
}
