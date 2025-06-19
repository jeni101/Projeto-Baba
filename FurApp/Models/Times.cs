using System;
using System.Collections.Generic;
using System.Linq;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;
using Models.JogosApp;
using Models.JogosApp.Partidas;

namespace Models.TimesApp
{
    public class Time : AModel
    {
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
        public string Tecnico { get; set; }
        public List<Conta_Jogador> Jogadores { get; set; }
        public List<string> Jogos { get; set; }
        public List<string> Partidas { get; set; }

        //Construtor privado
        public Time(string nome, string abreviacao, string tecnico)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Abreviacao = abreviacao;
            Tecnico = tecnico;
            Jogadores = new List<Conta_Jogador>();
            Jogos = new List<string>();
            Partidas = new List<string>();
        }
        
        //pesquisador de times
        public Time(Guid id, string nome, string abreviacao, string tecnico, List<Conta_Jogador> jogadores, string jogosStr, string partidasStr)
        {
            Id = id;
            Nome = nome;
            Abreviacao = abreviacao;
            Tecnico = tecnico;
            Jogadores = jogadores;
            Jogos = string.IsNullOrEmpty(jogosStr) ? new List<string>() : jogosStr.Split(',').ToList();
            Partidas = string.IsNullOrEmpty(partidasStr) ? new List<string>() : partidasStr.Split(',').ToList();
        }
    }
}