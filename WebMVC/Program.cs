using Application.Data.Repositories;
using Application.Services;
using Infrastructure;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebMVC.ConfigureHost;
using Application;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebMVC"));

//});
// Add Dbcontext
var dbcontext = builder.Services.ConfigureDbContext(builder.Configuration);
// Add repository
builder.Services.AddRepository();
// Add services
builder.Services.AddProductServices();
// Add mapper
builder.Services.AddMapper();
// Add identity custom
builder.Services.AddIdentityCustom();
// Add authentication custom
builder.Services.AddAuthenticationCustom();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
