using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ratmon.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.Configure<Ratmon.MainConfig>(builder.Configuration.GetSection("Main"));

if (builder.Environment.EnvironmentName == "Development")
{
    Console.WriteLine("DEV MODE");
    var dbName = builder.Configuration.GetSection("Main").GetValue<string>("DbPath");
    Console.WriteLine(String.Format("SQLite Database Name: {0}", dbName));
    Console.WriteLine(String.Format("SQLite Database Location: {0}", Path.Combine(Environment.CurrentDirectory, "db", dbName ?? "database.db")));
}

builder.Services.AddDbContext<RatmonDbContext>();

var config = builder.Configuration.GetSection("Main").GetSection("JWT");
var key = Encoding.ASCII.GetBytes(config.GetValue<string>("Secret") ?? "");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.Authority = config.GetValue<string>("Authority");
    o.Audience = config.GetValue<string>("Audience");
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = config.GetValue<string>("ValidAudience"),
        ValidIssuer = config.GetValue<string>("ValidIssuer"),
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
    o.SaveToken = true;
    if (o.Configuration is not null)
    {
        o.Configuration.AuthorizationEndpoint = "auth/login";
    }
    if (builder.Environment.EnvironmentName == "Development")
        o.IncludeErrorDetails = true;
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<RatmonDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.MapControllers();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
