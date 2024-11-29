namespace GezondOpReis.ViewModels
{
	public class GroepsReisDetailsViewModel
	{
		public string Naam { get; set; }
        public int id { get; set; }
        public string Foto { get; set; }
        public string Beschrijving { get; set; }
		public DateTime BeginDatum { get; set; }
		public DateTime EindDatum { get; set; }
		public int MinLeeftijd { get; set; }
        public int MaxLeeftijd { get; set; }
        public float Prijs { get; set; }

	}
}
