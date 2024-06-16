using Dapper;
using provaComputacaoOrientadaAServico.Model;
using provaComputacaoOrientadaAServico.PostgreSQL;
using System.Drawing;

namespace provaComputacaoOrientadaAServico.Repository
{
    public class CorRepository
    {
        public bool Add(Cor cor)
        {
            using var conn = new DbConnection();
            string query = @"INSERT INTO public.cor(nome, codego) VALUES(@Nome, @Codego)";
            var result = conn.Connection.Execute(sql: query, param: cor);
            return result == 1;
        }

        public List<Cor> GetAll()
        {
            using var conn = new DbConnection();
            string query = @"SELECT * FROM cor";
            var cores = conn.Connection.Query<Cor>(sql: query);
            return cores.ToList();
        }

        public Cor GetById(int id)
        {
            using var conn = new DbConnection();
            string query = @"SELECT * FROM cor WHERE id = @Id";
            var cor = conn.Connection.QuerySingleOrDefault<Cor>(sql: query, param: new { Id = id });
            return cor;
        }

        public bool Delete(int id)
        {
            using var conn = new DbConnection();
            string query = @"DELETE FROM cor WHERE id = @Id";
            var result = conn.Connection.Execute(sql: query, param: new { Id = id });
            return result == 1;
        }

        public bool Update(Cor cor)
        {
            using var conn = new DbConnection();
            string query = @"UPDATE cor SET nome = @Nome, codego = @Codego WHERE id = @Id";
            var result = conn.Connection.Execute(sql: query, param: cor);
            return result == 1;
        }
    }
}
