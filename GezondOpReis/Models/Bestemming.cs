namespace GezondOpReis.Models
{
	public class Bestemming
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Naam { get; set; }
		public string Beschrijving { get; set; }
		public int MinLeeftijd { get; set; }
		public int MaxLeeftijd { get; set; }
	}

}
