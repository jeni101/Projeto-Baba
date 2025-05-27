using System;
using MySqlConnector;
using Models.TimesApp;

namespace Utils.Pelase.Leitor.Times
{
    public static class LeitorDeTimes
    {
        public static Time LerTime(MySqlDataReader reader)
        {
            var time = new Time(
                Guid.Parse(reader.GetString("Id")),
                reader.GetString("Nome"),
                reader.GetString("Abrevicao"),
                reader.GetString("Tecnico"),
                reader.IsDBNull(reader.GetOrdinal("Jogadores")) ? "" : reader.GetString("Jogadores"),
                reader.IsDBNull(reader.GetOrdinal("Jogos")) ? "" : reader.GetString("Jogos"),
                reader.IsDBNull(reader.GetOrdinal("Partidas")) ? "" : reader.GetString("Partidas")
            );

            return time;
        }
    }
}