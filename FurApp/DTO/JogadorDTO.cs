using System;
using System.Collections.Generic;

namespace DTO.Perfil.Usuario.Jogador
{
    public class JogadorDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string TipoConta { get; set; }
        public required int Idade { get; set; }
        public required string Posicao { get; set; }
        public string TimeAtual { get; set; } = string.Empty;
        public List<string> NomesJogosInteressados { get; set; } = new List<string>();
        public List<string> NomePartidasJogadas { get; set; } = new List<string>();
    }
}