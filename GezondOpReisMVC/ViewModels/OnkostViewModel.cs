namespace GezondOpReis.ViewModels
{
    public class OnkostViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public float Bedrag { get; set; }
        public DateTime Datum {  get; set; }
        public string? Foto { get; set; }
    }
}
