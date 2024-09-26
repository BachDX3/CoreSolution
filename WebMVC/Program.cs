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
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configure host
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.File("Logs/MyAppLog.txt")
    .CreateLogger();

//Use Serilog for logging
builder.Host.UseSerilog();

// Add cookie custom
builder.Services.AddCookies();

// Configure authentication custom  
builder.Services.AddAuthenticationCustom();

// Configure identity custom
builder.Services.AddIdentityCustom();

// Configure Dbcontext
builder.Services.ConfigureDbContext(builder.Configuration);

// Configure Repository
builder.Services.AddRepository();

// Configure services
builder.Services.AddProductServices();

// Configure mapper
builder.Services.AddMapper();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
