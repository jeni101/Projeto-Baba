/*
using DTO.Perfil.Usuario.Jogador;
using DTO.Times;
using Models.TimesApp;
using Utils.Mappers.Jogadores;
using Utils.Mappers.Jogos;

namespace Utils.Mappers.Times
{
    public class MapperTimes
    {
        public static TimesDTO ToTimesDTO(Time time)
        {
            if (time == null)
            {
                throw new ArgumentNullException(nameof(time), " ! O objeto time não pode ser nulo para mapear o time ! ");
            }

            return new TimesDTO
            {
                Id = time.Id,
                Nome = time.Nome,
                Abreviacao = time.Abreviacao,
                Tecnico = time.TecnicoId.ToString(),
                Jogadores = time.JogadoresId?.Select(j => MapperJogador.ToJogadorDTO(j)).ToList() ?? new List<JogadorDTO>(),
                Jogos = time.JogosId?.Select(g => MapperJogo.ToJogoDTO(g)).ToList() ?? new List<JogadorDTO>(),
                Partidas = time.PartidasId?.Select(p => MapperJogador.ToJogadorDTO(p)).ToList() ?? new List<JogadorDTO>()
            };
        }
    }
}
*/