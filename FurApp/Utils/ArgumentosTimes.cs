using System;
using MySqlConnector;
using Models.TimesApp;

namespace Utils.Pelase.Argumentos.Times
{
    public static class ArgumentosTime
    {
        public static void PreencherParametros(MySqlCommand cmd, Time time)
        {
            cmd.Parameters.AddWithValue("@id", time.Id.ToString());
            cmd.Parameters.AddWithValue("nome", time.Nome);
            cmd.Parameters.AddWithValue("@abreviacao", time.Abreviacao);
            cmd.Parameters.AddWithValue("@tecnico", time.Tecnico);
            cmd.Parameters.AddWithValue("@jogadores", time.Jogadores);
            cmd.Parameters.AddWithValue("@jogos", time.Jogos);
            cmd.Parameters.AddWithValue("@partidas", time.Partidas);
        }
    }
}