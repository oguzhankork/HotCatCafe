using HotCatCafe.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotCatCafe.IOC.DependencyResolves
{
    public static class ContextService
    {
        public static IServiceCollection AddHotCatCafeDb(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<HotCatCafeContext>(options => options.UseSqlServer(configuration.GetConnectionString("OguzConnection"), b => b.MigrationsAssembly("HotCatCafe.MVC")));
            return services;
        }
    }
}
