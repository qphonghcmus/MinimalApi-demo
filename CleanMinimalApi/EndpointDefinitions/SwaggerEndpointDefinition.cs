using CleanMinimalApi.SecretSauce;
using Microsoft.OpenApi.Models;

namespace CleanMinimalApi.EndpointDefinitions;

public class SwaggerEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
