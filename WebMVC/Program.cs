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

builder.Services.AddControllersWithViews();

// Add authentication custom
builder.Services.AddAuthenticationCustom();
// Add identity custom
builder.Services.AddIdentityCustom();
// Add Dbcontext
builder.Services.ConfigureDbContext(builder.Configuration);
// Add repository
builder.Services.AddRepository();
// Add services
builder.Services.AddProductServices();
// Add mapper
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
