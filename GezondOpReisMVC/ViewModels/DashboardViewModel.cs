using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class DashboardViewModel
    {
        public List<Groepsreis> ReizenInVerleden { get; set; }
        public List<Groepsreis> IngeschrevenReizen { get; set; }
        public List<Kind> Kinderen { get; set; }
    }
}
