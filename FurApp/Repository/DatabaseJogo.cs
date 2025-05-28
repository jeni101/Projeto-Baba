using System;
using MySqlConnector;

namespace Repository.Database.Jogos
{
    public class DatabaseJogos : ADatabase
    {
        public override string NomeTabela => "jogos";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS jogos (
                Id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL UNIQUE,
                Aberto BOOLEAN DEFAULT TRUE,
                Data DATE NOT NULL,
                Hora TIME NOT NULL,
                Local VARCHAR(100) NOT NULL,
                TipoDeCampo VARCHAR(50) NOT NULL,
                QuantidadeDeJogadores INT NOT NULL,
                Interessados TEXT,
                Deletado BIT DEFAULT 0,
                DataDelecao DATETIME NULL,
                DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP)";
    }
}