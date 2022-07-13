namespace CleanMinimalApi.SecretSauce;

public static class EndpointDefinitionExtensions
{
    public static void AddEndpointDefinitions(
        this IServiceCollection services,
        params Type[] scanMarksers)
    {
        var endpointDefinitions = new List<IEndpointDefinition>();

        foreach (var marker in scanMarksers)
        {
            endpointDefinitions.AddRange(
                marker.Assembly.ExportedTypes
                .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.Equals(typeof(IEndpointDefinition)))
                .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());
        }
        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineServices(services);
        }

        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
        foreach (var endpointDefinition in definitions)
        {
            endpointDefinition.DefineEndpoints(app);
        }
    }
}
