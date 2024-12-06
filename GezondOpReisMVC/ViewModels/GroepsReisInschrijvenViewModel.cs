using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GezondOpReis.ViewModels
{
    public class GroepsReisInschrijvenViewModel
    {
        public int GroepsReisId { get; set; }
        
        [Required(ErrorMessage = "Selecteer een kind")]
        public int KindId { get; set; }
        
        public string? Opmerkingen { get; set; }
        
        public List<SelectListItem> Kinderen { get; set; } = new List<SelectListItem>();
    }
}
