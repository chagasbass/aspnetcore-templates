﻿namespace Chagas.API.Endpoints
{
    public static class EndpointWeatherExtensions
    {
        public static WebApplication AddWeatherV1Endpoints(this WebApplication app)
        {
            app.MapGet("/v1/weatherforecasts", ([FromServices] IApiCustomResults customResults,
                                             [FromServices] INotificationServices notificationServices) =>
            {
                var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool" };

                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();

                notificationServices.AddStatusCode(StatusCodeOperation.OK);

                var commandResult = new CommandResult(forecast, true, "Dados encontrados");

                return customResults.FormatApiResponse(commandResult);
            })
         .Produces<CommandResult>(StatusCodes.Status404NotFound)
         .Produces<CommandResult>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status500InternalServerError)
         .WithName("GetWeatherForecasts")
         .WithTags("Weatherforecasts")
         .WithDescription("Endpoint de listagem de weathers retornando 200")
         .WithOpenApi();


            app.MapGet("/v1/weatherforecasts/{temperature}", ([FromServices] IApiCustomResults customResults,
                                           [FromServices] INotificationServices notificationServices, int temperature) =>
            {
                var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool" };

                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray().Where(x => x.TemperatureC <= temperature).ToList();

                notificationServices.AddNotification(new Flunt.Notifications.Notification("Propriedade", "Erro encontrado"),
                                                     StatusCodeOperation.BadRequest);

                var commandResult = new CommandResult(forecast, false, "erro no processo de busca do weatherForecast");

                return customResults.FormatApiResponse(commandResult);
            })
       .Produces<CommandResult>(StatusCodes.Status404NotFound)
       .Produces<CommandResult>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status500InternalServerError)
       .WithName("GetWeatherForecastsWithTemperature")
       .WithTags("Weatherforecasts")
       .WithDescription("Endpoint de listagem de weathers por temperatura retornando 400")
       .WithOpenApi();

            return app;
        }
    }

    internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}