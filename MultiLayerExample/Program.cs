using Microsoft.EntityFrameworkCore;
using MultiLayerExample.BLL.DependencyInjection;
using MultiLayerExample.DAL.DependencyInjection;
using MultiLayerExample.Web.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Database connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Serilog configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console( outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {ThreadId}] {Message:lj} {NewLine}{Exception}")
    .WriteTo.File("Logs/log-.txt", 
        rollingInterval: RollingInterval.Day,
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {ThreadId}] {Message:lj} {NewLine}{Exception}")
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

//Add Serilog to our project
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddBusinessLayer();
builder.Services.AddDataLayer(connectionString);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
