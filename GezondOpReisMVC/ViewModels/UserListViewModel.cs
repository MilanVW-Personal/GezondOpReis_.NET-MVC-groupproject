using GezondOpReis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GezondOpReis.ViewModels
{
    public class UserListViewModel
    {
        public List<CustomUser> Users { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string SelectedRole { get; set; }
        public bool IsHoofdMonitor { get; set; }
    }
}