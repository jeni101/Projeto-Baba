using DTO.Campos;

namespace Presentation.Campos
{
    public static class PresenterCampos
    {
        public static void ExibirCampo(CamposDTO camposDTO)
        {
            if (camposDTO == null)
            {
                Console.WriteLine("Erro: Não foi possível exibir o campo. DTO nulo");
                return;
            }

            //Inspirado no PresenterPerfil.cs
            //Verificar padding depois

            Console.WriteLine("Campo:");
            Console.WriteLine($" .__________________________ Campo ___________________________.");
            Console.WriteLine($" | -=-             {camposDTO.Nome.ToUpper()}             -=- |");
            Console.WriteLine($" |============================================================|");
            Console.WriteLine($" |- ID: {camposDTO.Id}                                        |");
            Console.WriteLine($" |- Nome: {camposDTO.Nome}                                    |");
            Console.WriteLine($" |- Local: {camposDTO.Local}                                  |");
            Console.WriteLine($" |- Capacidade {camposDTO.Capacidade}                         |");
            Console.WriteLine($" |- Tipo de Campo: {camposDTO.TipoDeCampoNome}                |");
            Console.WriteLine($" |____________________________________________________________|");
            Console.WriteLine($" |============================================================|");

        }
    }
}