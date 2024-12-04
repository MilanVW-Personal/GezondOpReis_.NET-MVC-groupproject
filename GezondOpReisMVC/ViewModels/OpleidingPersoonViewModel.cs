namespace GezondOpReis.ViewModels
{
    public class OpleidingPersoonViewModel
    {
        public int Id { get; set; }
        public int OpleidingId { get; set; }
        public string PersoonId { get; set; }

        public bool IsGeschrevenIn { get; set; }
    }
}