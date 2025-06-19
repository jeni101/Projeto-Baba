using System;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.ADM;

namespace Utils.Pelase.Leitor.ADM
{
    public static class LeitorDeADM
    {
        public static Conta_Administrador LerADM(MySqlDataReader reader)
        {
            var adm = new Conta_Administrador(
                reader.GetString("Nome"),
                reader.GetString("SenhaHash"),
                reader.GetInt32("Idade"));

            return adm;
        }
    }
}