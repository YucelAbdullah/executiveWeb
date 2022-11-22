using executiveData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using executiveWeb;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(config =>
{
    config.UseLazyLoadingProxies();

    var provider = builder.Configuration.GetValue<string>("DbProvider");
    switch (provider)

    {
        case "Npgsql":

            config.UseNpgsql
                    (builder.Configuration.GetConnectionString("Npgsql"),
                     options => options.MigrationsAssembly("MigrationsNpgsql"));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            break;

        case "SqlServer":
        default:
            config.UseSqlServer
                (builder.Configuration.GetConnectionString("SqlServer"),
                options => options.MigrationsAssembly("MigrationsSqlServer"));
            break;


    }



});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(
    config =>
    {

        config.Password.RequiredLength = builder.Configuration.GetValue<int>("PasswordSettings:RequiredLength");
        config.Password.RequireLowercase = builder.Configuration.GetValue<bool>("PasswordSettings:RequireLowercase");
        config.Password.RequireUppercase = builder.Configuration.GetValue<bool>("PasswordSettings:RequireUppercase");
        config.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("PasswordSettings:RequireNonAlphanumeric");
        config.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("PasswordSettings:RequiredUniqueChars");

        config.SignIn.RequireConfirmedPhoneNumber = false;
        config.SignIn.RequireConfirmedEmail = true;

        config.Lockout.MaxFailedAccessAttempts = 3;
        config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

    })

     .AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders()
     .AddErrorDescriber<CustomIdentityErrorDescriber>();

var app = builder.Build();

builder.Services.AddAuthentication().AddCookie();


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
