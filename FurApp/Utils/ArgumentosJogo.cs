using System;
using MySqlConnector;
using Models.JogosApp;
using System.Threading.Tasks.Dataflow;

namespace Utils.Pelase.Argumentos.Jogos
{
    public static class ArgumentosJogos
    {
        public static void PreencherParametros(MySqlCommand cmd, Jogo jogo)
        {
            if (jogo == null)
            {
                throw new ArgumentNullException(nameof(jogo), "O objeto Jogo não pode ser nulo ao preencher parâmetros.");
            }

            cmd.Parameters.AddWithValue("@id", jogo.Id.ToString());
            cmd.Parameters.AddWithValue("@nome", jogo.Nome);
            cmd.Parameters.AddWithValue("@abreviacaoTimeA", jogo.AbreviacaoTimeA);
            cmd.Parameters.AddWithValue("@abreviacaoTimeB", jogo.AbreviacaoTimeB);
            cmd.Parameters.AddWithValue("@aberto", jogo.Aberto);
            cmd.Parameters.AddWithValue("@data", jogo.Data.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@hora", jogo.Hora.ToTimeSpan());
            cmd.Parameters.AddWithValue("@campoId", jogo.CampoId.ToString());
            cmd.Parameters.AddWithValue("@localDisplay", jogo.LocalDisplay);
            cmd.Parameters.AddWithValue("@tipoDeCampoDisplay", jogo.TipoDeCampoDisplay);
            string interessadosSerial = string.Join("###DELIMITER###", jogo.Interessados);
            cmd.Parameters.AddWithValue("@interessados", interessadosSerial);
            cmd.Parameters.AddWithValue("@quantidadeDeJogadores", jogo.QuantidadeDeJogadores);
        }
    }
}