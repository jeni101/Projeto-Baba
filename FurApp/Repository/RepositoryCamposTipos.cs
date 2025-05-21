using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.CamposApp.Tipo;
using Utils.Pelase.Leitor.Campos;
using Utils.Pelase.Argumentos.Campos;
using Repository.Database.Campos;
using Utils.Pelase.Argumentos.TipoCampos;
using Utils.Pelase.Leitor.TipoCampos;

namespace Repository.PersistenciaApp.CamposTipo
{
    public class RepositoryCamposTipos : ARepository<TipoDeCampo>
    {
        private readonly DatabaseCampos _dbSchema = new DatabaseCampos();
        public RepositoryCamposTipos() : base() { }

        //Salvar Tipo
        public async Task<bool> SalvarTipo(TipoDeCampo campoTipo)
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
                    INSERT INTO campos_tipo (
                        Id, Tipo, CapacidadePadrao)
                    VALUES (
                        @id, @tipo, @capacidadePadrao)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        Tipo = @tipo,
                        CapacidadePadrao = @capacidadePadrao", conn);

                ArgumentosTipoCampos.PreencherParametros(cmd, campoTipo);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar Tipo
        public async Task<List<TipoDeCampo>> CarregarTodos()
        {
            var camposTipoLista = new List<TipoDeCampo>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM campos_tipo WHERE deletado = 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    camposTipoLista.Add(LeitorDeTipoCampos.LerTipoCampos(reader));
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

            return camposTipoLista;
        }

        public override async Task<TipoDeCampo?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM campos_tipo WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? LeitorDeTipoCampos.LerTipoCampos(reader)
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