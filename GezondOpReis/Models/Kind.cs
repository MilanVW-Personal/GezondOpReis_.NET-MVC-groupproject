using Microsoft.EntityFrameworkCore.Storage;

namespace GezondOpReis.Models
{
    public class Kind
    {
        public int Id { get; set; }
        public string PersoonId { get; set; }
        public string Naam {  get; set; }
        public string Voornaam { get; set; }

        public DateTime GeboorteDatum { get; set; }
        public string Allergieen {  get; set; }
        public string Medicatie {  get; set; }
    }
}
