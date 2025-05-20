using System;
using MySqlConnector;
using Models.PosicaoApp;


namespace Utils.Pelase.Argumentos.Posicoes
{
    public static class ArgumentosPosicao
    {
        public static void PreencherParametros(MySqlCommand cmd, Posicao posicao)
        {
            cmd.Parameters.AddWithValue("@id", posicao.Id.ToString());
            cmd.Parameters.AddWithValue("nome", posicao.Nome);
            cmd.Parameters.AddWithValue("@categoria", posicao.Categoria);
            cmd.Parameters.AddWithValue("@abreviacao", posicao.Abreviacao);
        }
    }
}