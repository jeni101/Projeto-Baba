using System;
using MySqlConnector;
using Models.CamposApp.Tipo;

namespace Utils.Pelase.Argumentos.TipoCampos
{
    public static class ArgumentosTipoCampos
    {
        public static void PreencherParametros(MySqlCommand cmd, TipoDeCampo campoTipo)
        {
            cmd.Parameters.AddWithValue("@id", campoTipo.Id.ToString());
            cmd.Parameters.AddWithValue("@tipo", campoTipo.Tipo);
            cmd.Parameters.AddWithValue("@capacidadePadrao", campoTipo.CapacidadePadrao);
        }
    }
}