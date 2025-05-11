CREATE DATABASE IF NOT EXISTS furapp
  DEFAULT CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE furapp;

CREATE TABLE IF NOT EXISTS posicoes_jogadores (
    abreviacao VARCHAR(10) PRIMARY KEY,
    categoria ENUM('goleiro', 'defensor', 'meio_campista', 'atacante') NOT NULL
) CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

TRUNCATE TABLE posicoes_jogadores;

INSERT INTO posicoes_jogadores (abreviacao, categoria) VALUES
('GOL', 'goleiro'),
('DEF', 'defensor'),
('MC', 'meio_campista'),
('ATQ', 'atacante');