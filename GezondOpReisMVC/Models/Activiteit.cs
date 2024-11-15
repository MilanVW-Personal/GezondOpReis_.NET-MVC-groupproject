namespace GezondOpReis.Models
{
	public class Activiteit
	{
		public int Id { get; set; }
		public string Naam { get; set; }
		public string Beschrijving { get; set; }
		public List<Programma>? Programmas { get; set; }

	}
}
