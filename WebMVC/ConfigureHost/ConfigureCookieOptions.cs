using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace WebMVC.ConfigureHost
{
    public class ConfigureCookieOptions : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        public ConfigureCookieOptions()
        {
            
        }
        public void Configure(CookieAuthenticationOptions options)
        {
        }
        public void Configure(string name, CookieAuthenticationOptions options)
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            // Login page
            options.LoginPath = "/Login/Login";
            // AccessDenied page
            options.AccessDeniedPath = "/Login/AccessDenied";
            // Logout age
            options.LogoutPath = "/Login/Logout";
            // Create a new cookie when expiration time
            options.SlidingExpiration = true;
        }

    }
}
