using System.ComponentModel.DataAnnotations.Schema;
using GezondOpReis.Models;

namespace GezondOpReis.ViewModels
{
    public class ActiviteitViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
    }
}
