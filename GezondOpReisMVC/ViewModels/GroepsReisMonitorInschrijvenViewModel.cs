using GezondOpReis.Models;
using Monitor = GezondOpReis.Models.Monitor;

namespace GezondOpReis.ViewModels
{
    public class GroepsReisMonitorInschrijvenViewModel
    {
        public int GroepsReisId { get; set; }
        public string MonitorId { get; set; }
        public bool IsHoofdMonitor { get; set; }
    }
}
