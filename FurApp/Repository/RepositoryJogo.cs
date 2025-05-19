using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.JogosApp;
using Interfaces.IRepository;
using System.Data;
using Repository.Database.Jogos;
using Utils.Pelase.Argumentos.Jogos;
using Utils.Pelase.Leitor.Jogos;

namespace Repository.PersistenciaApp.Jogos
{
    public class RepositoryJogo : ARepository<Jogo>
    {
        private readonly DatabaseJogos _dbSchema = new DatabaseJogos();
        public RepositoryJogo() : base() { }

        //Salvar jogo
        public async Task<bool> SalvarJogos(Jogo jogo)
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
                    INSERT INTO jogos (
                        Id, Data, Hora, Local, TipoDeCampo, Interessados, QuantidadeDeJogadores)
                    VALUES (
                        @id, @data, @hora, @local, @tipoDeCampo, @interessados, @quantidadeDeJogadores)
                    ON DUPLICATE KEY UPDATE
                        Data = @data,
                        Hora = @hora,
                        Local = @local,
                        TipoDeCampo = @tipoDeCampo,
                        Interessados = @interessados,
                        QuantidadeDeJogadores = @quantidadeDeJogadores", conn);

                ArgumentosJogos.PreencherParametros(cmd, jogo);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar jogo
        public async Task<List<Jogo>> CarregarTodos()
        {
            var jogosLista = new List<Jogo>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM jogos WHERE deletado = 0");
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    jogosLista.Add(LeitorDeJogos.LerJogo(reader));
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

            return jogosLista;
        }

        //Deletar jogo
        public async Task<bool> DeletarJogo(Guid id)
        {
            using var conn = Conectar();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                UPDATE jogos
                SET Deletado = 1,
                    DataDelecao = NOW()
                WHERE Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            return await cmd.ExecuteNonQueryAsync() > 0;
        }
    }
}