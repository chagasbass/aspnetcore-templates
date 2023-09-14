using Chagas.API;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/weathers")]
public class WeatherForecastController : ApiBaseController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherForecastController(ILogServices logService,
                                     INotificationServices notificationServices) : base(logService, notificationServices) { }

    /// <summary>
    /// Exemplo para documentação de endpoint Endpoint de sucesso
    /// </summary>
    /// <param name="id">Exemplo de parametros
    ///  - </param>
    ///  <remarks>
    /// Exemplo request:
    ///
    /// </remarks>
    /// <response code="200">Retorna quando a solitação é válida.</response>
    /// <response code="400">Retorna quando a solitação gerou erro.</response>
    /// <response code="500">Retorna quando algum problema inesperado acontece na chamada.</response>
    /// <returns>Retorna um objeto do tipo CommandResult contendo o retorno da chamada</returns>
    [HttpGet("")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult<CommandResult> Get([FromQuery] int id)
    {
        var dados = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        return FormatApiResponse(new CommandResult(dados, true));
    }
}