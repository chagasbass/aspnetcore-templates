namespace Chagas.Extensions.Documentations.Versionings
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddMinimalApiVersionsing(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
             {
                 options.DefaultApiVersion = new ApiVersion(1, 0);
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 options.ReportApiVersions = true;
             });

            return services;
        }
    }
}
