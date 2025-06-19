/*
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
                jogo.AtualizarNome();
                using var conn = Conectar();
                await conn.OpenAsync();

                if (!await _dbSchema.TabelaExiste(conn))
                {
                    await _dbSchema.CriarTabelaAsync(conn);
                }

                string interessadosStr = string.Join(",", jogo.Interessados);

                var cmd = new MySqlCommand(@"
                    INSERT INTO jogos (
                        Id, Nome, AbreviacaoTimeA, AbreviacaoTimeB, Aberto, Data, Hora, 
                        CampoId, LocalDisplay, TipoDeCampoDisplay, Interessados, QuantidadeDeJogadores)
                    VALUES (
                        @id, @nome, @abreviacaoTimeA, @abreviacaoTimeB, @aberto, @data, @hora, 
                        @campoId, @localDisplay, @tipoDeCampoDisplay, @interessados, @quantidadeDeJogadores)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        AbreviacaoTimeA = @abreviacaoTimeA,
                        AbreviacaoTimeB = @abreviacaoTimeB,
                        Aberto = @aberto,
                        Data = @data,
                        Hora = @hora,
                        CampoId = @campoId,
                        LocalDisplay = @localDisplay,
                        TipoDeCampoDisplay = @tipoDeCampoDisplay,
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

        //Carrega jogos (abertos)
        public async Task<List<Jogo>> CarregarJogosAbertos()
        {
            var jogosAbertos = new List<Jogo>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM jogos WHERE Aberto = 1 AND Deletado = 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    jogosAbertos.Add(LeitorDeJogos.LerJogo(reader));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro MySQL ao carregar jogos abertos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral ao carregar jogos abertos: {ex.Message}");
            }

            return jogosAbertos;
        }

        public override async Task<Jogo?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM jogos WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return LeitorDeJogos.LerJogo(reader);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Jogo>> GetJogosByDataHora(DateOnly data, TimeOnly hora)
        {
            var jogosNoHorario = new List<Jogo>();
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM jogos WHERE Data = @data AND Hora = @hora AND Deletado = 0", conn);
                cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@hora", hora.ToString("HH:mm:ss")); 

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    jogosNoHorario.Add(LeitorDeJogos.LerJogo(reader));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro MySQL ao obter jogos por data e hora: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao obter jogos por data e hora: {ex.Message}");
            }
            return jogosNoHorario;
        }
    }
}
*/