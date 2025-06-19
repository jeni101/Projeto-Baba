/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Utils.Pelase.Leitor.Campos;
using Utils.Pelase.Argumentos.Campos;
using Repository.Database.Campos;
using Repository.PersistenciaApp.CamposTipo;

namespace Repository.PersistenciaApp.Campos
{
    public class RepositoryCampos : ARepository<Campo>
    {
        private readonly DatabaseCampos _dbSchema = new DatabaseCampos();
        private readonly RepositoryCamposTipos _repoTipoCampo;
        public RepositoryCampos() : base()
        {
            _repoTipoCampo = new RepositoryCamposTipos();
        }

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
                        Id, Nome, Local, Capacidade, TipoDeCampoId, Deletado, DataDelecao, QuemDeletou)
                    VALUES (
                        @id, @nome, @local, @capacidade, @tipoDeCampoId, @deletado, @dataDelecao, @quemDeletou)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        Local = @local,
                        Capacidade = @capacidade,
                        TipoDeCampoId = @tipoDeCampoId
                        Deletado = @deletado,       
                        DataDelecao = @dataDelecao,
                        QuemDeletou = @quemDeletou;", conn);

                if (campo.TipoDeCampo == null)
                {
                    throw new ArgumentNullException(nameof(campo.TipoDeCampo), " ! O tipo não pode ser nulo ao salvar ! ");
                }

                ArgumentosCampos.PreencherParametros(cmd, campo);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar campo
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
                    camposLista.Add(await LeitorDeCampos.LerCampos(reader, _repoTipoCampo));
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Pegar pelo nome
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
                    ? await LeitorDeCampos.LerCampos(reader, _repoTipoCampo)
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

        //Filtragem
        public async Task<List<Campo>> FiltrarCampo(string nome = "", string tipo = "")
        {
            var camposFiltrados = new List<Campo>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                var cmd = new MySqlCommand(@"
                    SELECT c.* FROM campos c
                    JOIN campos_tipo tc ON c.TipoDeCampoId
                    WHERE (c.Nome LIKE @Nome OR @Nome = '')
                    AND (tc.Tipo LIKE @Tipo OR @Tipo = '')
                    AND c.Deletado = 0", conn);

                cmd.Parameters.AddWithValue("@Nome", string.IsNullOrWhiteSpace(nome) ? "%%" : $"%{nome}%");
                cmd.Parameters.AddWithValue("@Tipo", string.IsNullOrWhiteSpace(tipo) ? "%%" : $"%{tipo}%");


                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    camposFiltrados.Add(await LeitorDeCampos.LerCampos(reader, _repoTipoCampo));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return camposFiltrados;
        }

        //Disponibilidade
        public async Task<bool> VerificarDisponibilidade(Guid campoId, DateOnly data, TimeOnly hora)
        {
            const int intervaloMinutos = 100;

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                var cmd = new MySqlCommand(@"
                    SELECT COUNT(*) FROM jogos
                    WHERE CampoId = @campoId
                    AND Data = @data
                    AND ABS(TIMESTAMPDIFF(MINUTE, Hora, @hora)) < @intervalo
                    AND Deletado = 0", conn);

                cmd.Parameters.AddWithValue("@campoId", campoId.ToString());
                cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@hora", hora.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@intervalo", intervaloMinutos);

                var count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return count == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
*/