CREATE TABLE contas_usuarios (
    nome VARCHAR(50) PRIMARY KEY,
    senha VARCHAR(255) NOT NULL,
    idade INT,
    saldo FLOAT DEFAULT 0,
    interesses TEXT,
    amistosos TEXT,
    tornou_se_jogador BOOLEAN DEFAULT FALSE,
    data_criacao DATETIME NOT NULL
);