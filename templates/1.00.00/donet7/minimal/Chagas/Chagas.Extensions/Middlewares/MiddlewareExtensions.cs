namespace Chagas.Extensions.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddGlobalExceptionHandlerMiddleware(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandlerMiddleware>();
            services.AddTransient<UnauthorizedTokenMiddleware>();

            return services;
        }
    }
}