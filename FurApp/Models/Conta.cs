using System;
using System.Security.Cryptography;
using System.Text;

namespace ContaApp
{
    public abstract class Conta
    {
        //sistema de ID
        public Guid Id { get; protected set; }
        //atributos
        public string Nome {get; private set;}
        public string SenhaHash {get; private set;}
        public int Idade {get; private set;}

        //Conta protegida
        protected Conta(string nome, string senha, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome não pode ser vazio", nameof(nome));
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("A senha não pode ser vazia", nameof(senha));
            if (idade <= 0) throw new ArgumentException("Idade não deve ser negativa", nameof(idade));
            //Gerando ID ao criar conta
            Id = Guid.NewGuid();
            Nome = nome;
            SenhaHash = HashPassword(senha);
            Idade = idade;
        } 

        //funcoes
        public virtual void Register() {}
        public virtual bool Login(string nome, string senha)
        {
            if (Autenticar(nome, senha))
            {
                Console.WriteLine("Login bem sucedido");
                return true;
            }
            Console.WriteLine("Falha login");
            return false;
        }
        public void Logout() 
        {
            Console.WriteLine("Logout realizado");
        }

        protected bool Autenticar(string nome, string senha)
        {
            return nome == Nome && VerificarSenha(senha, SenhaHash);
        }

        //Censura senha
        private string HashPassword(string senha)
        {
            byte[] salt = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            var key = new Rfc2898DeriveBytes(
            senha,
            salt,
            10000,                   
            HashAlgorithmName.SHA256 
            );
            byte[] hash = key.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
        //Verifica senha
        private bool VerificarSenha(string senha, string senhaHash)
        {
            byte[] hashBytes = Convert.FromBase64String(senhaHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var key = new Rfc2898DeriveBytes(
            senha,
            salt,
            10000,                   // Mais iterações = mais segurança
            HashAlgorithmName.SHA256 // SHA-256 é mais seguro que SHA-1
            );
            byte[] hash = key.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i+16] != hash[i])
                    return false;
            
            return true;

        }
    }
}
