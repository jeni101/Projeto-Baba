using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
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
                        Time VARCHAR(100)
                    );";
                
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

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

        public static Conta_Tecnico ObterTecnicoPorId(Guid id)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM tecnicos WHERE Id = @id", conn);
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
    }
}