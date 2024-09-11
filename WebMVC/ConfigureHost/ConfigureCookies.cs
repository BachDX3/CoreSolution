using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace WebMVC.ConfigureHost
{
    public static class ConfigureCookies
    {
        public static IServiceCollection AddCookies(this IServiceCollection services)
        {
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureCookieOptions>();
            return services;
        }
    }
}
