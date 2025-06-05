using DTO.Jogos.Placar;
using Models.JogosApp.PlacarJogo;

namespace Utils.Mappers.Jogos
{
    public static class MapperPlacar
    {
        public static PlacarDTO ToPlacarDTO(Placar placar)
        {
            if (placar == null)
            {
                throw new ArgumentNullException(nameof(placar), " ! O objeto placar não pode ser nulo para mapear o placar ! ");
            }

            return new PlacarDTO
            {
                GolsA = placar.GolsA,
                GolsB = placar.GolsB
            };
        }
    }
}