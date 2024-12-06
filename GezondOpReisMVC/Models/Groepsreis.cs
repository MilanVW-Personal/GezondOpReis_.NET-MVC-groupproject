namespace GezondOpReis.Models
{
	public class Groepsreis
	{
		public int Id {  get; set; }
		public int BestemmingId { get; set; }
		public DateTime BeginDatum { get; set; }
		public DateTime EindDatum { get; set; }
		public float prijs { get; set; }

		public List<Onkosten>? Onkosten { get; set; }  // voor delete mag verweiderd worden
		public Bestemming? Bestemming { get; set; }  // voor delete moet linking breken
		public List<Programma>? Programmas { get; set; } // voor delete mag verweiderd worden
        public List<Monitor>? Monitoren { get; set; } // voor delete moet linking breken
        public List<Deelnemer>? Deelnemers { get; set; } // voor delete moet linking breken
    }
}
