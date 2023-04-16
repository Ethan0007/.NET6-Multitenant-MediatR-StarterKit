using Microsoft.EntityFrameworkCore;
using Multitenant.Net6.API;
using Multitenant.Net6.Domain.DatabaseContext;
 
var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("appsettings.json", true);
    config.AddJsonFile($"appsettings.{env}.json", true);
}).UseDefaultServiceProvider(
           (_, options) =>
           {
               options.ValidateScopes = false;
           });
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
startup.Configure(app, builder.Services);
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
