using AspnetCoreTemplates.Extensions;
using DustInTheWind.ConsoleTools;

namespace AspnetCoreTemplates.Templates;

public static class ProjectGenerator
{
    public static async Task GenerateProject(string projectName, TemplateOptions template,
        Logger logger)//string projectPath
    {
        string projectDirectory;
#if DEBUG
        var testsDirectory = Path.Combine(
            new DirectoryInfo(Environment.CurrentDirectory).Parent!.FullName, "Tests");

        if (!Directory.Exists(testsDirectory))
            Directory.CreateDirectory(testsDirectory);

        projectDirectory = Path.Combine(testsDirectory, projectName);
#else
            projectDirectory = Path.Combine(Environment.CurrentDirectory, projectName);
#endif

        if (Directory.Exists(projectDirectory))
            throw new Exception("A directory with this project name already exists. Please enter a different project name!");

        Directory.CreateDirectory(projectDirectory);

        TemplateDefinition templateDefinition;

        switch (template)
        {
            case TemplateOptions.WebApiDotNet7:
                templateDefinition = new WebApiDotNet7();
                break;
            case TemplateOptions.MinimalApisDotNet7:
                templateDefinition = new MinimalApisDotNet7();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(template), template, null);
        }

        ConsoleToolsExtensions.ShowProgressBar();

        var httpClient = new HttpClient();

        foreach (var file in templateDefinition.Files)
        {
            var fileUrl = new Uri(new Uri(templateDefinition.BaseUrl! + "/"), file).ToString();

            var fileName = Path.GetFileName(fileUrl);

            var response = await httpClient.GetAsync(fileUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var filePath = Path.Combine(projectDirectory, file);

                Directory.CreateDirectory(new FileInfo(filePath).DirectoryName!);

                var fileContent = new StringBuilder(content);

                fileContent.Replace("Chagas", projectName);

                if (filePath.EndsWith(".csproj"))
                    filePath = filePath.Replace("Chagas.csproj", projectName + ".csproj");

                File.WriteAllText(filePath, fileContent.ToString());

                CustomConsole.WriteLineSuccess("${ filePath} created...");

                ConsoleToolsExtensions.HideProgressBar();
            }
            else
            {
                CustomConsole.WriteLineError($"Erro: {response.StatusCode} - {response.ReasonPhrase}");
                CustomConsole.WriteLineError("O Projeto não foi criado");

                ConsoleToolsExtensions.HideProgressBar();

                Console.ReadKey();
            }
        }
    }
}