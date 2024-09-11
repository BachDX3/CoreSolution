using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace WebMVC.ConfigureHost
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddAuthenticationCustom(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            return services;
        }
    }
}
