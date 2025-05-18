using System;
using Views_Campos;

namespace Controle_de_execoesApp
{
    public class ControleDeExecoes // classe para o tratamento de execoes base, obs: tentar adaptar p funcionar com o database
    {
        public static void ExecutarComTratamento(Action acao, string escolha) // Executa a ação passada, tratando possíveis erros relacionados ao valor da variável "escolha".
        {
            try
            {
                acao();
            }
            catch (Exception ex) // inplementar um so p miss click ou é perda de tempo?
            {
                if (ex is ArgumentOutOfRangeException) // verifica se é uma entrada dentro do intervalo
                {
                    Console.WriteLine("Erro: Escolha fora das opções validas. Tente novamente.\n");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (!int.TryParse(escolha, out _)) // verifica se é um numero
                {
                    Console.WriteLine("Erro: Entrada não é um número. Tente novamente.\n");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (ex is FormatException) // verifica se é um formato valido ex invalido:
                {
                    Console.WriteLine("Erro: Formato inválido. Tente novamente.\n");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}\n"); // fudeu, mas tem esse aqui ainda
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
