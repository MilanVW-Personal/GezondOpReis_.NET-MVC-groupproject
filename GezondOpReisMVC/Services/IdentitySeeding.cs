using GezondOpReis.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace GezondOpReis.Services
{
    public class IdentitySeeding
    {
        public async Task IdentitySeedingAsync(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                // Check if the admin user already exists
                var adminUser = await userManager.FindByNameAsync("Admin");
                if (adminUser == null)
                {
                    // Create the default user with a GUID as Id
                    var defaultUser = new CustomUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "Admin",
                        Naam = "De Beheerder",
                        Voornaam = "Admin",
                        Straat = "Adminstraat",
                        Huisnummer = "1",
                        Gemeente = "Admin Gemeente",
                        Postcode = "2580",
                        GeboorteDatum = DateTime.Now,
                        Huisdokter = "Admin Dokter",
                        TelefoonNummer = "0400 00 00 00",
                        IsActief = true,
                        Email = "admin@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };

                    // Gebruiker aanmaken
                    var result = await userManager.CreateAsync(defaultUser, "NielsBellens1*");
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }

                    // Rollen seeden
                    //string[] roles = { "Beheerder", "Gebruiker", "Monitor", "Ouder", "Verantwoordelijke" };

                    //foreach (var role in roles)
                    //{
                    //    if (!await roleManager.RoleExistsAsync(role))
                    //    {
                    //        await roleManager.CreateAsync(new IdentityRole(role));
                    //    }
                    //}
                    string role = "Beheerder";
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }

                    // Add the user to the "Beheerder" role
                    var addToRoleResult = await userManager.AddToRoleAsync(defaultUser, "Beheerder");
                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception($"Failed to add user to role: {string.Join(", ", addToRoleResult.Errors.Select(e => e.Description))}");
                    }

                }
                
                

            }
            catch (DbException ex)
            {
                throw new Exception($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during identity seeding: {ex.Message}", ex);
            }
        }
    }
}