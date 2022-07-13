using CleanMinimalApi.Models;
using CleanMinimalApi.SecretSauce;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointDefinitions(typeof(Customer));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseEndpointDefinitions();

app.Run();