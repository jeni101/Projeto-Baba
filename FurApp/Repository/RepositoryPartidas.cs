using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.JogosApp.Partidas;
using Interfaces.IRepository;
using System.Data;
using Repository.Database.Partidas;
using Utils.Pelase.Argumentos.Partidas;
using Utils.Pelase.Leitor.Partidas;

namespace Repository.PersistenciaApp.Partidas
{
    public class RepositoryPartidas : ARepository<Partida>
    {
        private readonly DatabasePartidas _dbSchema = new DatabasePartidas();
        public RepositoryPartidas() : base() { }

        //Salvar partida
        public async Task<bool> SalvarPartidas(Partida partida)
        {
            try
            {
                partida.AtualizarNomePartida();
                using var conn = Conectar();
                await conn.OpenAsync();

                if (!await _dbSchema.TabelaExiste(conn))
                {
                    await _dbSchema.CriarTabelaAsync(conn);
                }

                var cmd = new MySqlCommand(@"
                    INSERT INTO partidas (
                        Id, JogoId, Nome, TimeA, TimeB, GolsA, GolsB, Data, Hora, Local, Status
                    ) VALUES (
                        @id, @jogoId, @nome, @TimeA, @TimeB, @golsA, @golsB, @data, @hora, @local, @status
                    )
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        TimeA = @TimeA,
                        TimeB = @TimeB,
                        GolsA = @golsA,
                        GolsB = @golsB,
                        Data = @data,
                        Hora = @hora,
                        Local = @local,
                        Status = @status", conn);

                cmd.Parameters.AddWithValue("@id", partida.Id.ToString());
                cmd.Parameters.AddWithValue("@jogoId", partida.JogoId.ToString());
                cmd.Parameters.AddWithValue("@nome", partida.Nome); 
                cmd.Parameters.AddWithValue("@TimeA", partida.TimeA);
                cmd.Parameters.AddWithValue("@TimeB", partida.TimeB);
                cmd.Parameters.AddWithValue("@golsA", partida.Placar.GolsA);
                cmd.Parameters.AddWithValue("@golsB", partida.Placar.GolsB);
                cmd.Parameters.AddWithValue("@data", partida.Data.ToDateTime(TimeOnly.MinValue)); 
                cmd.Parameters.AddWithValue("@hora", partida.Hora.ToTimeSpan());
                cmd.Parameters.AddWithValue("@local", partida.Local);
                cmd.Parameters.AddWithValue("@status", partida.Status.ToString());

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar partida
        public async Task<List<Partida>> CarregarTodos()
        {
            var partidasLista = new List<Partida>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM partidas WHERE deletado = 0");
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    partidasLista.Add(LeitorDePartidas.LerPartida(reader));
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

            return partidasLista;
        }

        //Deletar partida
        public async Task<bool> DeletarPartida(Guid id)
        {
            using var conn = Conectar();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                UPDATE partidas
                SET Deletado = 1,
                    DataDelecao = NOW()
                WHERE Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public override async Task<Partida?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM partidas WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return LeitorDePartidas.LerPartida(reader);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}