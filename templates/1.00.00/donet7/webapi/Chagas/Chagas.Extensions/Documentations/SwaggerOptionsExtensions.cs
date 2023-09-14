namespace Chagas.Extensions.Documentations
{
    public class SwaggerOptionsExtensions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IConfiguration _configuration;

        const string mensagemPadrao = "Não informado";

        public SwaggerOptionsExtensions(IApiVersionDescriptionProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateVersionInfo(
            ApiVersionDescription description)
        {
            var applicationName = _configuration["BaseConfiguration:NomeAplicacao"];
            var applicationDescription = _configuration["BaseConfiguration:Descricao"];
            var developerName = _configuration["BaseConfiguration:Desenvolvedor"];


            if (string.IsNullOrEmpty(applicationName))
                applicationName = mensagemPadrao;

            if (string.IsNullOrEmpty(developerName))
                developerName = mensagemPadrao;

            var info = new OpenApiInfo
            {
                Title = applicationName,
                Description = $"{applicationDescription} Desenvolvido por: {developerName}",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " Esta versão de API está depreciada.";
            }

            return info;
        }
    }
}