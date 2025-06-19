using System;
using MySqlConnector;

namespace Repository.Database.ADM
{
    public class DatabaseADM : ADatabase
    {
        public override string NomeTabela => "adm";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS adm (
                Id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL UNIQUE,
                SenhaHash TEXT NOT NULL,
                Idade INT NOT NULL)";
    }
}