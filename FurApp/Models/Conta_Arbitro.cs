using System;
using ContaUsuarioApp;

namespace ContaArbitroApp
{
    public class ContaArbitro : ContaUsuario
    {
        // mesma observacao da conta tecnico.
        public string Jogos {get; set;}
        public string Partidas {get; set;}

        public ContaArbitro(string nome, string senha, int idade, float? saldo = null, string? interesses = null, string? amistosos = null, string? jogos = null, string? partidas = null)
            : base(nome, senha, idade, saldo ?? 0, interesses ?? string.Empty, amistosos ?? string.Empty)
            {
                Jogos = jogos ?? string.Empty;
                Partidas = partidas ?? string.Empty;
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