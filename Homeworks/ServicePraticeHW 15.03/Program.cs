using ServicePratice.Services;
using ServicePratice.Data.Models;
using ServicePratice.MiddlewareComponents;
using ServicePratice.Interfaces;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDbService<User>, UserDbService>();
builder.Services.AddSingleton<IVerificationService<User>, UserVerificationService>();
builder.Services.AddSingleton<IEncrypterService, PasswordEncrypterService>();
builder.Services.AddSingleton<ILoggerService, LoggerService>();

var app = builder.Build();

app.Map("/api/get-user-form", appBuilder => appBuilder.UseMiddleware<GetUserDataMiddleware>());
app.Map("/registration-page", appBuilder => appBuilder.UseMiddleware<MainPageMiddleware>());
app.MapGet("/", () => Results.Redirect("/registration-page"));

app.Run();
