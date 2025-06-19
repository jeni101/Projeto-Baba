using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Jogos;
using Models.JogosApp;
using Models.TimesApp;
using Models.JogosApp.PlacarJogo;
using Models.ContaApp.Usuario.Jogador;
using Utils.Mappers.Jogos;

namespace Services.Partidas.Controle
{
    public class ControleDePartidasServices
    {
        private List<Jogo> _jogos;
        private List<Time> _times;
        private List<Placar> _placar;

        public ControleDePartidasServices()
        {
            _jogos = new List<Jogo>();
            _times = new List<Time>();
            _placar = new List<Placar>();
        }
    }
}