namespace GezondOpReis.Models
{
	public class Groepsreis
	{
		public int Id {  get; set; }
		public int BestemmingId { get; set; }
		public DateTime BeginDatum { get; set; }
		public DateTime EindDatum { get; set; }
		public float prijs { get; set; }

		public List<Onkosten>? Onkosten { get; set; }
		public Bestemming? Bestemming { get; set; }
		public List<Programma>? Programmas { get; set; }
		public List<Monitor>? Monitoren { get; set; }
		public List<Deelnemer>? Deelnemers { get; set; }
	}
}
