using System;
using ContaUsuarioApp;

namespace ContaJogadorApp
{
    public class ContaJogador : ContaUsuario 
    {
        public ContaJogador(string nome, string senha, int idade, float saldo, string interesses, string amistosos)
            : base ( nome,  senha, idade, saldo, interesses, amistosos)
            {

            }

        public void ExibirTime(){}
        public void SairTime(){}

        public void ExibirCodigo(){}
        public void ExibirGols(){}
        public void ExibirAssistencias(){}
        public void ExibirJogos(){}
        public void ExibirPartidas(){}
    }
}