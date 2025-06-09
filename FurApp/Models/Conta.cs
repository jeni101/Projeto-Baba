using System;
using Utils.Pelase.CensuradorDeSenha;

namespace Models.ContaApp
{
    public abstract class Conta
    {
        //sistema de ID
        public Guid Id { get; protected set; }
        //atributos
        public string Nome {get; protected set;}
        public string SenhaHash {get; private set;}
        public int Idade {get; private set;}

        //Conta protegida
        protected Conta(string nome, string senha, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome)) 
                throw new ArgumentException("O nome não pode ser vazio", nameof(nome)); //LUIS VERIFICA O OUTPUT
            
            if (string.IsNullOrWhiteSpace(senha)) 
                throw new ArgumentException("A senha não pode ser vazia", nameof(senha)); //LUIS VERIFICA O OUTPUT
            
            if (idade <= 0) 
                throw new ArgumentException("Idade não deve ser negativa", nameof(idade)); //LUIS VERIFICA O OUTPUT

            //Gerando ID ao criar conta
            Id = Guid.NewGuid();
            Nome = nome;
            SenhaHash = CensuradorDeSenha.HashPassword(senha);
            Idade = idade;
        }

        //Verifica a senha
        public bool Autenticar(string senha)
        {
            return CensuradorDeSenha.VerificarSenha(senha, SenhaHash);
        }
    }
}
