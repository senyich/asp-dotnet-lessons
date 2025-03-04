using Services;
using Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ILoggerService, FileLoggerService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IPersonFormatter, StarsPersonFormatter>();

var app = builder.Build();

app.Map("/loggerEx", appBuilder => appBuilder.UseMiddleware<LoggerMiddleware>());
app.Map("/firstEx", appBuilder => appBuilder.UseMiddleware<ShowPersonMiddleware>());
app.Map("/secondEx", appBuilder => appBuilder.UseMiddleware<PersonFormatterMiddleware>());

app.Run();

    