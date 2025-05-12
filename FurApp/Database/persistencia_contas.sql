USE furapp;

CREATE TABLE IF NOT EXISTS persistencia_contas (
    id CHAR(36) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    idade INT NOT NULL,
    data_criacao DATETIME NOT NULL
);