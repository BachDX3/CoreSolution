using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebMVC.ConfigureHost
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddAuthenticationCustom(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            return services;
        }
    }
}
