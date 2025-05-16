using System;
using System.Collections.Generic;
using MySqlConnector;
using TimesApp;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Tecnico;

namespace PersistenciaApp
{
    public static class PersistenciaDeTimes
    {
        private const string MariaDB =  "Server=localhost;" +
                                        "Port=18046;" +
                                        "Database=furapp;" +
                                        "User ID=root;" +
                                        "Password=qhG171U4;" +
                                        "Connection Timeout=30;";
        
        public static void InicializarBancoTimes()
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS time (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        NomeTime VARCHAR(100) NOT NULL UNIQUE,
                        TecnicoId CHAR(36) NOT NULL,
                        FOREIGN KEY (TecnicoId) REFERENCES tecnicos(Id)
                    );";
                
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //LUIS VERIFICA O OUTPUT
            }
        }
        public static bool SalvarTime(Times time)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    INSERT INTO time (NomeTime, TecnicoId)
                    VALUES (@nomeTime, @tecnicoId)", conn);

                cmd.Parameters.AddWithValue("@nomeTime", time.NomeTime);
                cmd.Parameters.AddWithValue("@tecnicoId", time.Criador.Id.ToString());

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //LUIS VERIFICA O OUTPUT
                return false;
            }
        }
        public static List<Times> CarregarTimes()
        {
            var times = new List<Times>();

            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();
                
                var cmd = new MySqlCommand("SELECT * FROM times", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.IsDBNull(reader.GetOrdinal("Nometime")))
                    {
                        Console.WriteLine("Nome do time não pode ser nulo");
                        continue;
                    }

                    string nomeTime = reader.GetString("NomeTime");

                    if (reader.IsDBNull(reader.GetOrdinal("TecnicoId")))
                    {
                        Console.WriteLine($"Tecnico não definido para o time {nomeTime}");
                        continue;
                    }

                    string tecnicoIdStr = reader.GetString("TecnicoId");

                    if (!Guid.TryParse(tecnicoIdStr, out Guid tecnicoId))
                    {
                        Console.WriteLine($"Id de técnico inválido para time {nomeTime}");
                        continue;
                    }

                    var tecnico = PersistenciaDeTecnico.ObterTecnicoPorId(tecnicoId);
                    if (tecnico == null)
                    {
                        Console.WriteLine($"Técnico {tecnicoId} não encontrado para time {nomeTime}");
                        continue;
                    }

                    var time = new Times(nomeTime, tecnico);
                    times.Add(time);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //LUIS VERIFICA O OUTPUT
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //LUIS VERIFICA O OUTPUT
            }

            return times;
        }   
    }
}