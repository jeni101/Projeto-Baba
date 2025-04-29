using System;
using System.Collections.Generic;
using ContaUsuarioApp;

namespace ContaJogadorApp
{
    public class ContaJogador : ContaUsuario 
    {
        public string Posicao { get; set; }
        public string Time { get; private set; }
        public string Codigo { get; private set; }
        public int Gols { get; private set; }
        public int Assistencias { get; private set; }
        public List<string> Eventos { get; private set; } 
        public List<string> Jogos { get; private set; } 
        public List<string> Partidas { get; private set; } 

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
        //SairTime será parte das funcoes de time
        public void SairTime(){}

        public void ExibirCodigo()
        {
            Console.WriteLine(!string.IsNullOrEmpty(Codigo) ? $"Código do Jogador: {Codigo}" : "Código não definido");
        }
        public void ExibirGols()
        {
            Console.WriteLine($"Gols: {Gols}");
        }
        public void ExibirAssistencias()
        {
            Console.WriteLine($"Assistencias: {Assistencias}");
        }
        public void ExibirJogos()
        {
            if (Jogos.Count > 0)
            {
                Console.WriteLine("Jogos:");
                foreach (var jogo in Jogos)
                {
                    Console.WriteLine(jogo);
                }
            }
            
            else
            {
                Console.WriteLine("Nenhum jogo registrado");
            }
        }
        public void ExibirPartidas()
        {
            if (Partidas.Count > 0)
            {
                Console.WriteLine("Partidas:");
                foreach (var partida in Partidas)
                {
                    Console.WriteLine(partida);
                }
            }

            else
            {
                Console.WriteLine("Nenhuma partida registrada");
            }
        }
        public void AdicionarGols()
        {
            Gols++;
        }
        public void AdicionarAssistencia()
        {
            Assistencias++;
        }
    }
}