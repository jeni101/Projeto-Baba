using System;
using MySqlConnector;

namespace Repository.Database.Times
{
    public class DatabaseTimes : ADatabase
    {
        public override string NomeTabela => "times";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS times (
                Id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL UNIQUE,
                Abreviacao CHAR(5) NOT NULL UNIQUE,
                Tecnico VARCHAR(100) NOT NULL,
                Jogadores TEXT,
                Jogos TEXT,
                Partidas TEXT,
                Deletado BIT DEFAULT 0,
                DataDelecao DATETIME NULL,
                QuemDeletou VARCHAR(100) NULL,
                FOREIGN KEY (Tecnico) REFERENCES tecnicos(Nome))";
    }
}