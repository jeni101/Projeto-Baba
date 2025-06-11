using System;
using System.Collections.Generic;
using DTO.Times;
using DTO.Jogos.Placar;

namespace DTO.Jogos
{
    public class JogoDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required TimesDTO TimeA { get; set; }
        public required TimesDTO TimeB { get; set; }
        public required PlacarDTO Placar { get; set; }
        public bool Aberto { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public List<string> Interessados { get; set; } = new List<string>();
        public bool Deletado { get; set; }
        public DateTime? DataDelecao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}