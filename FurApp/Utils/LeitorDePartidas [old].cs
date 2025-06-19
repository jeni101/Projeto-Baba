using System;
using MySqlConnector;
using Models.JogosApp.Partidas;
using Models.JogosApp.PlacarJogo;

namespace Utils.Pelase.Leitor.Partidas
{
    public static class LeitorDePartidas
    {
        public static Partida LerPartida(MySqlDataReader reader)
        {
            Guid id = Guid.Parse(reader.GetString("Id"));
            Guid jogoId = Guid.Parse(reader.GetString("JogoId"));
            string nome = reader.GetString("Nome");
            string timeA = reader.GetString("TimeA");
            string timeB = reader.GetString("TimeB");
            int golsA = reader.GetInt32("GolsA");
            int golsB = reader.GetInt32("GolsB");
            DateOnly data = DateOnly.FromDateTime(reader.GetDateTime("Data"));
            TimeOnly hora = TimeOnly.FromTimeSpan(reader.GetTimeSpan("Hora"));
            string local = reader.GetString("Local");
            PartidaStatus status = (PartidaStatus)Enum.Parse(typeof(PartidaStatus), reader.GetString("Status"));

            var partida = new Partida(
                id,
                jogoId,
                nome,
                timeA,
                timeB,
                golsA,
                golsB,
                data,
                hora,
                local,
                status
            );

            return partida;
        }
    }
}
