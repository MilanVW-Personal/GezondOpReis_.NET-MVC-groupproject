namespace GezondOpReis.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string PersoonId { get; set; }
        public int BestemmingId { get; set; }
        public string? Tekst {  get; set; }
        public int Score { get; set; }

        public Bestemming Bestemming { get; set; }
    }
}
