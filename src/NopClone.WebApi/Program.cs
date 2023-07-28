using Microsoft.EntityFrameworkCore;
using NopClone.Data.Context;
using Microsoft.OpenApi.Models;
using NopClone.WebApi.ServiceExtension;
using NopClone.WebApi;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseStartup<Startup>();
var config = builder.Configuration;
var env = builder.Environment;

builder.Services.ConfigureDbContext(config);
builder.Services.AddIdentity(config, env);

builder.Services.AddCors(o => o.AddPolicy("All", p => p.AllowAnyHeader()
                                                       .AllowAnyMethod()
                                                       .WithOrigins("http://localhost:4200", "https://localhost:4200")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCors("All");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultControllerRoute();
app.MapGet("/", () => "api work!");

app.Services.SeedData();

app.Run();


public static class IdentityExtensions
{
    public static void AddIdentity(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        services.AddDbContext<ApiIdentityDbContext>(o => o.UseInMemoryDatabase("DevIdentityDb"));
        //services.AddDbContext<ApiIdentityDbContext>(o 
        //    => o.UseSqlServer(configuration.GetConnectionString("IdentityDefault")));

        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;

            if (env.IsDevelopment())
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }
            else
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }
        })
        .AddEntityFrameworkStores<ApiIdentityDbContext>()
        .AddDefaultTokenProviders();


        //services.ConfigureApplicationCookie(config =>
        //{
        //    config.LoginPath = "/Account/Login";
        //    config.LogoutPath = "/api/auth/logout";
        //    config.Cookie.Domain = configuration["CookieDomain"];
        //});

        services.AddAuthorization(options =>
        {

        });
    }
} 