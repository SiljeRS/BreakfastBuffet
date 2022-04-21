using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BreakfastBuffet.Data
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            /*
            const string adminEmail = "Admin@localhost";
            const string adminPassword = "Secret7$";
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            */

            const string receptionistEmail = "Receptionist@localhost";
            const string receptionistPassword = "Secret7$";
            const string waiterEmail = "Waiter@localhost";
            const string waiterPassword = "Secret7$";
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));

            // Receptionist
            if (userManager.FindByNameAsync(receptionistEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = receptionistEmail;
                user.Email = receptionistEmail;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, receptionistPassword).Result;

                if (result.Succeeded)
                {
                    var receptionistUser = userManager.FindByNameAsync(receptionistEmail).Result;
                    var claim = new Claim("IsReceptionist", "true");
                    var claimAdded = userManager.AddClaimAsync(receptionistUser, claim).Result;
                }
            }

            // Tjener
            if (userManager.FindByNameAsync(waiterEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = waiterEmail;
                user.Email = waiterEmail;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, waiterPassword).Result;

                if (result.Succeeded)
                {
                    var waiterUser = userManager.FindByNameAsync(waiterEmail).Result;
                    var claim = new Claim("IsWaiter", "true");
                    var claimAdded = userManager.AddClaimAsync(waiterUser, claim).Result;
                }
            }
        }
    }
}
