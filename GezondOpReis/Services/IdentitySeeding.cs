using System.Data.Common;

namespace GezondOpReis.Services
{
	public class IdentitySeeding
	{
		public async Task RoleSeedingAsync(RoleManager<IdentityRole> roleManager)
		{
			try
			{
				//User
				bool role = await roleManager.RoleExistsAsync("user");
				if (!role) await roleManager.CreateAsync(new IdentityRole("user"));

				//Admin
				role = await roleManager.RoleExistsAsync("admin");
				if (!role) await roleManager.CreateAsync(new IdentityRole("admin"));
			}
			catch (DbException ex)
			{
				throw new Exception(ex.Message.ToString());
			}
		}
	}
}
