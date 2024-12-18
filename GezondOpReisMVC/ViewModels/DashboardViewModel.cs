using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class DashboardViewModel
    {
        public List<Groepsreis> ReizenInVerleden { get; set; }
        public List<Groepsreis> IngeschrevenReizen { get; set; }
        public List<Kind> Kinderen { get; set; }
        public List<Groepsreis> AankomendeReizen { get; set; }
        public List<OpleidingViewModel> OpleidingenVanMonitoren { get; set; }
        public List<Groepsreis> AdminAankomendeReizen { get; set; }
        //public List<Groepsreis> AdminIngeschrevenReizen { get; set; }
        //public List<Groepsreis> AdminVorigeReizen { get; set; }
    }
}
