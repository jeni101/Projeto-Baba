using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.ContaApp.Usuario.Tecnico;
using Utils.Pelase.Leitor.Tecnico;
using Utils.Pelase.Argumentos.Tecnico;
using Repository.Database.Tecnicos;

namespace Repository.PersistenciaApp.Tecnico
{
    public class RepositoryTecnico : ARepository<Conta_Tecnico>
    {
        private readonly DatabaseTecnicos _dbSchema = new DatabaseTecnicos();
        public RepositoryTecnico() : base() { }

        //Salvar tecnico
        public async Task<bool> SalvarTecnico(Conta_Tecnico tecnico)
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
                    INSERT INTO tecnicos (
                        Id, Nome, SenhaHash, Idade, Interesses, Time
                    ) VALUES (
                        @id, @nome, @senhaHash, @idade, @interesses, @time
                    )
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Interesses = @interesses,
                        Time = @time", conn);

                ArgumentosTecnico.PreencherParametros(cmd, tecnico);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Carregar tecnico
        public async Task<List<Conta_Tecnico>> CarregarTodos()
        {
            var tecnicosLista = new List<Conta_Tecnico>();

            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM tecnicos WHERE deletado = 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    tecnicosLista.Add(LeitorDeTecnico.LerTecnico(reader));
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

            return tecnicosLista;
        }

        //Deletar Tecnico
        public async Task<bool> Deletar(Guid id, string quemDeletou)
        {
            using var conn = Conectar();
            await conn.OpenAsync();

            var cmd = new MySqlCommand(@"
                UPDATE tecnicos
                SET Deletado = 1,
                    DataDelecao = NOW(),
                    QuemDeletou = @quemDeletou
                WHERE Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id.ToString());
            cmd.Parameters.AddWithValue("@quemDeletou", quemDeletou);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        //Pegar pelo nome
        public override async Task<Conta_Tecnico?> GetByNameAsync(string nome)
        {
            try
            {
                using var conn = Conectar();
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM tecnicos WHERE Nome = @nome AND Deletado = 0 LIMIT 1", conn);

                cmd.Parameters.AddWithValue("@nome", nome);

                using var reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? LeitorDeTecnico.LerTecnico(reader)
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