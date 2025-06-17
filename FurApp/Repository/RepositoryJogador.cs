using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.ContaApp.Usuario.Jogador;
using Utils.Pelase.Leitor.Jogador;
using Utils.Pelase.Argumentos.Jogador;
using Repository.Database.Jogadores;

namespace Repository.PersistenciaApp.Jogador
{
    public class RepositoryJogador : ARepository<Conta_Jogador>
    {
        private readonly DatabaseJogadores _dbSchema = new DatabaseJogadores();
        public RepositoryJogador(string connStr) : base(connStr) { }

        //Salvar jogador
        public async Task<bool> SalvarJogador(Conta_Jogador jogador)
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
                    INSERT INTO jogadores (
                        Id, Nome, SenhaHash, Idade, Posicao, Time, Interesses)
                    VALUES (
                        @id, @nome, @senhaHash, @idade, @posicao, @time, @interesses)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Posicao = @posicao,
                        Time = @time,
                        Interesses = @interesses", conn);

                ArgumentosJogador.PreencherParametros(cmd, jogador);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar jogador
        public async Task<List<Conta_Jogador>> CarregarTodos()
        {
            var jogadoresLista = new List<Conta_Jogador>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM jogadores WHERE deletado = 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    jogadoresLista.Add(await LeitorDeJogador.LerJogador(reader));
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

            return jogadoresLista;
        }

        //Deletar Jogador
        public async Task<bool> DeletarJogador(Guid id, string quemDeletou)
        {
            using var conn = Conectar();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                UPDATE jogadores
                SET Deletado = 1,
                    DataDelecao = NOW(),
                    QuemDeletou = @quemDeletou
                WHERE Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id.ToString());
            cmd.Parameters.AddWithValue("@quemDeletou", quemDeletou);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public override async Task<Conta_Jogador?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM jogadores WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? await LeitorDeJogador.LerJogador(reader)
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

        public async Task<Conta_Jogador?> GetById(Guid id)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand(
                    "SELECT * FROM jogadores WHERE Id = @id AND Deletado = 0 LIMIT 1",
                    conn
                );
                cmd.Parameters.AddWithValue("@id", id.ToString());

                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return await LeitorDeJogador.LerJogador(reader);
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
            return null;
        }

        public async Task<List<Conta_Jogador>> GetByIds(List<Guid> ids)
        {
            var jogadores = new List<Conta_Jogador>();
            if (ids == null || !ids.Any())
            {
                return jogadores;
            }

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                var paramNames = ids.Select((id, index) => $"@id{index}").ToList();
                var inClause = string.Join(",", paramNames);

                using var cmd = new MySqlCommand(
                    $"SELECT * FROM jogadores WHERE Id IN ({inClause}) AND Deletado = 0",
                    conn
                );

                for (int i = 0; i < ids.Count; i++)
                {
                    cmd.Parameters.AddWithValue(paramNames[i], ids[i].ToString());
                }

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    jogadores.Add(await LeitorDeJogador.LerJogador(reader));
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
            return jogadores;
        }
    }
}