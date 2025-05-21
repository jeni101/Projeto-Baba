using System;
using MySqlConnector;

namespace Repository.Database.Campos
{
    public class DatabaseCampos : ADatabase
    {
        public override string NomeTabela => "campos";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS campos (
                Id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL UNIQUE,
                Local VARCHAR(100) NOT NULL UNIQUE,
                Capacidade INT NOT NULL,
                TipoDeCampo VARCHAR(100) NOT NULL,
                Deletado BIT DEFAULT 0,
                DataDelecao DATETIME NULL,
                QuemDeletou VARCHAR(100) NULL,
                FOREIGN KEY (TipoDeCampo) REFERENCES campos_tipo(Id))";
    }
}