using Interfaces.old.IDatabase;
using MySqlConnector;

namespace Repository.Database
{
    public abstract class ADatabase : IDatabase
    {
        public abstract string NomeTabela { get; }
        public abstract string ScriptCriacao { get; }

        public async Task<bool> TabelaExiste(MySqlConnection conn)
        {
            var sql = @"
                SELECT 1 FROM information_schema.tables
                WHERE table_schema = DATABASE()
                AND table_name = @nomeTabela
                LIMIT 1";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nomeTabela", NomeTabela);
            return (await cmd.ExecuteScalarAsync()) != null;
        }

        public async Task CriarTabelaAsync(MySqlConnection conn)
        {
            try
            {
                using var cmd = new MySqlCommand(ScriptCriacao, conn);
                await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"Tabela {NomeTabela} criada/verificada");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"➠ Erro ao inicializar o banco de dados: \n {ex.Message}");
                throw;
            }
        }

        public async Task GarantirExistenciaTabelaAsync(MySqlConnection conn)
        {
            if (!await TabelaExiste(conn))
                await CriarTabelaAsync(conn);
        }
    }
}