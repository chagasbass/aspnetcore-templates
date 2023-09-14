namespace AspnetCoreTemplates.Templates.Menu;

public static class MenuTemplates
{
    public static TemplateOptions Execute()
    {
        var textMenu = new TextMenu
        {
            TitleText = "**** Creating a REST API , MINIMAL API and WORKER SERVICES | © Thiago Chagas - 2023 - MIT License ****",
            ForegroundColor = ConsoleColor.Green,
            EraseAfterClose = false
        };

        textMenu.AddItems(new List<TextMenuItem>
        {
            new TextMenuItem
            {
                Id = $"{(int)(TemplateOptions.WebApiDotNet7)}",
                Text = "ASP.NET Core Web API in .NET 7"
            },
            new TextMenuItem
            {
                Id = $"{(int)(TemplateOptions.MinimalApisDotNet7)}",
                Text = "ASP.NET Core Minimal API in .NET 7"
            },
            new TextMenuItem
            {
                Id = $"{(int)(TemplateOptions.WorkerServiceLongRunningNet7)}",
                Text = "ASP.NET Core Worker Service Long Running Tasks in .NET 7"
            },
             new TextMenuItem
            {
                Id = $"{(int)(TemplateOptions.WokerServiceNet7)}",
                Text = "ASP.NET Core Worker Service  Tasks in .NET 7"
            }
        });

        textMenu.QuestionText = "Enter the template number of your choice: ";
        textMenu.InvalidOptionText = "Invalid option. Please select a valid number.";
        textMenu.Display();
        return (TemplateOptions)Enum.Parse(typeof(TemplateOptions), textMenu.SelectedItem.Id);
    }
}