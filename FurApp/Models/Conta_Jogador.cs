using System;
using ContaUsuarioApp;

namespace ContaJogadorApp
{
    public class ContaJogador : ContaUsuario 
    {
        public string Posicao { get; set; }
        public string Time { get; set; }
        public string Codigo { get; set; }
        public int Gols { get; set; }
        public int Assistencias { get; set; }
        public List<string> Eventos { get; set; } 
        public List<string> Jogos { get; set; } 
        public List<string> Partidas { get; set; } 

        public ContaJogador(string nome, 
                            string senha, 
                            int idade, 
                            string posicao, 
                            float? saldo = null, 
                            string? interesses = null, 
                            string? amistosos = null,
                            string? time = null, 
                            string? codigo = null, 
                            int? gols = null, 
                            int? assistencias = null)
            : base(nome, senha, idade, saldo ?? 0f, interesses ?? string.Empty, amistosos ?? string.Empty) // variaveis nulas p criacao de conta 
        {
            Posicao = posicao;
            Time = time ?? string.Empty;
            Codigo = codigo ?? string.Empty;
            Gols = gols ?? 0;
            Assistencias = assistencias ?? 0;
            Eventos = new List<string>();  // Inicializando a lista
            Jogos = new List<string>();    // Inicializando a lista
            Partidas = new List<string>(); 
        }

        public void ExibirTime()
        {
            if (!string.IsNullOrEmpty(Time))
            {
                Console.WriteLine(Time);
            }
            else
            {
                Console.WriteLine("Sem time");
            }
        }
        public void SairTime(){}
        public void ExibirCodigo(){}
        public void ExibirGols(){}
        public void ExibirAssistencias(){}
        public void ExibirJogos(){}
        public void ExibirPartidas(){}
    }
}