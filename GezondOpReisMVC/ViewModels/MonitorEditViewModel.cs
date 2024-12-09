namespace GezondOpReis.ViewModels
{
    public class MonitorEditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Straat is verplicht.")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Huisnummer is verplicht.")]
        public string Huisnummer { get; set; }

        [Required(ErrorMessage = "Gemeente is verplicht.")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht.")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht.")]
        [DataType(DataType.Date)]
        public DateTime GeboorteDatum { get; set; }

        [Required(ErrorMessage = "Huisdokter is verplicht.")]
        public string Huisdokter { get; set; }


        public string? ContactNummer { get; set; }

        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht.")]
        public string TelefoonNummer { get; set; }


        public string? RekeningNummer { get; set; }

        public bool IsActief { get; set; }

        public bool IsHoofdMonitor { get; set; }
    }
}
