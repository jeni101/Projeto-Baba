using DTO.Times;

namespace Presentation.Times
{
    public static class PresenterTimes
    {
        public static void ExibirTime(TimesDTO timesDTO)
        {
            if (timesDTO == null)
            {
                Console.WriteLine(" ! Erro: Não foi possível exibir time. DTO nulo ! ");
                return;
            }

            //Inspirado no PresenterPerfil.cs
            //Verificar padding depois

            Console.WriteLine("Campo:");
            Console.WriteLine($" .__________________________ Time ___________________________.");
            Console.WriteLine($" | -=-             {timesDTO.Nome.ToUpper()}             -=- |");
            Console.WriteLine($" |===========================================================|");
            Console.WriteLine($" |- ID: {timesDTO.Id}                                        |");
            Console.WriteLine($" |- Nome: {timesDTO.Nome}                                    |");
            Console.WriteLine($" |- Abreviação: {timesDTO.Abreviacao}                        |");
            Console.WriteLine($" |- Tecnico {timesDTO.Tecnico}                               |");
            Console.WriteLine($" |- Jogadores*: {timesDTO.Jogadores} *                       |");
            Console.WriteLine($" |- Jogos*: {timesDTO.Jogos} *                               |");
            Console.WriteLine($" |- Partidas*: {timesDTO.Partidas} *                         |");
            Console.WriteLine($" |___________________________________________________________|");
            Console.WriteLine($" |===========================================================|");

        }
    }
}