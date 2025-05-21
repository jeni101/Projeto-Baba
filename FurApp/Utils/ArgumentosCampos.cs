using System;
using MySqlConnector;
using Models.CamposApp;

namespace Utils.Pelase.Argumentos.Campos
{
    public static class ArgumentosCampos
    {
        public static void PreencherParametros(MySqlCommand cmd, Campo campo)
        {
            cmd.Parameters.AddWithValue("@id", campo.Id.ToString());
            cmd.Parameters.AddWithValue("@nome", campo.Nome);
            cmd.Parameters.AddWithValue("@local", campo.Local);
            cmd.Parameters.AddWithValue("@capacidade", campo.Capacidade);
            cmd.Parameters.AddWithValue("@tipoDeCampo", campo.TipoDeCampo);
        }
    }
}