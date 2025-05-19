using System;
using MySqlConnector;
using Models.JogosApp;

namespace Utils.Pelase.Argumentos.Jogos
{
    public static class ArgumentosJogos
    {
        public static void PreencherParametros(MySqlCommand cmd, Jogo jogo)
        {
            cmd.Parameters.AddWithValue("@id", jogo.Id.ToString());
            cmd.Parameters.AddWithValue("@data", jogo.Data);
            cmd.Parameters.AddWithValue("@hora", jogo.Hora);
            cmd.Parameters.AddWithValue("@local", jogo.Local);
            cmd.Parameters.AddWithValue("@tipoDeCampo", jogo.TipoDeCampo);
            cmd.Parameters.AddWithValue("@interessados", jogo.Interessados);
            cmd.Parameters.AddWithValue("@quantidadeDeJogadores", jogo.QuantidadeDeJogadores);
        }
    }
}