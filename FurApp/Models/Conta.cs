using System;
using PersistenciaApp;

namespace ContaApp
{
    public abstract class Conta
    {
        public string Nome {get; set;}
        public string Senha {get; set;}

        public int Idade {get; set;}


    public Conta(string nome, string senha, int idade)
    {
        Nome = nome;
        Senha = senha;
        Idade = idade;
    } 

    public void Register() {}
    public virtual void Login(string tipoConta, string nome, string senha)
    {}
    public void Logout() {}

    
    }
}
