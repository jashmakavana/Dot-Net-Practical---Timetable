using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Timetable.Application;

public static class ApplicationConfigurationExtension
{
    public static void ApplicationConfigureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}