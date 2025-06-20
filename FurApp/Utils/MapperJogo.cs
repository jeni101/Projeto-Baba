/*
using System;
using System.Collections.Generic;
using DTO.Jogos;
using DTO.Jogos.Placar;
using DTO.Times;
using Models.JogosApp;
using Models.JogosApp.PlacarJogo;
using Models.TimesApp;
using Utils.Mappers.Times;
using Utils.Mappers.Jogos;

namespace Utils.Mappers.Jogos
{
    public static class MapperJogo
    {
        public static JogoDTO ToJogoDTO(
            Jogo jogo,
            Time timeA,
            Time timeB,
            Placar placar
        )
        {
            if (jogo == null)
                throw new ArgumentNullException(nameof(jogo), "O objeto Jogo não pode ser nulo para mapear o JogoDTO.");
            if (timeA == null)
                throw new ArgumentNullException(nameof(timeA), "O TimeA não pode ser nulo para mapear o JogoDTO.");
            if (timeB == null)
                throw new ArgumentNullException(nameof(timeB), "O TimeB não pode ser nulo para mapear o JogoDTO.");
            if (placar == null)
                throw new ArgumentNullException(nameof(placar), "O Placar não pode ser nulo para mapear o JogoDTO.");

            return new JogoDTO
            {
                Id = jogo.Id,
                Nome = jogo.Nome, 
                TimeA = MapperTimes.ToTimesDTO(timeA), 
                TimeB = MapperTimes.ToTimesDTO(timeB), 
                Placar = MapperPlacar.ToPlacarDTO(placar),
                Aberto = jogo.Aberto,
                Data = jogo.Data,
                Hora = jogo.Hora, 
                Interessados = jogo.Interessados ?? new List<string>(), 
                Deletado = false,
                DataDelecao = null,
                DataCriacao = DateTime.MinValue
            };
        }
    }
}
*/