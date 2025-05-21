using System;
using MySqlConnector;

namespace Repository.Database.Campos
{
    public class DatabaseCamposTipo : ADatabase
    {
        public override string NomeTabela => "campos_tipo";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS campos_tipo (
                Id CHAR(36) PRIMARY KEY,
                Tipo VARCHAR(100) NOT NULL UNIQUE,
                CapacidadePadrao INT NULL)";
    }
}