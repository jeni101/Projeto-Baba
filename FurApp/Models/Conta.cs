using System;
using ContaUsuarioApp;

namespace ContaApp
{
    public abstract class Conta
    {
        public string Nome {get; private set;}
        public string SenhaHash {get; private set;}
        public int Idade {get; private set;}


    //Conta protegida
    protected Conta(string nome, string senha, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome não pode ser vazio", nameof(nome));
        }

        if (string.IsNullOrWhiteSpace(senha))
        {
            throw new ArgumentException("A senha não pode ser vazia", nameof(senha));
        }

        if (idade <= 0)
        {
            throw new ArgumentException("Idade não deve ser negativa", nameof(idade));
        }
        Nome = nome;
        SenhaHash = HashPassword(senha);
        Idade = idade;
    } 

    //funcoes
    public virtual void Register() {}
    public virtual bool Login(string nome, string senha)
    {
        if (nome == Nome && VerifyPassword(senha, SenhaHash))
        {
            Console.WriteLine("Login bem sucedido");
            return true;
        }
        Console.WriteLine("Falha login");
        return false;
    }
    public void Logout() {}

    //Censura senha
    private string HashPassword(string senha)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }
    }
    //Verifica senha
    private bool VerifyPassword(string senha, string senhaHash)
    {
        return HashPassword(senha) == senhaHash;
    }

    }
}
