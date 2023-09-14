namespace Chagas.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {

            services.AddScoped<DataContext, DataContext>();

            return services;
        }
    }
}