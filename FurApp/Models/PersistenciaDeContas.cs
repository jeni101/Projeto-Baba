using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ContaApp;
using ContaUsuarioApp;
using ContaJogadorApp;
using ContaTecnicoApp;

namespace PersistenciaApp
{
    public static class PersistenciaDeContas
    {
        private const string MariaDB = "Server=127.0.0.1;Port=18046;User ID=root;Password=qhG171U4;Database=furapp;";

        public static void SalvarJogador(Conta_Jogador jogador)
        {
            using var conn = new MySqlConnection(MariaDB);
            conn.Open();

            var cmd = new MySqlCommand(@"
                INSERT INTO Jogadores (Id, Nome, SenhaHash, Idade, Posicao, Time, Gols, Assistencias)
                VALUES (@id, @nome, @senhaHash, @idade, @posicao, @time, @gols, @assistencias)", conn);

            cmd.Parameters.AddWithValue("@id", jogador.Id.ToString());
            cmd.Parameters.AddWithValue("@nome", jogador.Nome);
            cmd.Parameters.AddWithValue("@senhaHash", jogador.SenhaHash);
            cmd.Parameters.AddWithValue("@idade", jogador.Idade);
            cmd.Parameters.AddWithValue("@posicao", jogador.Posicao);
            cmd.Parameters.AddWithValue("@time", jogador.Time);
            cmd.Parameters.AddWithValue("@gols", jogador.Gols);
            cmd.Parameters.AddWithValue("@assistencias", jogador.Assistencias);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Jogador Salvo");
        }

        public static List<Conta_Jogador> CarregarJogadores()
        {
            var jogadores = new List<Conta_Jogador>();
            
            using var conn = new MySqlConnection(MariaDB);
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM jogadores", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var jogador = new Conta_Jogador(
                    reader.GetString("Nome"),
                    reader.GetString("SenhaHash"),
                    reader.GetInt32("Idade"),
                    reader.GetString("Posicao"),
                    time: reader.IsDBNull(reader.GetOrdinal("Time")) ? null : reader.GetString("Time"),
                    gols: reader.IsDBNull(reader.GetOrdinal("Gols")) ? (int?)null : reader.GetInt32("Gols"),
                    assistencias: reader.IsDBNull(reader.GetOrdinal("Assistencias")) ? (int?)null : reader.GetInt32("Assistencias")
                );

                jogadores.Add(jogador);
            }
            return jogadores;
        }
    }
}