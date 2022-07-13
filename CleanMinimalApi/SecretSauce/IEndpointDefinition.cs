namespace CleanMinimalApi.SecretSauce;

public interface IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app);
    public void DefineServices(IServiceCollection services);
}
