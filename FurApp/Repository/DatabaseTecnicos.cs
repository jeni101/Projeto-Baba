using System;
using MySqlConnector;

namespace Repository.Database.Tecnicos
{
    public class DatabaseTecnicos : ADatabase
    {
        public override string NomeTabela => "tecnicos";

        public override string ScriptCriacao => @"
            CREATE TABLE IF NOT EXISTS tecnicos (
                Id CHAR(36) PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL UNIQUE,
                SenhaHash TEXT NOT NULL,
                Idade INT NOT NULL,
                Saldo DECIMAL(18,2),
                Interesses TEXT,
                Amistosos TEXT,
                Time VARCHAR(100),
                Deletado BIT DEFAULT 0,
                DataDelecao DATETIME NULL,
                QuemDeletou VARCHAR(100) NULL,
                TornouSeJogador BOOLEAN DEFAULT TRUE,
                TornouSeTecnico BOOLEAN DEFAULT TRUE)";
    }
}