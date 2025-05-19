using System;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Tecnico;

namespace Utils.Pelase.Argumentos.Tecnico
{
    public static class ArgumentosTecnico
    {
        public static void PreencherParametros(MySqlCommand cmd, Conta_Tecnico tecnico)
        {
            cmd.Parameters.AddWithValue("@id", tecnico.Id.ToString());
            cmd.Parameters.AddWithValue("nome", tecnico.Nome);
            cmd.Parameters.AddWithValue("@senhaHash", tecnico.SenhaHash);
            cmd.Parameters.AddWithValue("@idade", tecnico.Idade);
            cmd.Parameters.AddWithValue("@time", tecnico.Time);
            cmd.Parameters.AddWithValue("@interesses", tecnico.Interesses);
            cmd.Parameters.AddWithValue("@amistosos", tecnico.Amistosos);
        }
    }
}