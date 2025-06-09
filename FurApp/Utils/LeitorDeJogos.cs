using System;
using System.Linq;
using MySqlConnector;
using Models.JogosApp;
using System.Collections.Generic;

namespace Utils.Pelase.Leitor.Jogos
{
    public static class LeitorDeJogos
    {
        public static Jogo LerJogo(MySqlDataReader reader)
        {
            var id = Guid.Parse(reader.GetString("Id"));
            var nome = reader.GetString("Nome");
            var abreviacaoTimeA = reader.GetString("AbreviacaoTimeA");
            var abreviacaoTimeB = reader.GetString("AbreviacaoTimeB");
            var aberto = reader.GetBoolean("Aberto");
            var data = DateOnly.FromDateTime(reader.GetDateTime("Data"));
            var hora = TimeOnly.FromTimeSpan(reader.GetTimeSpan("Hora"));
            var campoId = Guid.Parse(reader.GetString("CampoId"));
            var localDisplay = reader.GetString("LocalDisplay");
            var tipoDeCampoDisplay = reader.GetString("TipoDeCampoDisplay");
            var quantidadeDeJogadores = reader.GetInt32("QuantidadeDeJogadores");

            List<string> interessados;
            if (!reader.IsDBNull(reader.GetOrdinal("Interessados")))
            {
                var interessadosSerial = reader.GetString("Interessados");
                if (string.IsNullOrWhiteSpace(interessadosSerial))
                {
                    interessados = new List<string>();
                }
                else
                {
                    interessados = interessadosSerial
                                    .Split(new string[] { "###DELIMITER###" }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();
                }
            }
            else
            {
                interessados = new List<string>();
            }

            var jogo = new Jogo(
                id: id,
                nome: nome,
                abreviacaoTimeA: abreviacaoTimeA,
                abreviacaoTimeB: abreviacaoTimeB,
                aberto: aberto,
                data: data,
                hora: hora,
                campoId: campoId,
                localDisplay: localDisplay,
                tipoDeCampoDisplay: tipoDeCampoDisplay,
                interessados: interessados,
                quantidadeDeJogadores: quantidadeDeJogadores
            );

            return jogo;
        }
    }
}