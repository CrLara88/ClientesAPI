using EdenredTest.Data;
using EdenredTest.Model.Dao;
using EdenredTest.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EdenredTest.Model.Authentication;
using EdenredTest.Model.Authentication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "database.db");
var connectionString = builder.Configuration.GetConnectionString("ClientConnection").Replace("{PATH}", dbPath);

builder.Services.AddDbContext<DbContextClient>(options => options.UseSqlite(connectionString));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API gestión clientes - TEST",
        Version = "1.0",
        Description = "API que permite la creación, actualización y consulta de clientes, protegida por autenticación y generación de token JWT."
    });
    var archivoXml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var directorioXml = Path.Combine(AppContext.BaseDirectory, archivoXml);
    a.IncludeXmlComments(directorioXml);
});


// Autenticación Jwt
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ConfiguracionJwt:Llave"] ?? string.Empty)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<IClientDao, ClientDao>();
builder.Services.AddScoped<IManejoJwt, ManejoJwt>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
