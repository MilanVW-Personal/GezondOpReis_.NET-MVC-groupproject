namespace GezondOpReis.Models
{
	public class Programma
	{
        public int Id { get; set; }
		public int ActiviteidId { get; set; }
		public int GroepsreisId { get; set; }
		public Activiteit? Activiteit { get; set; }
		public Groepsreis? Groepsreis { get; set; }
	}
}

