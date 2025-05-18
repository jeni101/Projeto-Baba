using System;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;

namespace Utils.Pelase.Leitor.Jogador
{
    public static class LeitorDeJogador
    {
        public static Conta_Jogador LerJogador(MySqlDataReader reader)
        {
            var jogador = new Conta_Jogador(
                reader.GetString("Nome"),
                reader.GetString("SenhaHash"),
                reader.GetInt32("Idade"),
                reader.GetString("Posicao"));

            typeof(Conta).GetProperty("Id")?.SetValue(jogador, Guid.Parse(reader.GetString("Id")));
            return jogador;
        }
    }
}