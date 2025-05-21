using System;
using MySqlConnector;
using Models.CamposApp;

namespace Utils.Pelase.Leitor.Campos
{
    public static class LeitorDeCampos
    {
        public static Campo LerCampos(MySqlDataReader reader)
        {
            var campo = new Campo(
                reader.GetString("Nome"),
                reader.GetString("SenhaHash"),
                reader.GetInt32("Idade"),
                reader.GetString("Posicao"));

            typeof(Campo).GetProperty("Id")?.SetValue(campo, Guid.Parse(reader.GetString("Id")));
            return campo;
        }
    }
}