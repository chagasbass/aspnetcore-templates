namespace Chagas.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        private readonly BaseConfigurationOptions _baseConfigurationOptions;
        private IDbConnection _DbConnection;

        public DataContext(IOptions<BaseConfigurationOptions> options)
        {
            _baseConfigurationOptions = options.Value;
        }

        public IDbConnection AbrirConexao()
        {
            if (_DbConnection is null || _DbConnection.State != ConnectionState.Open)
            {
                _DbConnection = new SqlConnection(_baseConfigurationOptions.StringConexaoBancoDeDados);
                _DbConnection.Open();
            }

            return _DbConnection;

        }

        public void Dispose()
        {
            if (_DbConnection != null && _DbConnection.State == ConnectionState.Open)
                _DbConnection.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}