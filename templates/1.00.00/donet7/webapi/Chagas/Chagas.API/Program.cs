var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

#region configuring logs
Log.Logger = LogExtensions.ConfigureStructuralLogWithSerilog(configuration);
builder.Logging.AddSerilog(Log.Logger);
#endregion

try
{
    Log.Information("Iniciando a aplicação");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer()
                    .AddDependencyInjenctions()
                    .AddApplicationInsightsApiTelemetry(configuration)
                    .SolveStructuralAppDependencyInjection()
                    .AddOptionsPattern(configuration)
                    .AddGlobalCustomsMiddlewares()
                    .AddCustomApiVersioning()
                    .AddSwaggerDocumentation(configuration)
                    .AddRequestResponseCompress()
                    .AddResponseRequestConfiguration()
                    .AddFilterToSystemLogs()
                    .AddAppHealthChecks()
                    .AddApiAuthentication();

    var app = builder.Build();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseResponseCompression()
       .UseMiddleware<GlobalExceptionHandlerMiddleware>()
       .UseMiddleware<SerilogRequestLoggerMiddleware>()
       .UseSwagger()
       .UseSwaggerUIMultipleVersions(provider);


    app.UseCors(x => x.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseMiddleware<UnauthorizedTokenMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.InsertHealthChecksMiddleware(configuration);

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal($"Erro fatal na aplicação => {ex.Message}");
}
finally
{
    Log.CloseAndFlush();
}