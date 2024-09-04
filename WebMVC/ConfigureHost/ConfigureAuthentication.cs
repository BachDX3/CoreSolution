using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebMVC.ConfigureHost
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddAuthenticationCustom(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();
            return services;
        }
    }
}
