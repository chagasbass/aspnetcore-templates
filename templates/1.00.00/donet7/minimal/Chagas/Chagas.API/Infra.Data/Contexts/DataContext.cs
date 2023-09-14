namespace Chagas.API.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        private readonly BaseConfigurationOptions _baseConfigurationOptions;
        private IDbConnection? _DbConnection;

        public DataContext(IOptions<BaseConfigurationOptions> options)
        {
            _baseConfigurationOptions = options.Value;

            var builder = new SqlConnectionStringBuilder(_baseConfigurationOptions.StringConexaoBancoDeDados);
            builder.Pooling = true;

            _DbConnection = new SqlConnection(builder.ConnectionString);
        }

        public IDbConnection AbrirConexao()
        {
            if (_DbConnection is null || _DbConnection.State != ConnectionState.Open)
            {
                _DbConnection.Open();
            }

            return _DbConnection;

        }

        public void Dispose()
        {

            if (_DbConnection != null)
            {
                if (_DbConnection.State != ConnectionState.Closed)
                {
                    _DbConnection.Close();
                }

                _DbConnection.Dispose();
                _DbConnection = default;
            }

        }
    }
}