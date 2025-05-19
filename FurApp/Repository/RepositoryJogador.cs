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
        public RepositoryJogador() : base() { }

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
                        Id, Nome, SenhaHash, Idade, Posicao, Saldo, Time, Gols, Assistencias, Interesses, Amistosos)
                    VALUES (
                        @id, @nome, @senhaHash, @idade, @posicao, @saldo, @time, @gols, @assistencias, @interesses, @amistosos)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Posicao = @posicao,
                        Saldo = @saldo,
                        Time = @time, 
                        Gols = @gols,
                        Assistencias = @assistencias,
                        Interesses = @interesses,
                        Amistosos = @amistosos", conn);

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
                    jogadoresLista.Add(LeitorDeJogador.LerJogador(reader));
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
    }
}