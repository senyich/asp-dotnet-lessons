using EndpointsHW_16._03.Data;
using EndpointsHW_16._03.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<GameDbService>();
var app = builder.Build();
using var context = new GameContext();

var edService = new EndpointsHandlerService();

app.MapGet("/", () => Results.Redirect("/games"));

app.Map("/games", edService.SendMainPage);
app.Map("/addgame", edService.SendAddGamePage);
app.Map("/deletegame", edService.SendDeletePage);

//вот это выглядит костыльно капец,
//я бы лучше делал через middleware, но так как сказано по заданию через эндпоинты делать, пришлось изгаляться,
//по другому я не придумал)
app.Map("/addgame+{name}+{genre}+{author}", async (string name, string genre, string author, GameDbService dbService) => await edService.AddGame(name, genre, author, dbService));
app.Map("/deletegame+{name}", async (string name, GameDbService dbService) => await edService.RemoveGame(name, dbService));

//ну и поиск я сделал жанр&&автор, не стал переделывать на жанр||автор, ибо сути не меняет
app.MapGet("/api/showgames", async (HttpContext context, GameDbService dbService) => {
    var genre = context.Request.Query["genre"];
    var author = context.Request.Query["author"];
    await edService.SendFilteredGames(context, dbService, genre, author);
});

app.Run();

