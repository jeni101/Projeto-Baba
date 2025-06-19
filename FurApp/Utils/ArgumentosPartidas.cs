using MySqlConnector;
using Models.JogosApp.Partidas;
using System;

namespace Utils.Pelase.Argumentos.Partidas
{
    public static class ArgumentosPartida
    {
        public static void PreencherParametros(MySqlCommand cmd, Partida partida)
        {
            cmd.Parameters.AddWithValue("@id", partida.Id.ToString());
            cmd.Parameters.AddWithValue("@jogoId", partida.JogoId.ToString());
            cmd.Parameters.AddWithValue("@nome", partida.Nome);
            cmd.Parameters.AddWithValue("@timeA", partida.TimeA);
            cmd.Parameters.AddWithValue("@timeB", partida.TimeB);
            cmd.Parameters.AddWithValue("@golsA", partida.Placar.GolsA);
            cmd.Parameters.AddWithValue("@golsB", partida.Placar.GolsB);
            cmd.Parameters.AddWithValue("@data", partida.Data.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@hora", partida.Hora.ToTimeSpan());
            cmd.Parameters.AddWithValue("@local", partida.Local);
            cmd.Parameters.AddWithValue("@status", partida.Status.ToString());
        }
    }
}
