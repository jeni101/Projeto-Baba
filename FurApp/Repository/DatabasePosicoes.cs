using System;
using MySqlConnector;

namespace Repository.Database.Posicoes
{
    public class DatabasePosicoes : ADatabase
    {
        public override string NomeTabela => "posicoes";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS posicoes (
                id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(50) NOT NULL UNIQUE,
                Categoria VARCHAR(20) NOT NULL,
                Abreviacao VARCHAR(5))";
    }
}