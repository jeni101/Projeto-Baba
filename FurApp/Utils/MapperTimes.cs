using DTO.Times;
using Models.TimesApp;

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
                Jogadores = time.Jogadores,
                Jogos = time.Jogos,
                Partidas = time.Partidas
            };
        }
    }
}