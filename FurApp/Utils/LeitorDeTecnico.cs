using System;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Tecnico;

namespace Utils.Pelase.Leitor.Tecnico
{
    public static class LeitorDeTecnico
    {
        public static Conta_Tecnico LerTecnico(MySqlDataReader reader)
        {
            var tecnico = new Conta_Tecnico(
                reader.GetString("Nome"),
                reader.GetString("SenhaHash"),
                reader.GetInt32("Idade"),
                reader.GetString("Time"));

            typeof(Conta).GetProperty("Id")?.SetValue(tecnico, Guid.Parse(reader.GetString("Id")));
            return tecnico;
        }
    }
}