namespace AspnetCoreTemplates.Templates.Options;

public class MinimalApisDotNet7 : TemplateDefinition
{
    public MinimalApisDotNet7()
    {
        BaseUrl = "https://raw.githubusercontent.com/chagasbass/DotNetApiVersioningTemplates/main/templates/1.00.00/dotnet7/minimal/Chagas";

        #region API
        Files.Add("Chagas.csproj");
        Files.Add("Chagas.API/Chagas.API.csproj");
        Files.Add("Chagas.API/Program.cs");
        Files.Add("Chagas.API/appsettings.json");
        Files.Add("Chagas.API/appsettings.Development.json");
        Files.Add("Chagas.API/Dockerfile");
        Files.Add("Chagas.API/GlobalUsings.cs");
        Files.Add("Chagas.API/Controllers/WeatherForecastController.cs");
        Files.Add("Chagas.API/Extensions/DependencyInjectionExtensions.cs");
        Files.Add("Chagas.API/Properties/launchSettings.json");
        Files.Add("Chagas.API/Base/ApiBaseController.cs");
        #endregion

        #region Application
        Files.Add("Chagas.Application/Chagas.Application.csproj");
        Files.Add("Chagas.Application/GlobalUsings.cs");
        #endregion

        #region Domain
        Files.Add("Chagas.Domain/Chagas.Domain.csproj");
        Files.Add("Chagas.Domain/GlobalUsings.cs");
        Files.Add("Chagas.Domain/Diagrams/DomainDiagram.cd");

        #endregion

        #region Extensions
        Files.Add("Chagas.Extensions/Chagas.Extensions.csproj");
        Files.Add("Chagas.Extensions/GlobalUsings.cs");
        Files.Add("Chagas.Extensions/Authentications/AuthenticationExtensions.cs");
        Files.Add("Chagas.Extensions/DependencyInjection/DependencyInjectionExtensions.cs");
        Files.Add("Chagas.Extensions/DependencyInjection/OptionsExtensions.cs");
        Files.Add("Chagas.Extensions/Documentations/Filters/ReApplyOptionalRouteParameterOperationFilter.cs");
        Files.Add("Chagas.Extensions/Documentations/SwaggerExtensions.cs");
        Files.Add("Chagas.Extensions/Documentations/SwaggerOptionsExtensions.cs");
        Files.Add("Chagas.Extensions/Documentations/VersioningExtensions.cs");
        Files.Add("Chagas.Extensions/Healths/GCInfoHealthCheckBuilderExtensions.cs");
        Files.Add("Chagas.Extensions/Healths/HealthCheckBuilderSelfExtensions.cs");
        Files.Add("Chagas.Extensions/Healths/HealthcheckExtensions.cs");
        Files.Add("Chagas.Extensions/Healths/HealthReportExtensions.cs");
        Files.Add("Chagas.Extensions/Healths/Customs/GarbageCollectorHealthcheck.cs");
        Files.Add("Chagas.Extensions/Healths/Customs/SelfHealthcheck.cs");
        Files.Add("Chagas.Extensions/Healths/Entities/GCInfoOptions.cs");
        Files.Add("Chagas.Extensions/Healths/Entities/HealthData.cs");
        Files.Add("Chagas.Extensions/Healths/Entities/HealthNames.cs");
        Files.Add("Chagas.Extensions/Healths/Entities/HealthInformation.cs");
        Files.Add("Chagas.Extensions/Healths/Entities/MemoryInformation.cs");
        Files.Add("Chagas.Extensions/Logs/Configurations/LogExtensions.cs");
        Files.Add("Chagas.Extensions/Logs/Entities/LogData.cs");
        Files.Add("Chagas.Extensions/Logs/Services/ILogServices.cs");
        Files.Add("Chagas.Extensions/Logs/Services/LogServices.cs");
        Files.Add("Chagas.Extensions/Middlewares/GlobalExceptionHandlerMiddleware.cs");
        Files.Add("Chagas.Extensions/Middlewares/MiddlewareExtensions.cs");
        Files.Add("Chagas.Extensions/Middlewares/SerilogRequestLoggerMiddleware.cs");
        Files.Add("Chagas.Extensions/Middlewares/UnauthorizedTokenMiddleware.cs");
        Files.Add("Chagas.Extensions/Notifications/NotificationExtensions.cs");
        Files.Add("Chagas.Extensions/Performances/PerformanceApiExtensions.cs");
        Files.Add("Chagas.Extensions/Resiliences/ResilienceExtensions.cs");
        Files.Add("Chagas.Extensions/Resiliences/ResiliencePolicies.cs");
        Files.Add("Chagas.Extensions/Telemetry/TelemetryExtensions.cs");
        #endregion

        #region Infra.Data
        Files.Add("Chagas.Infra.Data/Chagas.Infra.Data.csproj");
        Files.Add("Chagas.Infra.Data/DataContexts/DataContext.cs");
        Files.Add("Chagas.Infra.Data/DataContexts/GlobalUsings.cs");

        #endregion

        #region Shared
        Files.Add("Chagas.Shared/Chagas.Shared.csproj");
        Files.Add("Chagas.Shared/GlobalUsings.cs");
        Files.Add("Chagas.Shared/Configurations/BaseConfigurationOptions.cs");
        Files.Add("Chagas.Shared/Configurations/HealthchecksConfigurationOptions.cs");
        Files.Add("Chagas.Shared/Configurations/ProblemDetailConfigurationOptions.cs");
        Files.Add("Chagas.Shared/Configurations/ResilienceConfigurationOptions.cs");
        Files.Add("Chagas.Shared/Entities/ApiProblemDetails.cs");
        Files.Add("Chagas.Shared/Entities/BaseEntity.cs");
        Files.Add("Chagas.Shared/Entities/ICommandResult.cs");
        Files.Add("Chagas.Shared/Entities/CommandResult.cs");
        Files.Add("Chagas.Shared/Enums/Enumeration.cs");
        Files.Add("Chagas.Shared/Enums/StausCodeOperation.cs");
        Files.Add("Chagas.Shared/Extensions/MemoryConverterExtensions.cs");
        Files.Add("Chagas.Shared/Factories/JsonOptionsFactory.cs");
        Files.Add("Chagas.Shared/Helpers/DateTimeExtensions.cs");
        Files.Add("Chagas.Shared/Notifications/INotificationServices.cs");
        Files.Add("Chagas.Shared/Notifications/NotificationServices.cs");



        #endregion

        #region Tests

        Files.Add("Chagas.Tests/Chagas.Tests.csproj");
        Files.Add("Chagas.Tests/GlobalUsings.cs");
        Files.Add("Chagas.Tests/xunit.runner.json");
        Files.Add("Chagas.Tests/Bases/IFake.cs");

        #endregion

    }
}