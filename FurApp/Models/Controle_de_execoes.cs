using System;
using Views_Campos;

namespace Controle_de_execoesApp
{
    public class ControleDeExecoes // classe para o tratamento de execoes base, obs: tentar adaptar p funcionar com o database
    {
        public static bool ExecutarComTratamento(Action acao, string escolha, ref int contador_de_erros) // Executa a ação passada, tratando possíveis erros relacionados ao valor da variável "escolha".
        {
            try
            {
                acao();
                return false;
            }
            catch (Exception ex) // inplementar um so p miss click ou é perda de tempo?
            {
                contador_de_erros++;
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
                if (contador_de_erros ==2 || contador_de_erros ==3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Presta atenção abestado, assim num pode não!");
                    Console.ReadKey();
                    Console.ResetColor();

                }
                else if (contador_de_erros ==4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Cara..... precisa de ajuda?");
                    Console.ReadKey();
                    Console.ResetColor(); // resentdo a cor 
                }
                else if (contador_de_erros == 7)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Ainda por aqui amigo? .... Como vai a vida?");
                    Console.ReadKey();
                    Console.ResetColor();
                }

                else if (contador_de_erros == 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Rapaz......Tenso......");
                    Console.ReadKey();
                    Console.ResetColor();
                }

                return true;
            }
        }
    }
}
