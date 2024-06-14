using CorsiFormazione.Application.Extentions;
using CorsiFormazione.Models.Extentions;
using CorsiFormazione.Web.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();

