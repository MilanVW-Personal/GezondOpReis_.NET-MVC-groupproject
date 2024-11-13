namespace GezondOpReis.Models
{
    public class Deelnemer
    {
        public int Id { get; set; }
        public int KindId { get; set; }
        public int GroepsreisId { get; set; }
        public string? Opmerkingen { get; set; }
    }
}
