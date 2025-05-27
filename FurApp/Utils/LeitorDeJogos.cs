using System;
using MySqlConnector;
using Models.JogosApp;

namespace Utils.Pelase.Leitor.Jogos
{
    public static class LeitorDeJogos
    {
        public static Jogo LerJogo(MySqlDataReader reader)
        {
            var jogo = new Jogo(
                DateOnly.FromDateTime(reader.GetDateTime("Data")),
                TimeOnly.FromTimeSpan(reader.GetTimeSpan("Hora")),
                reader.GetString("Local"),
                reader.GetString("TipoDeCampo"),
                reader.GetInt32("QuantidadeDeJogadores")
            );

            typeof(Jogo).GetProperty("Id")?.SetValue(jogo, Guid.Parse(reader.GetString("Id")));
            typeof(Jogo).GetProperty("Nome")?.SetValue(jogo, Guid.Parse(reader.GetString("Nome")));
            typeof(Jogo).GetProperty("AbreviacaoTimeA")?.SetValue(jogo, Guid.Parse(reader.GetString("AbreviacaoTimeA")));
            typeof(Jogo).GetProperty("AbreviacaoTimeB")?.SetValue(jogo, Guid.Parse(reader.GetString("AbreviacaoTimeB")));
            typeof(Jogo).GetProperty("Aberto")?.SetValue(jogo, reader.GetBoolean("Aberto"));
            
            return jogo;
        }
    }
}