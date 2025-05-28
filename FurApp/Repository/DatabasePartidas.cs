using System;
using MySqlConnector;

namespace Repository.Database.Partidas
{
    public class DatabasePartidas : ADatabase
    {
        public override string NomeTabela => "partidas";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS partidas (
                Id CHAR(36) PRIMARY KEY,
                JogoId CHAR(36) NOT NULL,
                Nome VARCHAR(255) NOT NULL, 
                TimeA VARCHAR(100) NOT NULL,
                TimeB VARCHAR(100) NOT NULL,
                GolsA INT DEFAULT 0,
                GolsB INT DEFAULT 0,
                Data DATE NOT NULL,
                Hora TIME NOT NULL,
                Local VARCHAR(225) NOT NULL,
                Status VARCHAR(50) NOT NULL,
                Deletado BIT DEFAULT 0,
                DataDelecao DATETIME NULl,
                FOREIGN KEY (JogoId) REFERENCES jogos(Id))";
    }
}