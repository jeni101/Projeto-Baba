using System;
using Utils.Pelase.CensuradorDeSenha;
using System.Text.Json.Serialization;

namespace Models.ContaApp
{
    public abstract class Conta : AModel // AModel também precisa de construtor sem parâmetros e [JsonConstructor]
    {
        public string Nome { get; protected set; }
        public string SenhaHash { get; set; } // Deve ser 'public set' para desserialização
        public int Idade { get; set; }        // Deve ser 'public set' para desserialização

        // Construtor sem parâmetros (MUITO IMPORTANTE para desserialização padrão)
        public Conta()
        {
            Nome = string.Empty;
            SenhaHash = string.Empty;
            Idade = 0;
            // Id é inicializado pelo AModel, se tiver um construtor padrão
        }

        // Construtor para criação de novas contas
        protected Conta(string nome, string senha, int idade) : this()
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio", nameof(nome));
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha não pode ser vazia", nameof(senha));
            if (idade <= 0)
                throw new ArgumentException("Idade não deve ser negativa", nameof(idade));

            // Id = Guid.NewGuid(); // AModel deve cuidar da geração do Id no construtor padrão
            Nome = nome;
            SenhaHash = CensuradorDeSenha.HashPassword(senha);
            Idade = idade;
        }

        // Construtor de desserialização (marcado para o JsonConstructor)
        [JsonConstructor]
        protected Conta(Guid id, string nome, string senhaHash, int idade) : this() // Chama o construtor padrão primeiro
        {
            Id = id;
            Nome = nome;
            SenhaHash = senhaHash;
            Idade = idade;
        }

        public bool Autenticar(string senha)
        {
            return CensuradorDeSenha.VerificarSenha(senha, SenhaHash);
        }
    }
}