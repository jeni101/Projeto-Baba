/*
using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using Models.TimesApp;

namespace Utils.Pelase.Leitor.Times
{
    public class LeitorDeTimes
    {

        public async Task<Time> LerTime(MySqlDataReader reader)
        {
            List<Guid> ParseGuidList(string columnName)
            {
                if (reader.IsDBNull(reader.GetOrdinal(columnName)))
                {
                    return new List<Guid>();
                }

                string data = reader.GetString(columnName);
                if (string.IsNullOrWhiteSpace(data))
                {
                    return new List<Guid>();
                }
                return data.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Trim())
                            .Where(s => Guid.TryParse(s, out _))
                            .Select(Guid.Parse)
                            .ToList();
            }

            List<Guid> jogadorIds = ParseGuidList("Jogadores");
            List<Guid> jogosIds = ParseGuidList("Jogos");
            List<Guid> partidasIds = ParseGuidList("Partidas");

            Guid idTime = Guid.Parse(reader.GetString("Id"));
            string nomeTime = reader.GetString("Nome");
            string abreviacaoTime = reader.GetString("Abreviacao");
            string tecnicoNome = reader.GetString("Tecnico");

            var time = new Time(
                idTime,
                nomeTime,
                abreviacaoTime,
                tecnicoNome,
                new List<Models.ContaApp.Usuario.Jogador.Conta_Jogador>(),
                jogosIds.ToString(),
                partidasIds.ToString()
            );
            return time;
        }
    }
}
*/