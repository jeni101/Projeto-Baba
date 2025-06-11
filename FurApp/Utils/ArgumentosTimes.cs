using System;
using MySqlConnector;
using Models.TimesApp;

namespace Utils.Pelase.Argumentos.Times
{
    public static class ArgumentosTime
    {
        public static void PreencherParametros(MySqlCommand cmd, Time time, string jogadoresStr)
        {
            cmd.Parameters.AddWithValue("@id", time.Id.ToString());
            cmd.Parameters.AddWithValue("nome", time.Nome);
            cmd.Parameters.AddWithValue("@abreviacao", time.Abreviacao);
            cmd.Parameters.AddWithValue("@tecnico", time.Tecnico);
            cmd.Parameters.AddWithValue("@jogadores", jogadoresStr);
            cmd.Parameters.AddWithValue("@jogos", time.Jogos);
            cmd.Parameters.AddWithValue("@partidas", time.Partidas);
        }
    }
}