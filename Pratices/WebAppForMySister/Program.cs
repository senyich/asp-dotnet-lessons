using WebAppForMySister.MiddlewareComponents;
using WebAppForMySister.Services;
using WebAppForMySister.MiddlewareComponents.API;
using WebAppForMySister.Data.Models;
using WebAppForMySister.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDbService<ReviewModel>, ReviewDbService>();

var app = builder.Build();
app.UseStaticFiles();
var context = new Context();

app.Map("/api/get-reviews", appBuilder => appBuilder.UseMiddleware<ShowReviewsMiddleware>());
app.Map("/api/add-review", appBuilder => appBuilder.UseMiddleware<AddReviewApiMiddleware>());
app.Map("/mainpage", appBuilder => appBuilder.UseMiddleware<MainPageMiddleware>());
app.Map("/feedback", appBuilder => appBuilder.UseMiddleware<FeedbackPageMiddleware>());
app.Map("/contacts", appBuilder => appBuilder.UseMiddleware<ContactsPageMiddleware>());
app.Map("/review", appBuilder => appBuilder.UseMiddleware<ReviewPageMiddleware>());

app.MapGet("/", () => Results.Redirect("/mainpage"));

app.Run();
