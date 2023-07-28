namespace NopClone.WebApi.ServiceExtension;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}