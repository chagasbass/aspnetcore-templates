using DustInTheWind.ConsoleTools;

var logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
    .CreateLogger();

Console.WriteLine();

var template = MenuTemplates.Execute();

Console.WriteLine();

string? projectName = null;
do
{
    if (projectName is not null)
    {
        var oldForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        CustomConsole.WriteLineError("Inform a valid project name!");
        Console.ForegroundColor = oldForegroundColor;
        Console.WriteLine();
    }
    Console.Write("Project name: ");
    projectName = Console.ReadLine();
} while (String.IsNullOrWhiteSpace(projectName) ||
         !Regex.IsMatch(projectName, @"^(?:[a-zA-Z_][a-zA-Z0-9_]*(?:\.[a-zA-Z_][a-zA-Z0-9_]*)*)?$"));

try
{
    Console.WriteLine();
    CustomConsole.WriteLineWarning("Starting the project generation...");

    await ProjectGenerator.GenerateProject(projectName, template, logger);

    CustomConsole.WriteLineSuccess("Project * {projectName} * with template * {template} * generated successfully!");
}
catch (Exception ex)
{
    CustomConsole.WriteLineError("Error generating project");
    return;
}