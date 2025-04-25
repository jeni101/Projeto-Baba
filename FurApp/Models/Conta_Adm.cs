using System;
using ContaApp;


namespace ContaAdmApp
{
    public class ContaAdm : Conta
    {
        public ContaAdm(string nome, string senha, int idade)
            : base (nome, senha, idade )
            {

            }
        //conta
        public void CriarConta(){}
        public void editarConta(){}
        public void DeletarConta(){}

        //jogador
        public void CriarJogador(){}
        public void EditarJogador(){}
        public void DeletarJogador(){}

        // tecnico 
        public void CriarTecnico(){}
        public void EditarTecnico(){}
        public void DeletarTecnico(){}

        // arbitro
        public void CriarArbitro(){}
        public void EditarArbitro(){}
        public void DeletarArbitro(){}

        //saldo
        public void EditaraSaldo(){}
        
        //Time
        public void CriarTime(){}
        public void EditarTime(){}
        public void DeletarTime(){}

        //jogo
        public void CriarJogo(){}
        public void EditarJogo(){}
        public void DeletarJogo(){}

        //partidas 
        public void CriarPartidas(){}
        public void EditarPartidas(){}
        public void DeletarPartidas(){}
        public void EncerrarPartidas(){}

    


    }
}
