using DTO.Perfil.Usuario.Jogador;
using DTO.Times;
using Models.TimesApp;
using Utils.Mappers.Jogadores;

namespace Utils.Mappers.Times
{
    public class MapperTimes
    {
        public static TimesDTO toTimesDTO(Time time)
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
                    Tecnico = time.Tecnico,
                    Jogadores = time.Jogadores?.Select(j=> MapperJogador.ToJogadorDTO(j)).ToList() ?? new List<JogadorDTO>(),
                    Jogos = time.Jogos,
                    Partidas = time.Partidas
                };
        }
    }
}