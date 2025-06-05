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

            Console.WriteLine("=============PLACAR===============");
            Console.WriteLine($"{placarDTO.GolsA} - {placarDTO.GolsB}");
        }
    }
}