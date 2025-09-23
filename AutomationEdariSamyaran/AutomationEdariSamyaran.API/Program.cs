
using AutomationEdariSamyaran.Domain.Interfaces;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using AutomationEdariSamyaran.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// خواندن کانکشن از appsettings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 💬 ثبت MediatR از پروژه Application

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(typeof(Program));  

// 🎯 ثبت AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 🔁 فعال کردن CORS برای React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173") // آدرس React
                     .AllowAnyHeader()
                     .AllowAnyMethod();
    });
});

// 💾 ثبت Repository و UnitOfWork
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<ILivenessDetectionService, LivenessDetectionService>();
//builder.Services.AddScoped<ILivenessDetectionServiceFactory, LivenessDetectionServiceFactory>();
// 📦 API و Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// 🌐 فقط در محیط توسعه Swagger را فعال کن
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⚙️ Middlewareها
app.UseHttpsRedirection();
app.UseCors("AllowReactApp"); // فراموش نکن
app.UseAuthorization();
app.MapControllers();

app.Run();
