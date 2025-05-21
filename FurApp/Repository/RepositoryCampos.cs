using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.CamposApp;
using Utils.Pelase.Leitor.Campos;
using Utils.Pelase.Argumentos.Campos;
using Repository.Database.Campos;
using System.Runtime.InteropServices;

namespace Repository.PersistenciaApp.Campos
{
    public class RepositoryCampos : ARepository<Campo>
    {
        private readonly DatabaseCampos _dbSchema = new DatabaseCampos();
        public RepositoryCampos() : base() { }

        //Salvar campo
        public async Task<bool> SalvarCampo(Campo campo)
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
                    INSERT INTO campos (
                        Id, Nome, Local, Capacidade, TipoDeCampo, Deletado, DataDelecao, QuemDeletou)
                    VALUES (
                        @id, @nome, @local, @capacidade, @tipoDeCampo, @deletado, @dataDelecao, @quemDeletou)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        Local = @local,
                        Capacidade = @capacidade,
                        TipoDeCampo = @tipoDeCampo", conn);

                ArgumentosCampos.PreencherParametros(cmd, campo);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar jogador
        public async Task<List<Campo>> CarregarTodos()
        {
            var camposLista = new List<Campo>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM campos WHERE deletado = 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    camposLista.Add(LeitorDeCampos.LerCampos(reader));
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

            return camposLista;
        }

        //Deletar Campo
        public async Task<bool> DeletarCampo(Guid id, string quemDeletou)
        {
            using var conn = Conectar();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                UPDATE campos
                SET Deletado = 1,
                    DataDelecao = NOW(),
                    QuemDeletou = @quemDeletou
                WHERE Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id.ToString());
            cmd.Parameters.AddWithValue("@quemDeletou", quemDeletou);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public override async Task<Campo?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM campos WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? LeitorDeCampos.LerCampos(reader)
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

        public async Task<List<Campo>> FiltrarCampo(string nome = "", string tipo = "")
        {
            var camposFiltrados = new List<Campo>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                var cmd = new MySqlCommand(@"
                    SELECT * FROM campos
                    WHERE (Nome LIKE @Nome OR @Nome = '')
                    AND (TipoDeCampo LIKE @Tipo OR @Tipo = '')
                    AND Deletado = 0", conn);

                cmd.Parameters.AddWithValue("@Nome", $"%{nome}%");
                cmd.Parameters.AddWithValue("@Tipo", $"%{tipo}%");

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    camposFiltrados.Add(LeitorDeCampos.LerCampos(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return camposFiltrados;
        }
    }
}