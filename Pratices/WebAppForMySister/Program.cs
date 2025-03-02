using WebAppForMySister.Services;

RequestDelegateService requestService = new ();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.Map("/mainpage", (appBuilder) =>
{
    appBuilder.Run(requestService.HandleMainPageRequest);
});
app.Map("/feedback", (appBuilder) =>
{
    appBuilder.Run(requestService.HandleFeedbackPageRequest);
});

app.Map("/portfolio", (appBuilder) =>
{
    appBuilder.Run(requestService.HandlePortfolioPageRequest);
});

app.Run(requestService.HandleMainPageRequest);
app.Run();
