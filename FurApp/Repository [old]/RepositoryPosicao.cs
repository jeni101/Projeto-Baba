/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.PosicaoApp;
using Interfaces.IRepository;
using Repository.Database.Posicoes;
using Utils.Pelase.Argumentos.Posicoes;
using Utils.Pelase.Leitor.Posicoes;

namespace Repository.PersistenciaApp.Posicoes
{
    public class RepositoryPosicao : ARepository<Posicao>
    {
        private readonly DatabasePosicoes _dbSchema = new DatabasePosicoes();
        public RepositoryPosicao() : base() { }

        public async Task<bool> SalvarPosicao(Posicao posicao)
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
                    INSERT INTO posicoes (
                        Id, Nome, Categoria, Abreviacao)
                    VALUES (
                        @id, @nome, @categoria, @abreviacao)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome, 
                        Categoria = @categoria,
                        Abreviacao = @abreviacao", conn);

                ArgumentosPosicao.PreencherParametros(cmd, posicao);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Posicao>> CarregarTodas()
        {
            var posicoesLista = new List<Posicao>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM posicoes", conn);

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    posicoesLista.Add(LeitorDePosicao.LerPosicao(reader));
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

            return posicoesLista;
        }
        
        //Pegar por nome
        public override async Task<Posicao?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM posicoes WHERE Nome = @nome", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? LeitorDePosicao.LerPosicao(reader)
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
*/