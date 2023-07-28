using Microsoft.EntityFrameworkCore;
using NopClone.Data.Context;

namespace NopClone.WebApi.ServiceExtension
{
    public static class ConfigureDbContextExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string efCoreProvider = configuration.GetSection(AppConstants.EFCoreProvider)["Provider"]
                                    ?? throw new ArgumentException("EFCoreProvider doesn't exist in appsettings.json");
            var connectionString = configuration.GetConnectionString(efCoreProvider);

            if (efCoreProvider == AppConstants.EFCoreProviders.InMemory)
            {
                services.AddDbContext<NopCloneDataContext>(options => options.UseInMemoryDatabase("Dev"));

                return;
            }

            if (efCoreProvider == AppConstants.EFCoreProviders.Sqlite)
            {
                //services.AddDbContext<NopCloneDataContext>(options => options.UseSqlite(connectionString));

                return;
            }

            if (efCoreProvider == AppConstants.EFCoreProviders.SqlServer)
            {
                services.AddDbContext<NopCloneDataContext>(options => options.UseSqlServer(connectionString));
                
                return;
            }
        }
    }
}
