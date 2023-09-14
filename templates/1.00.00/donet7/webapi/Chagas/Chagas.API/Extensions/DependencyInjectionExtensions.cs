namespace Chagas.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjenctions(this IServiceCollection services)
        {

            services.AddScoped<DataContext, DataContext>();

            return services;
        }
    }
}