using Microsoft.Extensions.DependencyInjection;

namespace GymEvo.Domain.Mapper
{
    public static class AutoMapperDependencyInjection
    {
        public static IServiceCollection AddAutoMapperDependency(this IServiceCollection services)
        {
            return services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}