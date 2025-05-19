using System;
using MySqlConnector;

namespace Repository.Database.Jogadores
{
    public class DatabaseJogadores : ADatabase
    {
        public override string NomeTabela => "jogadores";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS jogadores (
                id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL UNIQUE,
                SenhaHash TEXT NOT NULL,
                Idade INT NOT NULL,
                Posicao VARCHAR(50),
                Saldo DECIMAL(18,2),
                Time VARCHAR(100),
                Gols INT DEFAULT 0,
                Assistencias INT DEFAULT 0,
                Interesses TEXT,
                Amistosos TEXT,
                Deletado BIT DEFAULT 0,
                DataDelecao DATETIME NULL,
                QuemDeletou VARCHAR(100) NULL,
                TornouSeJogador BOOLEAN DEFAULT TRUE,
                TornouSeTecnico BOOLEAN DEFAULT TRUE)";
    }
}