using System;
using System.Collections.Generic;
using MySqlConnector;
using ContaApp;
using ContaUsuarioApp;
using ContaJogadorApp;

namespace PersistenciaApp
{
    public static class PersistenciaDeJogador
    {
        private const string MariaDB = "Server=localhost;" +
                                       "Port=18046;" +
                                       "Database=furapp;" +
                                       "User ID=root;" +
                                       "Password=qhG171U4;" +
                                       "Connection Timeout=30;";

        public static void InicializarBancoJogador()
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS jogadores (
                        id CHAR(36) PRIMARY KEY,
                        Nome VARCHAR(100) NOT NULL UNIQUE,
                        SenhaHash TEXT NOT NULL,
                        Idade INT NOT NULL,
                        TipoConta VARCHAR(50) NOT NULL,
                        Posicao VARCHAR(50),
                        Saldo DECIMAL(18,2),
                        Time VARCHAR(100),
                        Gols INT DEFAULT 0,
                        Assistencias INT DEFAULT 0,
                        Interesses TEXT,
                        Amistosos TEXT
                    );";
                
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao inicializar o banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        public static bool SalvarJogador(Conta_Jogador jogador)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    INSERT INTO jogadores 
                    (Id, Nome, SenhaHash, Idade, TipoConta, Posicao, Saldo, Time, Gols, Assistencias, Interesses, Amistosos)
                    VALUES 
                    (@id, @nome, @senhaHash, @idade, @tipoConta, @posicao, @saldo, @time, @gols, @assistencias, @interesses, @amistosos)", conn);

                cmd.Parameters.AddWithValue("@id", jogador.Id.ToString());
                cmd.Parameters.AddWithValue("@nome", jogador.Nome);
                cmd.Parameters.AddWithValue("@senhaHash", jogador.SenhaHash);
                cmd.Parameters.AddWithValue("@idade", jogador.Idade);
                cmd.Parameters.AddWithValue("@tipoConta", jogador.GetType().Name);
                cmd.Parameters.AddWithValue("@posicao", jogador.Posicao);
                cmd.Parameters.AddWithValue("@saldo", jogador.Saldo);
                cmd.Parameters.AddWithValue("@time", jogador.Time);
                cmd.Parameters.AddWithValue("@gols", jogador.Gols);
                cmd.Parameters.AddWithValue("@assistencias", jogador.Assistencias);
                cmd.Parameters.AddWithValue("@interesses", jogador.Interesses);
                cmd.Parameters.AddWithValue("@amistosos", jogador.Amistosos);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao salvar jogador: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return false;
            }
        }

        public static List<Conta_Jogador> CarregarJogadores()
        {
            var jogadores = new List<Conta_Jogador>();

            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM jogadores", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Guid id;
                    if (!Guid.TryParse(reader.GetString("Id"), out id))
                    {
                        Console.WriteLine("Id inválido");
                        continue;
                    }

                    var jogador = new Conta_Jogador(
                        nome: reader.GetString("Nome"),
                        senha: reader.GetString("SenhaHash"),
                        idade: reader.GetInt32("Idade"),
                        posicao: reader.GetString("Posicao"),
                        saldo: reader.GetFloat("Saldo"),
                        interesses: !reader.IsDBNull(reader.GetOrdinal("Interesses")) ? reader.GetString("Interesses") : "",
                        amistosos: !reader.IsDBNull(reader.GetOrdinal("Amistosos")) ? reader.GetString("Amistosos") : "",
                        time: !reader.IsDBNull(reader.GetOrdinal("Time")) ? reader.GetString("Time") : "",
                        gols: reader.GetInt32("Gols"),
                        assistencias: reader.GetInt32("Assistencias")
                    );

                    typeof(Conta).GetProperty("Id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(jogador, id);

                    jogadores.Add(jogador);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao carregar jogadores: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            return jogadores;
        }

        public static Conta_Jogador ObterJogadorPorId(Guid id)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM jogadores WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id.ToString());

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var jogador = new Conta_Jogador(nome: reader.GetString("Nome"),
                        senha: reader.GetString("SenhaHash"),
                        idade: reader.GetInt32("Idade"),
                        posicao: reader.GetString("Posicao"),
                        saldo: reader.GetFloat("Saldo"),
                        interesses: !reader.IsDBNull(reader.GetOrdinal("Interesses")) ? reader.GetString("Interesses") : "",
                        amistosos: !reader.IsDBNull(reader.GetOrdinal("Amistosos")) ? reader.GetString("Amistosos") : "",
                        time: !reader.IsDBNull(reader.GetOrdinal("Time")) ? reader.GetString("Time") : "",
                        gols: reader.GetInt32("Gols"),
                        assistencias: reader.GetInt32("Assistencias")
                    ); 

                    typeof(Conta).GetProperty("Id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(jogador, id);
                    return jogador;
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