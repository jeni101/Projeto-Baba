using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ContaUsuarioApp
{
    public static class Persistencia_De_Contas
    {
        private const string MariaDB = "Server=localhost;Database=conta_usuario_db;User ID=root;Password=sua_senha;Port=3306;";
        
        public static List<Conta_Usuario> Carregar_Contas()
        {
            var contas = new List<Conta_Usuario>();
            
            try
            {
                using (var conexao = new MySqlConnection(MariaDB))
                {
                    conexao.Open();
                    string query = @"
                        SELECT nome, senha, idade, saldo, interesses, amistosos, tornou_se_jogador, data_criacao 
                        FROM contas_usuarios";

                    using (var cmd = new MySqlCommand(query, conexao))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contas.Add(new Conta_Usuario(
                                    nome: reader.GetString("nome"),
                                    senha: reader.GetString("senha"),
                                    idade: reader.GetInt32("idade"),
                                    saldo: reader.GetFloat("saldo"),
                                    interesses: reader.IsDBNull(reader.GetOrdinal("interesses")) ? null : reader.GetString("interesses"),
                                    amistosos: reader.IsDBNull(reader.GetOrdinal("amistosos")) ? null : reader.GetString("amistosos"),
                                    tornouSeJogador: reader.GetBoolean("tornou_se_jogador")
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar contas: {ex.Message}");
            }

            return contas;
        }

        public static void Salvar_Contas(List<Conta_Usuario> contas)
        {
            if (contas == null || contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta para salvar.");
                return;
            }

            try
            {
                using (var conexao = new MySqlConnection(MariaDB))
                {
                    conexao.Open();
                    using (var transaction = conexao.BeginTransaction())
                    {
                        foreach (var conta in contas)
                        {
                            string query = @"
                                INSERT INTO contas_usuarios 
                                    (nome, senha, idade, saldo, interesses, amistosos, tornou_se_jogador, data_criacao) 
                                VALUES 
                                    (@nome, @senha, @idade, @saldo, @interesses, @amistosos, @tornou_se_jogador, @data_criacao)
                                ON DUPLICATE KEY UPDATE
                                    senha = @senha, 
                                    idade = @idade, 
                                    saldo = @saldo, 
                                    interesses = @interesses, 
                                    amistosos = @amistosos, 
                                    tornou_se_jogador = @tornou_se_jogador, 
                                    data_criacao = @data_criacao";

                            using (var cmd = new MySqlCommand(query, conexao, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", conta.Nome);
                                cmd.Parameters.AddWithValue("@senha", conta.SenhaHash);
                                cmd.Parameters.AddWithValue("@idade", conta.Idade);
                                cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
                                cmd.Parameters.AddWithValue("@interesses", (object)conta.Interesses ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@amistosos", (object)conta.Amistosos ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@tornou_se_jogador", conta.TornouSeJogador);
                                cmd.Parameters.AddWithValue("@data_criacao", conta.DataCriacao);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        Console.WriteLine("Todas as contas foram salvas com sucesso.");
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine($"Erro no banco de dados: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contas: {ex.Message}");
            }
        }
    }
}