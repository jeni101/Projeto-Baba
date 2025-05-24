using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.TimesApp;
using Utils.Pelase.Leitor.Times;
using Utils.Pelase.Argumentos.Times;
using Repository.Database.Times;

namespace Repository.PersistenciaApp.Times
{
    public class RepositoryTimes : ARepository<Time>
    {
        private readonly DatabaseTimes _dbSchema = new DatabaseTimes();
        public RepositoryTimes() : base() { }

        //Salvar time
        public async Task<bool> SalvarTecnico(Time time)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                if (!await _dbSchema.TabelaExiste(conn))
                {
                    await _dbSchema.CriarTabelaAsync(conn);
                }

                var cmd = new MySqlCommand(@"
                    INSERT INTO times (
                        Id, Nome, Abreviacao, Tecnico, Jogadores, Jogos, Partidas
                    ) VALUES (
                        @id, @nome, @abreviacao, @tecnico, @jogadores, @jogos, @partidas
                    )
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        Abreviacao = @abreviacao,
                        Tecnico = @tecnico,
                        Jogadores = @jogadores,
                        Jogos = @jogos,
                        Partidas = @partidas", conn);

                ArgumentosTime.PreencherParametros(cmd, time);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar time
        public async Task<List<Time>> CarregarTodos()
        {
            var timesLista = new List<Time>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM times WHERE deletado = 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    timesLista.Add(LeitorDeTimes.LerTime(reader));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return timesLista;
        }

        //Deletar Time
        public async Task<bool> Deletar(Guid id, string quemDeletou)
        {
            using var conn = Conectar();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                UPDATE times
                SET Deletado = 1,
                    DataDelecao = NOW(),
                    QuemDeletou = @quemDeletou
                WHERE Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id.ToString());
            cmd.Parameters.AddWithValue("@quemDeletou", quemDeletou);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        //Pegar pelo nome
        public override async Task<Time?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM times WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? LeitorDeTimes.LerTime(reader)
                    : null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}