using Domain.Entity;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace WebMVC.ConfigureHost
{
    public static class ConfigureIdentity
    {
        public static IServiceCollection AddIdentityCustom(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}
