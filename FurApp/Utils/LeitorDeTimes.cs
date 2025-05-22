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
                reader.GetString("Nome"),
                reader.GetString("Abrevicao"),
                reader.GetInt32("Tecnico"),
                reader.GetString("Jogadores"),
                reader.GetString("Jogos"),
                reader.GetString("Partidas"));

            typeof(Time).GetProperty("Id")?.SetValue(time, Guid.Parse(reader.GetString("Id")));
            return time;
        }
    }
}