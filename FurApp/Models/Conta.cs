using System;

namespace ContaApp
{
    public abstract class Conta
    {
        private string Nome {get; set;}
        private string Senha {get; set;}

        private int Idade {get; set;}


    public Conta(string nome, string senha, int idade)
    {
        Nome = nome;
        Senha = senha;
        Idade = idade;
    } 

    public void Register() {}
    public void Login() {}
    public void Logout() {}

    
    }
}
