using WebAppForMySister.MiddlewareComponents;
using WebAppForMySister.Services;
using WebAppForMySister.MiddlewareComponents.API;
using WebAppForMySister.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbService<ReviewModel>, ReviewDbService>();

var app = builder.Build();

app.UseStaticFiles();
app.Map("/api/get-reviews", appBuilder => appBuilder.UseMiddleware<ShowReviewsApiMiddleware>());
app.Map("/api/add-review", appBuilder => appBuilder.UseMiddleware<AddReviewApiMiddleware>());
app.Map("/mainpage", appBuilder => appBuilder.UseMiddleware<MainPageMiddleware>());
app.Map("/feedback", appBuilder => appBuilder.UseMiddleware<FeedbackPageMiddleware>());
app.Map("/contacts", appBuilder => appBuilder.UseMiddleware<ContactsPageMiddleware>());
app.Map("/review", appBuilder => appBuilder.UseMiddleware<ReviewPageMiddleware>());

app.MapGet("/", () => Results.Redirect("/mainpage"));

app.Run();
