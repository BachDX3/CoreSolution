using Application.Models;
using Domain.Entity;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace WebMVC.ConfigureHost
{
    public static class ConfigureIdentity
    {
        public static IServiceCollection AddIdentityCustom(this IServiceCollection services)
        {
            // Add table user and role custom identity
            services.AddIdentity<User, Role>(options =>
            {
                // password settings
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                //user settings
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Config application cookie
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // Login page
                options.LoginPath = "/Account/Login";
                // AccessDenied page
                options.AccessDeniedPath = "/Login/AccessDenied";
                // Logout age
                options.LogoutPath = "/Login/Logout";
                // Create a new cookie when expiration time
                options.SlidingExpiration = true;
            });

            return services;
        }
    }
}
