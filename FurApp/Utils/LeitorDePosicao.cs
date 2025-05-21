using System;
using MySqlConnector;
using Models.PosicaoApp;

namespace Utils.Pelase.Leitor.Posicoes
{
    public static class LeitorDePosicao
    {
        public static Posicao LerPosicao(MySqlDataReader reader)
        {
            var posicao = new Posicao(
                reader.GetString("Nome"),
                reader.GetString("Categoria"),
                reader.GetString("Abreviacao")
            );

            typeof(Posicao).GetProperty("Id")?.SetValue(posicao, Guid.Parse(reader.GetString("Id")));
            return posicao;
        }
    }
}