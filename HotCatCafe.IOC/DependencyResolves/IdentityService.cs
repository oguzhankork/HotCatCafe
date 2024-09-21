using HotCatCafe.DAL.Context;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HotCatCafe.IOC.DependencyResolves
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<HotCatCafeContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(cookie =>
            {
                cookie.LoginPath = new PathString("/Home/Login");
                cookie.AccessDeniedPath = new PathString("/Home/Denied");
                cookie.Cookie = new CookieBuilder { Name = "HotCatDemoCookie" };
                cookie.SlidingExpiration = true;
            });
            return services;
        }
    }
}
