using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GymEvo.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var x in assemblies)
            {
                if (x.FullName.Contains("GymEvo.Application"))
                {
                    var handlers = x.ExportedTypes.Where(y => y.Name.Contains("Handler")).ToList();

                    handlers.ForEach(handler =>
                    {
                        services.TryAddScoped(handler, handler);
                    });
                }
            }

            return services;
        }
    }
}