using ContaUsuarioApp;

namespace ContaArbitroApp
{
    public class Conta_Arbitro : ContaUsuario
    {
        // mesma observacao da conta tecnico.
        public string Jogos {get; set;}
        public string Partidas {get; set;}

        public Conta_Arbitro(string nome, string senha, int idade, float? saldo = null, string? interesses = null, string? amistosos = null, string? jogos = null, string? partidas = null)
            : base(nome, senha, idade, saldo ?? 0, interesses ?? string.Empty, amistosos ?? string.Empty)
            {
                Jogos = jogos ?? string.Empty;
                Partidas = partidas ?? string.Empty;
            }
         //jogo obs - mesmas funcoes presentes na classe tecnico com execao do exibir, reciclagem de codigo?
        public void Criar_Novo_Jogo(){}
        public void Exibir_Jogo(){}
        public void Editar_Jogo(){}
        public void Deletar_Jogo(){}

        //partidas obs - mesmas funcoes presentes na classe tecnico com execao do exibir, reciclagem de codigo?
        public void Criar_Partidas(){}
        public void Exibir_Partidas(){}
        public void Editar_Partidas(){}
        public void Deletar_Partidas(){}
        public void Encerrar_Partidas(){}
    }
}