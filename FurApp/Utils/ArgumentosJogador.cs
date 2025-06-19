using System;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;

namespace Utils.Pelase.Argumentos.Jogador
{
    public static class ArgumentosJogador
    {
        public static void PreencherParametros(MySqlCommand cmd, Conta_Jogador jogador)
        {
            cmd.Parameters.AddWithValue("@id", jogador.Id.ToString());
            cmd.Parameters.AddWithValue("nome", jogador.Nome);
            cmd.Parameters.AddWithValue("@senhaHash", jogador.SenhaHash);
            cmd.Parameters.AddWithValue("@idade", jogador.Idade);
            cmd.Parameters.AddWithValue("@posicao", jogador.Posicao);
            cmd.Parameters.AddWithValue("@timeId", jogador.Time?.Id.ToString());
            cmd.Parameters.AddWithValue("@interesses", string.Join(",", jogador.Interesses));
            cmd.Parameters.AddWithValue("@partidas", string.Join(",", jogador.Partidas));
            cmd.Parameters.AddWithValue("@tornouSeJogador", jogador.TornouSeJogador);
            cmd.Parameters.AddWithValue("@tornouSeTecnico", jogador.TornouSeTecnico);
            cmd.Parameters.AddWithValue("@dataCriacao", jogador.DataCriacao);
            cmd.Parameters.AddWithValue("@deletado", jogador.Deletado);
            cmd.Parameters.AddWithValue("@dataDelecao", jogador.DataDelecao ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@quemDeletou", jogador.QuemDeletou ?? (object)DBNull.Value);
        }
    }
}