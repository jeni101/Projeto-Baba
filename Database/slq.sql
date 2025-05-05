CREATE TABLE IF NOT EXISTS contas_usuarios (
    nome VARCHAR(100) PRIMARY KEY,
    senha VARCHAR(255) NOT NULL,
    idade INT NOT NULL,
    saldo FLOAT NOT NULL DEFAULT 0.0,
    interesses TEXT DEFAULT NULL,
    amistosos TEXT DEFAULT NULL,
    data_criacao DATETIME NOT NULL,

    -- Campos de Jogador
    posicao VARCHAR(50),
    time VARCHAR(100),
    codigo_ra VARCHAR(20) UNIQUE DEFAULT NULL,
    gols INT DEFAULT 0,
    assistencias INT DEFAULT 0
);