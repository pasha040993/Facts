using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Facts.Web.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Facts.Web.Data
{
    public static class DataInitializer
    {
        internal static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var isExist = context!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator && await databaseCreator.ExistsAsync();
            if (isExist)
            {
                return;
            }

            await context.Database.MigrateAsync();
            var roles = AppData.Roles.ToArray();
            var roleStore = new RoleStore<IdentityRole>(context);
            foreach (var role in roles)
            {
                if (!context.Roles.Any(x => x.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role) { NormalizedName = role.ToUpper() });
                }
            }

            const string userName = "pasha@yandex.ru";
            var user = new IdentityUser()
            {
                Email = userName,
                EmailConfirmed = true,
                NormalizedEmail = userName.ToUpper(),
                PhoneNumber = "+79009009090",
                PhoneNumberConfirmed = true,
                NormalizedUserName = userName.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString("D")

            };
            var passwordHAser = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHAser.HashPassword(user, "1qaz@WSX");
            var userStore = new UserStore<IdentityUser>(context);
            var identityResult = await userStore.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                throw new Exception("");
            }

            //var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            //await userManager!.AddToRolesAsync(user, roles);

            await context.SaveChangesAsync();
        }
    }
}
