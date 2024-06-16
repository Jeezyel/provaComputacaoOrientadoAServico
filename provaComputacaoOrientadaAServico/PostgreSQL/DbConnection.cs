using Npgsql;

namespace provaComputacaoOrientadaAServico.PostgreSQL
{
    public class DbConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public DbConnection()
        {
            Connection = new NpgsqlConnection("Host=bdpostgres;Port=5432;Username=postgres;Password=Postgres2024;Database=ComputacaoOrientadoAServiso");
            Connection.Open();
        }
        public void Dispose()
        {
            Connection.Dispose();

        }
    }
}
