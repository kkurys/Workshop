using Microsoft.AspNetCore.Identity;
using Workshop.Data.Models.Account;

namespace Workshop.Data
{
    public class WorkshopDbInitializer
    {
        public static void SeedUsers(UserManager<WorkshopUser> userManager)
        {
            var adminUser = new WorkshopUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.pl",
                NormalizedEmail = "ADMIN@ADMIN.pl",
                FirstName = "Admin",
                LastName = "Adminowski"
            };

            var clientUser = new WorkshopUser
            {
                UserName = "client",
                NormalizedUserName = "CLIENT",
                Email = "client@client.pl",
                NormalizedEmail = "CLIENT@CLIENT.pl",
                FirstName = "Klient",
                LastName = "Interesancki"
            };

            var managerUser = new WorkshopUser
            {
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.pl",
                NormalizedEmail = "MANAGER@MANAGER.pl",
                FirstName = "Manager",
                LastName = "Zarzadzajacy"
            };

            AddIfNotExists(adminUser, userManager);
            AddIfNotExists(clientUser, userManager);
            AddIfNotExists(managerUser, userManager);
        }

        private static void AddIfNotExists(WorkshopUser user, UserManager<WorkshopUser> userManager)
        {
            if (userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var result = userManager.CreateAsync(user, "Haslo123.").Result;

                if (result.Succeeded) userManager.AddToRoleAsync(user, user.UserName.ToUpper()).Wait();
            }
        }
    }
}