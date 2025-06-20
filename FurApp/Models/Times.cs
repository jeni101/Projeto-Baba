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
        public Guid TecnicoId { get; set; }
        public List<Guid> JogadoresId { get; set; }
        public List<Guid> JogosId { get; set; }
        public List<Guid> PartidasId { get; set; }

        //Construtor privado
        public Time(string nome, string abreviacao, Guid tecnico)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Abreviacao = abreviacao;
            TecnicoId = tecnico;
            JogadoresId = new List<Guid>();
            JogosId = new List<Guid>();
            PartidasId = new List<Guid>();
        }
        
        //pesquisador de times
        public Time(Guid id, string nome, string abreviacao, Guid tecnico, List<Guid> jogadores, string jogosStr, string partidasStr)
        {
            Id = id;
            Nome = nome;
            Abreviacao = abreviacao;
            TecnicoId = tecnico;
            JogadoresId = jogadores;
            JogosId = new List<Guid>();
            PartidasId = new List<Guid>();
        }
    }
}