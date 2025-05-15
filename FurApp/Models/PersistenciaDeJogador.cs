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
        //conexão
        private const string MariaDB = "Server=localhost;" +
                                       "Port=18046;" +
                                       "Database=furapp;" +
                                       "User ID=root;" +
                                       "Password=qhG171U4;" +
                                       "Connection Timeout=30;";
        //Cria tabela de jogador
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
                        Amistosos TEXT,
                        Detetado BIT DEFAULT 0,
                        DataDelecao DELETETIME NULL,
                        QuemDeletou VARCHAR(100) NULL,
                        TornouSeJogador BOOLEAN DEFAULT TRUE,
                        TornouSeTecnico BOOLEAN DEFAULT TURE
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

        //Salvar jogador
        public static bool SalvarJogador(Conta_Jogador jogador)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    INSERT INTO jogadores (
                        Id, Nome, SenhaHash, Idade, TipoConta, Posicao, Saldo, Time, Gols, Assistencias, Interesses, Amistosos)
                    VALUES (
                        @id, @nome, @senhaHash, @idade, @tipoConta, @posicao, @saldo, @time, @gols, @assistencias, @interesses, @amistosos
                    )
                    ON DUBPLICATE KEY UPDATE
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Saldo = @saldo,
                        Time = @time,
                        Gols = @gols,
                        Assistencias = @assistencias,
                        Interesses = @amistosos,
                        Amistosos = @amistosos"
                    , conn);

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
                cmd.Parameters.AddWithValue("@tornouSeJogador", jogador.TornouSeJogador);
                cmd.Parameters.AddWithValue("@tournouSeTecnico", jogador.TornouSeTecnico);

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

        //Carregar jogador
        public static List<Conta_Jogador> CarregarJogadores()
        {
            var jogadores = new List<Conta_Jogador>();

            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM jogadores WHERE Deletado = 0", conn);
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

        //Procurar por ID
        public static Conta_Jogador ObterJogadorPorId(Guid id)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand("SELECT * FROM jogadores WHERE Id = @id AND Deletado = 0", conn);
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

        //Atualizar jogador
        public static bool AtualizarJogador(Conta_Jogador jogador)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    UPDATE jogadores
                    SET
                        Nome = @nome,
                        SenhaHash = @senhaHash,
                        Idade = @idade,
                        Posicao = @posicao,
                        Saldo = @saldo,
                        Time = @time,
                        Gols = @gols,
                        Assistencias = @assistencias,
                        Interesses = @interesses,
                        Amistosos = @amistosos
                    WHERE 
                        Id = @id", conn);
                    
                cmd.Parameters.AddWithValue("@id", jogador.Id.ToString());
                cmd.Parameters.AddWithValue("@nome", jogador.Nome);
                cmd.Parameters.AddWithValue("@senhaHash", jogador.SenhaHash);
                cmd.Parameters.AddWithValue("@idade", jogador.Idade);
                cmd.Parameters.AddWithValue("@posicao", jogador.Posicao);
                cmd.Parameters.AddWithValue("@saldo", jogador.Saldo);
                cmd.Parameters.AddWithValue("@time", jogador.Time);
                cmd.Parameters.AddWithValue("@gols", jogador.Gols);
                cmd.Parameters.AddWithValue("@assistencias", jogador.Assistencias);
                cmd.Parameters.AddWithValue("@interesses", jogador.Interesses);
                cmd.Parameters.AddWithValue("@amistosos", jogador.Amistosos);
                cmd.Parameters.AddWithValue("@tornouSeJogador", jogador.TornouSeJogador);
                cmd.Parameters.AddWithValue("@tournouSeTecnico", jogador.TornouSeTecnico);

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
        public static bool DeletarJogador(Guid idjogador, string quemDeletou)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    UPDATE jogadores
                    SET
                        Deletado = 1,
                        DataDelecao = @dataDelecao,
                        QuemDeletou = @quemDeletou
                    WHERE
                        Id = @id", conn);
                
                cmd.Parameters.AddWithValue("@id", idjogador.ToString());
                cmd.Parameters.AddWithValue("@dataDelecao", DateTime.Now);
                cmd.Parameters.AddWithValue("@quemDeletou", quemDeletou);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                if (linhasAfetadas > 0)
                {
                    Console.WriteLine($"{idjogador} marcado como deletado em {DateTime.Now} por {quemDeletou}");
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

        //Restaurar Jogador
        public static bool RestaurarJogador(Guid idJogador)
        {
            try
            {
                using var conn = new MySqlConnection(MariaDB);
                conn.Open();

                var cmd = new MySqlCommand(@"
                    UPDATE jogadores
                    SET
                        Deletado = 0,
                        DataDelecao = NULL,
                        QuemDeletou = NULL
                    WHERE
                        Id = @id", conn);

                cmd.Parameters.AddWithValue("@id", idJogador.ToString());

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