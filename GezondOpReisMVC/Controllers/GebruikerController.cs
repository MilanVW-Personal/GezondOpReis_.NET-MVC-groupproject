using GezondOpReis.Models;
using GezondOpReis.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GezondOpReis.Controllers
{
    public class GebruikerController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GebruikerController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        // Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(GebruikerLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid.");
                return View(model);
            }

            // Trim and convert to lowercase for case-insensitive comparison
            string email = model.Email.Trim().ToLower();

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email);
            if (user == null)
            {
                Console.WriteLine($"User not found for email: {email}");
                ModelState.AddModelError("", "Emailadres is niet gevonden.");
                return View(model);
            }

            if (!user.EmailConfirmed)
            {
                Console.WriteLine("Email is not confirmed.");
                ModelState.AddModelError("", "Emailadres is nog niet bevestigd.");
                return View(model);
            }
            if (user.IsActief == false)
            {
                ModelState.AddModelError("", "Je account staat op non-actief");
                return View(model);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            Console.WriteLine($"Password valid: {passwordValid}");

            if (!passwordValid)
            {
                Console.WriteLine("Incorrect password.");
                // Nooit exacte informatie geven: zeg alleen dat combinatie verkeerd is...
                ModelState.AddModelError("", "Verkeerde logincombinatie!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, false);

            if (result.Succeeded)
            {
                Console.WriteLine($"Login successful for user: {user.UserName}");
                return RedirectToAction("Index", "Groepsreis");
            }

            if (result.IsLockedOut)
            {
                Console.WriteLine($"Account locked for user: {user.UserName}");
                ModelState.AddModelError("", "Account geblokkeerd.");
                return View(model);
            }

            Console.WriteLine($"Login failed for user: {user.UserName}");
            ModelState.AddModelError("", "Ongeldige loginpoging.");
            return View(model);

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(GebruikerIndexViewModel model)
        {
            // Controleer of de gebruiker geauthenticeerd is
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Gebruiker");
            }
            Console.WriteLine(User);
       

            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);




            bool isAdmin = await _userManager.IsInRoleAsync(user, "Beheerder");

            // Maak een ViewModel aan met de gebruikersnaam en de admin status
            GebruikerIndexViewModel viewModel = new GebruikerIndexViewModel
            {
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Straat = user.Straat,
                Huisnummer = user.Huisnummer,
                Gemeente = user.Gemeente,
                Postcode = user.Postcode,
                GeboorteDatum = user.GeboorteDatum,
                Huisdokter = user.Huisdokter,
                ContactNummer = user.ContactNummer,
                Email = user.Email,
                TelefoonNummer = user.TelefoonNummer,
                RekeningNummer = user.RekeningNummer,
                IsAdmin = isAdmin // Set the IsAdmin property
            };

            return View(viewModel);
        }



        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Groepsreis");
        }

        [HttpPost]
        public async Task<IActionResult> Create(GebruikerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Your account creation logic here
                // For example, using Identity:
                var user = new CustomUser
                {
                    UserName = model.Voornaam + model.Naam + model.GeboorteDatum.Day + model.GeboorteDatum.Month + model.GeboorteDatum.Year,
                    Email = model.Email,
                    EmailConfirmed = true,
                    Naam = model.Naam,
                    Voornaam = model.Voornaam,
                    Straat = model.Straat,
                    Huisnummer = model.Huisnummer,
                    Gemeente = model.Gemeente,
                    Postcode = model.Postcode,
                    GeboorteDatum = model.GeboorteDatum,
                    Huisdokter = model.Huisdokter,
                    ContactNummer = model.ContactNummer,
                    TelefoonNummer = model.TelefoonNummer,
                    RekeningNummer = model.RekeningNummer,
                    IsActief = true // Set to true or based on your logic

                };

                var result = await _userManager.CreateAsync(user, model.Passwoord);
                if (result.Succeeded)
                {
                    // Add the user to the "Gebruiker" role
                    var addToRoleResult = await _userManager.AddToRoleAsync(user, "Gebruiker");
                    if (addToRoleResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Groepsreis");
                    }
                    else
                    {
                        foreach (var error in addToRoleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Gebruiker");
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Gebruiker");
            }

            var viewModel = new GebruikerCreateViewModel
            {
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Straat = user.Straat,
                Huisnummer = user.Huisnummer,
                Gemeente = user.Gemeente,
                Postcode = user.Postcode,
                GeboorteDatum = user.GeboorteDatum,
                Huisdokter = user.Huisdokter,
                ContactNummer = user.ContactNummer,
                Email = user.Email,
                TelefoonNummer = user.TelefoonNummer,
                RekeningNummer = user.RekeningNummer,
                Passwoord = string.Empty, // Clear password for security
                
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(GebruikerCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Gebruiker");
            }

            user.Naam = model.Naam;
            user.Voornaam = model.Voornaam;
            user.Straat = model.Straat;
            user.Huisnummer = model.Huisnummer;
            user.Gemeente = model.Gemeente;
            user.Postcode = model.Postcode;
            user.GeboorteDatum = model.GeboorteDatum;
            user.Huisdokter = model.Huisdokter;
            user.ContactNummer = model.ContactNummer;
            user.Email = model.Email;
            user.TelefoonNummer = model.TelefoonNummer;
            user.RekeningNummer = model.RekeningNummer;

            if (!string.IsNullOrEmpty(model.Passwoord))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, model.Passwoord);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Index", "Gebruiker");
        }
        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> UserList(string selectedRole)
        {
            var users = await _userManager.Users.ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();

            if (!string.IsNullOrEmpty(selectedRole) && selectedRole != "Filter op rol")
            {
                users = users.Where(u => _userManager.IsInRoleAsync(u, selectedRole).Result).ToList();

                if (selectedRole == "Hoofdmonitor")
                {
                    users = users.Where(u => u.IsHoofdMonitor == true).ToList();
                }
            }

            var roleItems = roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name,
                Selected = r.Name == selectedRole
            }).ToList();

            roleItems.Insert(0, new SelectListItem
            {
                Value = "Filter op rol",
                Text = "Filter op rol",
                Selected = string.IsNullOrEmpty(selectedRole) || selectedRole == "Filter op rol"
            });

            var viewModel = new UserListViewModel
            {
                Users = users,
                Roles = roleItems,
                SelectedRole = selectedRole
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> UserEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.ToListAsync();
            Console.WriteLine(roles);
            if (!roles.Any())
            {
                Console.WriteLine("No roles found.");
                ModelState.AddModelError("", "Geen rollen beschikbaar.");
                return View(new GebruikerEditViewModel());
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var viewModel = new GebruikerEditViewModel
            {
                Id = user.Id,
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Straat = user.Straat,
                Huisnummer = user.Huisnummer,
                Gemeente = user.Gemeente,
                Postcode = user.Postcode,
                GeboorteDatum = user.GeboorteDatum,
                Huisdokter = user.Huisdokter,
                ContactNummer = user.ContactNummer,
                Email = user.Email,
                TelefoonNummer = user.TelefoonNummer,
                RekeningNummer = user.RekeningNummer,
                IsActief = user.IsActief,
                SelectedRole = userRoles.FirstOrDefault(), // Assuming a user can have only one role
                Roles = roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }),
                IsHoofdMonitor = user.IsHoofdMonitor ?? false // Set the IsHoofdMonitor property
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpPost]
        public async Task<IActionResult> UserEdit(GebruikerEditViewModel model)
        {
            Console.WriteLine(model.Roles);
            if (!ModelState.IsValid)
            {
                var roles = await _roleManager.Roles.ToListAsync();
                model.Roles = roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name });
                Console.WriteLine("Model state is invalid.");
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Validation error: {error.ErrorMessage}");
                    }
                }
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return NotFound();
            }

            // Log the selected role
            Console.WriteLine($"Selected Role: {model.SelectedRole}");

            user.Naam = model.Naam;
            user.Voornaam = model.Voornaam;
            user.Straat = model.Straat;
            user.Huisnummer = model.Huisnummer;
            user.Gemeente = model.Gemeente;
            user.Postcode = model.Postcode;
            user.GeboorteDatum = model.GeboorteDatum;
            user.Huisdokter = model.Huisdokter;
            user.ContactNummer = model.ContactNummer;
            user.Email = model.Email;
            user.TelefoonNummer = model.TelefoonNummer;
            user.RekeningNummer = model.RekeningNummer;
            user.IsActief = model.IsActief;

            // Set IsHoofdMonitor if the selected role is "Monitor"
            if (model.SelectedRole == "Monitor")
            {
                user.IsHoofdMonitor = model.IsHoofdMonitor;
            }
            else
            {
                user.IsHoofdMonitor = false; // Ensure it's false for other roles
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                var roles = await _roleManager.Roles.ToListAsync();
                model.Roles = roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name });
                Console.WriteLine("User update failed.");
                return View(model);
            }

            // Remove existing roles
            var userRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!removeResult.Succeeded)
            {
                foreach (var error in removeResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                var roles = await _roleManager.Roles.ToListAsync();
                model.Roles = roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name });
                Console.WriteLine("Role removal failed.");
                return View(model);
            }

            // Add selected role
            if (!string.IsNullOrEmpty(model.SelectedRole))
            {
                var addResult = await _userManager.AddToRoleAsync(user, model.SelectedRole);
                if (!addResult.Succeeded)
                {
                    foreach (var error in addResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var roles = await _roleManager.Roles.ToListAsync();
                    model.Roles = roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name });
                    Console.WriteLine("Role addition failed.");
                    return View(model);
                }
            }

            Console.WriteLine("User updated and redirected to UserList.");
            return RedirectToAction("UserList", "Gebruiker");
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var role = userRoles.FirstOrDefault(); // Assuming a user can have only one role

            var viewModel = new GebruikerDetailsViewModel
            {
                Id = user.Id,
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Straat = user.Straat,
                Huisnummer = user.Huisnummer,
                Gemeente = user.Gemeente,
                Postcode = user.Postcode,
                GeboorteDatum = user.GeboorteDatum,
                Huisdokter = user.Huisdokter,
                ContactNummer = user.ContactNummer,
                Email = user.Email,
                TelefoonNummer = user.TelefoonNummer,
                RekeningNummer = user.RekeningNummer,
                IsActief = user.IsActief,
                Role = role,
                IsHoofdMonitor = user.IsHoofdMonitor ?? false
            };

            return View(viewModel);
        }
        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> UserDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new GebruikerDetailsViewModel
            {
                Id = user.Id,
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Straat = user.Straat,
                Huisnummer = user.Huisnummer,
                Gemeente = user.Gemeente,
                Postcode = user.Postcode,
                GeboorteDatum = user.GeboorteDatum,
                Huisdokter = user.Huisdokter,
                ContactNummer = user.ContactNummer,
                Email = user.Email,
                TelefoonNummer = user.TelefoonNummer,
                RekeningNummer = user.RekeningNummer,
                IsActief = user.IsActief
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpPost]
        public async Task<IActionResult> UserDeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Delete", new GebruikerDetailsViewModel
                {
                    Id = user.Id,
                    Naam = user.Naam,
                    Voornaam = user.Voornaam,
                    Straat = user.Straat,
                    Huisnummer = user.Huisnummer,
                    Gemeente = user.Gemeente,
                    Postcode = user.Postcode,
                    GeboorteDatum = user.GeboorteDatum,
                    Huisdokter = user.Huisdokter,
                    ContactNummer = user.ContactNummer,
                    Email = user.Email,
                    TelefoonNummer = user.TelefoonNummer,
                    RekeningNummer = user.RekeningNummer,
                    IsActief = user.IsActief
                });
            }

            return RedirectToAction("UserList", "Gebruiker");
        }
    }
}