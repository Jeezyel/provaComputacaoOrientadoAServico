using Dapper;
using Npgsql;

namespace provaComputacaoOrientadaAServico.PostgreSQL
{
    public class DbConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public DbConnection()
        {
            Connection = new NpgsqlConnection("Host=bdpostgres;Port=5432;Username=postgres;Password=Postgres2024;Database=postgres");
            Connection.Open();
            Initialize();
        }
        public void Dispose()
        {
            Connection.Dispose();

        }
        // esse Initialize ve se ja tem a tabela cor no banco de dados se tiver ela n faz nada mas se tiver ela cria
        public void Initialize() 
        {
            string queryInit = @"CREATE TABLE IF NOT EXISTS cor (
                                    Id SERIAL PRIMARY KEY,  -- Campo 'Id' como chave primária e autoincrementado
                                    Nome VARCHAR(100) NOT NULL,  -- Campo 'nome' como VARCHAR
                                    Codego VARCHAR(100) NOT NULL -- Campo 'codego' como VARCHAR
                                );
                                ";
            Connection.Execute(queryInit);
        }
    }
}
