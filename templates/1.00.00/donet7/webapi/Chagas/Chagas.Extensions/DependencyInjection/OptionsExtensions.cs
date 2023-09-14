namespace Chagas.Extensions.DependencyInjection
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddOptionsPattern(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BaseConfigurationOptions>(configuration.GetSection(BaseConfigurationOptions.BaseConfig));
            services.Configure<HealthchecksConfigurationOptions>(configuration.GetSection(HealthchecksConfigurationOptions.BaseConfig));
            services.Configure<ProblemDetailConfigurationOptions>(configuration.GetSection(ProblemDetailConfigurationOptions.BaseConfig));
            services.Configure<ResilienceConfigurationOptions>(configuration.GetSection(ResilienceConfigurationOptions.ResilienciaConfig));
            return services;
        }
    }
}