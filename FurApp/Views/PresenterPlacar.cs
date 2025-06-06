using DTO.Jogos.Placar;

namespace Presentation.Placar
{
    public static class PresenterPlacar
    {
        public static void ExibirPlacar(PlacarDTO placarDTO)
        {
            if (placarDTO == null)
            {
                Console.WriteLine(" ! Erro: Não foi possível exibir placar ! ");
                return;
            }
            //É Mais ou menos assim que vai ser mostrador na hora,
            //  tem que ver se vai manter os nomes dos times ou deixar assim mesmo
            Console.WriteLine($" .____________________ Placar ____________________.");
            Console.WriteLine($" |-=-    Time A        {placarDTO.GolsA}  X  {placarDTO.GolsB}     Time B      -=-|");
        }
    }
}