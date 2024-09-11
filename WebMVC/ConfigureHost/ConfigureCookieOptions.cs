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
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.LoginPath = "/Login/Login";
            options.AccessDeniedPath = "/Login/AccessDenied";
            options.LogoutPath = "/Login/Logout";
        }

    }
}
