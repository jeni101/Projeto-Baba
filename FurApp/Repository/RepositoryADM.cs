using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.ContaApp.ADM;
using Utils.Pelase.Argumentos.ADM;
using Utils.Pelase.Leitor.ADM;
using Repository.Database.ADM;

namespace Repository.PersistenciaApp.ADM
{
    public class RepositoryADM : ARepository<Conta_Administrador>
    {
        private readonly DatabaseADM _dbSchema = new DatabaseADM();
        public RepositoryADM() : base() { }

        //Salvar ADM
        public async Task<bool> SalvarADM(Conta_Administrador adm)
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
                    INSERT INTO adm (
                        Id, Nome, SenhaHash, Idade)
                    VALUES (
                        @id, @nome, @senhaHash, @idade)
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade", conn);

                ArgumentosADM.PreencherParametros(cmd, adm);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar adm
        public async Task<List<Conta_Administrador>> CarregarTodos()
        {
            var admLista = new List<Conta_Administrador>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM adm", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    admLista.Add(LeitorDeADM.LerADM(reader));
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

            return admLista;
        }

        public override async Task<Conta_Administrador?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM adm WHERE Nome = @nome LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? LeitorDeADM.LerADM(reader)
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