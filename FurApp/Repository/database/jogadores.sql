USE furapp;

CREATE TABLE IF NOT EXISTS jogadores (
    id CHAR(36) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL UNIQUE,
    SenhaHash TEXT NOT NULL,
    Idade INT NOT NULL,
    TipoConta VARCHAR(50) NOT NULL,
    Posicao VARCHAR(50),
    Saldo DECIMAL(18,2),
    Time VARCHAR(100),
    Gols INT DEFAULT 0,
    Assistencias INT DEFAULT 0,
    FOREIGN KEY (id) REFERENCES contas(id) ON DELETE CASCADE
);
