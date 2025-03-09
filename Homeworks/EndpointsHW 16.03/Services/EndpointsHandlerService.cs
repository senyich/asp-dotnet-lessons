using EndpointsHW_16._03.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace EndpointsHW_16._03.Services
{
    public class EndpointsHandlerService
    {
        public async Task SendMainPage(HttpContext context)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.SendFileAsync("Pages/index.html");
        }       
        public async Task SendDeletePage(HttpContext context)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.SendFileAsync("Pages/deletegame.html");
        }

        public async Task SendAddGamePage(HttpContext context)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.SendFileAsync("Pages/addgame.html");
        }

        public async Task SendGameById(int id, HttpContext context, GameDbService dbService)
        {
            var game = dbService.GetGame(id);
            await context.Response.WriteAsJsonAsync(game);
        }

        public async Task SendAllGames(HttpContext context, GameDbService dbService)
        {
            var games = await dbService.GetGames();
            await context.Response.WriteAsJsonAsync(games);
        }

        public async Task SendFilteredGames(HttpContext context, GameDbService dbService, string? genre, string? author)
        {
            ICollection<GameModel> games = null;
            if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(genre))
                games = await dbService.GetGames();
            else
                games = await dbService.GetGamesByFilter(genre, author);
            await context.Response.WriteAsJsonAsync(games);
        }
        public async Task AddGame(string name, string genre, string author, GameDbService dbService) => await dbService.AddGame(new GameModel(name, genre, author));
        public async Task RemoveGame(string name, GameDbService dbService) => await dbService.DeleteGame(name);

    }
}
