using System;
using System.Collections.Generic;
using MySqlConnector;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;

namespace PersistenciaApp
{
    public static class PersistenciaDeTecnico
    {
        private const string MariaDB = "Server=localhost;" +
                                       "Port=18046;" +
                                       "Database=furapp;" +
                                       "User ID=root;" +
                                       "Password=qhG171U4;" +
                                       "Connection Timeout=30;";
        //Cria tabela tecnico
        public static void InicializarBancoTecnico()
        {
            try 
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS tecnicos (
                        Id CHAR(36) PRIMARY KEY,
                        Nome VARCHAR(100) NOT NULL UNIQUE,
                        SenhaHash TEXT NOT NULL,
                        Idade INT NOT NULL,
                        Saldo DECIMAL(18,2),
                        Interesses TEXT,
                        Amistosos TEXT,
                        Time VARCHAR(100),
                        Deletado BIT DEFAULT 0,
                        DataDelecao DATETIME NULL,
                        QuemDeletou VARCHAR(100) NULL,
                        TornouSeJogador BOOLEAN DEFAULT TRUE,
                        TornouSeTecnico BOOLEAN DEFAULT TRUE
                    );";
                
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        //Salvar tecnico
        public static bool SalvarTecnico(Conta_Tecnico tecnico)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    INSERT INTO tecnicos (
                        Id, Nome, SenhaHash, Idade, Saldo, Interesses, Amistosos, Time
                    ) VALUES (
                        @id, @nome, @senhaHash, @idade, @saldo, @interesses, @amistosos, @time
                    )
                    ON DUPLICATE KEY UPDATE
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Saldo = @saldo,
                        Interesses = @interesses,
                        Amistosos = @amistosos,
                        Time = @time", conn);
                
                cmd.Parameters.AddWithValue("@id", tecnico.Id.ToString());
                cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
                cmd.Parameters.AddWithValue("@senhaHash", tecnico.SenhaHash);
                cmd.Parameters.AddWithValue("@idade", tecnico.Idade);
                cmd.Parameters.AddWithValue("@saldo", tecnico.Saldo);
                cmd.Parameters.AddWithValue("@interesses", tecnico.Interesses);
                cmd.Parameters.AddWithValue("@amistosos", tecnico.Amistosos);
                cmd.Parameters.AddWithValue("@time", tecnico.Time);
                cmd.Parameters.AddWithValue("@tornouSeJogador", tecnico.TornouSeJogador);
                cmd.Parameters.AddWithValue("@tornouSeTecnico", tecnico.TornouSeTecnico);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return false;
            }
        }

        //Carregar Tecnico
        public static List<Conta_Tecnico> CarregarTecnicos()
        {
            var tecnicos = new List<Conta_Tecnico>();

            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM tecnicos", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Guid id;
                    if (!Guid.TryParse(reader.GetString("Id"), out id))
                    {
                        Console.WriteLine("Id inválido");
                        continue;
                    }

                    var tecnico = new Conta_Tecnico(
                        nome : reader.GetString("Nome"),
                        senha : reader.GetString("SenhaHash"),
                        idade : reader.GetInt32("Idade"),
                        saldo : reader.GetFloat("Saldo"),
                        interesses : reader.IsDBNull(reader.GetOrdinal("Interesses")) ? null : reader.GetString("Interesses"),
                        amistosos : reader.IsDBNull(reader.GetOrdinal("Amistosos")) ? null : reader.GetString("Amistosos"),
                        time : reader.IsDBNull(reader.GetOrdinal("Time")) ? null : reader.GetString("Time")
                    );

                    typeof(Conta).GetProperty("Id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(tecnico, id);

                    tecnicos.Add(tecnico);
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

            return tecnicos;
        }

        //Procurar por ID
        public static Conta_Tecnico ObterTecnicoPorId(Guid id)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM tecnicos WHERE Id = @id AND Deletado = 0", conn);
                cmd.Parameters.AddWithValue("@id", id.ToString());

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var tecnico = new Conta_Tecnico(
                        nome : reader.GetString("Nome"),
                        senha : reader.GetString("SenhaHash"),
                        idade : reader.GetInt32("Idade"),
                        saldo : reader.GetFloat("Saldo"),
                        interesses : reader.IsDBNull(reader.GetOrdinal("Interesses")) ? null : reader.GetString("Interesses"),
                        amistosos : reader.IsDBNull(reader.GetOrdinal("Amistosos")) ? null : reader.GetString("Amistosos"),
                        time : reader.IsDBNull(reader.GetOrdinal("Time")) ? null : reader.GetString("Time")
                    );

                    typeof(Conta).GetProperty("Id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(tecnico, id);
                    return tecnico;
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

        //Atualizar tecnico
        public static bool AtualizarTecnico(Conta_Tecnico tecnico)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    UPDATE tecnicos
                    SET
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Saldo = @saldo,
                        Interesses = @interesses,
                        Amistosos = @amistosos,
                        Time = @time
                    WHERE
                        Id = @id", conn);
                    
                cmd.Parameters.AddWithValue("@id", tecnico.Id.ToString());
                cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
                cmd.Parameters.AddWithValue("@senhaHash", tecnico.SenhaHash);
                cmd.Parameters.AddWithValue("@idade", tecnico.Idade);
                cmd.Parameters.AddWithValue("@saldo", tecnico.Saldo);
                cmd.Parameters.AddWithValue("@interesses", tecnico.Interesses);
                cmd.Parameters.AddWithValue("@amistosos", tecnico.Amistosos);
                cmd.Parameters.AddWithValue("tornouSeJogador", tecnico.TornouSeJogador);
                cmd.Parameters.AddWithValue("tornouSeTecnico", tecnico.TornouSeTecnico);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Deletar
        public static bool DeletarJogador(Guid idtecnico, string quemDeletou)
        {
            try 
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    UPDATE tecnicos
                    SET
                        Deletado = 1,
                        DataDelecao = @dataDelecao,
                        QuemDeletou = @quemDeletou
                    WHERE
                        Id = @id", conn);

                cmd.Parameters.AddWithValue("@id", idtecnico.ToString());
                cmd.Parameters.AddWithValue("@dataDelecao", DateTime.Now);
                cmd.Parameters.AddWithValue("@quemDeletou", quemDeletou);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                if (linhasAfetadas > 0)
                {
                    Console.WriteLine($"{idtecnico} marcado como deletado em {DateTime.Now} por {quemDeletou}");
                    return true;
                }

                return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Restaurar Tecnico
        public static bool RestaurarTecnico(Guid idtecnico)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    UPDATE tecnicos
                    SET
                        Deletado = 0,
                        DataDelecao = NULL,
                        QuemDeletou = NULL
                    WHERE
                        Id = @id", conn);
                
                cmd.Parameters.AddWithValue("@id", idtecnico.ToString());

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}