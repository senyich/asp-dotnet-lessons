using WebAppForMySister.MiddlewareComponents;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.Map("/mainpage", appBuilder => appBuilder.UseMiddleware<MainPageMiddleware>());
app.Map("/feedback", appBuilder => appBuilder.UseMiddleware<FeedbackPageMiddleware>());
app.Map("/contacts", appBuilder => appBuilder.UseMiddleware<ContactsPageMiddleware>());
app.Map("/review", appBuilder => appBuilder.UseMiddleware<ReviewPageMiddleware>());

app.MapGet("/", () => Results.Redirect("/mainpage"));

app.Run();
