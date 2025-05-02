using ContaApp;

namespace ContaAdmApp
{
    public class Conta_Administrador : Conta
    {
        public Conta_Administrador(string nome, string senha, int idade)
            : base (nome, senha, idade )
            {

            }
        //conta
        public void Criar_Nova_Conta(){}
        public void Editar_Conta(){}
        public void Deletar_Conta(){}

        //jogador
        public void Criar_Novo_Jogador(){}
        public void Editar_Jogador(){}
        public void Deletar_Jogador(){}

        // tecnico 
        public void Criar_Novo_Tecnico(){}
        public void Editar_Tecnico(){}
        public void Deletar_Tecnico(){}

        // arbitro
        public void Criar_Novo_Arbitro(){}
        public void Editar_Arbitro(){}
        public void Deletar_Arbitro(){}

        //saldo
        public void Editar_Saldo(){}
        
        //Time
        public void Criar_Novo_Time(){}
        public void Editar_Time(){}
        public void Deletar_Time(){}

        //jogo
        public void Criar_Jogo(){}
        public void Editar_Jogo(){}
        public void Deletar_Jogo(){}

        //partidas 
        public void Criar_Nova_Partidas(){}
        public void Editar_Partidas_Existentes(){}
        public void Deletar_Partidas_Existentes(){}
        public void Encerrar_Partidas(){}
    }
}
