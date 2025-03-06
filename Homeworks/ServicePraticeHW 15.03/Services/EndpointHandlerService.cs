using Microsoft.AspNetCore.Http;
using ServicePratice.Data.Models;
using System.Text.Json;

namespace ServicePratice.Services
{
    public class EndpointHandlerService
    {
        public async Task HandleAccountEndpoint(HttpContext context, int id, string username)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            var userData = new User
            {
                Id = id,
                Username = username,
                HashedPassword = "0"
            };
            await context.Response.WriteAsJsonAsync(userData);
        }
    }
}
