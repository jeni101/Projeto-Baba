/*
using System;
using MySqlConnector;
using Models.CamposApp.Tipo;

namespace Utils.Pelase.Leitor.TipoCampos
{
    public static class LeitorDeTipoCampos
    {
        public static TipoDeCampo LerTipoCampos(MySqlDataReader reader)
        {
            var campoTipo = new TipoDeCampo(
                reader.GetString("Tipo"),
                reader.GetInt32("CapacidadePadrao"));

            typeof(TipoDeCampo).GetProperty("Id")?.SetValue(campoTipo, Guid.Parse(reader.GetString("Id")));
            return campoTipo;
        }
    }
}
*/