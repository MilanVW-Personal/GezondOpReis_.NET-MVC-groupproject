namespace GezondOpReis.Models
{
	public class Groepsreis
	{
		public int Id {  get; set; }
		public int BestemmingId { get; set; }
		public DateTime BeginDatum { get; set; }
		public DateTime EindDatum { get; set; }
		public float prijs { get; set; }
	}
}
