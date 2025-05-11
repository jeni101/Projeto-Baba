CREATE TABLE IF NOT EXISTS contas_jogadores_db (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome_usuario VARCHAR(100) NOT NULL,  -- A coluna nome_usuario é agora NOT NULL
    senha VARCHAR(30),
    idade VARCHAR(30),
    posisao VARCHAR(30),
    vitorias VARCHAR(30),
    disponibilidade VARCHAR(30),
    time VARCHAR(50),
    rank VARCHAR(30),
    assistencias VARCHAR(30),
    
    -- Definindo a chave estrangeira para referenciar a tabela 'contas_usuarios'
    FOREIGN KEY (nome_usuario) REFERENCES contas_usuarios(nome)
);

