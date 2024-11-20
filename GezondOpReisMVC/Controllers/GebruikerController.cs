using GezondOpReis.Models;
using GezondOpReis.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
                return RedirectToAction("Index", "Home");
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
        public IActionResult Index()
        {
            // Controleer of de gebruiker geauthenticeerd is
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Gebruiker");
            }

            // Haal de gebruiker synchronously op
            var user = _userManager.GetUserAsync(User).Result;

            if (user == null)
            {
                // Fallback als de gebruiker niet gevonden wordt
                return RedirectToAction("Login", "Gebruiker");
            }

            // Maak een ViewModel aan met de gebruikersnaam
            GebruikerIndexViewModel viewModel = new GebruikerIndexViewModel
            {
                Username = user.UserName
            };

            return View(viewModel);
        }



        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}