using System;
using System.Collections.Generic;
using MySqlConnector;
using TimesApp;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Tecnico;

namespace Repository.PersistenciaApp
{
    public static class Posicoes
    {
        private const string MariaDB =  "Server=localhost;" +
                                        "Port=18046;" +
                                        "Database=furapp;" +
                                        "User ID=root;" +
                                        "Password=qhG171U4;" +
                                        "Connection Timeout=30;";
    } 
}