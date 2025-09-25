using AutomationEdariSamyaran.API;
using AutomationEdariSamyaran.Application.Contracts;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Interfaces;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using AutomationEdariSamyaran.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---------------- JWT ----------------
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

if (string.IsNullOrEmpty(jwtSettings.SecretKey))
{
    throw new InvalidOperationException("JwtSettings:SecretKey is not configured in appsettings.json");
}

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization();

// ---------------- Database ----------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// ---------------- MediatR ----------------
builder.Services.AddMediatR(typeof(Program).Assembly);

// ---------------- Repository ----------------
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ---------------- Swagger ----------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<LoginModelExampleFilter>();
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "برای استفاده از توکن، 'Bearer {token}' را وارد کنید."
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ---------------- CORS ----------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();

// ---------------- Swagger UI روی روت ----------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // 🔑 این باعث میشه Swagger روی روت باز بشه
    });
}

// ---------------- Middleware ----------------
app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
