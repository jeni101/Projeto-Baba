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

        public ContaJogador(string nome, string senha, int idade, float saldo, string interesses, string amistosos,
                            string posicao, string time, string codigo, int gols, int assistencias)
            : base(nome, senha, idade, saldo, interesses, amistosos)
        {
            Posicao = posicao;
            Time = time;
            Codigo = codigo;
            Gols = gols;
            Assistencias = assistencias;
            Eventos = new List<string>();  // Inicializando a lista
            Jogos = new List<string>();    // Inicializando a lista
            Partidas = new List<string>(); 
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