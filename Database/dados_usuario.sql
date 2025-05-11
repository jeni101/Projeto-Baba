CREATE DATABASE IF NOT EXISTS conta_usuario_db;

USE conta_usuario_db;

CREATE TABLE IF NOT EXISTS contas_usuarios (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    idade INT NOT NULL,
    saldo FLOAT NOT NULL DEFAULT 0,
    interesses TEXT,
    amistosos TEXT,
    tornou_se_jogador BOOLEAN NOT NULL DEFAULT FALSE,
    data_criacao DATETIME NOT NULL
);