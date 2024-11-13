namespace GezondOpReis.Models
{
    public class Monitor
    {
        public int Id { get; set; }
        public string PersoonId { get; set; }
        public int GroepsreisId { get; set; }
        public bool? isHoofdMonitor { get; set; }

    }
}
