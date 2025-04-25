using System;
using ContaUsuarioApp;

namespace ContaArbitroApp
{
    public class ContaArbitro : ContaUsuario
    {
        // mesma observacao da conta tecnico.
        public string Jogos {get; set;}
        public string Partidas {get; set;}

        public ContaArbitro(string nome, string senha, int idade, float saldo, string interesses, string amistosos, string jogos, string partidas)
            : base(nome, senha, idade, saldo, interesses, amistosos)
            {
                Jogos = jogos;
                Partidas = partidas;
            }
        
        
         //jogo obs - mesmas funcoes presentes na classe tecnico com execao do exibir, reciclagem de codigo?
        public void CriarJogo(){}
        public void ExibirJogo(){}
        public void EditarJogo(){}
        public void DeletarJogo(){}

        //partidas obs - mesmas funcoes presentes na classe tecnico com execao do exibir, reciclagem de codigo?
        public void CriarPartidas(){}
        public void ExibirPartidas(){}
        public void EditarPartidas(){}
        public void DeletarPartidas(){}
        public void EncerrarPartidas(){}


    }
}