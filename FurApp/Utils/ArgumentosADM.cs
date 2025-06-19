using System;
using MySqlConnector;
using Models.ContaApp.ADM;

namespace Utils.Pelase.Argumentos.ADM
{
    public static class ArgumentosADM
    {
        public static void PreencherParametros(MySqlCommand cmd, Conta_Administrador adm)
        {
            cmd.Parameters.AddWithValue("@id", adm.Id.ToString());
            cmd.Parameters.AddWithValue("nome", adm.Nome);
            cmd.Parameters.AddWithValue("@senhaHash", adm.SenhaHash);
            cmd.Parameters.AddWithValue("@idade", adm.Idade);
        }
    }
}