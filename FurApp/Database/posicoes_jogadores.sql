USE dados_projeto_baba;

CREATE TABLE posicoes_jogadores (
    abreviacao VARCHAR(10) PRIMARY KEY,
    categoria ENUM('goleiro', 'defensor', 'meiocampista', 'atacante') NOT NULL
) CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO posicoes_jogadores (abreviacao, categoria) VALUES
('GOL', 'goleiro'),
('DEF', 'defensor'),
('MC', 'meiocampista'),
('ATQ', 'atacante');