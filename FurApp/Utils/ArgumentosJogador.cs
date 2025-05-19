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
            cmd.Parameters.AddWithValue("@time", jogador.Time);
            cmd.Parameters.AddWithValue("@gols", jogador.Gols);
            cmd.Parameters.AddWithValue("@assistencias", jogador.Assistencias);
            cmd.Parameters.AddWithValue("@interesses", jogador.Interesses);
            cmd.Parameters.AddWithValue("@amistosos", jogador.Amistosos);
        }
    }
}