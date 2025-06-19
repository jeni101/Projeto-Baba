using DTO.Jogos.Placar;
using DTO.Times;

namespace Presentation.Placar
{
    public static class PresenterPlacar
    {
        public static void ExibirPlacar(PlacarDTO placarDTO, TimesDTO timeADTO, TimesDTO timeBDTO)
        {
            if (placarDTO == null)
            {
                Console.WriteLine(" ! Erro: Não foi possível exibir placar ! ");
                return;
            }
            //É Mais ou menos assim que vai ser mostrador na hora,
            //  tem que ver se vai manter os nomes dos times ou deixar assim mesmo
            // Eu, Gustavo, acho bom com as abreviações
            Console.WriteLine($" .____________________ Placar ____________________.");
            Console.WriteLine($" |-=-    {timeADTO.Abreviacao}           {placarDTO.GolsA}  X  {placarDTO.GolsB}     `{timeBDTO.Abreviacao}         -=-|");
        }
    }
}