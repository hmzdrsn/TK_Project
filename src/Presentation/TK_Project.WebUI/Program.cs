using TK_Project.Persistance;
using TK_Project.Application;
using TK_Project.Persistance.Context;
using TK_Project.Application.Interfaces.Auth;
using TK_Project.Persistance.Auth;
using TK_Project.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using FluentValidation;
using TK_Project.Application.Validators;
using TK_Project.Application.ViewModel;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registrations
builder.Services.PersistanceRegister();
builder.Services.AddApplicationServices();
builder.Services.InfrastructureRegister();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["connectionStrings:MSSQL:DefaultConnection"]);
});


//Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Eticaret.cookie";
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Login";
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Auth/Login");
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
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
