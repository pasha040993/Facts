using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

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


        }
    }
}
